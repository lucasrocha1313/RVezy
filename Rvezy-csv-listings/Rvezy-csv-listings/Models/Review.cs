using System.ComponentModel.DataAnnotations.Schema;

namespace Rvezy_csv_listings.Models
{
    [Table("reviews")]
    public class Review
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("date_review")]
        public DateTime Date { get; set; }
        [Column("reviewer_id")]
        public long ReviewerId { get; set; }
        [Column("reviewer_name")]
        public string ReviewerName { get; set; }
        [Column("comments")]
        public string Comments { get; set; }
        [Column("listing_id")]
        public int ListingId { get; set; }

        public Listing Listing { get; set; }
    }
}
