namespace SoftwarePatterns.Core.Decorator
{
	public class MediumPizza : Pizza
	{
		public MediumPizza()
		{
			Description = "Medium Pizza";
		}

		public override string GetDescription()
		{
			return Description;
		}

		public override decimal CalculateCost()
		{
			return 6.00m;
		}
	}
}