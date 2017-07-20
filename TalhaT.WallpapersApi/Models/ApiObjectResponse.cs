using Newtonsoft.Json.Linq;

namespace TalhaT.WallpapersApi.Models
{
    public class ApiObjectResponse<T> : ApiResponse
    {

        /// <summary>
        /// Returns the data if success. If not, will throw <see cref="WallpaperApiException"/>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="WallpaperApiException"></exception>
        public T GetData()
        {
            if (Data == null || Data is bool) throw new WallpaperApiException(Message);
            var @object = (JObject) Data;
            return @object.ToObject<T>();

        }
        

    }
}