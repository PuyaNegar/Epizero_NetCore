using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace TeacherPresentationLayer
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
            services.AddAuthentication("ASPNetCoreAuthenticationScheme").AddCookie("ASPNetCoreAuthenticationScheme", options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "TeacherEpizeroWebCookie";
                options.AccessDeniedPath = "/Account/Forbidden/";
                options.LoginPath = "/Identities/Account";
                options.SlidingExpiration = true;
                options.LogoutPath = "/";
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
                //app.UseExceptionHandler("/Home/Error");
            }
            Config404NotFoundUrl(app);
            app.UseCookiePolicy();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "R0",
                   pattern: "{area:exists}/{controller}/{action}/{id?}"
               );

                endpoints.MapControllerRoute(
                    name: "R1",
                    pattern: "api/{area:exists}/{controller}/{action}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "R2",
                    pattern: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "R3",
                    pattern: "{area:exists}/{controller}/{name?}",
                    defaults: new { action = "Index" }
                );
            });

            #region Threads
            //new Thread(CartsUnBlockerThread.Execute) { IsBackground = true }.Start();
            #endregion
        }


        private void Config404NotFoundUrl(IApplicationBuilder app)
        {
            //app.UseStatusCodePages(async context =>
            //{

            //    if (context.HttpContext.Request.Method.ToLower() == "post" || context.HttpContext.Request.Path.Value.ToLower().StartsWith("/api"))
            //    {
            //        context.HttpContext.Response.ContentType = "text/plain";
            //        context.HttpContext.Response.StatusCode = 404;
            //    }
            //    else
            //    {
            //        context.HttpContext.Response.Redirect("/Error/Page404");
            //    }
            //});
        }

    }
}
