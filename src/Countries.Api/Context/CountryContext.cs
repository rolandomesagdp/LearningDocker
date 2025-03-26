using Microsoft.EntityFrameworkCore;
using Countries.Api.Countries;

namespace Countries.Api.Context
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
    }
}
