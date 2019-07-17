using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;

namespace OptionBindSample
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<School>(configuration);
            //services.AddMvc();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IApplicationLifetime application)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region router 的两种实现
            ///1
            app.UseRouter(builder => builder.MapGet("/action", async context =>
            {
                var routeValue = context.GetRouteData().Values;
                await context.Response.WriteAsync($"action route:{string.Join(", ", routeValue)}");
            }));

            ///2
            IRouter router = new Route(
                new RouteHandler(context=>  context.Response.WriteAsync("this a action s")),
                "actions",
                 app.ApplicationServices.GetRequiredService<IInlineConstraintResolver>()
                );
            app.UseRouter(router);
            #endregion
            //应用程序启动
            application.ApplicationStarted.Register(()=> 
            {
                Console.WriteLine("start");
            });
            app.Use(async (context, next) => 
            {
                await context.Response.WriteAsync("1 start");
                await next.Invoke();
            });
            app.Use(next =>
            {
                return (context =>
                {
                    return context.Response.WriteAsync("2 start");
                });
            });

           

            //app.UseMvcWithDefaultRoute();
            //app.Run(async (context) =>
            //{
            //    var  school = new School();//json数据 映射到实体
            //    configuration.Bind(school);


            //    await context.Response.WriteAsync($"ClassName:{school.ClassName}");
            //    await context.Response.WriteAsync($"StudentCount{school.Student.Count}");
            //});
        }
    }
}
