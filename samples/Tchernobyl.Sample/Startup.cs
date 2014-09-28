using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;

namespace Tchernobyl.Sample {
    public class Startup {
        public void Configure(IApplicationBuilder app) {
            app.UseServices(services => {
                services.AddMvc();
                services.AddTchernobyl(() => app.ApplicationServices);
            });

            app.UseMvc();
        }
    }
}
