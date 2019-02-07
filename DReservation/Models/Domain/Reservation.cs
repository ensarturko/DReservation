using System;

namespace DReservation.Models.Domain
{
    public class Reservation
    {
        public string FacilityId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Patient Patient { get; set; }

        public string Comments { get; set; }
    }
}
