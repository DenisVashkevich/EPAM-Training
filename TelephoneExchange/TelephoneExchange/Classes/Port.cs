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
 
            private set
            {
                if (value != this._state)
                {
                    this._state = value;
                    NotifyPropertyChanged();
                }
                
            }
        }

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
    }
}
