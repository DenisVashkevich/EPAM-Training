﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelephoneExchange.Interfaces;

namespace TelephoneExchange
{
    public abstract class ContractHead
    {
        public int ContractNumber { get; private set; }
        protected Dictionary<DateTime, ITariffPlan> Plan = new Dictionary<DateTime, ITariffPlan>();
        public int PhoneNumber { get; private set; }

        public bool ChangeTariffPlan(ITariffPlan newPlan)
        {
            if ((DateTime.Today - Plan.Keys.Last()).Days > DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month))
            {
                Plan.Add(DateTime.Today, newPlan);
                return true;
            }
            return false;
        }

        public ITariffPlan GetCurrentTariffPlan()
        {
            return Plan.Last().Value;
        }

        public ContractHead(int contractNumber, ITariffPlan plan, int phoneNum)
        {
            ContractNumber = contractNumber;
            Plan.Add(DateTime.Today, plan);
            PhoneNumber = phoneNum;

        }
    }
}
