using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TalhaT.WallpapersApi.Http
{
    /// <summary>
    /// A requester without a rate limiter.
    /// </summary>
    public class Requester : RequesterBase
    {
        public Requester(string apiKey) : base(apiKey)
        {
        }

        #region Public Methods        
        public string CreateGetRequest(string relativeUrl, List<string> addedArguments = null,
            bool useHttps = true)
        {
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            var response = Get(request);
            return GetResponseContent(response);
        }

        public async Task<string> CreateGetRequestAsync(string relativeUrl,
            List<string> addedArguments = null, bool useHttps = true)
        {
            var request = PrepareRequest(relativeUrl, addedArguments, useHttps, HttpMethod.Get);
            var response = await GetAsync(request);
            return await GetResponseContentAsync(response);
        }

        #endregion
    }
}