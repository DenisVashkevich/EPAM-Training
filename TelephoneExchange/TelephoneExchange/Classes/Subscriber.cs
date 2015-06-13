using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Classes;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class Subscriber : Subscribers
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PassportNumber { get; private set; }
        //public Terminal Telephone { get; set; }

        public Subscriber(string fName, string sName, DateTime dtBirth, string passNum)
        {
            FirstName = fName;
            LastName = sName;
            DateOfBirth = dtBirth;
            PassportNumber = passNum;
        }

        public override string GetName()
        {
            return FirstName + " " + LastName; 
        }

        public int GetContractNumber()
        {
            return Contract.ContractNumber;
        }
    }
}
