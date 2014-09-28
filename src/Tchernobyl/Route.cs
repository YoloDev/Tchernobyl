using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Tchernobyl {
    public static class Route {
        public static dynamic Get(string route, IEnumerable<IFilter> filters, Delegate action) {
            return Tuple.Create(route, "GET", filters, action);
        }

        public static dynamic Get(string route, Action action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get(string route, Func<Task> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get(string route, Func<IActionResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get(string route, Func<Task<IActionResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TResult>(string route, Func<TResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TResult>(string route, Func<Task<TResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }


        public static dynamic Get<TArg>(string route, Action<TArg> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg>(string route, Func<TArg, Task> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg>(string route, Func<TArg, IActionResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg>(string route, Func<TArg, Task<IActionResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg, TResult>(string route, Func<TArg, TResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg, TResult>(string route, Func<TArg, Task<TResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }


        public static dynamic Get<TArg1, TArg2>(string route, Action<TArg1, TArg2> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2>(string route, Func<TArg1, TArg2, Task> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2>(string route, Func<TArg1, TArg2, IActionResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2>(string route, Func<TArg1, TArg2, Task<IActionResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2, TResult>(string route, Func<TArg1, TArg2, TResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2, TResult>(string route, Func<TArg1, TArg2, Task<TResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }


        public static dynamic Get<TArg1, TArg2, TArg3>(string route, Action<TArg1, TArg2, TArg3> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2, TArg3>(string route, Func<TArg1, TArg2, TArg3, Task> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2, TArg3>(string route, Func<TArg1, TArg2, TArg3, IActionResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2, TArg3>(string route, Func<TArg1, TArg2, TArg3, Task<IActionResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2, TArg3, TResult>(string route, Func<TArg1, TArg2, TArg3, TResult> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }

        public static dynamic Get<TArg1, TArg2, TArg3, TResult>(string route, Func<TArg1, TArg2, TArg3, Task<TResult>> action, params IFilter[] filters) {
            return Get(route, filters, action as Delegate);
        }



        public static dynamic Post(string route, IEnumerable<IFilter> filters, Delegate action) {
            return Tuple.Create(route, "POST", filters, action);
        }


        public static dynamic Post(string route, Action action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post(string route, Func<Task> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post(string route, Func<IActionResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post(string route, Func<Task<IActionResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TResult>(string route, Func<TResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TResult>(string route, Func<Task<TResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }


        public static dynamic Post<TArg>(string route, Action<TArg> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg>(string route, Func<TArg, Task> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg>(string route, Func<TArg, IActionResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg>(string route, Func<TArg, Task<IActionResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg, TResult>(string route, Func<TArg, TResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg, TResult>(string route, Func<TArg, Task<TResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }


        public static dynamic Post<TArg1, TArg2>(string route, Action<TArg1, TArg2> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2>(string route, Func<TArg1, TArg2, Task> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2>(string route, Func<TArg1, TArg2, IActionResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2>(string route, Func<TArg1, TArg2, Task<IActionResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2, TResult>(string route, Func<TArg1, TArg2, TResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2, TResult>(string route, Func<TArg1, TArg2, Task<TResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }


        public static dynamic Post<TArg1, TArg2, TArg3>(string route, Action<TArg1, TArg2, TArg3> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2, TArg3>(string route, Func<TArg1, TArg2, TArg3, Task> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2, TArg3>(string route, Func<TArg1, TArg2, TArg3, IActionResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2, TArg3>(string route, Func<TArg1, TArg2, TArg3, Task<IActionResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2, TArg3, TResult>(string route, Func<TArg1, TArg2, TArg3, TResult> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }

        public static dynamic Post<TArg1, TArg2, TArg3, TResult>(string route, Func<TArg1, TArg2, TArg3, Task<TResult>> action, params IFilter[] filters) {
            return Post(route, filters, action as Delegate);
        }
    }
}