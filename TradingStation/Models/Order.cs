using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    // Order-Modell, eine Order wuerde selbst nicht gespeichert sondern bliebe solange 'instanziert' wie sie Pending ist 
    // und wuerde dann verbucht aufs Konto sowie als durchgefuehrte Transaktion.
    public class Order
    {
        public int OrderId { get; set; }

        public KindOfAsset KindOfAsset { get; set; }
        
        public int AssetId { get; set; }

        public decimal Amount { get; set; }

        public int UserId { get; set; }
    }
}