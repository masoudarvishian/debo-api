using DEBO.API.Helpers;
using DEBO.Core.ApplicationService.Implements;
using DEBO.Core.ApplicationService.Interfaces;
using DEBO.Core.DomainService;
using DEBO.Infrastructure.Data;
using DEBO.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
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
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "DEBO API",
                    Description = "DEBO API"
                });

                c.IncludeXmlComments(GetXmlCommentsPath());
            });

            services.AddCors();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactService, ContactService>();
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
                app.UseExceptionHandler(
                   builder =>
                   {
                       builder.Run(
                           async context =>
                           {
                               context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                               var error = context.Features.Get<IExceptionHandlerFeature>();
                               if (error != null)
                               {
                                   context.Response.AddApplicationError(error.Error.Message);
                                   await context.Response.WriteAsync(error.Error.Message);
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

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DEBO API V1");
            });

            //------------------------------------------------------------------
            // ef core migration
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                context.Database.Migrate();
            }
        }

        private string GetXmlCommentsPath()
        {
            var app = System.AppDomain.CurrentDomain.BaseDirectory;
            return System.IO.Path.Combine(app, "DEBO.API.xml");
        }
    }
}
