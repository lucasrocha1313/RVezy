using Microsoft.EntityFrameworkCore;
using Rvezy_csv_listings.Models;

namespace Rvezy_csv_listings.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Listing> Listing { get; set; }
        public DbSet<Review> Review{ get; set; }
        public DbSet<Calendar> Calendar { get; set; }
    }
}
