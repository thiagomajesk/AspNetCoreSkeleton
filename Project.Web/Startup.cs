using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.App.Config.AutoFac;
using Project.Infra;
using System;

namespace Project.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures application services on container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.LoginPath = new PathString("/home/login");
                    opts.AccessDeniedPath = new PathString("/home/denied");
                    opts.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });

            services.AddRouting(config =>
            {
                config.LowercaseUrls = true;
                config.AppendTrailingSlash = true;
            });

            services.AddDbContext<DatabaseContext>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        /// <summary>
        /// Specif AutoFac container registrations
        /// </summary>
        /// <remarks>
        /// This method is called after <see cref="ConfigureServices(IServiceCollection)"/>. Then, it
        /// will override any configs made on <see cref="ConfigureServices"/>
        /// </remarks>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<MediatRModule>();
            builder.RegisterModule<AutoMapperModule>();
            builder.RegisterModule<ApplicationModule>();
        }

        /// <summary>
        /// ASP.NET Middleware pipeline configuration
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/home/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();
        }
    }
}