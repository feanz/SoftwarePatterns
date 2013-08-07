using System.Drawing;

namespace SoftwarePatterns.Core.Flyweight
{
	/// <summary>
	/// An example of ITile this object stores lots of state
	/// </summary>
	public class CeramicTile : ITile
	{
		public static int ObjectCounter = 0;
		private readonly int x;
		private readonly int y;
		private readonly int width;
		private readonly int height;
		private readonly Brush paintBrush;

		public CeramicTile(int x, int y, int width, int height)
		{
			paintBrush = Brushes.Red;
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
			ObjectCounter++;
		}

		public void Draw(Graphics g)
		{
			g.FillRectangle(paintBrush, x, y, width, height);
		}
	}
}