using System;

namespace SoftwarePatterns.Tests.State
{
	public class ActiveState : BaseState
	{
		public ActiveState(WorkItem owner) :base(owner) { }

		public override bool Delete()
		{
			Console.WriteLine("Work item is already active, can't be deleted");
			return false;
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
					Console.WriteLine("Work item is already active");
					break;
				case Status.Proposed:
				case Status.Resolved:
					_owner.State = newState;
					break;
				case Status.Closed:
					Console.WriteLine("Work item is in active state and can't be closed");
					break;
			}
		}
	}
}