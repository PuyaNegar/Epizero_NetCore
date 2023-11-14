using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
using PanelPresentationLayer.Infrastracture.Filters;

namespace PanelPresentationLayer
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddRazorPages();

            services.AddSession(c => { c.Cookie.Name = "PishroozamanSession"; c.IdleTimeout = TimeSpan.FromHours(24); c.Cookie.HttpOnly = true; });
            services.AddAuthentication("ASPNetCoreAuthenticationScheme").AddCookie("ASPNetCoreAuthenticationScheme", options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "EpizeroCookie";
                options.AccessDeniedPath = "/Account/Forbidden/";
                options.LoginPath = "/Account/Index/";
                options.SlidingExpiration = true;
                options.LogoutPath = "/Account/Index/";
                options.ExpireTimeSpan = TimeSpan.FromHours(2);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseCookiePolicy();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

            });
        }
    }
}
