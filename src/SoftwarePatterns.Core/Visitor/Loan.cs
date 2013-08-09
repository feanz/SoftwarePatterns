namespace SoftwarePatterns.Core.Visitor
{
	public class Loan : IAsset
	{
		public int Owed { get; set; }
		public int MonthlyPayments { get; set; }

		public void Accept(IAssetVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}