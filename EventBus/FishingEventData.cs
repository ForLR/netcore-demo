using System;
using System.Collections.Generic;
using System.Text;
using static EventBus.Program;

namespace EventBus
{
    public class FishingEventData: EventData
    {
        public FishType type { get; set; }
        public FishingMan FishingMan { get; set; }
    }
}
