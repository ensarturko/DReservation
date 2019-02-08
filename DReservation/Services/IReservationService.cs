using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DReservation.Models.Domain;

namespace DReservation.Services
{
    public interface IReservationService
    {
        Task<IList<(DateTime date, IDictionary<TimeSpan, bool> times)>> GetWeekAvailability(DateTime startingDate);
        Task PostAsync(Reservation reservationData);
    }
}
