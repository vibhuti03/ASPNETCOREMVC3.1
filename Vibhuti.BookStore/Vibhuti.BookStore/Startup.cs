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
        {  // IWebHostEnvironment reads the settings from the launchsettings.json and tells about the current env variable
            if (env.IsDevelopment())  
            {  //checks if the current env variable is Development in launchsettings.json
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); //to map the url to a particular resource (endpoints vale mei jo "MapGet()" krke h)

            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context => //mapping a  particular url("/",i.e., domain itself) to a particular resource
                {
                    if(env.IsDevelopment())
                    {
                        await context.Response.WriteAsync("Hello from dev!");
                    }
                    else if(env.IsProduction())
                    {
                        await context.Response.WriteAsync("Hello from prod!");
                    }
                    else if(env.IsStaging())
                    {
                        await context.Response.WriteAsync("Hello from staging!");
                    }
                    else if (env.IsEnvironment("Develop") )
                    {
                        await context.Response.WriteAsync("Hello from other environments!");
                    }
                    await context.Response.WriteAsync("\nEnvironment name is " + env.EnvironmentName);
                });
            });
        }
    }
}
