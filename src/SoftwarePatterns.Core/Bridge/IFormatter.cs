using System.Linq;

namespace SoftwarePatterns.Core.Bridge
{
	public interface IFormatter
	{
		string Format(string key, string value);
	}
}