namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public interface IExpenseApprover
	{
		string Name { get; }
		ApprovalResponse ApproveExpense(IExpenseReport expenseReport);
	}
}