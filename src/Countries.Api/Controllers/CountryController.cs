using Countries.Api.Context;
using Countries.Api.Countries;
using Microsoft.AspNetCore.Mvc;

namespace Countries.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {

        private readonly ILogger<CountryController> _logger;
        private readonly CountryContext countryContext;

        public CountryController(ILogger<CountryController> logger, CountryContext countryContext)
        {
            _logger = logger;
            this.countryContext = countryContext;
        }

        [HttpGet(Name = "GetCountries")]
        public IEnumerable<Country> Get()
        {
            var countries = countryContext.Countries.ToArray();
            return countries;
        }
    }
}
