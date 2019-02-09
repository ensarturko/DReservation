using System.Collections.Generic;

namespace DReservation.UI.Models
{
    public class GetAvailabilityViewModel
    {
        public GetAvailabilityViewModel()
        {
            GetAvailabilityDateItemViewModel = new List<GetAvailableDateItemViewModel>();
        }
        public List<GetAvailableDateItemViewModel> GetAvailabilityDateItemViewModel { get; set; }

        public int SlotDurationMinutes { get; set; }
    }
}
