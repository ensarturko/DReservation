using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.Settings
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; }
        public string GetRequestPath { get; set; }
        public string PostRequestPath { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
