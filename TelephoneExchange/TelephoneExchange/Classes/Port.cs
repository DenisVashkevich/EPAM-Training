using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TelephoneExchange
{
    public class Port : INotifyPropertyChanged
    {
        private PortState _state;
        public PortState State 
        {
            get { return this._state; }
 
            set
            {
                if (value != this._state)
                {
                    this._state = value;
                    NotifyPropertyChanged();
                }
                
            }
        }
        public int PhoneNumberInfo { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void OnTerminalUnPluged(object sender, EventArgs e)
        {
            this.State = PortState.TerminalDisconnected;
        }

        public void OnTerminalPlugedIn(object sender, EventArgs e)
        {
            this.State = PortState.Ready;
        }

        public void OnOutgoingCall(object sender, CallEventArgs e)
        {
            PhoneNumberInfo = e.PhoneNumber;
            this.State = PortState.OutgoingCall;
        }

        //public void OnIncommingCall(object sender, CallEventArgs e)
        //{

        //}

        public void OnDropCall(object sender, EventArgs e)
        {
            this.State = PortState.Ready;
        }

        public void OnAnswerToCall(object sender, EventArgs e)
        {
            this.State = PortState.CallAccepted;
        }
    }
}
