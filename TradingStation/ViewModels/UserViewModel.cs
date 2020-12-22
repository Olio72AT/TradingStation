using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradingStation.Models;

namespace TradingStation.ViewModels
{

    //README:
    // waere gedacht um alle relevanten Daten des Users anzuzeigen.
    // und eventuell auch die Konten zu verketten.
    public class UserViewModel
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string eMail { get; set; }

        public bool hasToken { get; set; }

        public List<AssetKonto> kontoList { get; set; }

        public List<Termin> terminList { get; set; }

    }
}