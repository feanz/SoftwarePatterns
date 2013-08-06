namespace SoftwarePatterns.Core.Facade
{
	/// <summary>
	/// Fake geo lookup service
	/// </summary>
	public class GeoLookupService
	{
		public Coordinates GetCoordinatesForPostCode(string postCode)
		{
			return new Coordinates(55d,1d);
		}

		public string GetCityForPostCode(string postCode)
		{
			return "Newcastle";
		}

		public string GetProvinceForPostCode(string postCode)
		{
			return "Tyne and Wear";
		}
	}
}