using System;

namespace SoftwarePatterns.Core.State
{
	public class ResolvedState : BaseState
	{
		public ResolvedState(WorkItem owner) : base(owner)
		{
		}

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
				case Status.Proposed:
					Console.WriteLine("Work item is already resolved it can't be set to Proposed");
					break;
				case Status.Active:
					_owner.State = newState;
					break;
				case Status.Resolved:
					Console.WriteLine("Work item is already resolved");
					break;
				case Status.Closed:
					_owner.State = newState;
					break;
			}
		}
	}
}