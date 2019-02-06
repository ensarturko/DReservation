using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.Models.Domain
{
    public class Patient
    {
        public string Name { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
