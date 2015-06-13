using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Interfaces
{
    public interface ITerminal
    {
        void PlugInTerminal();
        void UnplugTerminal();
        void CallTo(int phoneNumber);
        void DropCall();
        void AnswerCall();

        event EventHandler PlugIn;
        event EventHandler Unplug;
        event EventHandler<CallEventArgs> Call;
        event EventHandler Drop;
        event EventHandler Answer;

    }
}
