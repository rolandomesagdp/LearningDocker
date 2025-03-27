using Countries.Api.Context;
using Countries.Api.Countries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Countries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryContext countryContext;

        public CountryController(CountryContext countryContext)
        {
            this.countryContext = countryContext;
        }

        [HttpGet(Name = "GetCountries")]
        public IEnumerable<Country> Get()
        {
            var countries = countryContext.Countries.ToArray();
            return countries;
        }

        [HttpGet("code/{countryCode}")]
        public async Task<IActionResult> GetCountryByCode(string countryCode = "SP")
        {
            var country = await countryContext.Countries.Where(x => x.CountryCode == countryCode).FirstOrDefaultAsync();
            return Ok(country);
        }
    }
}
