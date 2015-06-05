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
        private TelephoneExchange _tes;
        private PortState _state;

        public int Id { get; private set; }
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

        public Port(TelephoneExchange tes,int id)
        {
            _tes = tes;
            Id = id;
            State = PortState.Blocked;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void TerminalDisconnected()
        {
            this.State = PortState.TerminalDisconnected;
        }

        public void TerminalConnected()
        {
            this._tes.InitializeTerminal(this);
        }
    }
}
