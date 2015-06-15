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

        public int PhoneNumberInfo { get; set; } // Information about PhoneNumber(incomming call / destination customer) 

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //Event handler for subscriber unplug terminal
        public void OnTerminalUnPluged(object sender, EventArgs e)
        {
            this.State = PortState.TerminalDisconnected;
        }

        //Event handler for subscriber plugIn terminal
        public void OnTerminalPlugedIn(object sender, EventArgs e)
        {
            this.State = PortState.Ready;
        }

        //Event handler for subscriber is colling to someone
        public void OnOutgoingCall(object sender, CallEventArgs e)
        {
            PhoneNumberInfo = e.PhoneNumber;
            this.State = PortState.OutgoingCall;
        }

        //Event handler for subscriber drops call
        public void OnDropCall(object sender, EventArgs e)
        {
            this.State = PortState.Ready;
        }

        //Event handler for subscriber unplug terminal
        public void OnAnswerToCall(object sender, EventArgs e)
        {
            this.State = PortState.CallAccepted;
        }
    }
}
