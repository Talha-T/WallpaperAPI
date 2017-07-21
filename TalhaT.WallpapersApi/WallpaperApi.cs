using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TalhaT.WallpapersApi.Http;
using TalhaT.WallpapersApi.Models;

namespace TalhaT.WallpapersApi
{

    /// <summary>
    /// Main class of the wrapper.
    /// </summary>
    public static class WallpaperApi
    {

        #region Private Fields

        private const string WallpapersUrl = "/wallpapers";
        private const string WallpaperDetailUrl = "/{0}";

        private const string CategoriesUrl = "/categories";
        private const string CategoryDetailUrl = "/{0}";

        private const string ArtistsUrl = "/artists";
        private const string ArtistDetailUrl = "/{0}";

        private const string CommentsUrl = "/comments";
        private const string CommentDetailUrl = "/{0}";

        private static bool _secure = true;

        private static Requester _requester;

        #endregion

        /// <summary>
        /// Set the API key to given key. Wrapper will throw NullReferenceException if key is not set.
        /// </summary>
        /// <param name="apiKey">API key to set.</param>
        public static void SetKey(string apiKey)
        {
            _requester = new Requester(apiKey);
        }

        /// <summary>
        /// Set to use http or https. Https by default.
        /// </summary>
        /// <param name="secure"></param>
        public static void SetSecure(bool secure)
        {
            _secure = secure;
        }

        /// <summary>
        /// Returns a list of <see cref="Wallpaper"/>
        /// </summary>
        /// <param name="queryArguments">List of query arguments, you can write queries as seperate strings.</param>
        /// <returns></returns>
        #region Async Methods
        public static async Task<ApiArrayResponse<Wallpaper>> GetWallpapersAsync(params string[] queryArguments)
        {
            var json = await _requester.CreateGetRequestAsync(WallpapersUrl, queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ApiArrayResponse<Wallpaper>>(json));
            return obj;
        }

        /// <summary>
        /// Returns an instance of <see cref="Wallpaper"/> instance for given id. Will throw <see cref="WallpaperApiException"/> if not found.
        /// </summary>
        /// <param name="id">Id of the wallpaper</param>
        /// <param name="queryArguments">List of query arguments</param>
        /// <returns></returns>
        /// <exception cref="WallpaperApiException"></exception>
        public static async Task<ApiObjectResponse<Wallpaper>> GetWallpaperDetailAsync(int id, params string[] queryArguments)
        {           
            var json =
                await _requester.CreateGetRequestAsync($"{WallpapersUrl}{string.Format(WallpaperDetailUrl, id)}",
                    queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(
                () => JsonConvert.DeserializeObject<ApiObjectResponse<Wallpaper>>(json));
            return obj;
        }

        /// <summary>
        /// Returns a list of <see cref="Category"/>
        /// </summary>
        /// <param name="queryArguments">List of query arguments</param>
        /// <returns></returns>
        public static async Task<ApiArrayResponse<Category>> GetCategoriesAsync(params string[] queryArguments)
        {
            var json = await _requester.CreateGetRequestAsync(CategoriesUrl, queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ApiArrayResponse<Category>>(json));
            return obj;
        }


        /// <summary>
        /// Returns an instance of <see cref="Category"/> instance for given id. Will throw <see cref="WallpaperApiException"/> if not found.
        /// </summary>
        /// <param name="id">Id of the category</param>
        /// <param name="queryArguments">List of query arguments</param>
        /// <returns></returns>
        /// <exception cref="WallpaperApiException"></exception>
        public static async Task<ApiArrayResponse<Category>> GetCategoryDetailAsync(int id, params string[] queryArguments)
        {
            var json = await _requester.CreateGetRequestAsync($"{CategoriesUrl}{string.Format(CategoryDetailUrl, id)}", queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ApiArrayResponse<Category>>(json));
            return obj;
        }

        /// <summary>
        /// Returns a list of <see cref="Artist"/>
        /// </summary>
        /// <param name="queryArguments">List of query arguments</param>
        /// <returns></returns>
        public static async Task<ApiArrayResponse<Artist>> GetArtistsAsync(params string[] queryArguments)
        {
            var json = await _requester.CreateGetRequestAsync(ArtistsUrl, queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ApiArrayResponse<Artist>>(json));
            return obj;
        }

        /// <summary>
        /// Returns an instance of <see cref="Artist"/> instance for given id. Will throw <see cref="WallpaperApiException"/> if not found.
        /// </summary>
        /// <param name="id">Id of the artist</param>
        /// <param name="queryArguments">List of query arguments</param>
        /// <returns></returns>
        /// <exception cref="WallpaperApiException"></exception>
        public static async Task<ApiArrayResponse<Artist>> GetArtistDetailAsync(int id, params string[] queryArguments)
        {
            var json = await _requester.CreateGetRequestAsync($"{ArtistsUrl}{string.Format(ArtistDetailUrl, id)}", queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ApiArrayResponse<Artist>>(json));
            return obj;
        }

        /// <summary>
        /// Returns all comments as <see cref="Category"/> type
        /// </summary>
        /// <param name="queryArguments">List of query arguments</param>
        /// <returns></returns>
        public static async Task<ApiArrayResponse<Comment>> GetCommentsAsync(params string[] queryArguments)
        {
            var json = await _requester.CreateGetRequestAsync(CommentsUrl, queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ApiArrayResponse<Comment>>(json));
            return obj;
        }

        /// <summary>
        /// Returns an instance of <see cref="Comment"/> instance for given id. Will throw <see cref="WallpaperApiException"/> if not found.
        /// </summary>
        /// <param name="id">Id of the comment</param>
        /// <param name="queryArguments">List of query arguments</param>
        /// <returns></returns>
        /// <exception cref="WallpaperApiException"></exception>
        public static async Task<ApiArrayResponse<Comment>> GetCommentDetailAsync(int id, params string[] queryArguments)
        {
            var json = await _requester.CreateGetRequestAsync($"{CommentsUrl}{string.Format(CommentDetailUrl, id)}", queryArguments.ToList(), _secure);
            var obj = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ApiArrayResponse<Comment>>(json));
            return obj;
        }

        #endregion

        #region Sync methods

        public static ApiArrayResponse<Wallpaper> GetWallpapers(params string[] queryArguments)
        {
            var json =  _requester.CreateGetRequest(WallpapersUrl, queryArguments.ToList(), _secure);
            var obj =  JsonConvert.DeserializeObject<ApiArrayResponse<Wallpaper>>(json);
            return obj;
        }

        public static ApiObjectResponse<Wallpaper> GetWallpaperDetail(int id, params string[] queryArguments)
        {
            var json =  _requester.CreateGetRequest($"{WallpapersUrl}{string.Format(WallpaperDetailUrl, id)}", queryArguments.ToList(), _secure);
            var obj =  JsonConvert.DeserializeObject<ApiObjectResponse<Wallpaper>>(json);
            return obj;
        }

        public static ApiArrayResponse<Category> GetCategories(params string[] queryArguments)
        {
            var json =  _requester.CreateGetRequest(CategoriesUrl, queryArguments.ToList(), _secure);
            var obj =  JsonConvert.DeserializeObject<ApiArrayResponse<Category>>(json);
            return obj;
        }

        public static ApiArrayResponse<Category> GetCategoryDetail(int id, params string[] queryArguments)
        {
            var json =  _requester.CreateGetRequest($"{CategoriesUrl}{string.Format(CategoryDetailUrl, id)}", queryArguments.ToList(), _secure);
            var obj =  JsonConvert.DeserializeObject<ApiArrayResponse<Category>>(json);
            return obj;
        }

        public static ApiArrayResponse<Artist> GetArtists(params string[] queryArguments)
        {
            var json =  _requester.CreateGetRequest(ArtistsUrl, queryArguments.ToList(), _secure);
            var obj =  JsonConvert.DeserializeObject<ApiArrayResponse<Artist>>(json);
            return obj;
        }

        public static ApiArrayResponse<Artist> GetArtistDetail(int id, params string[] queryArguments)
        {
            var json =  _requester.CreateGetRequest($"{ArtistsUrl}{string.Format(ArtistDetailUrl, id)}", queryArguments.ToList(), _secure);
            var obj =  JsonConvert.DeserializeObject<ApiArrayResponse<Artist>>(json);
            return obj;
        }

        public static ApiArrayResponse<Comment> GetComments(params string[] queryArguments)
        {
            var json = _requester.CreateGetRequest(CommentsUrl, queryArguments.ToList(), _secure);
            var obj = JsonConvert.DeserializeObject<ApiArrayResponse<Comment>>(json);
            return obj;
        }

        public static ApiArrayResponse<Comment> GetCommentDetail(int id, params string[] queryArguments)
        {
            var json = _requester.CreateGetRequest($"{CommentsUrl}{string.Format(CommentDetailUrl, id)}", queryArguments.ToList(), _secure);
            var obj = JsonConvert.DeserializeObject<ApiArrayResponse<Comment>>(json);
            return obj;
        }

        #endregion

    }
}