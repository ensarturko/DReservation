using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DReservation.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace DReservation.Tests.Integration
{
    [TestFixture]
    public class ReservationIntegrationTestsPost
    {
        private readonly HttpClient _client;

        private const string ValidSlot = "{ 'Start':'2017-06-13 11:00:00', 'End':'2017-06-13 12:00:00', 'Patient' : { 'Name' : 'Mario', 'SecondName' : 'Neta', 'Email' : 'mario@myspace.es', 'Phone' : '555 44 33 22' }, 'Comments':'my arm hurts a lot' } ";

        private const string InvalidSlot = "{ 'Start':'', 'End':'2017-06-13 12:00:00', 'Patient' : { 'Name' : '', 'SecondName' : 'Neta', 'Email' : 'mario@myspace.es' }, 'Comments':'my arm hurts a lot' } ";

        public ReservationIntegrationTestsPost()
        {
            // Arrange
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            _client = server.CreateClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Test]
        public async Task Post_Should_Return_Bad_Request_When_Parameter_Is_Null()
        {
            // Act
            var response = await _client.PostAsync("/api/availability/takeslot", GetHttpContentFromJSON(string.Empty));

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Post_Should_Return_Bad_Request_When_Parameter_Has_Missing_Parts()
        {
            // Act
            var response = await _client.PostAsync("/api/availability/takeslot", GetHttpContentFromJSON(InvalidSlot));

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task Post_Should_Return_Ok_When_Parameter_Is_Valid()
        {
            // Act
            var response = await _client.PostAsync("/api/availability/takeslot", GetHttpContentFromJSON(ValidSlot));
            response.EnsureSuccessStatusCode();

            // Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
        }

        private ByteArrayContent GetHttpContentFromJSON(string data)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
    }
}
