﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public enum PortState
    {
        Ready,
        Busy,
        IncomingCall,
        OutgoingCall,
        TerminalDisconnected
    }
}