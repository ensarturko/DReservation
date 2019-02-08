using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.UI.Models
{
    public class GetAvailableDateItemViewModel
    {
        public GetAvailableDateItemViewModel()
        {
            Times = new Dictionary<TimeSpan, bool>();
        }
        public DateTime Date { get; set; }
        public IDictionary<TimeSpan, bool> Times { get; set; }
        public string DayOfWeek { get; set; }
    }
}
