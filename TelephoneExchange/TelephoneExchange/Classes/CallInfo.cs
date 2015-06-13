using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CallInfo
    {
        public int Caller {get; set;}
        public int Receiver { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }

        public CallInfo() { }

        public CallInfo(CallInfo callInfo)
        {
            Caller = callInfo.Caller;
            Receiver = callInfo.Receiver;
            Duration = callInfo.Duration;
            StartTime = callInfo.StartTime;
        }
    }
}
