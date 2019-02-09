using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using DReservation.Common;
using DReservation.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using DReservation.UI.Models;
using DReservation.Services;

namespace DReservation.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IReservationService _reservationService;

        public HomeController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("~/")]
        public IActionResult Index()
        {
            var model = new StartingDateViewModel
            {
                StartingDate = DateTime.Now.ToString("dd-MM-yyyy")
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> DoReservation(DoReservationViewModel model)
        {
            var reservationViewModel = new ReservationViewModel
            {
                Start = model.SelectedDay + model.StartDate, End = model.SelectedDay + model.EndDate
            };

            return View(reservationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GetAvailableTimes([FromForm]string startingDate)
        {
            var viewModel = new GetAvailabilityViewModel();

            var dateTime = DateTime.ParseExact(startingDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            viewModel.SlotDurationMinutes = await _reservationService.GetSlotDurationMinutes(dateTime);

            foreach (var (date, times) in await _reservationService.GetWeekAvailability(dateTime))
            {
                var item = new GetAvailableDateItemViewModel
                {
                    Date = date,
                    DayOfWeek = date.DayOfWeek.ToString(),
                    Times = times
                };

                viewModel.GetAvailabilityDateItemViewModel.Add(item);
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DoReservation([FromForm] Reservation reservation)
        {
            try
            {
                await _reservationService.PostAsync(reservation);

                return View("Successful", reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
