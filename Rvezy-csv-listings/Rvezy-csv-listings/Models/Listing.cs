using System.ComponentModel.DataAnnotations.Schema;

namespace Rvezy_csv_listings.Models
{

    [Table("listings")]
    public class Listing
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("listing_url")]
        public string ListingUrl { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string description { get; set; }
        [Column("property_type")]
        public string PropertyType { get; set; }

        public ICollection<Calendar> Calendars { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
