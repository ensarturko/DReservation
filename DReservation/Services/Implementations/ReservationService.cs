using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DReservation.Models.Domain;
using DReservation.Providers;
using DReservation.Settings;
using Newtonsoft.Json;

namespace DReservation.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly ApiSettings _settings;
        private readonly IHttpClientProvider _httpClientProvider;

        public ReservationService(ApiSettings settings, IHttpClientProvider httpClientProvider)
        {
            _settings = settings;
            _httpClientProvider = httpClientProvider;
        }

        private async Task<Schedule> GetAsync(DateTime startingDate)
        {
            var reservationResponse = await _httpClientProvider
                .GetClient(_settings.BaseUrl)
                .ToBase64(_settings.Username, _settings.Password)
                .GetStringAsync(string.Concat(_settings.GetRequestPath, startingDate.ToString("yyyyMMdd")));

            if (string.IsNullOrEmpty(reservationResponse))
                return new Schedule();

            return JsonConvert.DeserializeObject<Schedule>(reservationResponse);
        }

        public async Task<IList<(DateTime date, IDictionary<TimeSpan, bool> times)>> GetWeekAvailability(DateTime startingDate)
        {
            var result = new List<(DateTime, IDictionary<TimeSpan, bool>)>();

            var schedule = await GetAsync(startingDate);
            
            var slotDurationMinutes = TimeSpan.FromMinutes(schedule.SlotDurationMinutes);

            for (var date = startingDate; date < startingDate.AddDays(5); date += TimeSpan.FromDays(1))
            {
                var slot = schedule.Days[date.DayOfWeek];

                if (slot != null)
                {
                    result.Add((date, new Dictionary<TimeSpan, bool>(
                        GetSlotAvailability(slot, slotDurationMinutes))));
                }
            }

            return result;
        }

        private static IEnumerable<KeyValuePair<TimeSpan, bool>> GetSlotAvailability(Slot slot, TimeSpan slotDurationMinutes)
        {
            if (slot == null)
            {
                throw new ArgumentNullException(nameof(slot));
            }

            for (var time = TimeSpan.FromHours(slot.WorkPeriod.StartHour);
                time < TimeSpan.FromHours(slot.WorkPeriod.EndHour); time += slotDurationMinutes)
            {
                var isAvailable = true;

                if (slot.BusySlots != null)
                {
                    foreach (var busySlot in slot.BusySlots)
                    {
                        if (time >= busySlot.Start.TimeOfDay && time <= busySlot.Start.TimeOfDay)
                        {
                            isAvailable = false;
                        }
                    }
                }

                if (time >= TimeSpan.FromHours(slot.WorkPeriod.LunchStartHour) &&
                    time < TimeSpan.FromHours(slot.WorkPeriod.LunchEndHour))
                {
                    isAvailable = false;
                }

                yield return new KeyValuePair<TimeSpan, bool>(time, isAvailable);
            }
        }

        public async Task PostAsync(Reservation reservationData)
        {
            await _httpClientProvider
                .GetClient(_settings.BaseUrl)
                .ToBase64(_settings.Username, _settings.Password)
                .PostAsync(_settings.PostRequestPath, reservationData);
        }

        public async Task<int> GetSlotDurationMinutes(DateTime startingDate)
        {
            var schedule = await GetAsync(startingDate);

            return schedule.SlotDurationMinutes;
        }
    }
}
