using CoreModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            this._loggerFactory = loggerFactory;
        }

       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            
            
                
            }); 
            ///数据库上下文 注入
            services.AddDbContext<CoreContext>(options =>
            options.UseMySQL(Configuration.GetConnectionString("MySqlServerConnection"))
            );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IPerson,Student>();

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var logger = _loggerFactory.CreateLogger<Startup>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                logger.LogInformation("IsDevelopment");
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                logger.LogInformation("NotIsDevelopment");
            }
        
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
           // app.UseWelcomePage();

            ///route
            ///
            app.UseMvc(routes =>
            {
              
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
