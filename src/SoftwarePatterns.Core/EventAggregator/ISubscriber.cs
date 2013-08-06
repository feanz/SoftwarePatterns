namespace SoftwarePatterns.Core.EventAggregator
{
	public interface ISubscriber<TEvent>
	{
		void OnEvent(TEvent e);
	}
}