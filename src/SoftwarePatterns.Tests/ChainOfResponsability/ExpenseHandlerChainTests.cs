using System;
using SoftwarePatterns.Core.ChainOfResponsability;
using Xunit;
using Xunit.Extensions;

namespace SoftwarePatterns.Tests.ChainOfResponsability
{
	public class ExpenseHandlerChainTests
	{
		public class ApproveMethod
		{
			[Theory]
			[InlineData(55,"Jill")]
			[InlineData(150, "Barry")]
			[InlineData(1500, "Donald")]
			public void ShouldApproveByCorrectApprover(int expenseAmount, string approvedBy)
			{
				var sut = new ExpenseHandlerChain(new ExpenseHandler(new ExpenseApprover("Edd", 0)))
					.RegisterNext(new ExpenseHandler(new ExpenseApprover("Jill", 100)))
					.RegisterNext(new ExpenseHandler(new ExpenseApprover("Barry", 1000)))
					.RegisterNext(new ExpenseHandler(new ExpenseApprover("Donald", 10000)));
				
				var expenseReport = new ExpenseReport(expenseAmount);

				var result = sut.Approve(expenseReport);

				Assert.Equal(approvedBy, result.ApprovedBy.Name);
			}

			[Fact]
			public void ShouldRejectExpenseBeyondLimit()
			{
				var sut = new ExpenseHandlerChain(new ExpenseHandler(new ExpenseApprover("Edd", 0)))
					.RegisterNext(new ExpenseHandler(new ExpenseApprover("Jill", 100)))
					.RegisterNext(new ExpenseHandler(new ExpenseApprover("Barry", 1000)))
					.RegisterNext(new ExpenseHandler(new ExpenseApprover("Donald", 10000)));

				var expenseReport = new ExpenseReport(10000000000);

				var result = sut.Approve(expenseReport);

				Assert.Equal(ApprovalState.Denied, result.State);
			}
		}
	}
}