using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;
using System.ComponentModel;

namespace TelephoneExchange
{
    public class Terminal : ITerminal
    {
        public event EventHandler PlugIn;
        public event EventHandler Unplug;
        public event EventHandler<CallEventArgs> Call;
        public event EventHandler Drop;
        public event EventHandler Answer;

        public Action<Terminal> OnIncommingCallAction;

        public void PlugInTerminal()
        {
            var p = PlugIn;
            if (p != null)
                p(this, new EventArgs());
        }

        public void UnplugTerminal()
        {
            var u = Unplug;
            if (u != null)
                u(this, new EventArgs());
        }

        public void CallTo(int phoneNumber)
        {
            
            var c = Call;
            if (c != null) 
                c(this, new CallEventArgs(phoneNumber));
        }

        public void DropCall()
        {
            var d = Drop;
            if (d != null)
                d(this, new EventArgs());
        }

        public void AnswerCall()
        {
            var a = Answer;
            if (a != null)
                a(this, new EventArgs());
        }
        
        public void OnIncommingCall(object sender, CallEventArgs e)
        {
            //AnswerCall();
            //System.Threading.Thread.Sleep((int)System.TimeSpan.FromSeconds(2).TotalMilliseconds);
            //DropCall();
            if (OnIncommingCallAction!=null) OnIncommingCallAction(this);
        }

        public void OnPortStateChanged(object sender, PropertyChangedEventArgs e)
        {
            Port myPort = sender as Port;
            switch (myPort.State)
            {
                case PortState.IncomingCall:
                    OnIncommingCall(sender, new CallEventArgs(myPort.PhoneNumberInfo));
                    break;
            }
        }
    }
}
