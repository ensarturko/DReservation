using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DReservation.Models.Domain;
using DReservation.Services;
using Microsoft.AspNetCore.Mvc;

namespace DReservation.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{startingDate}")]
        public async Task<IActionResult> Get(string startingDate)
        {
            try
            {
                var result = await _reservationService.GetAsync(startingDate);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservation reservation)
        {
            await _reservationService.PostAsync(reservation);

            return Created("/", reservation);
        }
    }
}
