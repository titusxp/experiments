using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alerts.Domain.Contracts.Dama;
using Alerts.Domain.Contracts.Personnel;
using Alerts.Domain.Dama;
using Alerts.Domain.Personel;
using Alerts.Repository.Contracts.Dama;
using Alerts.Repository.Contracts.Personel;
using Alerts.Repository.Contracts.System;
using Alerts.Repository.Dama;
using Alerts.Repository.Personel;
using Alerts.Repository.System;
using Core.System.Email;
using Core.System.SMS;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Alerts
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string AlertsPolicyOrigins = "AlertsPolicyOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Alerts API",
                    Description = "API to send SMS and Email alerts",
                    TermsOfService = new Uri("https://dama.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Dama Team",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/dama"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Dama License",
                        Url = new Uri("https://dama.com/license"),
                    }
                });
            });

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy(AlertsPolicyOrigins, policy =>
                {
                    policy.WithOrigins(
                        "http://localhost:3000",
                        "http://localhost:3001")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddMediatR(typeof(Startup));

            //services.AddDbContext()

            services.AddTransient<ISMSClient, SMSClient>();

            services.AddScoped<IARTVisitsRepository, ARTVisitsRepository>();
            services.AddScoped<IARTVisitDomain, ARTVisitDomain>();
            
            services.AddScoped<IAlertDomain, AlertDomain>();
            services.AddScoped<IAlertRepository, AlertRepository>();

            services.AddScoped<IConfigurationsRepository, ConfigurationsRepository>();

            services.AddScoped<IEmailClient, EmailClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AlertsPolicyOrigins);

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
