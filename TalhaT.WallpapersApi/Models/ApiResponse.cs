using Newtonsoft.Json;

namespace TalhaT.WallpapersApi.Models
{
    public abstract class ApiResponse
    {

        /// <summary>
        /// Returns if response result is success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Returns response data. This is stored as object because it can be false, use GetData method instead./>
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Error message if an error occurred. Do error handling with try catch and GetData method instead.
        /// </summary>
        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}