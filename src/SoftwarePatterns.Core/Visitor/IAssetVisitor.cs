namespace SoftwarePatterns.Core.Visitor
{
	public interface IAssetVisitor
	{
		void Visit(BankAccount bankAccount);
		void Visit(Loan loan);
		void Visit(RealEstate realEstate);
	}
}