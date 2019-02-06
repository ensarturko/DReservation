using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.Models.Domain
{
    public class WeekHours
    {
        public TimeSpan? Monday { get; set; }

        public TimeSpan? Tuesday { get; set; }

        public TimeSpan? Wednesday { get; set; }

        public TimeSpan? Thursday { get; set; }

        public TimeSpan? Friday { get; set; }

        public TimeSpan? Saturday { get; set; }

        public TimeSpan? Sunday { get; set; }
    }
}
