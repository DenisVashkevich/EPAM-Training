using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;
using TelephoneExchange.Classes;

namespace TelephoneExchange
{
    public class CommunicationCompany
    {
        public EventHandler<NewContractEventArgs> NewContractRegistering;

        private TelephoneExchange ATS;
        private Dictionary<int, ContractHead> Contracts = new Dictionary<int, ContractHead>();

        public CommunicationCompany(TelephoneExchange ats)
        {
            ATS = ats;
        }
        
        public void AddContract(Subscribers newSubscriber, ContractHead newContract)
        {
            if (NewContractRegistering != null) 
            {
                Contracts.Add(newContract.ContractNumber, newContract);
                NewContractEventArgs args = new NewContractEventArgs(newContract.PhoneNumber);
                NewContractRegistering(this, args);
                Terminal terminal = new Terminal();
                terminal.PlugIn += args.port.OnTerminalPlugedIn;
                terminal.Unplug += args.port.OnTerminalUnPluged;
                terminal.Call += args.port.OnOutgoingCall;
                terminal.Drop += args.port.OnDropCall;
                terminal.Answer += args.port.OnAnswerToCall;
                args.port.PropertyChanged += terminal.OnPortStateChanged;
                newSubscriber.Contract = newContract;
                newSubscriber.Telephone = terminal;
            }
        }

        public int GenerateNewContractNumber()
        {
            return Contracts.Count + 1;
        }

        public int GenerateNewTelephoneNumber()
        {
            return Contracts.Count + 2700001;
        }

        public IEnumerable<DetalizationLine> GetCSubscriberdetalization(int phoneNumber)
        {
            Func<CallInfo, double> CallCost = Contracts.FirstOrDefault(c => c.Value.PhoneNumber == phoneNumber).Value.GetCurrentTariffPlan().CalculateCallCost;
            
            IEnumerable<CallInfo> CallsHistory = ATS.GetCallsHistory(phoneNumber);

            return CallsHistory.Select(ci =>
                new DetalizationLine(
                    ci.StartTime,
                    ci.Caller == phoneNumber ? ci.Receiver : ci.Caller,
                    ci.Caller == phoneNumber ? 1 : 2,
                    ci.Duration, CallCost(ci)
                    )
                ).OrderBy(dl => dl.calllDateTime);
        }

    }
}
