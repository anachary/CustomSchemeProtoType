using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using CustomSchemeProtoType.Services.Handlers;
using CustomSchemeProtoType.Services.Requirements;

namespace CustomSchemeProtoType
{
    public class Startup
    {
          // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAuthentication()
            //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o => { })
            .AddScheme<Saml2AuthenticationSchemeOptions, Saml2AuthenticationHandler>("Saml2Scheme", o => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Saml2Policy", policy =>
                {
                    policy.Requirements.Add(new Saml2Requirement(true));
                });

            });

            services.AddSingleton<IAuthorizationHandler, Saml2AuthorizationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

           
            app.UseMvcWithDefaultRoute();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
           
        }
    }
}
