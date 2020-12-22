using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    public class Transaktion
    {// quasi logmodell ueber alle durchgefuehrten Transaktionen
     // Id -
     //Datum - Uhrzeit
     //Volumen - also Menge wieviel an Coins getradet wurde ganzzahlig oder Bruch bzw. Komma
     //GesamtWert - Gesamtwert der durchgefuehrten Transaktion zum Durchfuehrungszeitpunkt.

        // Chart.js Nuget Packet Erforderlich für einbeten eines Charts (Diagramms) 
        // die Scripts werden um Chart.js und Chart.min.js erweitert

        public DateTime Datum { get; set; }

        public Asset Asset { get; set; }


    }
}