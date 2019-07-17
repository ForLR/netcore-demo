using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace CoreApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(x=> 
            {
                x.SwaggerDoc("v1",new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v0.1.0",
                    Title = "Blog.Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Blog.Core", Email = "Blog.Core@xxx.com", Url = "https://www.jianshu.com/u/94102b59cc2a" }
                });
                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                //swagger接口注释
                var xmlPath = Path.Combine(basePath, "CoreApi.xml");
                x.IncludeXmlComments(xmlPath, true);

                //添加swagger请求参数实体注释
                var xmlModelPath = Path.Combine(basePath, "CoreModel.xml");
                x.IncludeXmlComments(xmlModelPath);


                #region Token服务注册
                var security = new Dictionary<string, IEnumerable<string>> { {"Blog.core",new string[] { } } };
                x.AddSecurityRequirement(security);
                x.AddSecurityDefinition("Blog.core",new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入{token}\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });

                #endregion

            });
            #region Token服务注册
            services.AddSingleton<IMemoryCache>(x =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            services.AddAuthorization(x =>
            {
                x.AddPolicy("Client",y=>y.RequireRole("Client").Build());
                x.AddPolicy("Admin", y => y.RequireRole("Admin").Build());
                x.AddPolicy("AdminOrClient", y => y.RequireRole("Client,Admin").Build());
            });
        }
      

        #endregion  
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           
            if (env.IsDevelopment())//判断是否是环境变量
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
           
            app.UseHttpsRedirection(); 
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(x=> { x.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1"); });
         
            
        }
    }
}
