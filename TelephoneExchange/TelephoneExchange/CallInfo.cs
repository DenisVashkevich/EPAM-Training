using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CallInfo
    {
        public Subscriber Caller {get; private set;}
        public Subscriber Receiver { get; private set; }
        public TimeSpan Duration { get; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
    }
}
