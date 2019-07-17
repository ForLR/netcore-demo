using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus
{
    interface IEventData
    {
        DateTime EventTime { get; set; }
        object EventSource { get; set; }
    }
}
