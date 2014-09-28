using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ReflectedModelBuilder;
using Microsoft.Framework.DependencyInjection;

namespace Tchernobyl {
    public class TchernobylConvention : IReflectedApplicationModelConvention {
        private readonly IControllerAssemblyProvider _assemblyProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly ITypeActivator _typeActivator;

        public TchernobylConvention(
            [NotNull] IControllerAssemblyProvider assemblyProvider,
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] ITypeActivator typeActivator) {
            _assemblyProvider = assemblyProvider;
            _serviceProvider = serviceProvider;
            _typeActivator = typeActivator;
        }

        protected virtual MethodInfo FindInitializer([NotNull] Type type) {
            foreach (var method in type.GetMethods()) {
                // Exclude methods whose name is not "GetRoutes".
                if (!string.Equals(method.Name, "GetRoutes", StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }

                // Exclude generic methods and methods taking parameters.
                if (method.ContainsGenericParameters || method.GetParameters().Any()) {
                    continue;
                }

                // Exclude methods whose return type is not compatible.
                if (method.ReturnType != typeof(IEnumerable) &&
                    method.ReturnType != typeof(IEnumerable<object>)) {
                    continue;
                }

                return method;
            }

            return null;
        }

        public void OnModelCreated([NotNull] ReflectedApplicationModel model) {
            foreach (var typeInfo in from assembly in _assemblyProvider.CandidateAssemblies
                                     from type in assembly.GetExportedTypes()
                                     select type.GetTypeInfo()) {
                // Exclude value types, abstract classes and generic types.
                if (!typeInfo.IsClass || typeInfo.IsAbstract || typeInfo.ContainsGenericParameters) {
                    continue;
                }

                var initializer = FindInitializer(typeInfo.AsType());
                if (initializer == null) {
                    continue;
                }

                var controller = new ReflectedControllerModel(typeInfo);
                var prototype = _typeActivator.CreateInstance(_serviceProvider, typeInfo.AsType());

                // Make sure to dispose the prototype.
                using (prototype as IDisposable) {
                    // Add the attribute filters defined at the controller level.
                    var attributes = typeInfo.GetCustomAttributes(inherit: true).OfType<IFilter>();
                    controller.Filters.AddRange(attributes.ToList());

                    foreach (object route in (IEnumerable) initializer.Invoke(prototype, new object[0])) {
                        var operation = route as Tuple</* template: */ string, /* methods: */ string, IEnumerable<IFilter>, Delegate>;
                        if (operation == null) {
                            throw new NotSupportedException(Resources.Convention_ElementTypeUnsupported);
                        }

                        var method = operation.Item4.GetMethodInfo();

                        var action = new ReflectedActionModel(method) {
                            ActionName = method.Name,
                            AttributeRouteModel = new ReflectedAttributeRouteModel { Template = operation.Item1 },
                            HttpMethods = { operation.Item2 }
                        };

                        foreach (var parameter in method.GetParameters()) {
                            if (string.IsNullOrWhiteSpace(parameter.Name)) {
                                throw new NotSupportedException(Resources.Convention_OptimizedAnonymousMethodUnsupported);
                            }

                            action.Parameters.Add(new ReflectedParameterModel(parameter) {
                                IsOptional = parameter.IsOptional,
                                ParameterName = parameter.Name
                            });
                        }

                        // Add the inline filters defined at the action level.
                        action.Filters.AddRange(operation.Item3);
                        controller.Actions.Add(action);
                    }

                    model.Controllers.Add(controller);
                }
            }
        }
    }
}