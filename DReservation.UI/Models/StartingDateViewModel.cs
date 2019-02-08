using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DReservation.UI.Models
{
    public class StartingDateViewModel
    {
        public string StartingDate { get; set; }

        public List<SelectListItem> StartingDates { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "11-02-2019", Text = "11-02-2019" },
            new SelectListItem { Value = "18-02-2019", Text = "18-02-2019" },
            new SelectListItem { Value = "25-02-2019", Text = "25-02-2019" },
            new SelectListItem { Value = "04-03-2019", Text = "04-03-2019" },
            new SelectListItem { Value = "11-03-2019", Text = "11-03-2019" },
            new SelectListItem { Value = "18-03-2019", Text = "18-03-2019" }
        };
    }
}
