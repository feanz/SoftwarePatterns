using System;

namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public class ExpenseApprover : IExpenseApprover
	{
		private readonly string name;
		private readonly decimal approvalLimit;

		public ExpenseApprover(string name, Decimal approvalLimit)
		{
			this.name = name;
			this.approvalLimit = approvalLimit;
		}

		public string Name
		{
			get
			{
				return name;
			}
		}

		public ApprovalResponse ApproveExpense(IExpenseReport expenseReport)
		{
			return expenseReport.Total > approvalLimit ?
				ApprovalResponse.BeyondApprovalLimit(this) : ApprovalResponse.Approved(this);
		}
	}
}