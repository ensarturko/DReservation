using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Schedule> GetAsync(string startingDate)
        {
            var reservationResponse = await _httpClientProvider
                .GetClient(_settings.BaseUrl)
                .ToBase64(_settings.Username, _settings.Password)
                .GetStringAsync(string.Concat(_settings.GetRequestPath, startingDate));

            if (string.IsNullOrEmpty(reservationResponse))
                return new Schedule();

            return JsonConvert.DeserializeObject<Schedule>(reservationResponse, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });
        }

        public async Task PostAsync(Reservation reservationData)
        {
            await _httpClientProvider
                .GetClient(_settings.BaseUrl)
                .ToBase64(_settings.Username, _settings.Password)
                .PostAsync(_settings.PostRequestPath, reservationData);
        }
    }
}
