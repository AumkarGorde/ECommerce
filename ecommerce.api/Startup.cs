using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ecommerce.data.CustomerMapper;
using ecommerce.repo.Execution;
using ecommerce.repo.Interface;
using ecommerce.service.Execution;
using ecommerce.service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ecommerce.api
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            SwaggerServices.Register(services);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer(options =>
       {

           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = true,
               ValidateAudience = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidIssuer = "newSearch",
               ValidAudience = "newSearch",
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("651997651997651997"))
           };
       });


            services.AddControllers();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddAutoMapper(typeof(CustomerMapping));

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "E-Commerece API");
                //To serve the Swagger UI at the app's root
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
