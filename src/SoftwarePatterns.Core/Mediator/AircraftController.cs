using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwarePatterns.Core.Mediator
{
	public class AircraftController : IAircraftController
	{
		private readonly List<IAircraft> _aircraft = new List<IAircraft>();

		public void RegisterAircraft(IAircraft aircraft)
		{
			if (!_aircraft.Contains(aircraft))
			{
				_aircraft.Add(aircraft);
			}
		}

		public void RecieveAircraftLocation(IAircraft reportingAircraft)
		{
			foreach (var aircraft in _aircraft.Where(a => a != reportingAircraft)
				.Where(aircraft => Math.Abs(aircraft.Altitude - reportingAircraft.Altitude) > 100))
			{
				reportingAircraft.WarnOfAirspaceIntrusion(aircraft);
				aircraft.WarnOfIntrusionIntoAirspace(reportingAircraft);
			}
		}
	}

	public interface IAircraftController
	{
		void RegisterAircraft(IAircraft aircraft);
		void RecieveAircraftLocation(IAircraft reportingAircraft);
	}
}