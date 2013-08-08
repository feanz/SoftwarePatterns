using System;
using SoftwarePatterns.Core.Factory;

namespace SoftwarePatterns.Core.NullObject
{
	public abstract class AutomobileBase : IAuto
	{
		public virtual Guid Id { get; set; }

		public virtual string Name { get; set; }

		public abstract void TurnOn();

		public abstract void TurnOff();

		public static AutomobileBase Null
		{
			get
			{
				return _null;
			}
		}

		private static readonly NullAutomobile _null = new NullAutomobile();

		#region NULL
		public class NullAutomobile : AutomobileBase
		{
			public override Guid Id
			{
				get
				{
					return Guid.Empty;
				}
				set
				{

				}
			}

			public override string Name { get; set; }

			public override void TurnOn() { }

			public override void TurnOff() { }
		}
		#endregion
	}

	public class AutomobileRepository
	{
		public IAuto GetAutoByName(string name)
		{
			if(name == "Mini")
				return new MiniCooper();
			return AutomobileBase.Null;
		}
	}
}