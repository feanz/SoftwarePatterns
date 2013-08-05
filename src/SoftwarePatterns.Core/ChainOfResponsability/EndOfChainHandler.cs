using System;

namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public class EndOfChainHandler : IExpenseHandler
	{
		private static readonly EndOfChainHandler instance = new EndOfChainHandler();

		public static EndOfChainHandler Instance
		{
			get { return instance; }
		}

		public ApprovalResponse Approve(IExpenseReport expenseReport)
		{
			return ApprovalResponse.Denied();
		}

		public void RegisterNext(IExpenseHandler next)
		{
			throw new InvalidOperationException("End of chain handler must be the end of the chain!");
		}
	}
}