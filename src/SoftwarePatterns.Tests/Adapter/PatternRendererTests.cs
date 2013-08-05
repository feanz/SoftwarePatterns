using System;
using System.Collections.Generic;
using System.Linq;
using SoftwarePatterns.Core.Adapter;
using Xunit;

namespace SoftwarePatterns.Tests.Adapter
{
	public class PatternRendererTests
	{
		public class ListPatternsMethod
		{
			[Fact]
			public void RenderTheNumberOfPatternProvided()
			{
				var sut = new PatternRenderer();
				
				var patterns = new List<Pattern>
				{
					new Pattern { ID = 1, Name = "Builder", Description = "Build stuff"},
					new Pattern { ID = 2, Name = "Adapter", Description = "Makes things fit"}
				};

				var result = sut.ListPatterns(patterns);

				Console.Write(result);

				Assert.Equal(patterns.Count + 2, result.Count(c => c == '\n'));
			}
		}
	}
}