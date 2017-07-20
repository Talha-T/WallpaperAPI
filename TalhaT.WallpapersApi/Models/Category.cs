using Newtonsoft.Json;

namespace TalhaT.WallpapersApi.Models
{
    public class Category
    {
        /// <summary>
        /// ID of the category
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Slug of the category
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// ID of its parent
        /// </summary>
        [JsonProperty("parent_ID")]
        public int? ParentId { get; set; }

        /// <summary>
        /// Name of its parent
        /// </summary>
        [JsonProperty("parent_name")]
        public string ParentName { get; set; }

        /// <summary>
        /// Number of wallpapers attached to this category
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Link to the category
        /// </summary>
        public string Link { get; set; }

    }
}
