namespace SoftwarePatterns.Core.Facade
{
	public class ImperialMetricConverter
	{
		public double CelciusToFarenheit(double celcius)
		{
			var fahr = (celcius*9/5) + 32;
			return fahr;
		}
	}
}