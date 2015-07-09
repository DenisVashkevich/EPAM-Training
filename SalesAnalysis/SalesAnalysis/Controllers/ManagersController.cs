using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SalesAnalysis.Controllers
{
    public class ManagersController : Controller
    {
        private DAL.ManagerRepository managerRep = new DAL.ManagerRepository();

        // GET: Managers
        public ActionResult Index()
        {
            return View(managerRep.Items);
        }

        //// GET: Managers/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Managers/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Managers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DAL.Models.Manager manager)
        {
            if(ModelState.IsValid)
            {
                managerRep.Add(manager);
                managerRep.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Managers/Edit/5
        [HttpPost]
        public ActionResult Edit(DAL.Models.Manager manager)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    managerRep.Update(manager);
                    managerRep.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View(manager);
            }
            return View(manager);
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DAL.Models.Manager manager = managerRep.Items.FirstOrDefault(x => x.Id == id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            try
            {
                DAL.Models.Manager manager = managerRep.Items.FirstOrDefault(x => x.Id == id);
                if (manager != null)
                {
                    managerRep.Remove(manager);
                    managerRep.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }
    }
}
