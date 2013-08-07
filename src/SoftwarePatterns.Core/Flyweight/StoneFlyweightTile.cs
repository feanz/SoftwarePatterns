using System.Drawing;

namespace SoftwarePatterns.Core.Flyweight
{
	/// <summary>
	/// The flyweight implementations of ITile take in there 
	/// state from the client only storing the paint brush
	/// </summary>
	public class StoneFlyweightTile : IFlyweightTile
	{
		public static int ObjectCounter { get; set; }

		private readonly Brush paintBrush;

		public StoneFlyweightTile()
		{
			paintBrush = Brushes.Blue;
			ObjectCounter++;
		}

		public void Draw(Graphics g, int x, int y, int width, int height)
		{
			g.FillRectangle(paintBrush, x, y, width, height);
		}
	}
}