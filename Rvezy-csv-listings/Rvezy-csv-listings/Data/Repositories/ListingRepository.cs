﻿using Rvezy_csv_listings.Data.Repositories.Interfaces;
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
    }
}