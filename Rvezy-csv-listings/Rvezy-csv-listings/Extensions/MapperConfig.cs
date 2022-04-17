using AutoMapper;
using Rvezy_csv_listings.Profiles;

namespace Rvezy_csv_listings.Extensions
{
    public static class MapperConfig
    {
        public static IServiceCollection AddAutoMapperCopnfiguration(this IServiceCollection services)
        {
            var config = new MapperConfiguration(o =>
            {
                o.AddProfile(new CsvListingsProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
