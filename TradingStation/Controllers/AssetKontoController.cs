using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TradingStation.Models;

namespace TradingStation.Controllers
{
    public class AssetKontoController : Controller
    {
        public static List<AssetKonto> AssetKontoList = new List<AssetKonto>();


        // GET: AssetKonto
        //[Authorize(Roles = "U")]
        public ActionResult Index()
        {
            return View(AssetKontoList);
        }

        // GET: AssetKonto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetKonto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetKonto/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetKonto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetKonto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetKonto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetKonto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
