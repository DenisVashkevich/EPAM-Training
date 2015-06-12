using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CallEventArgs : EventArgs
    {
        public int PhoneNumber { get; private set; }
        public CallEventArgs(int phoneNum)
        {
            PhoneNumber = phoneNum;
        }
    }
}
