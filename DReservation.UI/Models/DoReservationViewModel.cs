using System;

namespace DReservation.UI.Models
{
    public class DoReservationViewModel
    {
        public TimeSpan StartDate { get; set; }
        public TimeSpan EndDate { get; set; }
        public DateTime SelectedDay { get; set; }


    }
}
