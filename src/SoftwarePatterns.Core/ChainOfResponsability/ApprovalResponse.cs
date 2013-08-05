namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public class ApprovalResponse
	{
		public ApprovalState State { get; set; }
		public IExpenseApprover ApprovedBy  { get; set; }

		public static ApprovalResponse Approved(IExpenseApprover expenseApprover)
		{
			return new ApprovalResponse
			{
				State = ApprovalState.Approved,
				ApprovedBy = expenseApprover
			};
		}

		public static ApprovalResponse BeyondApprovalLimit(IExpenseApprover expenseApprover)
		{
			return new ApprovalResponse
			{
				State = ApprovalState.BeyondApprovalLimit,
				ApprovedBy = expenseApprover
			};
		}

		public static ApprovalResponse Denied()
		{
			return new ApprovalResponse
			{
				State = ApprovalState.Denied
			};
		}
	}
}