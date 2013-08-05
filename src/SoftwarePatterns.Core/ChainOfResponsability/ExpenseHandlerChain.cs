using System.Collections.Generic;
using System.Linq;

namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public class ExpenseHandlerChain
	{
		private readonly List<IExpenseHandler> chain;

		public ExpenseHandlerChain(IExpenseHandler initialHandler)
		{
			chain = new List<IExpenseHandler> {initialHandler};
		}

		public ExpenseHandlerChain RegisterNext(IExpenseHandler expenseHandler)
		{
			chain.Last().RegisterNext(expenseHandler);
			chain.Add(expenseHandler);
			return this;
		}

		public ApprovalResponse Approve(ExpenseReport expenseReport)
		{
			return chain.First().Approve(expenseReport);
		}
	}
}