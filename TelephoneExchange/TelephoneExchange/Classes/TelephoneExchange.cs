using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using TelephoneExchange.Classes.EventsArgs;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        private class Connection
        {
            public enum ConnectionState
            {
                Initiated,
                Started
            }

            private ConnectionState state = ConnectionState.Initiated;
            private Stopwatch timer;
            private Port caller;
            private Port receiver;
            private DateTime ConnectionStarted;
            private TimeSpan Duration;
            private TelephoneExchange ats;

            public event EventHandler<CallInfoEventArgs> ConnectionFinished;

            public Connection(Port callerPort, Port receiverPort, TelephoneExchange TelEx)
            {
                caller = callerPort;
                receiver = receiverPort;
                ats = TelEx;
                caller.PropertyChanged += this.OnPortStatechanged;
                receiver.PropertyChanged += this.OnPortStatechanged;
            }

            public void DispatchCall()
            {
                int callerPhoneNumber;
                ats.PhoneNumbers.TryGetValue(caller, out callerPhoneNumber);
                receiver.PhoneNumberInfo = callerPhoneNumber;
                receiver.State = PortState.IncomingCall;
            }

            public void StartConnection()
            {
                //timer = Stopwatch.StartNew();
                ConnectionStarted = DateTime.Now;                                
            }

            public void CloseConnection()
            {
                //timer.Stop();
                Duration = new TimeSpan(10000);// timer.Elapsed;
                caller.PropertyChanged -= this.OnPortStatechanged;
                receiver.PropertyChanged -= this.OnPortStatechanged;

            }

            private void OnPortStatechanged(object sender, PropertyChangedEventArgs e)
            {
                switch((sender as Port).State)
                {
                    case PortState.CallAccepted :
                        //if (sender == receiver) StartConnection();
                        StartConnection();
                        break;

                    case PortState.Ready :
                        if (sender == receiver) caller.State = PortState.Ready; 
                        else receiver.State = PortState.Ready;
                        break;
                }
            }
        }

        private List<CallInfo> CallsHistory = new List<CallInfo>();
        private  Dictionary<int, Port> Ports = new Dictionary<int, Port>();
        private Dictionary<Port, int> PhoneNumbers = new Dictionary<Port, int>();

        private void OnConnectionFinished(object sender, CallInfoEventArgs e)
        {
            Console.WriteLine("Connection finished:/n Caller : {0}; receiver : {1}; Started at {2}; Duration {2}", e.callInfo.Caller, e.callInfo.Receiver, e.callInfo.StartTime, e.callInfo.Duration); ;
            CallsHistory.Add(e.callInfo);
        }

        public void OnPortStateChanged(object sender, PropertyChangedEventArgs e)
        {
            Port callerPort = sender as Port;
            //int callerPhoneNumber; ;
//            PhoneNumbers.TryGetValue(callerPort, out callerPhoneNumber);
            switch (callerPort.State)
            {
                case PortState.OutgoingCall :
                    Port receiverPort;
                    Ports.TryGetValue(callerPort.PhoneNumberInfo, out receiverPort);
                    //Console.WriteLine("subscriber {0} is calling to Subscriber {1}", callerPhoneNumber, callerPort.PhoneNumberInfo);
                    Connection con = new Connection(callerPort, receiverPort, this);
                    con.ConnectionFinished += this.OnConnectionFinished;
                    con.DispatchCall();
                    con.CloseConnection();
                    break;
            }
        }

        public void OnNewcontractRegistering(object sender, NewContractEventArgs e)
        {
            //Console.WriteLine("ATS : {0}", e.TelephoneNumber);
            Port port = new Port();
            port.PropertyChanged += this.OnPortStateChanged;
            e.port = port;
            Ports.Add(e.TelephoneNumber, port);
            PhoneNumbers.Add(port, e.TelephoneNumber);
        }


    }

}
