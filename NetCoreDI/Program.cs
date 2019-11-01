using System;
using Microsoft.Extensions.DependencyInjection;
namespace NetCoreDI
{
    class Program
    {
        static void Main(string[] args)
        {

            Scoped();
            Console.ReadKey();
        }
        //整个应用程序都是共用单一实例
        public static void Singleton()
        {
            var serviceCollection = new ServiceCollection();
            //默认无参构造
            serviceCollection.AddSingleton<IOperationSingleton,Operation>();
            //自定义传入guid空值
            serviceCollection.AddSingleton<IOperationSingleton>(new Operation(Guid.Empty));
            //自定义guid初始值
            serviceCollection.AddSingleton<IOperationSingleton>(new Operation(Guid.NewGuid()));
            //三次注册1 取最后一次注册的值 前面的被覆盖    



            var provider = serviceCollection.BuildServiceProvider();

            var singleton1 = provider.GetService<IOperationSingleton>();
            Console.WriteLine($"singleton1:{singleton1.OperationId}");

            var singleton2 = provider.GetService<IOperationSingleton>();
            Console.WriteLine($"singleton2:{singleton1.OperationId}");
            Console.WriteLine($"singleton1==singleton2:{singleton1== singleton2}");  
        }
        /// <summary>
        ///每次获取都是不同实例
        /// </summary>
        public static void Tranisent()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IOperationTransient, Operation>();

            var provider = serviceCollection.BuildServiceProvider();

            var tranisent1 = provider.GetService<IOperationTransient>();
            Console.WriteLine($"tranisent1:{tranisent1.OperationId}");

            var tranisent2 = provider.GetService<IOperationTransient>();
            Console.WriteLine($"tranisent2:{tranisent2.OperationId}");
            Console.WriteLine($"tranisent1==tranisent2:{tranisent1 == tranisent2}");
        }
        //用Scope注册的对象，在同一个请求()下的 Scope下相当于单例。 例如一个controller下面的action 里面的Scope注册的  一次请求获取的对象实例是相同的
        public static void Scoped()
        {
            var servicr = new ServiceCollection()
                .AddTransient<IOperationTransient, Operation>()
                .AddSingleton<IOperationSingleton, Operation>()
                .AddScoped<IOperationScoped, Operation>();

            var provider = servicr.BuildServiceProvider();
            using (var scope1=provider.CreateScope())
            {
                var p = scope1.ServiceProvider;

                var singleton1 = p.GetService<IOperationSingleton>();
                var tranisent1 = p.GetService<IOperationTransient>();
                var scopeobj1 = p.GetService<IOperationScoped>();

                var singleton2 = p.GetService<IOperationSingleton>();
                var tranisent2 = p.GetService<IOperationTransient>();
                var scopeobj2 = p.GetService<IOperationScoped>();

                Console.WriteLine($"singleton1:{singleton1.OperationId}\ntranisent1:{tranisent1.OperationId}\nscopeobj1:{scopeobj1.OperationId}\n");

                Console.WriteLine($"singleton2:{singleton2.OperationId}\ntranisent2:{tranisent2.OperationId}\nscopeobj2:{scopeobj2.OperationId}");
            }

        }
    }
}
