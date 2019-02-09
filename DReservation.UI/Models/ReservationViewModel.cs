using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DReservation.Models.Domain;

namespace DReservation.UI.Models
{
    public class ReservationViewModel
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Patient Patient { get; set; }

        public string Comments { get; set; }
    }
}
