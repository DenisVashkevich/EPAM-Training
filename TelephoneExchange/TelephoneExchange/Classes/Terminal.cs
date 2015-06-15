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

        /// <summary>
        /// PlugIn terminal to port
        /// </summary>
        public void PlugInTerminal()
        {
            var p = PlugIn;
            if (p != null)
                p(this, new EventArgs());
        }

        /// <summary>
        /// Unplug terminal to port
        /// </summary>
        public void UnplugTerminal()
        {
            var u = Unplug;
            if (u != null)
                u(this, new EventArgs());
        }

        /// <summary>
        /// Call to other subscriber
        /// </summary>
        /// <param name="phoneNumber">Telephone number of other subscriber</param>
        public void CallTo(int phoneNumber)
        {
            
            var c = Call;
            if (c != null) 
                c(this, new CallEventArgs(phoneNumber));
        }

        /// <summary>
        /// End current call, or drop incomming call
        /// </summary>
        public void DropCall()
        {
            var d = Drop;
            if (d != null)
                d(this, new EventArgs());
        }

        /// <summary>
        /// Accept incomming call
        /// </summary>
        public void AnswerCall()
        {
            var a = Answer;
            if (a != null)
                a(this, new EventArgs());
        }
        
        /// <summary>
        /// Executes OnIncammingCallAction
        /// </summary>
        /// <param name="sender">Port rised event</param>
        /// <param name="e">CallEventArgs object</param>
        public void OnIncommingCall(object sender, CallEventArgs e)
        {
            if (OnIncommingCallAction!=null) OnIncommingCallAction(this);
        }

        /// <summary>
        /// Port listener
        /// </summary>
        /// <param name="sender">Port rised event</param>
        /// <param name="e">PropertyChangedEventArgs object</param>
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
