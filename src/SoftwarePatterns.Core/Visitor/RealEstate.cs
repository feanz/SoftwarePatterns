namespace SoftwarePatterns.Core.Visitor
{
	public class RealEstate : IAsset
	{
		public int EstimatedValue { get; set; }
		public int MonthlyRepayments { get; set; }

		public void Accept(IAssetVisitor visitor)
		{
			visitor.Visit(this);
		}
	}
}