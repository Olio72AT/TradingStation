using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TradingStation.Models
{
    public class Termin
    {
        public int TerminId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Name")]
        public string Title { get; set; }

        [Display(Name = "Beschreibung")]
        public string Description { get; set; }

        public bool Pending { get; set; }

        [Display(Name = "Erinnerungsdatum")]
        public DateTime TerminReminder { get; set; }

        [Display(Name = "Priorität")]
        public Priority TerminPriority { get; set; }

        public enum Priority
        {
            [Display(Name = "niedrig")]
            low,
            [Display(Name = "mittel")]
            medium,
            [Display(Name = "hoch")]
            high
        }
    }
}