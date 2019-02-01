using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;

namespace Cederfelt.se
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddSpaStaticFiles(c =>
            {
                c.RootPath = "cederfelt-app";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

           // app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "cederfelt-app";
                //if (env.IsDevelopment())
                //{
                //    spa.UseAngularCliServer(npmScript: "start");
                //}
                //SSR server side rendering
                //x.UseSpaPrerendering(options =>
                //{
                //    options.BootModulePath = $"{x.Options.SourcePath}/dist-server/main.bundle.js";
                //    options.BootModuleBuilder = env.IsDevelopment() ? new AngularCliBuilder(npmScript: "build:ssr") : null;
                //    options.ExcludeUrls = new[] { "/socksjs-node" };
                //});

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                    //  spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //app.Use(async (ctx, next) =>
            //{
            //    ctx.Response.Headers.Add("Content-Security-Policy-Report-Only",
            //        "default-src 'self'");
            //    await next();
            //});

            //< add name = "Content-Security-Policy-Report-Only" value = "default-src 'self'" />

            //app.Use(async (ctx, next) =>
            //{
            //    ctx.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //    ctx.Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,OPTIONS");
            //    ctx.Response.Headers.Add("Access-Control-Request-Headers", "*");

            //    await next();
            //});
        }
    }
}
