using System.ComponentModel.DataAnnotations.Schema;

namespace Rvezy_csv_listings.Models
{
    [Table("calendar")]
    public class Calendar
    {
        [Column("listing_id")]
        public int ListingId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("available")]
        public bool Available { get; set; }
        [Column("price")]
        public string Price { get; set; }

    }
}
