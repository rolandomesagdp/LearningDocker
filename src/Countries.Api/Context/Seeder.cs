using Countries.Api.Countries;

namespace Countries.Api.Context
{
    public static class Seeder
    {
        public static void Seed(this CountryContext countryContext)
        {
            if (!countryContext.Countries.Any())
            {
                //--- The next two lines add 100 rows to your database
                AddCountries(countryContext);
                countryContext.SaveChanges();
            }
        }

        private static void AddCountries(this CountryContext countryContext)
        {
            List<Country> countries = new List<Country>();
            countries.Add(new Country() { CountryCode = "SP", Name = "Spain" });
            countries.Add(new Country() { CountryCode = "PT", Name = "Portugal" });
            countries.Add(new Country() { CountryCode = "US", Name = "United States" });
            countries.Add(new Country() { CountryCode = "FR", Name = "France" });

            countryContext.AddRange(countries);
        }
    }
}
