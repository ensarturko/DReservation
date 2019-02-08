using System;
using System.Collections.Generic;
using System.Text;

namespace DReservation.Common
{
    public static class DateHelper
    {
        public static string GetProperDate(string startingDate)
        {
            string[] splittedDate = startingDate.Split('-');

            string requestDate = String.Empty;

            for (int i = 2; i >= 0; i--)
            {
                requestDate += splittedDate[i];
            }

            return requestDate;
        }
    }
}
