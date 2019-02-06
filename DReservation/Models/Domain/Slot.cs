using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.Models.Domain
{
    public class Slot
    {
        public WorkPeriod WorkPeriod { get; set; }

        public List<BusySlot> BusySlots { get; set; }
    }
}
