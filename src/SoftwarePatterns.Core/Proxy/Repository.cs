namespace SoftwarePatterns.Core.Proxy
{
	public abstract class Repository<T>
	{
		public abstract T GetById(int id);
	}
}