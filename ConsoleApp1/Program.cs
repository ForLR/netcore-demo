using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static object _locker = new object();
        static void Main(string[]  args)
        {
            //Thread th = new Thread(() => { Console.WriteLine(1); });
            //th.Priority = ThreadPriority.AboveNormal;
            //th.Start();
            ThreadPool.QueueUserWorkItem(WaitCallBack,5);
            Console.WriteLine("线程池执行完");
            Thread.Sleep(1000);
            Console.WriteLine("线程池执行完....");

            //CallContext.LogicalGetData();
            Console.ReadKey();
        }
        
        private static void WaitCallBack(object o)
        {
            Console.WriteLine("线程池"+o);
            Thread.Sleep(1000);
        }

        private static string No()
        {
             int result = 0;
             Random ran = new Random();
             switch (ran.Next(1, 4))
                    {
                        case 1:
                            result = ran.Next(100000, 999999);
                            break;
                        case 2:
                            result = ran.Next(10000000, 99999999);
                            break;
                        case 3:
                            result = ran.Next(100000000, 999999999);
                            break;
                        default:
                            break;
                    }
                    return result.ToString();
        
            }
    }
}
