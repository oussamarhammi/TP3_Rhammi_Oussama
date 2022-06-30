using JuliePro_Core;
using JuliePro_Core.Interfaces;
using JuliePro_DataAccess.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro
{
    public class Startup
    {
        private CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("fr-CA"),
                new CultureInfo("es-ES")
            };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<ICertificationsService, CertificationsService>();
            services.AddScoped<ICustomersService, CustomersService>();
            services.AddScoped<IEquipmentsService, EquipmentsService>();
            services.AddScoped<IObjectivesService, ObjectivesService>();
            services.AddScoped<ISpecialitiesService, SpecialitiesService>();
            services.AddScoped<ITrainersService, TrainersService>();
            services.AddScoped<ITrainingsService, TrainingsService>();
            services.AddScoped<IEquipmentsService, EquipmentsService>();

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddControllersWithViews().AddRazorRuntimeCompilation()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization();
            services.AddRazorPages();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            
            services.AddDbContext<JulieProDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionStringForComputer("JulieProMaster2")));

            /* Activer après avoir configurer MSIdentity*/
           // services.AddScoped<IDbInitializer, DbInitializer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
