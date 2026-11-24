
namespace MyTv.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

        public int UserId { get; set; }

        public int MediaItemId { get; set; }

        public int Score { get; set; }

        public string Review { get; set; }

        public DateTime DateRated { get; set; }
    }
}
