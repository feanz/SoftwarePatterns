namespace SoftwarePatterns.Core.Visitor
{
	public interface IAsset
	{
		void Accept(IAssetVisitor visitor);
	}
}