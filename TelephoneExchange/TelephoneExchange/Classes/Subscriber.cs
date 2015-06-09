using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    abstract class Subscriber
    {
        public int Id { get; private set; }

        public Subscriber(int id)
        {
            Id = id;
        }
    }
}
