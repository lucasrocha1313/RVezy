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

        [HttpPost("csv")]
        public IActionResult UploadCsv(IFormFile postedFile)
        {
            if(postedFile != null)
            {
                List<Listing> listings = new List<Listing>();

                string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                string csvData = System.IO.File.ReadAllText(filePath);
                var firstRow = true;
                foreach(var row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row) && !firstRow)
                    {
                        listings.Add(new Listing
                        {
                            Id = Convert.ToInt32(row.Split(',')[0]),
                            ListingUrl = row.Split(',')[1],
                            Name = row.Split(',')[2],
                            Description = row.Split(',')[3],
                            PropertyType = row.Split(',')[4]
                        });
                    }

                    firstRow = false;
                }

                return Ok();
            }
            return BadRequest();
        }
    }
}
