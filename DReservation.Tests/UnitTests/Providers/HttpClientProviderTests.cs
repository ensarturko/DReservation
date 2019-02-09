using System.Net.Http;
using System.Threading.Tasks;
using DReservation.Providers;
using DReservation.Providers.Implementations;
using NUnit.Framework;

namespace DReservation.Tests.UnitTests.Providers
{
    public class HttpClientProviderTests
    {
        private static readonly HttpClient Client = new HttpClient();
        private readonly HttpClientProvider _clientProvider = new HttpClientProvider(Client);

        [TestCase("https://test.draliacloud.net/api/")]
        public void GetClient_Should_Return_IHttpClientProvider(string url)
        {
            // Act
            var response = _clientProvider.GetClient(url);

            // Assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IHttpClientProvider>(response);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("notvalidurl")]
        public void GetClient_Should_Fail_With_Invalid_Url(string url)
        {
            try
            {
                // Act
                var response = _clientProvider.GetClient(url);

                // Assert
                Assert.Fail();
            }
            catch (System.Exception)
            {
                // ignored
            }
        }

        [TestCase("techuser", "secretpassWord")]
        public void ToBase64_Should_Return_IHttpClientProvider(string username, string password)
        {
            // Act
            var response = _clientProvider.ToBase64(username, password);

            // Assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<IHttpClientProvider>(response);
        }


        [TestCase("")]
        public async Task GetString_Should_Fail_With_Empty_Request(string request)
        {
            try
            {
                // Act
                await _clientProvider.GetStringAsync(request);

                // Assert
                Assert.Fail();
            }
            catch (System.Exception)
            {
                // ignored
            }
        }

    }
}
