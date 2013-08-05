using System.Collections.Generic;
using System.Linq;

namespace SoftwarePatterns.Core.Adapter
{
	public interface IDataPatternRendererAdapter
	{
		string ListPatterns(IEnumerable<Pattern> patterns);
	}
}