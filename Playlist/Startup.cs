using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Playlist.Data;
using Playlist.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Playlist
{
    
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; set;}
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ISongRepo,SongRepo>();
            services.AddTransient<IGenreRepo,GenreRepo>();
            services.AddTransient<IAlbumRepo,AlbumRepo>();
            services.AddTransient<IArtistRepo,ArtistRepo>();

            // services.AddTransient<ICustomerRepo,CustomerRepo>();
            // services.AddTransient<IBookRepo,BookRepo>();

            services.AddMvc(opt => opt.EnableEndpointRouting = false);

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("ConnectionString")
            ));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults : new {controller="Song", action="Index"}
                );

                routes.MapRoute(
                    name: null,
                    template: "{controller}",
                    defaults: new {action="Index"}
                );
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}"
                );
            });

        }
    }
}
