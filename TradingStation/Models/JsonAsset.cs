using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    // README:
    // dieses Model ist angedacht als Model zur Rueckuebergabe an die View
    // kann man machen, muss man aber nicht.
    public class JsonAsset
    {
        public int Id { get; set; }
        public string Time { get; set; }

        public string ChartName { get; set; }

        public float PriceEur { get; set; } = 0.0f;

        public float Amount { get; set; } = 0.0f;

        public action Transaction { get; set; }

        public bool Active { get; set; } = true;
    }

    public enum action
    {
        bought, sold
    }



}