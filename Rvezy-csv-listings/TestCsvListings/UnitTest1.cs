using NSubstitute;
using Rvezy_csv_listings.Data.Repositories.Interfaces;
using Rvezy_csv_listings.Services;
using Xunit;

namespace TestCsvListings
{
    public class UnitTest1
    {
        private ListingService ListingService;
        private IListingRepository _listingRepository;

        [Fact]
        public void Test1()
        {
            _listingRepository = Substitute.For<IListingRepository>();
            ListingService = new ListingService(_listingRepository);
        }
    }
}