using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Tchernobyl.Sample {
    public class DefaultController : Controller {
        public IEnumerable GetRoutes() {
            yield return Route.Get("/", () => {
                return Content("Hello world");
            });

            yield return Route.Get("/say/{value=Hey!}", (string value) => {
                return Content(value);
            });

            yield return Route.Get("/items/{id:long}-{slug}", async (long id, string slug) => {
                await Task.Delay(50);

                return Json(new { id, slug });
            });

            yield return Route.Get("/filter", () => {
                return Content("You can't see me. Ahaha.");
            }, new AuthorizeAttribute());
        }
    }
}