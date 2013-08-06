using System.Linq;

namespace SoftwarePatterns.Core.EventAggregator
{
	public interface IEventAggregator
	{
		void Publish<TEvent>(TEvent eventToPublish);
		void Subscribe(object subscriber);
	}
}