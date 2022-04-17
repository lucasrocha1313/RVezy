namespace Rvezy_csv_listings.Exceptions
{
    public class SaveCsvException : Exception
    {
        public SaveCsvException(string message) : base("Error trying to save csv: " + message)
        {

        }
    }
}
