//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;


//namespace SalesAnalysis.Controllers
//{
//    [Authorize]
//    public class ManagerSetsController : Controller
//    {
//        private SalesEntities db = new SalesEntities();

//        // GET: ManagerSets
//        public async Task<ActionResult> Index()
//        {
//            return View(await db.ManagerSets.ToListAsync());
//        }

//        // GET: ManagerSets/Details/5
//        public async Task<ActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ManagerSet managerSet = await db.ManagerSets.FindAsync(id);
//            if (managerSet == null)
//            {
//                return HttpNotFound();
//            }
//            return View(managerSet);
//        }

//        // GET: ManagerSets/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: ManagerSets/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,SecondName")] ManagerSet managerSet)
//        {
//            if (ModelState.IsValid)
//            {
//                db.ManagerSets.Add(managerSet);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(managerSet);
//        }

//        // GET: ManagerSets/Edit/5
//        public async Task<ActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ManagerSet managerSet = await db.ManagerSets.FindAsync(id);
//            if (managerSet == null)
//            {
//                return HttpNotFound();
//            }
//            return View(managerSet);
//        }

//        // POST: ManagerSets/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,SecondName")] ManagerSet managerSet)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(managerSet).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(managerSet);
//        }

//        // GET: ManagerSets/Delete/5
//        public async Task<ActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            ManagerSet managerSet = await db.ManagerSets.FindAsync(id);
//            if (managerSet == null)
//            {
//                return HttpNotFound();
//            }
//            return View(managerSet);
//        }

//        // POST: ManagerSets/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(int id)
//        {
//            ManagerSet managerSet = await db.ManagerSets.FindAsync(id);
//            db.ManagerSets.Remove(managerSet);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
