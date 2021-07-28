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
        // Used to add all the features/dependencies that we are going to use in this application
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //telling application we are going to use MVC
            //either use AddMvc() to add all three else AddControllers(),AddControllersWithViews()
            services.AddControllersWithViews();
        }

        //HTTP Pipeline is defined here
        //Hence, all the middlewares that are used in this application are defined inside Configure()
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
                endpoints.MapDefaultControllerRoute(); 
                //map the endpoints by default to the default controller routes
                //action=Index (Index() in Controller class)
            });
        }
    }
}
