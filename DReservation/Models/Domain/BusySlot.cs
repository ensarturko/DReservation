using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.Models.Domain
{
    public class BusySlot
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}
