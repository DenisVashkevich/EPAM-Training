using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using TelephoneExchange.Classes.EventsArgs;
using TelephoneExchange.Classes;

namespace TelephoneExchange
{
    public class TelephoneExchange
    {
        //initializes a connection between two subscribers,
        //gives information about connection
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
            private Timer connectionTimeOut;
            
            public event EventHandler<CallInfoEventArgs> ConnectionFinished;

            public Connection(Port callerPort, Port receiverPort, TelephoneExchange TelEx)
            {
                this.caller = callerPort;
                this.receiver = receiverPort;
                ats = TelEx;
                this.caller.PropertyChanged += this.OnPortStatechanged;
                this.receiver.PropertyChanged += this.OnPortStatechanged;
            }

            //Dispatch a call from caller to receiver
            public void DispatchCall()
            {
                int callerPhoneNumber;
                connectionTimeOut = new Timer(6000);//Timec counting possible time for acting on incomming call
                connectionTimeOut.Elapsed += this.OnConnectionTimeOut;
                connectionTimeOut.Enabled = true;
                ats.PhoneNumbers.TryGetValue(caller, out callerPhoneNumber);
                this.receiver.PhoneNumberInfo = callerPhoneNumber;
                this.callInformation.Caller = callerPhoneNumber;
                this.callInformation.Receiver = caller.PhoneNumberInfo;
                Console.WriteLine("Dispathing call from {0} to {1}", callerPhoneNumber, caller.PhoneNumberInfo);
                this.receiver.State = PortState.IncomingCall;
                
            }

            private void OnConnectionTimeOut(object sender, ElapsedEventArgs e)
            {
                if (this.state != ConnectionState.Closed) 
                {
                    this.caller.State = PortState.Ready;
                    this.receiver.State = PortState.Ready;
                    this.caller.PropertyChanged -= this.OnPortStatechanged;
                    this.receiver.PropertyChanged -= this.OnPortStatechanged;
                    this.connectionTimeOut.Elapsed -= this.OnConnectionTimeOut;
                    this.connectionTimeOut.Enabled = false;

                    this.state = ConnectionState.Closed;
                    Console.WriteLine("No ansewer.");
                }

            }

            private void StartConnection()
            {
                this.state = ConnectionState.Opened;
                this.timer = Stopwatch.StartNew();
                this.ConnectionStarted = DateTime.Now;        
                this.callInformation.StartTime=this.ConnectionStarted;
                Console.WriteLine("Subscriber {0} is talking whith subscriber {1}", this.callInformation.Caller, this.callInformation.Receiver);
            }

            private void CloseConnection()
            {
                this.state = ConnectionState.Closed;
                Console.WriteLine("Connection closed.");
                this.timer.Stop();
                this.Duration = this.timer.Elapsed;
                this.caller.PropertyChanged -= this.OnPortStatechanged;
                this.receiver.PropertyChanged -= this.OnPortStatechanged;
                this.callInformation.Duration = new TimeSpan(this.Duration.Hours, this.Duration.Minutes, this.Duration.Seconds);
                //Notifies ATS that connection is finished and sends connection information
                ConnectionFinished(this, new CallInfoEventArgs(this.callInformation));
            }

            //Ports state listener
            private void OnPortStatechanged(object sender, PropertyChangedEventArgs e)
            {
                switch((sender as Port).State)
                {
                    case PortState.CallAccepted :
                        if (sender == this.receiver)
                        {
                            this.connectionTimeOut.Elapsed -= this.OnConnectionTimeOut;
                            this.connectionTimeOut.Enabled = false;
                            Console.WriteLine("connection started");
                            //Starting a connection when other subscriber accepts call
                            StartConnection();
                        }
                        break;

                    case PortState.Ready :
                        if (this.state == ConnectionState.Opened) 
                        {
                            //Closing connection when one of subscribers finishes call
                            CloseConnection();
                            //reseting port state of second subscriber
                            if (sender == this.receiver) this.caller.State = PortState.Ready;
                            else this.receiver.State = PortState.Ready;
                        }
                        break;
                }
            }
        }

        private List<CallInfo> CallsHistory = new List<CallInfo>();  //Information history for past calls
        private  Dictionary<int, Port> Ports = new Dictionary<int, Port>(); //Dictionary for getting port based on phoneNumber
        private Dictionary<Port, int> PhoneNumbers = new Dictionary<Port, int>(); // Dictionary fpr getting phoneNUmber based on port

        //Adding a record to Calls History when connection is finished
        private void OnConnectionFinished(object sender, CallInfoEventArgs e)
        {
            Console.WriteLine("{0}   {1}   {2}   {2}",e.callInfo.Caller, e.callInfo.Receiver,e.callInfo.StartTime,e.callInfo.Duration);
            CallsHistory.Add(e.callInfo);
        }

        //Port state listener 
        private void OnPortStateChanged(object sender, PropertyChangedEventArgs e)
        {
            Port callerPort = sender as Port;
            switch (callerPort.State)
            {
                case PortState.OutgoingCall :
                    Port receiverPort;
                    Ports.TryGetValue(callerPort.PhoneNumberInfo, out receiverPort);
                    Connection con = new Connection(callerPort, receiverPort, this);
                    con.ConnectionFinished += this.OnConnectionFinished;
                    con.DispatchCall();
                    break;
            }
        }

        /// <summary>
        /// Creates a new port for new terminal
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">NewContractEventArgs</param>
        public void OnNewcontractRegistering(object sender, NewContractEventArgs e)
        {
            Port port = new Port();
            port.PropertyChanged += this.OnPortStateChanged;
            e.port = port;
            Ports.Add(e.TelephoneNumber, port);
            PhoneNumbers.Add(port, e.TelephoneNumber);
        }

        /// <summary>
        /// Generates fake records in Calls History 
        /// for demonstration mode
        /// </summary>
        /// <param name="numRecords">Number of records to generate</param>
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

            //int j = 0;
            //Console.WriteLine("*******************Calls register**********************");
            //foreach (CallInfo c in CallsHistory)
            //{
            //    Console.WriteLine("Record # {4} :\n \t Caller: {0}\n \t Receiver : {1}\n \t Started at {2}\n \t Duration {3}", c.Caller, c.Receiver, c.StartTime, c.Duration, ++j);
            //}
        }

        /// <summary>
        /// Returns calls history for specified subscriber
        /// </summary>
        /// <param name="clientPhoneNumber">Telephone number of subscriber</param>
        /// <param name="from">Start of period for query</param>
        /// <param name="till">End of period for query</param>
        /// <returns>IEnumerable Collection of CallInfo records</returns>
        public IEnumerable<CallInfo> GetCallsHistory(int clientPhoneNumber, DateTime from, DateTime till)
        {
            return CallsHistory.Where(ci => 
                ((ci.Caller == clientPhoneNumber) || (ci.Receiver == clientPhoneNumber)) 
                & ci.StartTime > from 
                & ci.StartTime < till
                );
        }

        /// <summary>
        /// Returns calls history for specified subscriber
        /// </summary>
        /// <param name="clientPhoneNumber">Telephone number of subscriber</param>
        /// <param name="destinationPhoneNumber">Telephone number of call receiver</param>
        /// <param name="from">Start of period for query</param>
        /// <param name="till">End of period for query</param>
        /// <returns>IEnumerable Collection of CallInfo records</returns>
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
