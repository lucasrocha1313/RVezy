using Rvezy_csv_listings.Data.Repositories.Interfaces;
using Rvezy_csv_listings.Exceptions;
using Rvezy_csv_listings.Models;
using Rvezy_csv_listings.Services.Interfaces;

namespace Rvezy_csv_listings.Services
{
    public class ListingService : IListingService
    {
        private readonly IListingRepository _listingRepository;

        public ListingService(IListingRepository listingRepository)
        {
            _listingRepository = listingRepository;
        }
        public async Task AddListingsFromCsv(string filePath)
        {
            List<Listing> listings = new List<Listing>();

            string csvData = File.ReadAllText(filePath);
            var firstRow = true;
            foreach (var row in csvData.Split('\n'))
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

            await _listingRepository.AddAll(listings);
        }

        public string SaveCsvFaleToDirectory(IFormFile postedFile)
        {
            try
            {
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

                return filePath;
            } catch (Exception ex)
            {
                throw new SaveCsvException(ex.Message);
            }
            
        }
    }
}
