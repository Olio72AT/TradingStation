using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingStation.Models;

namespace TradingStation.Controllers
{
    public class KontoAssetController : Controller
    {
        public static List<KontoAsset> KontoAssetList = new List<KontoAsset>();
        // GET: KontoAsset
        public ActionResult Index()
        {
            return View(KontoAssetList);
        }

        // GET: KontoAsset/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KontoAsset/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KontoAsset/Create
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

        // GET: KontoAsset/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KontoAsset/Edit/5
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

        // GET: KontoAsset/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KontoAsset/Delete/5
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
