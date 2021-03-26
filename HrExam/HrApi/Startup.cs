using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HrApi.Models;
using HrApi.Service;
using HrApi.Interfaces;
using FluentValidation.AspNetCore;
using FluentValidation;
using HrApi.Validators;

namespace Two
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            services.AddDbContext<EmployeeContext>(opts =>
              opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            

            services.AddControllers().AddFluentValidation();

            services.AddTransient<IValidator<Employee>, EmployeeValidator>();

            services.Configure<JsonOptions>(opts =>
            {
                opts.JsonSerializerOptions.IgnoreNullValues = true;
            });



            services.AddScoped<ICrudService, CrudService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
                app.UseDeveloperExceptionPage();
           
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
