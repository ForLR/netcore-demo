using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static requestDelegate管道.RequestDelegate;

namespace requestDelegate管道
{
    class Program
    {

        private static List<Func<RequestDalegate, RequestDalegate>> _list = new List<Func<RequestDalegate, RequestDalegate>>();
        static void Main(string[] args)
        {
            RequestDalegate end = (context) => 
            {
                Console.WriteLine();
                return Task.CompletedTask;
            };

            Use(next =>
            {
                return context =>
                {
                    Console.WriteLine(1);
                    // return next.Invoke(context);
                    return Task.CompletedTask;
                };
            });

            Use(next => 
            {
                return context =>
                {
                    Console.WriteLine(2);
                    return next.Invoke(context);
                };
            });
            _list.Reverse();
            foreach (var item in _list)
            {
                end = item.Invoke(end);
            }
            end.Invoke(new Context());
            Console.ReadKey();
           
        }
        public static void Use(Func<RequestDalegate, RequestDalegate> middleware)
        {
            _list.Add(middleware);
        }
    }
}
