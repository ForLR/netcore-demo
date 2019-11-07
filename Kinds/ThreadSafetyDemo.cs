using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kinds
{
    public class ThreadSafetyDemo
    {
        static int count = 0;
        static Queue<string> queue = new Queue<string>();

        /// <summary>
        /// 线程安全的集合区
        /// </summary>
        static BlockingCollection<string> blockingCollection = new BlockingCollection<string>();

        private static object _lock = new object();
        static void Main(string[] args)
        {

            Thread thread1 = new Thread(Producer);
            thread1.Start();

            Thread thread2 = new Thread(Consumer);
            Thread thread3 = new Thread(Consumer);
            thread2.Start();
            thread3.Start();
            Console.ReadKey();
        }
        public  static void Producer()
        {
            

                while (true)
                {
                    string value = "value" + count++;
                    Console.WriteLine($"开始生产 {value}");
                    blockingCollection.Add(value);
                    //queue.Enqueue(value);
               // Thread.Sleep(100);
                }
        }

        public static void Consumer()
        {
            while (true)
            {
                #region 默认

                //if (queue.Count > 0)
                //{
                //    var value = queue.Dequeue();
                //    Console.WriteLine($"消费者{Thread.CurrentThread.ManagedThreadId}开始消费 " + value);
                //}
                #endregion

                #region Queue自带的线程安全
                //string result;
                //if (queue.TryDequeue(out result))
                //{
                //    Console.WriteLine($"消费者{Thread.CurrentThread.ManagedThreadId}开始消费 " + result);
                //}
                #endregion 加lock
                //lock (_lock)
                //{
                //    if (queue.Count > 0)
                //    {
                //        var value = queue.Dequeue();
                //        Console.WriteLine($"消费者{Thread.CurrentThread.ManagedThreadId}开始消费 " + value);
                //    }
                //}

                #region  线程安全的集合区
                Console.WriteLine($"消费者{Thread.CurrentThread.ManagedThreadId}开始消费 " + blockingCollection.Take());
                #endregion
            }

        }
    }
}
