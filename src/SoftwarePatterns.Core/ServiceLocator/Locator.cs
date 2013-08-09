using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.ServiceLocator
{
	/// <summary>
	/// Very simple service locator pattern
	/// </summary>
	public static class Locator
	{
		private readonly static Dictionary<Type, Func<object>>
			services = new Dictionary<Type, Func<object>>();

		public static void Register<T>(Func<T> resolver)
		{
			services[typeof(T)] = () => resolver();
		}

		public static T Resolve<T>()
		{
			return (T)services[typeof(T)]();
		}

		public static void Reset()
		{
			services.Clear();
		}
	}
}