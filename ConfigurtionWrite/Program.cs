using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
namespace ConfigurtionWrite
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //student.Say();
            //person s = new student();
            //s.cry();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(No());
            }
            
            Console.ReadLine();
        }
        /// <summary>
        /// 配置参数
        /// </summary>
        public static void ReadConfigurtion(string[] args)
        {
            var setting = new Dictionary<string, string>
            {
                {"name","张三"},{ "age","22"}

            };
            var build = new ConfigurationBuilder()
                 .AddInMemoryCollection()//从字典读取
                 .AddCommandLine(args);//从项目程序参数读取

            var configuration = build.Build();
            Console.WriteLine($"name:{configuration["name"]}");
            Console.WriteLine($"age:{configuration["age"]}");
            Console.WriteLine("Hello World!");
        }
        /// <summary>
        /// 读取json配置文件信息
        /// </summary>
        public static void ReadJson()
        {
            var builde = new ConfigurationBuilder().AddJsonFile("JsonSetting.json");

            var configurtion = builde.Build();

            Console.WriteLine($"class:{configurtion["class"]}");
            Console.WriteLine($"name:{configurtion["Student:0:name"]}");//依照这格式读取json数组中的数据
        }
        public class person
        {
            public static void Say() => Console.WriteLine("person static say");
            public virtual void cry() => Console.WriteLine("person virtual cry");
            public void haha ()=> Console.WriteLine("haha");
        }
        public class student:person
        {
            public static void Say() => Console.WriteLine("student static say");
            public override void cry() => Console.WriteLine("person virtual cry");
            public void haha() => Console.WriteLine("student haha");
        }

        public static string No()
        {
            int result = 0;
            var ran = new Random().Next(1, 4);

            switch (ran)
            {
                case 1:
                    result = new Random().Next(100000, 999999);
                    break;
                case 2:
                    result = new Random().Next(10000000, 99999999);
                    break;
                case 3:
                    result = new Random().Next(100000000, 999999999);
                    break;
                default:
                    break;
            }
            return result.ToString();
        }


    }
}
