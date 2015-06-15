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

        /// <summary>
        /// Adds new contract
        /// </summary>
        /// <param name="newSubscriber">New subscriber</param>
        /// <param name="newContract">New contract</param>
        public void AddContract(Subscribers newSubscriber, ContractHead newContract)
        {
            if (NewContractRegistering != null) 
            {
                Contracts.Add(newContract.ContractNumber, newContract);
                NewContractEventArgs args = new NewContractEventArgs(newContract.PhoneNumber);
                NewContractRegistering(this, args);
                Terminal terminal = new Terminal();
                //subscribing port to terminal events, and tepminal to port events 
                terminal.PlugIn += args.port.OnTerminalPlugedIn;
                terminal.Unplug += args.port.OnTerminalUnPluged;
                terminal.Call += args.port.OnOutgoingCall;
                terminal.Drop += args.port.OnDropCall;
                terminal.Answer += args.port.OnAnswerToCall;
                args.port.PropertyChanged += terminal.OnPortStateChanged;
                //Giving new contract and terminal to subscriber
                newSubscriber.Contract = newContract;
                newSubscriber.Telephone = terminal;
            }
        }

        public bool ChangeTariffPlan(Subscribers subscriber, ITariffPlan newPlan)
        {
            ContractHead subsContract;
            Contracts.TryGetValue(subscriber.Contract.ContractNumber, out subsContract);
            if(subsContract.ChangeTariffPlan(newPlan)) return true;
            return false;
            
        }

        /// <summary>
        /// Generates new contract number
        /// </summary>
        /// <returns></returns>
        public int GenerateNewContractNumber()
        {
            return Contracts.Count + 1;
        }

        /// <summary>
        /// Generates new telephone number
        /// </summary>
        /// <returns></returns>
        public int GenerateNewTelephoneNumber()
        {
            return Contracts.Count + 2700001;
        }

        /// <summary>
        /// Returns collection of detalization records
        /// if both "from" and "till" params are skiped, period is current month
        /// you must specify corect period whith both "from" and "till" pramiters for correct result
        /// </summary>
        /// <param name="phoneNumber">Phone number of subscriber ordering detalization</param>
        /// <param name="from">Start period o detalization query</param>
        /// <param name="till">End period of detalization query</param>
        /// <param name="costMoreThen">Filter on call cost (returns records with cost more then costMoreThen)</param>
        /// <returns>IEnumerable collection of DetalizationRow</returns>
        public IEnumerable<DetalizationRow> GetSubscriberdetalization(int phoneNumber, DateTime from = new DateTime(), DateTime till = new DateTime(), double costMoreThen = 0)
        {
            Func<int, CallInfo, double> CallCost = Contracts.FirstOrDefault(c => c.Value.PhoneNumber == phoneNumber).Value.GetCurrentTariffPlan().CalculateCallCost;

            if((from == new DateTime())||(till == new DateTime()))
            {
                from = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                till = DateTime.Now;
            }
            IEnumerable<CallInfo> CallsHistory = ATS.GetCallsHistory(phoneNumber, from, till);
            return CallsHistory.Select(ci =>
                new DetalizationRow(
                    ci.StartTime,
                    ci.Caller == phoneNumber ? ci.Receiver : ci.Caller,
                    ci.Caller == phoneNumber ? 1 : 2,
                    ci.Duration, 
                    CallCost(phoneNumber, ci)
                    )
                ).Where(det => det.cost >= costMoreThen).OrderBy(det => det.calllDateTime);
        }

        /// <summary>
        /// Returns collection of detalization records for calls to specified subscriber
        /// if both "from" and "till" params are skiped, period is current month
        /// you must specify corect period whith both "from" and "till" pramiters for correct result
        /// </summary>
        /// <param name="phoneNumber">Phone number of subscriber ordering detalization</param>
        /// <param name="destPhoneNUmber">Phone number of interlocutor </param>
        /// <param name="from">Start period o detalization query</param>
        /// <param name="till">End period of detalization query</param>
        /// <param name="costMoreThen">Filter on call cost (returns records with cost more then costMoreThen)</param>
        /// <returns>IEnumerable collection of DetalizationRow</returns>
        public IEnumerable<DetalizationRow> GetSubscriberdetalization(int phoneNumber, int destPhoneNUmber, DateTime from = new DateTime(), DateTime till = new DateTime(), double costMoreThen = 0)
        {
            Func<int, CallInfo, double> CallCost = Contracts.FirstOrDefault(c => c.Value.PhoneNumber == phoneNumber).Value.GetCurrentTariffPlan().CalculateCallCost;

            if ((from == new DateTime()) || (till == new DateTime()))
            {
                from = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                till = DateTime.Now;
            }
            IEnumerable<CallInfo> CallsHistory = ATS.GetCallsHistory(phoneNumber, destPhoneNUmber, from, till);

            return CallsHistory.Select(ci =>
                new DetalizationRow(
                    ci.StartTime,
                    ci.Caller == phoneNumber ? ci.Receiver : ci.Caller,
                    ci.Caller == phoneNumber ? 1 : 2,
                    ci.Duration, 
                    CallCost(phoneNumber, ci)
                    )
                ).Where(det => det.cost >= costMoreThen).OrderBy(det => det.calllDateTime);
        }

    }
}
