using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.Data;
using Template.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Template
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(opt => opt.EnableEndpointRouting = false);

            //polaczenie z bazka, string z appsetting jonsona
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("TemplateConnectionString")
            ));

            //dla kazdego repo 
            services.AddTransient<IModelRepo, ModelRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //routing, jesli pusty url to /Model/Index, jesli sam kontroller to /Index kontrollera
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults : new {controller="Model", action="Index"}
                );

                routes.MapRoute(
                    name: null,
                    template: "{controller}",
                    defaults: new {action="Index"}
                );

                
            });

            
        }
    }
}
