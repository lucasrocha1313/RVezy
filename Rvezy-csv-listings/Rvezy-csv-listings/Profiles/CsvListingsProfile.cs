using AutoMapper;
using Rvezy_csv_listings.Controllers.Dtos;
using Rvezy_csv_listings.Models;

namespace Rvezy_csv_listings.Profiles
{
    public class CsvListingsProfile : Profile
    {
        public CsvListingsProfile()
        {
            CreateMap<ListingToAddDto, Listing>();
        }
    }
}
