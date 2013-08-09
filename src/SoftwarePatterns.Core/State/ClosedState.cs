using System;

namespace SoftwarePatterns.Core.State
{
	public class ClosedState : BaseState
	{
		public ClosedState(WorkItem owner) : base(owner)
		{
		}

		public override bool Delete()
		{
			return true;
		}

		public override void Edit(string name, string description)
		{
			Console.WriteLine("Can't edit a closed work item");
		}

		public override void SetState(Status newState)
		{
			switch (newState)
			{
				case Status.Proposed:
					Console.WriteLine("Work item is already closed it can't be set to Proposed");
					break;
				case Status.Active:
					Console.WriteLine("Work item is already closed it can't be set to Active");
					break;
				case Status.Resolved:
					_owner.State = newState;
					break;
				case Status.Closed:
					Console.WriteLine("Work item is already closed");
					break;
			}
		}
	}
}