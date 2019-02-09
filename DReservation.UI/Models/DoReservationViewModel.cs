using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.UI.Models
{
    public class DoReservationViewModel
    {
        public TimeSpan StartDate { get; set; }
        public TimeSpan EndDate { get; set; }
        public DateTime SelectedDay { get; set; }


    }
}
