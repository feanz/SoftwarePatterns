namespace SoftwarePatterns.Core.Momento
{
	public interface IMemento
	{
		object State { get; set; } 
	}

	public class InkCanvasMemeto : IMemento
	{
		public object State { get; set; }
	}
}