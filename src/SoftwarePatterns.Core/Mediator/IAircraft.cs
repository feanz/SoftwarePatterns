namespace SoftwarePatterns.Core.Mediator
{
	public interface IAircraft
	{
		bool Intrusion { get; set; }
		double Altitude { get; set; }
		IAircraftController Controller { get; set; }
		string Identifer { get; }
		void WarnOfAirspaceIntrusion(IAircraft aircraftIntruding);
		void WarnOfIntrusionIntoAirspace(IAircraft intrudingBy);
	}
}