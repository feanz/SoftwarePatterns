using SoftwarePatterns.Core.Observer.IObserver;
using Xunit;

namespace SoftwarePatterns.Tests.Observer
{
	public class ObserverTests
	{
		public class RunTicker
		{
			[Fact]
			public void ShouldClearObserversWhenComplete()
			{
				var ticker = new ObservableStockTicker();

				var google = new GoogleObserver();
				var msft = new MicrosoftObserver();

				ticker.RunTicker();

				Assert.Equal(0, ticker.Observers.Count);
			}
		}
		public class Unsubscriber
		{
			[Fact]
			public void ShouldUnsubscribeOnDispose()
			{
				var ticker = new ObservableStockTicker();

				var google = new GoogleObserver();
				var msft = new MicrosoftObserver();

				using (ticker.Subscribe(google))
				{
					using (ticker.Subscribe(msft))
					{

					}

					Assert.Equal(1, ticker.Observers.Count);
				}
			}
		}
	}
}