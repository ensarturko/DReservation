using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DReservation.Providers
{
    public interface IHttpClientProvider
    {
        IHttpClientProvider GetClient(string url);

        IHttpClientProvider ToBase64(string user, string password);

        Task<string> GetStringAsync(string request);

        Task PostAsync<T>(string url, T objectToSend) where T : class;
    }
}
