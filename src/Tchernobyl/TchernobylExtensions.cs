using System;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.DependencyInjection;

namespace Tchernobyl {
    public static class TchernobylExtensions {
        public static IServiceCollection AddTchernobyl(
            [NotNull] this IServiceCollection services,
            [NotNull] Func<IServiceProvider> serviceProviderLocator) {
            return services.SetupOptions<MvcOptions>(options => {
                var serviceProvider = serviceProviderLocator();
                if (serviceProvider == null) {
                    throw new InvalidOperationException(Resources.Extensions_ServiceProviderLocatorInvalid);
                }
                
                options.ApplicationModelConventions.Add(new TchernobylConvention(
                    serviceProvider: serviceProvider,
                    typeActivator: serviceProvider.GetService<ITypeActivator>(),
                    assemblyProvider: serviceProvider.GetService<IControllerAssemblyProvider>()));
            });
        }
    }
}