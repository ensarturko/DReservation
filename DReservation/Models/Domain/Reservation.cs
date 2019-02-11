using System;

namespace DReservation.Models.Domain
{
    public class Reservation
    {
        public Guid FacilityId { get; set; } = new Guid("b04f80b4-5c35-42f3-941c-6c78a726387b");

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Patient Patient { get; set; }

        public string Comments { get; set; }
    }
}
