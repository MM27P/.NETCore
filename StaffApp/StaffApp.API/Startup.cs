using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StaffApp.API.Handler;
using StaffApp.API.Requirement;
using StaffApp.Database;
using StaffApp.Services;
using StaffApp.Services.Interfaces.Services;
using StaffApp.Services.Services;

namespace StaffApp.API
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
            var mapperConfiguration = new MapperConfiguration(Configuration =>
            {
                Configuration.AddProfile(new AutoMapperProfile());
            });

            services.AddSingleton(mapperConfiguration.CreateMapper());
            services.AddSingleton<IAuthorizationHandler, BasicAuthorizationHandler>();
            services.AddDbContext<StaffAppContext>();
            services.AddControllers();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<SearchParametersFilter, SearchParametersFilter>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new OpenApiInfo { Title = "Certificates API", Version = "v1" }));

            services.AddAuthorization(options =>
            options.AddPolicy("BasicUser", policy => policy.Requirements.Add(new CustomUserRequirement())));
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = true;
                options.ForwardClientCertificate = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Certificates API V1");
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
