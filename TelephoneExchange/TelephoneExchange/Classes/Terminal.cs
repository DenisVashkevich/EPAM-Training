using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class Terminal
    {
        private int phoneNumber;
        public string  MyPhoneNumber 
            {
                get
                {
                    return phoneNumber.ToString().Substring(0, 3) 
                        + "-" 
                        + phoneNumber.ToString().Substring(3, 5) 
                        + "-" 
                        + phoneNumber.ToString().Substring(5, 7);
                }
            }

        public event EventHandler PlugIn;
        public event EventHandler Unplug;

        public Terminal(int phoneNum)
        {
            phoneNumber = phoneNum;
        }

        
        public void PlugInTerminal()
        {
            if (PlugIn != null) 
                PlugIn(this, new EventArgs());
        }

        public void UnplugTerminal()
        {
            if (Unplug != null) 
                Unplug(this, new EventArgs());
        }

        public void Call()
        {
        }

    }
}
