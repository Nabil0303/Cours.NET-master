using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Projetbiblio.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projetbiblio
{
   
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(options => options.UseInMemoryDatabase("LibraryDatabase"));
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddSwaggerDocument();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder Projetbiblio, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                Projetbiblio.UseDeveloperExceptionPage();
            }
            else
            {
                Projetbiblio.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                Projetbiblio.UseHsts();
            }
            Projetbiblio.UseHttpsRedirection();
            Projetbiblio.UseStaticFiles();
            Projetbiblio.UseRouting();
            Projetbiblio.UseAuthorization();
            Projetbiblio.UseOpenApi();
            Projetbiblio.UseSwaggerUi3();
            Projetbiblio.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = Projetbiblio.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var libraryDbContext = services.GetRequiredService<LibraryDbContext>();
                DbInitializer.Initialize(libraryDbContext);
            }
        }
    }
}
