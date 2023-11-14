using Common.Functions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.Text;

namespace WebPresentationLayer
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
            services.AddSession(c => { c.Cookie.Name = "EpizeroSession"; c.IdleTimeout = TimeSpan.FromHours(24); c.Cookie.HttpOnly = true; });

            services.AddCors();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                x.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
         .AddJwtBearer(x =>
         {
             x.RequireHttpsMetadata = false;
             x.SaveToken = true;
             x.TokenValidationParameters = new TokenValidationParameters
             {
                 ClockSkew = TimeSpan.Zero,
                 // RequireExpirationTime = true,
                 RequireSignedTokens = true,
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppConfigProvider.jwtTokenKey())),
                 ValidateIssuer = false,
                 //ValidIssuer = "localhost:9431",
                 ValidateAudience = false,
                 //ValidAudience = "localhost:9431",
                 ValidateLifetime = false,

             };
         }).AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "EpizeroWebCookie";
                options.AccessDeniedPath = "/Account/Forbidden/";
                options.LoginPath = "/Account/Login";
                options.SlidingExpiration = true;
                options.LogoutPath = "/";
                options.ExpireTimeSpan = TimeSpan.FromHours(4);
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
            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
                c.AllowAnyHeader();

            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
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
            app.UseStatusCodePages(async context =>
            {

                if (context.HttpContext.Request.Method.ToLower() == "post" || context.HttpContext.Request.Path.Value.ToLower().StartsWith("/api"))
                {
                    context.HttpContext.Response.ContentType = "text/plain";
                    context.HttpContext.Response.StatusCode = 404;
                }
                else
                {
                    context.HttpContext.Response.Redirect("/Error/Page404");
                }
            });
        }

    }
}
