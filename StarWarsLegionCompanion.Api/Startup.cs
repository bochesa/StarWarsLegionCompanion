using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtilityLibrary.Data.SWContext;
using MediatR;
using UtilityLibrary.Application;
using UtilityLibrary.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.IO;
using UtilityLibrary.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using StarWarsLegionCompanion.Api.Auth;

namespace StarWarsLegionCompanion.Api
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

            services.AddControllers().AddNewtonsoftJson();
            // .AddNewtonsoftJson(options =>
            //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //     )

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "StarWarsLegionCompanion.Api", Version = "v1" });
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            }).AddSwaggerGenNewtonsoftSupport();

            // implement Mediator pattern
            services.AddMediatR(typeof(ApplicationMediatorEntryPoint).Assembly);

            // Entrypoint for Unit of Work and Repository Pattern
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDTOServices, DTOServices>();
            services.AddDbContext<ApplicationContext>(options =>
            {
                //var connectionsString = Configuration.GetConnectionString("LocalDBConnectionString");
                var connectionsString = Configuration.GetConnectionString("Bochesa_SWLEgion");
                options.UseSqlServer(connectionsString);
                //options.UseInMemoryDatabase("SWLegion");
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.Authority = $"https://{Configuration["Auth0:Domain"]}/";
                        options.Audience = Configuration["Auth0:Audience"];
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            NameClaimType = ClaimTypes.NameIdentifier
                        };
                    });
            services
                  .AddAuthorization(options =>
                  {
                      options.AddPolicy(
                        "read:messages",
                        policy => policy.Requirements.Add(
                          new HasScopeRequirement("read:messages", "domain")
                        )
                      );
                  });
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarWarsLegionCompanion.Api v1"));
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
