using System;

namespace SoftwarePatterns.Core.Observer.IObserver
{
	public class GoogleObserver : IObserver<Stock>
	{
		public void OnNext(Stock value)
		{
			if (value.Name.ToLowerInvariant() == "google")
				Console.WriteLine("GOOGLE stock: {0}", value.Level);
		}

		public void OnError(Exception error)
		{
			Console.WriteLine("Error on stock ticker");
		}

		public void OnCompleted()
		{
			Console.WriteLine("End of Stock");
		}
	}
}