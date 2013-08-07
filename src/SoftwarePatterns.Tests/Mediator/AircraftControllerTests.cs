using SoftwarePatterns.Core.Mediator;
using Xunit;

namespace SoftwarePatterns.Tests.Mediator
{
	public class AircraftControllerTests
	{
		[Fact]
		public void IntrusionStateWhenAtSameAltitude()
		{
			var controller = new AircraftController();

			var aircraft = new Boeing747("1234", 10000, controller);
			var aircraft1 = new Airbus577("4567", 8000, controller);

			aircraft.Altitude += 1000;

			Assert.True(aircraft.Intrusion);
			Assert.True(aircraft1.Intrusion);
		}
	}
}