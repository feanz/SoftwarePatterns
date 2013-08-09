using System;
using System.Dynamic;
using System.Web.SessionState;

namespace SoftwarePatterns.Core.Singleton
{
	/// <summary>
	/// This implementation of the singleton pattern is fully lazy with the static member of the nested class only being instantiated on first call to the parent classes property.
	/// This is fully thread safe and faster than locking
	/// </summary>
	public sealed class Singleton
	{
		public decimal GlobalValue
		{
			get
			{
				return 300;
			}
		}

		private Singleton()
		{
		}

		public static Singleton Instance
		{
			get
			{
				return Nested.instance;
			}
		}

		private sealed class Nested
		{
			// Explicit static constructor to tell C# compiler
			// not to mark type as beforefieldinit
			static Nested()
			{
			}

			internal static readonly Singleton instance = new Singleton();
		}
	}
	
	// Example one simple singleton Bad! This Code is not thread safe
	//public sealed class SimpleSingleton
	//{
	//	static Singleton instance = null;

	//	SimpleSingleton()
	//	{
	//	}

	//	public static SimpleSingleton Instance
	//	{
	//		get
	//		{
	//			if (instance == null)
	//			{
	//				instance = new SimpleSingleton();
	//			}
	//			return instance;
	//		}
	//	}
	//}

	// Example two lock singleton This code is thread safe but its use of locking is not that performant
	//public sealed class LockSingleton
	//{
	//	private static LockSingleton instance = null;
	//	private static readonly object padLock = new object(); 

	//	LockSingleton()
	//	{
	//	}

	//	public static LockSingleton Instance
	//	{
	//		get
	//		{
	//			lock (padLock)
	//			{
	//				if (instance == null)
	//				{
	//					instance = new LockSingleton();
	//				}
	//			}
	//			return instance;
	//		}
	//	}
	//}

	//Example three using double check Bad Code! locking this tries to improve performance by not always locking.  
	//This pattern performs differently in different version of c# and java and is easy to get wrong
	//public class DoubleCheckLockingSingleton
	//{
	//	private static DoubleCheckLockingSingleton instance = null;
	//	private static readonly object padlock = new object();

	//	private DoubleCheckLockingSingleton()
	//	{
			
	//	}

	//	public static DoubleCheckLockingSingleton Instance
	//	{
	//		get
	//		{
	//			if (instance == null)
	//			{
	//				lock (padlock)
	//				{
	//					if (instance == null)
	//					{
	//						instance = new DoubleCheckLockingSingleton();
	//					}
	//				}
	//			}
	//			return instance;
	//		}
	//	}
	//}
}