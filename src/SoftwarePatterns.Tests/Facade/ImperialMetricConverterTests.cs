using System;
using SoftwarePatterns.Core.Facade;
using Xunit;
using Xunit.Extensions;

namespace SoftwarePatterns.Tests.Facade
{
	public class ImperialMetricConverterTests
	{
		public class CelciusToFarenheitMethod
		{
			[Theory]
			[InlineData(-10, 14)]
			[InlineData(1, 34)]
			[InlineData(15, 59)]
			[InlineData(19, 66)]
			[InlineData(45, 113)]
			public void ShouldCalculateCorrectResult(double temp, double expected)
			{
				var converter = new ImperialMetricConverter();
				var actual = converter.CelciusToFarenheit(temp);

				const double sigma = 0.9;
				Assert.True(Math.Abs(expected - actual) < sigma);
			}
		}
	}
}