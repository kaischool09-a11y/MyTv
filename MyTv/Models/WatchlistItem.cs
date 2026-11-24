
namespace MyTv.Models
{
    public class WatchlistItem
    {
        public int WatchlistItemId { get; set; }

        public int UserId { get; set; }

        public int MediaItemId { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
