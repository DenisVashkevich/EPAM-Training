using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesAnalysis.Models
{
    public class ManagerViewModel : DAL.Models.Manager
    {
        public ManagerViewModel(DAL.Models.Manager manager)  
        {
            this.Id = manager.Id;
            this.FirstName = manager.FirstName;
            this.SecondName = manager.SecondName;
        }
     
        public string FullName { get { return SecondName + " " + FirstName; } }
    }
}