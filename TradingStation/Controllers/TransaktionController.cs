using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradingStation.Models;

namespace TradingStation.Controllers
{
    public class TransaktionController : Controller
    {
        public static List<Transaktion> transaktionsListe = new List<Transaktion>();
        // GET: Transaktion
        // Per Ajax muss der Wert vom Json vom Home/Index View ausgelesen werden für weitere Verarbeitung im Controller 
        // Asset Werte muessen in einer Liste abgespeichert werden inkl. Datum um vergleichswerte erzeugen zu koennen in der View
        // Zum verwenden und darstellen der Werte in eine Viewbag packen und in der 
        // View im Chart anzeigen lassen per Jscript funktion() 
        // Zusätlich eine Funktion für Dynamisches aktualisieren der View und der Werte  

        public ActionResult Dashboard()
        {
            //var chartValues = transaktionsListe.Select(x => x.Asset.CurrentValue).FirstOrDefault();
            return View();
        }


    }
}
