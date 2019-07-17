using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus
{
    public class EventData : IEventData
    {
        public DateTime EventTime { get; set ; }
        public object EventSource { get ; set ; }
        public EventData()
        {
            EventTime = DateTime.Now;
        }
    }
}
