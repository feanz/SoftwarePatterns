namespace SoftwarePatterns.Core.Bridge
{
	public class StandardFormatter : IFormatter
	{
		public string Format(string key, string value)
		{
			return string.Format("{0}: {1}", key, value);
		}
	}
}