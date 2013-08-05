using System;

namespace SoftwarePatterns.Core.EnumerationClass
{
	public abstract partial class EmployeeType : Enumeration
	{
		public static readonly EmployeeType 
			Manager = new ManagerType(),
			Basic = new BasicType();

		protected EmployeeType(int id, string name) : base(id, name) { }

		public abstract Decimal BonusSize { get; }

		//subtypes are hidden inside the employee type or this is the only place they can be constructed
		private class ManagerType : EmployeeType
		{
			public ManagerType() : base(0, "Manager") { }

			public override decimal BonusSize
			{
				get { return 1000; }
			}
		}
	}

	//you can use partial classes to stop the main type getting to big
	public abstract partial class EmployeeType
	{
		private class BasicType : EmployeeType
		{
			public BasicType() : base(1, "Servent") { }

			public override decimal BonusSize
			{
				get { return 0; }
			}
		}
	}
}