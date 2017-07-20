using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TalhaT.WallpapersApi.Models
{
    public class ApiArrayResponse<T> : ApiResponse
    {

        /// <summary>
        /// Returns the data if success. If not, will throw <see cref="WallpaperApiException"/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="WallpaperApiException"></exception>
        public List<T> GetData()
        {
            if (Data == null || Data is bool) throw new WallpaperApiException(Message);
            var array = (JArray) Data;
            return array.ToObject<List<T>>();

        }
        

    }
}