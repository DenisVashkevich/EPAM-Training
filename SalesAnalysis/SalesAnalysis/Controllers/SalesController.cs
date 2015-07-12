using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesAnalysis.Models;
using PagedList;
using PagedList.Mvc;

namespace SalesAnalysis.Controllers
{
    public class SalesController : Controller
    {
        private DAL.SalesRepository salesContext = new DAL.SalesRepository();
        private DAL.ManagerRepository managersContext = new DAL.ManagerRepository();
        private DAL.ClientRepository clientsContext = new DAL.ClientRepository();
        private DAL.GoodsRepository goodsContext = new DAL.GoodsRepository();

        // GET: Sales
        public ActionResult Index()
        {
            ViewBag.ManagersList = new SelectList(managersContext.Items.Select(x => new ManagerViewModel(x)).ToList(), dataValueField: "Id", dataTextField: "FullName");
            ViewBag.ClientsList = new SelectList(clientsContext.Items.ToList(), dataValueField: "Id", dataTextField: "Name");
            ViewBag.GoodsList = new SelectList(goodsContext.Items.ToList(), dataValueField: "Id", dataTextField: "Name");
            return View();
        }


        public PartialViewResult SalesFiltered(int? managerId, int? clientId, int? productId, DateTime? dateFrom, DateTime? dateTo, int? page)
        {
            
            DateTime dtFrom =  (dateFrom ?? new DateTime(2000,1,1));
            DateTime dtTo =  (dateTo ?? DateTime.Today);

            ViewBag.DateFrom = dtFrom;
            ViewBag.DateTo = dtTo;

            var salesData = salesContext.Items.Where(
                x => ((managerId == null ? x.Manager.Id>0 : x.Manager.Id == managerId)&&
                     (clientId == null ? x.Client.Id > 0 : x.Client.Id == clientId) &&
                     (productId == null ? x.Goodds.Id > 0 : x.Goodds.Id == productId))
                ).Where(x=>(x.Date>=dtFrom && x.Date<=dtTo)
                ).Select(x => new SalesViewModel
                    {
                        Id = x.Id,
                        Date = x.Date,
                        Manager = new ManagerViewModel(x.Manager),
                        Client = x.Client,
                        Goodds = x.Goodds,
                        Cost = x.Cost
                    }).OrderBy(x=>x.Date);

            var pageNumber = page ?? 1;
            var onePageOfSales = salesData.ToPagedList(pageNumber, 10); 

            ViewBag.OnePageOfProducts = onePageOfSales;
            ViewBag.CurrentManagerId = managerId;
            ViewBag.CurrentClientId = clientId;
            ViewBag.CurrentProductId = productId;
            ViewBag.CurrentDateFrom = dateFrom;
            ViewBag.CurrentDateTo = dateTo;

            return PartialView(onePageOfSales);
                
        }
    }
}