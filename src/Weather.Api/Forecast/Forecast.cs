using Weather.Api.Countries;

namespace Weather.Api.Forecast
{
    public class Forecast
    {
        public required Country Country { get; set; }

        public DateTime ForecastTime { get; set; }

        public string ForecastMessage { get; set; }

        public string ForecastSuggestion { get; set; }
    }
}
