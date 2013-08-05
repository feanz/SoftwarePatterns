using System;
using System.IO;
using System.Linq;
using SoftwarePatterns.Core.Adapter.Library;
using Xunit;

namespace SoftwarePatterns.Tests.Adapter
{
	public class DataRendererTests
	{
		public class RenderMethod
		{
			[Fact]
			public void ShouldRenderOneRowGivenStubDataApater()
			{
				var sut = new DataRenderer(new StubDataAdapter());

				var writer = new StringWriter();
				sut.Render(writer);

				var result = writer.ToString();
				Console.Write(result);

				Assert.Equal(3, result.Count(c => c == '\n'));
			} 
		} 
	}
}