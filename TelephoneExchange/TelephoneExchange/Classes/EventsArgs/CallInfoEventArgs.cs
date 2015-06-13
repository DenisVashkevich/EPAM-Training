using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Classes.EventsArgs
{
    public class CallInfoEventArgs:EventArgs
    {
        public CallInfo callInfo;
        public CallInfoEventArgs(CallInfo info)
        {
            callInfo = info;
        }
    }
}
