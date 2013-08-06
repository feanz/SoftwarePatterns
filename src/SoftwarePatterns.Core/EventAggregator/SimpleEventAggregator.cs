using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SoftwarePatterns.Core.EventAggregator
{
	public class SimpleEventAggregator : IEventAggregator
	{
		private readonly object _lock = new object();
		private readonly Dictionary<Type, List<WeakReference>> eventSubscibers = new Dictionary<Type, List<WeakReference>>();

		private List<WeakReference> GetSubscribers(Type subscriberType)
		{
			List<WeakReference> subscribers;
			lock (_lock)
			{
				var found = eventSubscibers.TryGetValue(subscriberType, out subscribers);
				if (!found)
				{
					subscribers = new List<WeakReference>();
					eventSubscibers.Add(subscriberType, subscribers);
				}
			}
			return subscribers;
		}

		public void Publish<TEvent>(TEvent eventToPublish)
		{
			var subsciberType = typeof (ISubscriber<>).MakeGenericType(typeof (TEvent));
			var subscribers = GetSubscribers(subsciberType);
			var subsribersToRemove = new List<WeakReference>();

			foreach (var weakSubsciber in subscribers)
			{
				if (weakSubsciber.IsAlive)
				{
					var subsciber = (ISubscriber<TEvent>) weakSubsciber.Target;
					var syncContext = SynchronizationContext.Current ?? new SynchronizationContext();

					syncContext.Post(state => subsciber.OnEvent(eventToPublish), null);
				}
				else
				{
					subsribersToRemove.Add(weakSubsciber);
				}
			}

			if (subsribersToRemove.Any())
			{
				lock (_lock)
				{
					foreach (var remove in subsribersToRemove)
						subscribers.Remove(remove);
				}
			}
		}

		public void Subscribe(object subscriber)
		{
			lock (_lock)
			{
				var subscriberTypes = subscriber
					.GetType()
					.GetInterfaces()
					.Where(type => type.IsGenericType 
						&& type.GetGenericTypeDefinition() == typeof (ISubscriber<>));

				var weakReference = new WeakReference(subscriber);
				foreach (var subscriberType in subscriberTypes)
				{
					var subscribers = GetSubscribers(subscriberType);
					subscribers.Add(weakReference);
				}
			}
		}
	}
}