using SoftwarePatterns.Core.NullObject;
using Xunit;

namespace SoftwarePatterns.Tests.NullObject
{
	public class AutoRepositoryTests
	{
		public class GetCarMethod
		{
			[Fact]
			public void ReturnNullCarForUnknowCar()
			{
				var repo = new AutomobileRepository();

				var actual = repo.GetAutoByName("Made up name");

				Assert.Equal(AutomobileBase.Null, actual);
			}
		}
	}
}