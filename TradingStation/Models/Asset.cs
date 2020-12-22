using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    public class Asset
    {// Code was hart zum schreiben war.. muss auch hart zum lesen sein lg ruhland :D
        public int AssetID { get; set; }
        public string AssetName { get; set; }
        public decimal CurrentValue { get; set; }
        public KindOfAsset KindOfAsset { get; set; }

    }
}