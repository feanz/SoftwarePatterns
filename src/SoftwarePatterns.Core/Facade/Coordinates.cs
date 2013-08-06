namespace SoftwarePatterns.Core.Facade
{
	public class Coordinates
	{
		public Coordinates(double lat, double lon)
		{
			Longitude = lon;
			Latitude = lat;
		}

		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
}