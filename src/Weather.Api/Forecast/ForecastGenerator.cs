using Weather.Api.Countries;

namespace Weather.Api.Forecast
{
    public class ForecastGenerator
    {
        public Country Country { get; set; }

        public ForecastGenerator(Country country)
        {
            Country = country;
        }

        public Forecast GenerateForecast()
        {
            return new Forecast()
            {
                Country = Country,
                ForecastTime = DateTime.Now,
                ForecastMessage = "Today is going to be could and rainy.",
                ForecastSuggestion = "Don't forget your jacket and your umbrella."
            };
        }
    }
}
