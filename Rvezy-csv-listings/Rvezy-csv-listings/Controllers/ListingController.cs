using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rvezy_csv_listings.Controllers.Dtos;
using Rvezy_csv_listings.Data.Repositories.Interfaces;
using Rvezy_csv_listings.Models;

namespace Rvezy_csv_listings.Controllers
{
    [ApiController]
    [Route("listing/[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly IListingRepository _listingRepository;
        private readonly IMapper _mapper;

        public ListingController(IListingRepository listingRepository, IMapper mapper)
        {
            _listingRepository = listingRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ListingToAddDto listingToAdd)
        {
            var listing = _mapper.Map<Listing>(listingToAdd);
            await _listingRepository.Add(listing);
            return Ok();
        }
    }
}
