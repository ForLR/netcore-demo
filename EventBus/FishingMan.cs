using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus
{
    public class FishingMan
    {
        public FishingMan(string name)
        {
            this.name = name;
        }
        public string name { get; set; }
        public int FishCount { get; set; }
        public FishingRod fishingRod { get; set; }
        public void Fishing()
        {
            this.fishingRod.ThrowHook(this);
        }
        public void Update(FishType type)
        {
            FishCount++;
            Console.WriteLine("{0}：钓到一条[{2}]，已经钓到{1}条鱼了！", name, FishCount, type);
        }
    }
}
