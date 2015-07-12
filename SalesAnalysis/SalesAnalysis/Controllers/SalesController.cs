using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesAnalysis.Models;

namespace SalesAnalysis.Controllers
{
    public class SalesController : Controller
    {
        private DAL.SalesRepository salesContext = new DAL.SalesRepository();
        private DAL.ManagerRepository managersContext = new DAL.ManagerRepository();
        // GET: Sales
        public ActionResult Index()
        {
            ViewBag.ManagersList = new SelectList(managersContext.Items.Select(x => new ManagerViewModel(x)).ToList(), dataValueField: "Id", dataTextField: "FullName");
            return View();
        }


        //public PartialViewResult SalesFiltered(int? managerId, DateTime? dateFrom, DateTime? dateTo)
        public PartialViewResult SalesFiltered(int? managerId, DateTime? dateFrom, DateTime? dateTo)
        {
            //Random rand = new Random();
            //managerId = rand.Next(1, 99);

            if (managerId == null) managerId = 7;
            ViewBag.ManagerId = managerId;
            DateTime dtFrom =  (dateFrom ?? new DateTime(2000,1,1));
            DateTime dtTo =  (dateTo ?? DateTime.Today);

            ViewBag.DateFrom = dtFrom;
            ViewBag.DateTo = dtTo;

            var salesData = salesContext.Items.Where(
                x => (managerId == null ? x.Manager.Id>0 : x.Manager.Id == managerId)).Where(
                x=>(x.Date>=dtFrom && x.Date<=dtTo)
                ).Select(x => new SalesViewModel
                    {
                        Id = x.Id,
                        Date = x.Date,
                        Manager = new ManagerViewModel(x.Manager),
                        Client = x.Client,
                        Goodds = x.Goodds,
                        Cost = x.Cost
                    });

            ViewBag.RecordsCount = salesData.Count();

            return PartialView(salesData);
                
        }
    }
}