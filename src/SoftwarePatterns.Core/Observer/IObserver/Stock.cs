namespace SoftwarePatterns.Core.Observer.IObserver
{
	public class Stock
	{
		public Stock(string name, int level)
		{
			Name = name;
			Level = level;
		}

		public string Name { get; set; }
		public int Level { get; set; }
	}
}