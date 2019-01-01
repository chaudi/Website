using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


            }

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

               app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
