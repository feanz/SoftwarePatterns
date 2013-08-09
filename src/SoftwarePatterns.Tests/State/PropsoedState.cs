using System;

namespace SoftwarePatterns.Tests.State
{
	public class PropsoedState : BaseState
	{
		public PropsoedState(WorkItem owner) : base(owner)
		{
		}

		public override bool Delete()
		{
			Console.WriteLine("Work item is not yet active it can be deleted");
			return true;
		}

		public override void Edit(string name, string description)
		{
			_owner.Name = name;
			_owner.Description = description;
		}

		public override void SetState(Status newState)
		{
			switch (newState)
			{
				case Status.Active:
					_owner.State = newState;
					break;
				case Status.Proposed:
					Console.WriteLine("Work item is already Proposed");
					break;
				case Status.Resolved:
					Console.WriteLine("Work item is not yet active it can't be resolved");
					break;
				case Status.Closed:
					Console.WriteLine("Work item is not yet active it can't be closed");
					break;
			}
		}
	}
}