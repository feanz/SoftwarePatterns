namespace SoftwarePatterns.Core.Mediator
{
	public class Boeing747 : Aircraft
	{
		public Boeing747(string ident, double initialAltitude, IAircraftController controller)
			: base(ident, initialAltitude, controller)
		{

		}

		protected override string Make
		{
			get { return "Boeing747"; }
		}
	}
}