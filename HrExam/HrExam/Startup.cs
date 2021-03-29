using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using HrExam.Models;


namespace HrExam
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("IdentityConnection");
            services.AddDbContext<AplicationContext>(opts =>
            opts.UseSqlServer(connectionString)
            );

            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<AplicationContext>();

           

            services.AddControllersWithViews();
        }


        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>            {
              
                    endpoints.MapControllerRoute(
                        name:"default",
                        pattern:"{controller=Home}/{action=Index}/{id?}"

                        );
               
            });
        }
    }
}
