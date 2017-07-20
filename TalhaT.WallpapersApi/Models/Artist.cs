namespace TalhaT.WallpapersApi.Models
{
    public class Artist
    {

        /// <summary>
        /// Id of the artist
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the artist
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Slug of the artist
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Number of wallpapers attached to this artist
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Link to the artist
        /// </summary>
        public string Link { get; set; }
    }
}