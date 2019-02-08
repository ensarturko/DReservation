using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        [JsonIgnore]
        public IDictionary<DayOfWeek, Slot> Days => new Dictionary<DayOfWeek, Slot>
        {
            [DayOfWeek.Monday] = Monday,
            [DayOfWeek.Tuesday] = Tuesday,
            [DayOfWeek.Wednesday] = Wednesday,
            [DayOfWeek.Thursday] = Thursday,
            [DayOfWeek.Friday] = Friday
        };
    }
}
