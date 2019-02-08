using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DReservation.Models.Domain;
using DReservation.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;

namespace DReservation.Tests.IntegrationTests
{
    [TestFixture]
    public class ReservationIntegrationTests_Get
    {
        private readonly HttpClient _client;

        public ReservationIntegrationTests_Get()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            _client = server.CreateClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Test]
        public async Task Get_Should_Return_BadRequest_When_Date_Is_Empty()
        {
            // Arrange
            var response = await _client.GetAsync("/api/availability/week");

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestCase("XYZ")]
        [TestCase("1234")]
        [TestCase("1236-18-32")]
        [TestCase("1")]
        public async Task Get_Should_Return_Bad_Request_When_Date_Is_Invalid(string invalidDateTime)
        {
            // Act
            var response = await _client.GetAsync($"/api/availability/week/{invalidDateTime}");

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestCase("20190206")]
        [TestCase("20190205")]
        public async Task Get_Should_Return_Bad_Request_When_Date_Is_Not_Monday(string startDate)
        {
            // Act
            var response = await _client.GetAsync($"/api/availability/week/{startDate}");

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [TestCase("20190107")]
        [TestCase("20190114")]
        [TestCase("20190121")]
        [TestCase("20190128")]
        [TestCase("20190211")]
        [TestCase("20190204")]
        public async Task Get_Should_Return_Ok_When_Date_Is_Valid(string startDate)
        {
            // Act
            var response = await _client.GetAsync($"/api/availability/week/{startDate}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Schedule>(json);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Schedule>(result);
        }
    }
}
