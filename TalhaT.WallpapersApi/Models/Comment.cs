using System;
using Newtonsoft.Json;

namespace TalhaT.WallpapersApi.Models
{
    public class Comment
    {

        /// <summary>
        /// ID of the comment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date on which comment was posted. Format: 0000-00-00 00:00:00
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// ID of the wallpaper attached to this comment
        /// </summary>
        [JsonProperty("wallpaper_ID")]
        public int WallpaperId { get; set; }

        /// <summary>
        /// Author of the comment
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Content of the comment
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// ID of its parent
        /// </summary>
        [JsonProperty("parent_ID")]
        public int ParentId { get; set; }

    }
}