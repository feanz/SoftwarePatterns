namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public interface IExpenseHandler
	{
		ApprovalResponse Approve(IExpenseReport expenseReport);
		void RegisterNext(IExpenseHandler next);
	}
}