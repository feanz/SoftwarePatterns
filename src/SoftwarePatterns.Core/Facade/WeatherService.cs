namespace SoftwarePatterns.Core.Facade
{
	/// <summary>
	/// Fake weather service
	/// </summary>
	public class WeatherService
	{
		public double GetTemp(double latitude, double longitude)
		{
			return 23.2d;
		}
	}
}