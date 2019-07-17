using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus
{
    public class FishingRod
    {
        public delegate void FishingHandler(FishingEventData data);
        public event FishingHandler FishingEvent;
        public FishingEventData data;
        public FishingRod(FishingEventData data)
        {
            this.data = data;
        }
        public  void ThrowHook(FishingMan man)
        {
            Console.WriteLine("开始下钓");

            if (new Random().Next(0, 100) % 2 == 0)
            {
               
                Console.WriteLine("鱼儿上钩");
                FishingEvent?.Invoke(data);
            }

        }
    }
}
