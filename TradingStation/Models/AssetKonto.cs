using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    public class AssetKonto
    {// Code was hart zum schreiben war.. muss auch hart zum lesen sein
        //eier
        public int AssetKontoID { get; set; } // own ID
        public KontoAsset KontoAsset{ get; set; }
        public string KontoArt { get; set; }
    }
}