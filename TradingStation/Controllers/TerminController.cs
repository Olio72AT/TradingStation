using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingStation.Models;

namespace TradingStation.Controllers
{
    public class TerminController : Controller
    {
        public static List<Termin> terminList = new List<Termin>();
        // GET: Termin
        public ActionResult Index()
        {
            List<Termin> pendingList = new List<Termin>();

            foreach (var item in terminList)
            {
                if (item.Pending == true)
                {
                    pendingList.Add(item);
                }
            }

            return View(pendingList);
        }

        // GET: Termin/Details/5
        public ActionResult Details(int id)
        {
            var termin = terminList.Where(x => x.TerminId == id).FirstOrDefault();

            return View(termin);
        }

        // GET: Termin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Termin/Create
        [HttpPost]
        public ActionResult Create(Termin termin)
        {
            try
            {
                termin.TerminId = terminList.Count + 1;
                termin.Pending = true;
                terminList.Add(termin);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Termin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Termin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Termin termin)
        {
            try
            {
                terminList.Where(x => x.TerminId == id).FirstOrDefault().Title = termin.Title;
                terminList.Where(x => x.TerminId == id).FirstOrDefault().Description = termin.Description;
                terminList.Where(x => x.TerminId == id).FirstOrDefault().TerminReminder = termin.TerminReminder;
                terminList.Where(x => x.TerminId == id).FirstOrDefault().TerminPriority = termin.TerminPriority;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Termin/Delete/5
        public ActionResult Delete(int id)
        {
            Termin termin = terminList.Where(x => x.TerminId == id).FirstOrDefault();

            return View(termin);
        }

        // POST: Termin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Termin termin)
        {
            try
            {
                terminList.Where(x => x.TerminId == id).FirstOrDefault().Pending = false;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
