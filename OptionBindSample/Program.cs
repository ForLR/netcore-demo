using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OptionBindSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //热更新的原理
                //.ConfigureAppConfiguration(config=> 
                //{
                //    config.AddJsonFile("appsettings.json",false,true);
                //})
               // .UseUrls("http://localhost:5001") //更改启动url  
                .UseStartup<Startup>();
    }
}
