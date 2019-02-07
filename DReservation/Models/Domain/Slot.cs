using System.Collections.Generic;

namespace DReservation.Models.Domain
{
    public class Slot
    {
        public WorkPeriod WorkPeriod { get; set; }

        public List<BusySlot> BusySlots { get; set; }
    }
}
