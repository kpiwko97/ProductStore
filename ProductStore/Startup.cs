using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductStore.Controllers;
using ProductStore.Models;

namespace ProductStore
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSession();
            services.AddMemoryCache();
            services.AddTransient<IRepository, Repository>();
          services.AddDbContext<ProductContext>(config =>
          {
                    config.UseSqlServer(_configuration.GetConnectionString("ProductStoreConnectionString"));
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "",
                    template: "Category{productCategory:int}/Strona{productPage:int}",
                    defaults: new {Controller = "Home", Action = "Index"});
                routes.MapRoute(name: "",
                    template:"Category{productCategory:int}",
                    defaults: new {Controller="Home",Action="Index", productPage = "1"});
                routes.MapRoute(name: "",
                    template: "Strona{productPage:int}", 
                    defaults: new {Controller = "Home", Action = "Index", productCategory = 0 });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
               
            });
        }
    }
}
