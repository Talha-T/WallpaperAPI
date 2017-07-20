using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TalhaT.WallpapersApi.Http
{
    public abstract class RequesterBase
    {
        private const string ApiRootUrl = "api.lolwallpapers.net/alpha";

        private readonly HttpClient _httpClient;

        public string ApiKey { get; set; }

        protected RequesterBase(string apiKey)
        {
            if (String.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey));
            ApiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(apiKey);
        }

        #region Protected Methods

        /// <summary>
        /// Send a get request synchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected HttpResponseMessage Get(HttpRequestMessage request)
        {
            var response = _httpClient.GetAsync(request.RequestUri).Result;
            return response;
        }

        /// <summary>
        /// Send a get request asynchronously.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        protected async Task<HttpResponseMessage> GetAsync(HttpRequestMessage request)
        {
            var response = await _httpClient.GetAsync(request.RequestUri);
            return response;
        }
        

        protected HttpRequestMessage PrepareRequest(string relativeUrl, List<string> addedArguments,
            bool useHttps, HttpMethod httpMethod)
        {
            var scheme = useHttps ? "https" : "http";
            var url = addedArguments == null || !addedArguments.Any() ? $"{scheme}://{ApiRootUrl}{relativeUrl}"
                : $"{scheme}://{ApiRootUrl}{relativeUrl}?{BuildArgumentsString(addedArguments)}";
            return new HttpRequestMessage(httpMethod, url);
        }

        protected string BuildArgumentsString(List<string> arguments)
        {
            var str = arguments
                .Where(arg => arg != String.Empty)
                .Aggregate(String.Empty, (current, arg) => current + arg + "&");
            if (str.EndsWith("&"))
                str = str.Substring(0, str.Length - 1);
            return str;
        }

       

        protected string GetResponseContent(HttpResponseMessage response)
        {
            string result;

            using (var content = response.Content)
            {
                result = content.ReadAsStringAsync().Result;
            }
            return result;
        }

        protected async Task<string> GetResponseContentAsync(HttpResponseMessage response)
        {
            Task<string> result;
            using (response)
            {
                using (var content = response.Content)
                {
                    result = content.ReadAsStringAsync();
                }
            }
            return await result;
        }    

        #endregion
    }
}