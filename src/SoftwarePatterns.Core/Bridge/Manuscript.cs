namespace SoftwarePatterns.Core.Bridge
{
	public abstract class Manuscript
	{
		protected readonly IFormatter formatter;

		protected Manuscript(IFormatter formatter)
		{
			this.formatter = formatter;
		}

		public abstract void Print();
	}
}