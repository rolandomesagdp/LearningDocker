using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Weather.Api.Countries;
using Weather.Api.Forecast;

namespace Weather.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public WeatherForecastController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet("country/{countryCode}")]
        public async Task<IActionResult> GetByCountry(string countryCode = "SP")
        {
            try
            {
                var countryApiBaseUrl = configuration["Endpoints:CountryApiDomainName"];
                HttpResponseMessage result;

                // demo code, ignore the direct creation of the HttpClient here!
                using (var client = new HttpClient())
                {
                    var url = string.Concat(countryApiBaseUrl, $"/country/code/{countryCode}");

                    var request = new HttpRequestMessage(HttpMethod.Get, url);

                    result = await client.SendAsync(request);
                }

                if (result.IsSuccessStatusCode)
                {
                    var payload = await result.Content.ReadAsStringAsync();

                    var country = JsonConvert.DeserializeObject<Country>(payload);

                    var forecast = new ForecastGenerator(country).GenerateForecast();

                    return Ok(forecast);
                }
                else
                {
                    throw new Exception($"The call to the country api returned a status code of {result.StatusCode.ToString()}");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
