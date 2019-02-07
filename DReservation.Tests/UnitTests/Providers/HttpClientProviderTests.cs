using System.Net.Http;
using System.Threading.Tasks;
using DReservation.Providers;
using DReservation.Providers.Implementations;
using NUnit.Framework;

namespace DReservation.Tests.UnitTests.Providers
{
    public class HttpClientProviderTests
    {
        private HttpClientProvider _provider;
        private readonly HttpClient _client;

        public HttpClientProviderTests(HttpClient client)
        {
            _client = client;
        }

        [SetUp]
        public void SetUp()
        {
            _provider = new HttpClientProvider(_client);
        }

        [TestCase("https://test.draliacloud.net/api/")]
        public void GetClient_Should_Return_IHttpClientProvider(string url)
        {
            // Act
            var response = _provider.GetClient(url);

            // Assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IHttpClientProvider>(response);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("notvalidurl")]
        public void GetClient_Should_Fail_With_Invalid_Url(string url)
        {
            // Act
            var response = _provider.GetClient(url);

            // Assert
            Assert.Fail();
        }

        [TestCase("techuser", "secretpassWord")]
        public void ToBase64_Should_Return_IHttpClientProvider(string username, string password)
        {
            // Act
            var response = _provider.ToBase64(username, password);

            // Assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IHttpClientProvider>(response);
        }

        [TestCase("", "")]
        [TestCase(null, null)]
        [TestCase(null, "")]
        [TestCase("", null)]
        public void ToBase64_Should_Fail_With_Invalid_Parameters(string username, string password)
        {
            // Act
            var response = _provider.ToBase64(username, password);

            // Assert
            Assert.Fail();
        }

        [TestCase("")]
        public async Task GetString_Should_Fail_With_Empty_Request(string request)
        {
            // Act
            var response = await _provider.GetStringAsync(request);

            // Assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IHttpClientProvider>(response);
        }

    }
}
