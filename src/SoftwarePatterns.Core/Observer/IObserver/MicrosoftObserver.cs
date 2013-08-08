using System;

namespace SoftwarePatterns.Core.Observer.IObserver
{
	public class MicrosoftObserver : IObserver<Stock>
	{
		public void OnNext(Stock value)
		{
			if (value.Name.ToLowerInvariant() == "msft" && value.Level >= 100)
				Console.WriteLine("MSFT is at 100 woow");
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