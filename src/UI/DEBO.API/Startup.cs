using AutoMapper;
using DEBO.API.Extensions;
using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.DomainService;
using DEBO.Infrastructure.Data;
using DEBO.Infrastructure.Data.Repositories;
using DEBO.Infrastructure.Libraries.AutoMapperLib;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DEBO.API
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
            services.AddDbContext<ApplicationContext>(
                options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region AutoMapper Config

            var config = new AutoMapper.MapperConfiguration(conf =>
            {
                var allProfiles =
                    (from t in typeof(DataMapper).Assembly.GetTypes()
                        where t.IsSubclassOf(typeof(Profile))
                        select (Profile) Activator.CreateInstance(t)).ToList();

                foreach (var profile in allProfiles)
                {
                    conf.AddProfile(profile);
                }
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region Swagger Config

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Swashbuckle.AspNetCore.Swagger.Info
                    {
                        Version = "v1",
                        Title = "DEBO API",
                        Description = "DEBO API"
                    });

                c.IncludeXmlComments(GetXmlCommentsPath());

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "Bearer", new string[]
                        {
                        }
                    },
                };

                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        Description =
                            "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(security);
            });

            #endregion

            services.AddCors();

            #region Dependency Injection Config

            services.AddSingleton<IDataMapper, DataMapper>();
            services.AddScoped(typeof(IGenericRepository<>),
                typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork<>),
                typeof(UnitOfWork<>));
            services.AddScoped<IAuthRepository, AuthRepository>();

            var serviceNamespace = $"{nameof(DEBO)}." +
                                   $"{nameof(DEBO.Core)}." +
                                   $"{nameof(DEBO.Core.ApplicationService)}." +
                                   $"{nameof(DEBO.Core.ApplicationService.Implements)}";

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IBaseService<,,,,>))
                .AddClasses(classes => classes.InNamespaces(serviceNamespace))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            #endregion

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    options =>
                    {
                        options.TokenValidationParameters =
                            new TokenValidationParameters
                            {
                                ValidateIssuerSigningKey = true,
                                IssuerSigningKey = new SymmetricSecurityKey(
                                    System.Text.Encoding.UTF8.GetBytes(
                                        Configuration
                                            .GetSection("AppSettings:Token")
                                            .Value
                                    )
                                ),
                                ValidateIssuer = false,
                                ValidateAudience = false
                            };
                    }
                );



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    builder =>
                    {
                        builder.Run(
                            async context =>
                            {
                                context.Response.StatusCode =
                                    (int) HttpStatusCode.InternalServerError;
                                var error =
                                    context.Features
                                        .Get<IExceptionHandlerFeature>();
                                if (error != null)
                                {
                                    context.Response.AddApplicationError(
                                        error.Error.Message);
                                    await context.Response.WriteAsync(
                                        error.Error.Message);
                                }
                            }
                        );
                    }
                );
                //app.UseHsts();
            }

            // app.UseHttpsRedirection();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.ConfigureExceptionHandler();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "DEBO API V1");
            });

            //------------------------------------------------------------------
            // ef core migration
            using (var serviceScope = app.ApplicationServices
                .GetService<IServiceScopeFactory>()
                .CreateScope())
            {
                var context = serviceScope.ServiceProvider
                    .GetRequiredService<ApplicationContext>();
                context.Database.Migrate();
            }
        }

        private string GetXmlCommentsPath()
        {
            var app = System.AppDomain.CurrentDomain.BaseDirectory;
            return System.IO.Path.Combine(app,
                "DEBO.API.xml");
        }
    }
}