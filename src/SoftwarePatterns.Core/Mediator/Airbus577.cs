namespace SoftwarePatterns.Core.Mediator
{
	public class Airbus577 : Aircraft
	{
		public Airbus577(string ident, double initialAltitude, IAircraftController controller)
			: base(ident, initialAltitude, controller)
		{
		}

		protected override string Make
		{
			get { return "Airbus577"; }
		}
	}
}