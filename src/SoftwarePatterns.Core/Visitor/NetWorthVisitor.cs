namespace SoftwarePatterns.Core.Visitor
{
	public class NetWorthVisitor : IAssetVisitor
	{
		public int Networth { get; set; }

		public void Visit(BankAccount bankAccount)
		{
			Networth += bankAccount.Amount;
		}

		public void Visit(Loan loan)
		{
			Networth -= loan.Owed;
		}

		public void Visit(RealEstate realEstate)
		{
			Networth += realEstate.EstimatedValue;
		}
	}
}