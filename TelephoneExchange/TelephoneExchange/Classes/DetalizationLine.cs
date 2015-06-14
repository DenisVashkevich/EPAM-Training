using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange.Classes
{
    public class DetalizationLine
    {
        public DateTime calllDateTime = new DateTime();
        public int phoneNumber;
        public int code;
        public TimeSpan duration;
        public double cost;

        public DetalizationLine(DateTime calllDT, int phoneNum, int cd, TimeSpan dur, double cst)
        {
            this.calllDateTime = calllDT;
            this.phoneNumber = phoneNum;
            this.code = cd;
            this.duration = dur;
            this.cost = cst;
        }

    }
}
