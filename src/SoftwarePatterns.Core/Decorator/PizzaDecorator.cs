namespace SoftwarePatterns.Core.Decorator
{
	public class PizzaDecorator : Pizza
	{
		protected readonly Pizza pizza;

		public PizzaDecorator(Pizza pizza)
		{
			this.pizza = pizza;
		}

		public override string GetDescription()
		{
			return pizza.Description;
		}

		public override decimal CalculateCost()
		{
			return pizza.CalculateCost();
		}
	}

	public class Cheese : PizzaDecorator
	{
		public Cheese(Pizza pizza)
			: base(pizza)
		{
			Description = "cheese";
		}

		public override string GetDescription()
		{
			return string.Format("{0},  {1}", pizza.GetDescription(), Description);
		}

		public override decimal CalculateCost()
		{
			return pizza.CalculateCost() + 1.25m;
		}
	}

	public class Peppers : PizzaDecorator
	{
		public Peppers(Pizza pizza)
			: base(pizza)
		{
			Description = "peppers";
		}

		public override string GetDescription()
		{
			return string.Format("{0},  {1}", pizza.GetDescription(), Description);
		}

		public override decimal CalculateCost()
		{
			return pizza.CalculateCost() + 0.25m;
		}
	}

	public class Ham : PizzaDecorator
	{
		public Ham(Pizza pizza)
			: base(pizza)
		{
			Description = "ham";
		}

		public override string GetDescription()
		{
			return string.Format("{0},  {1}", pizza.GetDescription(), Description);
		}

		public override decimal CalculateCost()
		{
			return pizza.CalculateCost() + 1.00m;
		}
	}
}