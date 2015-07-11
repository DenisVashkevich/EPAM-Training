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
            //ViewBag.ManagersList = managersList;

            return View();

        }


        public PartialViewResult SalesFiltered(string Id)
        {
            ViewBag.ManagerId = Id;
            //var salesData = salesContext.Items.Where(x=>x.Id == ViewBag.ManagerId).Select(x => new SalesViewModel
            //{
            //    Id = x.Id,
            //    Date = x.Date,
            //    Manager = new ManagerViewModel(x.Manager),
            //    Client = x.Client,
            //    Goodds = x.Goodds,
            //    Cost = x.Cost
            //});

            return PartialView();
        }
    }
}