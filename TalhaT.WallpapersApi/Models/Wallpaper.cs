using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TalhaT.WallpapersApi.Models
{
    public class Wallpaper
    {
        /// <summary>
        /// ID of the wallpaper
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date on which wallpaper was published. Format: 0000-00-00 00:00:00
        /// </summary>
        [JsonProperty("date")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Last modified date
        /// </summary>
        [JsonProperty("modified")]
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Title of the wallpaper
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Image filename on the server
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Image width (in pixels)
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Image height (in pixels)
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Image MIME type
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        /// <summary>
        /// Image size (in bytes)
        /// </summary>
        public int FileSize { get; set; }

        /// <summary>
        /// Image size (in human readable format)
        /// </summary>
        [JsonProperty("pretty_filesize")]
        public string PrettyFileSize { get; set; }

        /// <summary>
        /// A list of links (page, image, download)
        /// </summary>
        public Links Links { get; set; }

        /// <summary>
        /// A list of available sizes
        /// </summary>
        public Sizes Sizes { get; set; }

        /// <summary>
        /// A list of categories attached to this wallpaper
        /// </summary>
        [JsonProperty("Category")]
        public List<IdName> Categories { get; set; }

        /// <summary>
        /// A list of artists attached to this wallpaper
        /// </summary>
        [JsonProperty("Artist")]
        public List<IdName> Artists { get; set; }

        /// <summary>
        /// ID of the uploader
        /// </summary>
        [JsonProperty("uploader_ID")]
        public int UploaderId { get; set; }

        /// <summary>
        /// Number of comments
        /// </summary>
        [JsonProperty("comment_count")]
        public int CommentCount { get; set; }

        /// <summary>
        /// Number of views
        /// </summary>
        [JsonProperty("view_count")]
        public int ViewCount { get; set; }

        /// <summary>
        /// Number of likes
        /// </summary>
        [JsonProperty("like_count")]
        public int LikeCount { get; set; }

        /// <summary>
        /// Number of downloads
        /// </summary>
        [JsonProperty("download_count")]
        public int DownloadCount { get; set; }

    }
}
