using System;

namespace DReservation.Models.Domain
{
    public class Reservation
    {
        public Guid FacilityId { get; set; } = new Guid();

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Patient Patient { get; set; }

        public string Comments { get; set; }
    }
}
