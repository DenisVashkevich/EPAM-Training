using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public class PersonSubscriber : ISubscriber 
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string PassportNumber { get; private set; }

        public PersonSubscriber(string fName, string sName, DateTime dtBirth, string passNum)
        {
            FirstName = fName;
            LastName = sName;
            DateOfBirth = dtBirth;
            PassportNumber = passNum;
        }
    }
}
