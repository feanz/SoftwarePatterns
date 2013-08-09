namespace SoftwarePatterns.Tests.State
{
	public interface ICommands
	{
		bool Delete();
		void Edit(string name, string description);
		void Print();
		void SetState(Status newState);
	}
}