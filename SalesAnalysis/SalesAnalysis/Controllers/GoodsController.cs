using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesAnalysis.Controllers
{
    public class GoodsController : Controller
    {
        DAL.GoodsRepository goodsContext = new DAL.GoodsRepository();
        // GET: Goods
        public ActionResult Index()
        {
            return View(goodsContext.Items);
        }


        // POST: Goods/Create

        // GET: Goods/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Goods/Edit/5
        [HttpPost]
        public ActionResult Edit(DAL.Models.Goods product)
        {
            if (ModelState.IsValid)
            {
                goodsContext.Update(product);
                goodsContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

    }
}
