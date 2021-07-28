 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vibhuti.BookStore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from first middleware\n");

                await next(); // to call next middleware

                await context.Response.WriteAsync("First again!!\n");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from second middleware\n");

                await next();
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from third middleware\n");

                await next();
            });

            app.UseRouting(); //to map the url to a particular resource (endpoints vale mei jo "MapGet()" krke h)

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context => //mapping a  particular url("/",i.e., domain itself) to a particular resource
                {
                    await context.Response.WriteAsync("Hello World!\n");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/vibhuti", async context => //mapping only when GET request ++ url -> "domain/vibhuti"
                {
                    await context.Response.WriteAsync("Hello Vibhuti!\n");
                });
            });
        }
    }
}
