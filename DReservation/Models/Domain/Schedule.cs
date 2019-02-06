using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.Models.Domain
{
    public class Schedule
    {
        public Facility Facility { get; set; }

        public int SlotDurationMinutes { get; set; }

        public Slot Monday { get; set; }

        public Slot Tuesday { get; set; }

        public Slot Wednesday { get; set; }

        public Slot Thursday { get; set; }

        public Slot Friday { get; set; }

        public Slot Saturday { get; set; }

        public Slot Sunday { get; set; }
    }
}
