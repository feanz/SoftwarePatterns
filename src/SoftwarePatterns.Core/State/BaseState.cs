using System;

namespace SoftwarePatterns.Core.State
{
	public abstract class BaseState : ICommands
	{
		protected readonly WorkItem _owner;

		protected BaseState(WorkItem owner)
		{
			_owner = owner;
		}

		public abstract bool Delete();

		public abstract void Edit(string name, string description);

		public virtual void Print()
		{
			Console.WriteLine();
			Console.WriteLine("WorkItem ID: {0}", _owner.Id);
			Console.WriteLine("WorkItem Name: {0}", _owner.Name);
			Console.WriteLine("WorkItem State: {0}", _owner.State);
			Console.WriteLine("WorkItem Description: {0}", _owner.Description);
			Console.WriteLine();
		}

		public abstract void SetState(Status newState);
	}
}