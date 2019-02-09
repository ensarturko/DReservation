using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
