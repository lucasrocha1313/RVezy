namespace Rvezy_csv_listings.Services.Interfaces
{
    public interface IListingService
    {
        Task AddListingsFromCsv(string filePath);
        string SaveCsvFaleToDirectory(IFormFile postedFile);
    }
}
