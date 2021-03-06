using Rvezy_csv_listings.Filters;
using Rvezy_csv_listings.Models;

namespace Rvezy_csv_listings.Data.Repositories.Interfaces
{
    public interface IListingRepository
    {
        Task Add(Listing listing);
        Task AddAll(ICollection<Listing> listings);
        Listing FindById(int id);
        ICollection<Listing> GetAllPaginated(PaginationFilter paginationFilter);
    }
}
