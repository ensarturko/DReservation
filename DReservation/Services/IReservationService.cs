﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DReservation.Models.Domain;

namespace DReservation.Services
{
    public interface IReservationService
    {
        Task<Schedule> GetAsync(string startingDate);
        Task PostAsync(Reservation reservationData);
    }
}