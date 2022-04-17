using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rvezy_csv_listings.Controllers.Dtos;
using Rvezy_csv_listings.Data.Repositories.Interfaces;
using Rvezy_csv_listings.Models;
using Rvezy_csv_listings.Services.Interfaces;

namespace Rvezy_csv_listings.Controllers
{
    [ApiController]
    [Route("listing/[controller]")]
    public class ListingController : ControllerBase
    {
        private readonly IListingRepository _listingRepository;
        private readonly IMapper _mapper;
        private readonly IListingService _listingService;

        public ListingController(IListingRepository listingRepository, IMapper mapper, IListingService listingService)
        {
            _listingRepository = listingRepository;
            _mapper = mapper;
            _listingService = listingService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ListingToAddDto listingToAdd)
        {
            var listing = _mapper.Map<Listing>(listingToAdd);
            await _listingRepository.Add(listing);
            return Ok();
        }

        [HttpPost("csv")]
        public async Task<IActionResult> UploadCsv(IFormFile postedFile)
        {
            if(postedFile != null)
            {
                var filePath = _listingService.SaveCsvFaleToDirectory(postedFile);
                await _listingService.AddListingsFromCsv(filePath);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> FindListingById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var listing = _listingRepository.FindById(id.Value);
            if(listing == null)
            {
                return NotFound();
            }

            return Ok(listing);
        }
    }
}
