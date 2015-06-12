using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class JustCallAndPayContractForPerson : SimpleContractForPerson
    {
        public JustCallAndPayContractForPerson(int contracrNum, int phoneNumber, string firstName, string lastName, DateTime dateOfBirth, string passportNumber) 
            : base(contracrNum,new JustCallAndPayTariffPlan(), phoneNumber, firstName, lastName, dateOfBirth, passportNumber)
        { 
            
        }
    }
}
