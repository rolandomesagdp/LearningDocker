﻿namespace Weather.Api.Countries
{
    public class Country
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string CountryCode { get; set; }
    }
}
