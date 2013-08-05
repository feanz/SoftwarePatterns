using System;
using System.Linq;

namespace SoftwarePatterns.Core.Bridge
{
	public class BackwardsFormatter : IFormatter
	{
		public string Format(string key, string value)
		{
			return String.Format("{0}: {1}", key, new string(value.Reverse().ToArray()));
		}
	}
}