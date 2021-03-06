﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;

namespace SalesAnalysis.Controllers
{
    public class ClientsController : Controller
    {
        DAL.ClientRepository clientsRep = new DAL.ClientRepository();
        // GET: Clients
        public ActionResult Index()
        {
            return View(clientsRep.Items);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clients/Edit/5
        [HttpPost]
        public ActionResult Edit(DAL.Models.Client client)
        {
            if (ModelState.IsValid)
            {
                clientsRep.Update(client);
                clientsRep.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

    }
}
