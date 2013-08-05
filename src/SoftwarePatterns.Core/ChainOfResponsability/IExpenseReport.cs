using System;

namespace SoftwarePatterns.Core.ChainOfResponsability
{
	public interface IExpenseReport
	{
		 Decimal Total { get; }
	}

	public class ExpenseReport : IExpenseReport
	{
		public ExpenseReport(decimal total)
		{
			Total = total;
		}

		public decimal Total { get; private set; }
	}
}