using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DReservation.Providers.Implementations
{
    public class HttpClientProvider : IHttpClientProvider
    {
        private HttpClient _client;

        public HttpClientProvider(HttpClient client)
        {
            _client = client;
        }

        public IHttpClientProvider GetClient(string url)
        {
            var handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true
            };

            _client = new HttpClient(handler) { BaseAddress = new Uri(url) };

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return this;
        }

        public IHttpClientProvider ToBase64(string username, string password)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            return this;
        }

        public async Task<string> GetStringAsync(string request)
        {
            using (_client)
            {
                return await _client.GetStringAsync(request);
            }
        }

        public async Task PostAsync<T>(string url, T objectToSend) where T : class
        {
            using (_client)
            {
                var json = JsonConvert.SerializeObject(objectToSend);
                var buffer = Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                await _client.PostAsync(url, byteContent);
            }
        }
    }
}
