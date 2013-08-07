using System;

namespace SoftwarePatterns.Core.Mediator
{
	public abstract class Aircraft : IAircraft
	{
		private readonly string _ident;
		private double _altitude;

		protected Aircraft(string ident, double initialAltitude, IAircraftController controller)
		{
			_ident = ident;
			_altitude = initialAltitude;
			Controller = controller;
			controller.RegisterAircraft(this);
		}

		protected abstract string Make { get; }

		public double Altitude
		{
			get { return _altitude; }
			set
			{
				_altitude = value;
				Controller.RecieveAircraftLocation(this);
			}
		}

		public IAircraftController Controller { get; set; }

		public string Identifer
		{
			get
			{
				return _ident;
			}
		}

		public void WarnOfAirspaceIntrusion(IAircraft aircraftIntruding)
		{
			Intrusion = true;
			Console.WriteLine("Aircraft {0} just intruded into airspace of {1}", Identifer, aircraftIntruding.Identifer);
		}

		public bool Intrusion { get; set; }

		public void WarnOfIntrusionIntoAirspace(IAircraft intrudingBy)
		{
			Intrusion = true;
			Console.WriteLine("Aircraft " + Identifer + " just had airspace intruded on by " + intrudingBy.Identifer);
		}
	}
}