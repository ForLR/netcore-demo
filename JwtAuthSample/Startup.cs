using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtAuthSample
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
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            var jwt = new JwtSettings();
            Configuration.Bind("JwtSettings", jwt);

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {

                ///默认token
                //o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                //{
                //    ValidIssuer = jwt.Issuer,
                //    ValidAudience=jwt.Audience,
                //    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey))

                //};

                ///自定义token
                o.SecurityTokenValidators.Clear();
                o.SecurityTokenValidators.Add(new MyTokenValidate());
                o.Events = new JwtBearerEvents()
                {
                   
                    OnMessageReceived = context =>
                    {
                        //设置token获取方式
                        var token = context.Request.Headers["mytoken"];
                        //var token = context.Request.Query["mytoken"];
                        context.Token = token.FirstOrDefault();
                        return Task.CompletedTask;
                    }
                    
                };
            });
            services.AddAuthorization(option=> 
            {
                option.AddPolicy("SuperAdmin", police => police.RequireClaim("SuperAdmin"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
