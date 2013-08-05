using System.Linq;

namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public class ExpenseHandler : IExpenseHandler
	{
		private readonly IExpenseApprover approver;
		private IExpenseHandler next;

		public ExpenseHandler(IExpenseApprover approver)
		{
			this.approver = approver;
			next = EndOfChainHandler.Instance;
		}

		public ApprovalResponse Approve(IExpenseReport expenseReport)
		{
			var response = approver.ApproveExpense(expenseReport);

			if (response.State == ApprovalState.BeyondApprovalLimit)
				return next.Approve(expenseReport);

			return response;
		}

		public void RegisterNext(IExpenseHandler next)
		{
			this.next = next;
		}
	}
}