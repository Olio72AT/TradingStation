using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    public class KontoAsset
    {
        public int KontoAssetID { get; set; }
        public Asset asset { get; set; }
        public int assetAmount { get; set; }

        // ueber Konstruktor 2tes Asset verbieten.

    }
}