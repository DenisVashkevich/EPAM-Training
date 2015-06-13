using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class SimpleContractForPerson : ContractHead
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PassportNumber { get; private set; }
        //public int PhoneNumber { get; private set; }
        
        public SimpleContractForPerson(int contracrNum, ITariffPlan plan, int phoneNumber, string firstName, string lastName, DateTime dateOfBirth, string passportNumber) : base(contracrNum, plan, phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            PassportNumber = passportNumber;
        }
    }
}
