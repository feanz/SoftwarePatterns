namespace SoftwarePatterns.Core.Facade
{
	public class TemperatureLookupFacade
	{
		private readonly WeatherService weatherService;
		private readonly GeoLookupService geoLookupService;
		private readonly ImperialMetricConverter converter;

		public TemperatureLookupFacade():this(new WeatherService(), new GeoLookupService(), new ImperialMetricConverter())
		{
		}

		public TemperatureLookupFacade(WeatherService weatherService,GeoLookupService geoLookupService, ImperialMetricConverter converter)
		{
			this.weatherService = weatherService;
			this.geoLookupService = geoLookupService;
			this.converter = converter;
		}

		public LocalTemperature GetTemperature(string postCode)
		{
			var coords = geoLookupService.GetCoordinatesForPostCode(postCode);
			var city = geoLookupService.GetCityForPostCode(postCode);
			var province = geoLookupService.GetProvinceForPostCode(postCode);

			var celcius = weatherService.GetTemp(coords.Latitude, coords.Longitude);
			var farenheit = converter.CelciusToFarenheit(celcius);

			return new LocalTemperature
			{
				Fahrenheit = farenheit,
				Celsius = celcius,
				City = city,
				Province = province
			};
		}
	}
}