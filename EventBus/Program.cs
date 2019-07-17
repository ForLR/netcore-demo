using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventBus
{
    class Program
    {
        static void Main(string[] args)
        {

            var fishingRod = new FishingRod(new FishingEventData()
            {
                FishingMan = new FishingMan("卢睿"),
                type = (FishType)new Random().Next(0, 5)
            });

            fishingRod.data.FishingMan.fishingRod = fishingRod;
            while (fishingRod.data.FishingMan.FishCount<5)
            {
                fishingRod.data.FishingMan.Fishing();
              
                Console.WriteLine("重新钓鱼");
                Console.WriteLine("-----------------");
                Thread.Sleep(1000);

            }

            Console.ReadKey();
        }

      
    }
}
