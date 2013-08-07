using System.Drawing;
using System.Linq;

namespace SoftwarePatterns.Core.Flyweight
{
	public interface IFlyweightTile
	{
		void Draw(Graphics g, int x, int y, int width, int height);
	}
}