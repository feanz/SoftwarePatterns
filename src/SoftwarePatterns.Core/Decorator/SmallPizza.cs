namespace SoftwarePatterns.Core.Decorator
{
	public class SmallPizza : Pizza
	{
		public SmallPizza()
		{
			Description = "Small Pizza";
		}

		public override string GetDescription()
		{
			return Description;
		}

		public override decimal CalculateCost()
		{
			return 3.00m;
		}
	}
}