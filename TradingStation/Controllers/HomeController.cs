using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TradingStation.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Kommentar schreiben
        // Entweder seperate Views für User, Admin oder Anonymus anlegen
        // oder Logik zur speziellen Anzeige im View implementieren
        public ActionResult Anonym()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get(".o");

            if (cookie != null)
            {
                return RedirectToAction("IsUser");
            }


            return View();
        }

        // ACHTUNG: der RoleProvider 'mRoleProvider' arbeitet noch nicht dynamisch.
        // Er gibt an die AnnotationMethode(bzw. ist von ihr abrufbar) momentan nur eine statische(hardcoded) Liste bzw. Array in UserIDs
        // no-matter-what eigentlich im/beim User fuer Rollen eingetragen sind.
        // man muesste schon dort (mRoleProvider) eine Logik implementieren, die den User ansieht, also welche Rollem im Zugewiesen sind,
        // bzw. welche rolle er zugewiesen bekommen hat, momentan ist das Role-Feld nur ein einzelwert und nicht als array vorgesehen, 
        // soll ein benutzer mehrere Rollen uebernehmen koennen, dann muss man das als Array bzw. Liste anlegen und ein dementsprechnedes Array von der Methode
        // "GetUseRoles" zurueckgeben lassen.
        [Authorize(Roles = "U")]
        public ActionResult IsUser()
        {


            return View();
        }


        public ActionResult Wallet()
        {
            HttpCookie cookie = HttpContext.Request.Cookies.Get(".o");

            if (cookie != null)
            {
                return RedirectToAction("WalletLogin");
            }

            return View();
        }

        [Authorize(Roles = "U")]
        public ActionResult WalletLogin()
        {

            return View();
        }


        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}