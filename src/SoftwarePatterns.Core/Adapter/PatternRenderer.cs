using System.Collections.Generic;

namespace SoftwarePatterns.Core.Adapter
{
	public class PatternRenderer
	{
		private readonly IDataPatternRendererAdapter _dataPatternRenderer;

		public PatternRenderer(IDataPatternRendererAdapter dataPatternRenderer)
		{
			_dataPatternRenderer = dataPatternRenderer;
		}

		public PatternRenderer(): this(new DataPatternRendererAdapter())
		{
			
		}

		public string ListPatterns(IEnumerable<Pattern> patterns)
		{
			return _dataPatternRenderer.ListPatterns(patterns);
		} 
	}
}