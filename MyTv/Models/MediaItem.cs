
namespace MyTv.Models
{
    public class MediaItem
    {
        public int MediaItemId { get; set; }

        public int TmdbId { get; set; }

        public string Title { get; set; }

        public string Overview { get; set; }

        public string PosterPath { get; set; }

        public string MediaType { get; set; }

        public string ReleaseDate { get; set; }

        public string Genre { get; set; }
    }
}
