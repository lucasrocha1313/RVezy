using Rvezy_csv_listings.Data.Repositories.Interfaces;
using Rvezy_csv_listings.Filters;
using Rvezy_csv_listings.Models;

namespace Rvezy_csv_listings.Data.Repositories
{
    public class ListingRepository : BaseRepository, IListingRepository
    {
        public ListingRepository(DataContext context) : base(context)
        {
        }

        public async Task Add(Listing listing)
        {
            await _context.AddAsync(listing);
            await _context.SaveChangesAsync();
        }

        public async Task AddAll(ICollection<Listing> listings)
        {
            await _context.AddRangeAsync(listings);
            await _context.SaveChangesAsync();
        }

        public Listing FindById(int id) => _context.Listing.Where(a => a.Id == id).FirstOrDefault();

        public ICollection<Listing> GetAllPaginated(PaginationFilter validFilter)
        {
            return _context.Listing.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize).ToList();
        }
    }
}
