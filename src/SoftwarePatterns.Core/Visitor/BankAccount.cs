namespace SoftwarePatterns.Core.Visitor
{
	public class BankAccount : IAsset
	{
		public int Amount { get; set; }
		public decimal MonthlyInterest { get; set; }
		
		public void Accept(IAssetVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}