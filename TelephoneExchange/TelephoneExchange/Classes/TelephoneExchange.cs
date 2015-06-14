using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using TelephoneExchange.Classes.EventsArgs;
using TelephoneExchange.Classes;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        private class Connection
        {
            private enum ConnectionState
            {
                Initiated,
                Opened,
                Closed
            }

            private ConnectionState state = ConnectionState.Initiated;
            private Stopwatch timer;
            private Port caller;
            private Port receiver;
            private DateTime ConnectionStarted;
            private TimeSpan Duration;
            private TelephoneExchange ats;
            private CallInfo callInformation = new CallInfo();

            public event EventHandler<CallInfoEventArgs> ConnectionFinished;

            public Connection(Port callerPort, Port receiverPort, TelephoneExchange TelEx)
            {
                this.caller = callerPort;
                this.receiver = receiverPort;
                ats = TelEx;
                this.caller.PropertyChanged += this.OnPortStatechanged;
                this.receiver.PropertyChanged += this.OnPortStatechanged;
            }

            public void DispatchCall()
            {
                int callerPhoneNumber;
                ats.PhoneNumbers.TryGetValue(caller, out callerPhoneNumber);
                this.receiver.PhoneNumberInfo = callerPhoneNumber;
                this.callInformation.Caller = callerPhoneNumber;
                this.callInformation.Receiver = caller.PhoneNumberInfo;
                Console.WriteLine("Dispathing call from {0} to {1}", callerPhoneNumber, caller.PhoneNumberInfo);
                this.receiver.State = PortState.IncomingCall;
            }

            public void StartConnection()
            {
                this.state = ConnectionState.Opened;
                this.timer = Stopwatch.StartNew();
                this.ConnectionStarted = DateTime.Now;        
                this.callInformation.StartTime=this.ConnectionStarted;
                Console.WriteLine("Subscriber {0} is talking whith subscriber {1}", this.callInformation.Caller, this.callInformation.Receiver);
            }

            public void CloseConnection()
            {
                this.state = ConnectionState.Closed;
                Console.WriteLine("Connection closed.");
                this.timer.Stop();
                this.Duration = this.timer.Elapsed;
                this.caller.PropertyChanged -= this.OnPortStatechanged;
                this.receiver.PropertyChanged -= this.OnPortStatechanged;
                this.callInformation.Duration =this.Duration;
                ConnectionFinished(this, new CallInfoEventArgs(this.callInformation));
            }

            private void OnPortStatechanged(object sender, PropertyChangedEventArgs e)
            {
                switch((sender as Port).State)
                {
                    case PortState.CallAccepted :
                        if (sender == this.receiver)
                        {
                            Console.WriteLine("connection started");
                            StartConnection();
                        }
                        break;

                    case PortState.Ready :
                        if (this.state == ConnectionState.Opened) 
                        {
                            CloseConnection();
                            if (sender == this.receiver) this.caller.State = PortState.Ready;
                            else this.receiver.State = PortState.Ready;
                            
                        }
                        break;
                }
            }
        }

        private List<CallInfo> CallsHistory = new List<CallInfo>();
        private  Dictionary<int, Port> Ports = new Dictionary<int, Port>();
        private Dictionary<Port, int> PhoneNumbers = new Dictionary<Port, int>();

        private void OnConnectionFinished(object sender, CallInfoEventArgs e)
        {
            //Console.WriteLine("Connection summary :\n \t Caller : {0}\n \t Receiver : {1}\n \t Started at {2}\n \t Duration {3}", e.callInfo.Caller, e.callInfo.Receiver, e.callInfo.StartTime, e.callInfo.Duration); ;
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

        public void GenerateSomeFakeCallInfoRecords(int numRecords)
        {
            CallInfo callInfo;
            Random rand = new Random();
            for (int i = 1; i <= numRecords; i++)
            {
                callInfo = new CallInfo();
                callInfo.Caller = rand.Next(this.Ports.Keys.Min(), this.Ports.Keys.Max());
                do
                {
                    callInfo.Receiver = rand.Next(this.Ports.Keys.Min(), this.Ports.Keys.Max());
                } while (callInfo.Caller == callInfo.Receiver);
                callInfo.StartTime = new DateTime(2015, rand.Next(1, 12), rand.Next(1, 27), rand.Next(0, 23), rand.Next(0, 59), rand.Next(0, 59));
                callInfo.Duration = new TimeSpan(0, rand.Next(25), rand.Next(1, 59));
                CallsHistory.Add(callInfo);
            }

            int j = 0;
            Console.WriteLine("*******************Calls register**********************");
            foreach (CallInfo c in CallsHistory)
            {
                Console.WriteLine("Record # {4} :\n \t Caller: {0}\n \t Receiver : {1}\n \t Started at {2}\n \t Duration {3}", c.Caller, c.Receiver, c.StartTime, c.Duration, ++j);
            }
        }

        //public IEnumerable<CallInfo> GetCallsHistory(int phoneNumber)
        //{
        //    return CallsHistory.Where(ci => ((ci.Caller == phoneNumber) || (ci.Receiver == phoneNumber)));
        //}

        public IEnumerable<CallInfo> GetCallsHistory(int clientPhoneNumber, DateTime from, DateTime till)
        {
            return CallsHistory.Where(ci => 
                ((ci.Caller == clientPhoneNumber) || (ci.Receiver == clientPhoneNumber)) 
                & ci.StartTime > from 
                & ci.StartTime < till
                );
        }

        public IEnumerable<CallInfo> GetCallsHistory(int clientPhoneNumber, int destinationPhoneNumber, DateTime from, DateTime till)
        {
            return CallsHistory.Where(ci =>
                ((ci.Caller == clientPhoneNumber) || (ci.Receiver == clientPhoneNumber))
                & ((ci.Caller == destinationPhoneNumber) || (ci.Receiver == destinationPhoneNumber))
                & ci.StartTime > from
                & ci.StartTime < till
                );
        }
    }

}
