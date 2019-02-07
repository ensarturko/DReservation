using System.Collections.Generic;

namespace DReservation.Models.Domain
{
    public class WeekSchedule
    {
        public Facility Facility { get; set; }

        public int SlotDurationMinutes { get; set; }

        public List<WeekHours> WeekHours { get; set; }
    }
}
