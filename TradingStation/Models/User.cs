using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    public enum UserRole
    {
        admin = 0,
        user = 1
    }
    public class User
    {
        public static int UserCounter;
        public int Id { get; set; }
        public UserRole userRole { get; set;}      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        // no bool needed since when token is set account has to be locked until reset.
        public string Token { get; set; }

        public string Salt { get; set; }

        public List<Termin> mEventDates {get; set;}

        public List<AssetKonto> assetKontos { get; set; }


    }
}