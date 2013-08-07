using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoftwarePatterns.Core.Flyweight;

namespace SoftwarePatterns.Forms
{
	public partial class TileDemo : Form
	{
		private readonly Random random = new Random();

		public TileDemo()
		{
			InitializeComponent();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			//DrawTiles(e);
			DrawTilesFlyweight(e);
		}

		private void DrawTilesFlyweight(PaintEventArgs e)
		{
			//with flyweight pattern applied
			var factory = new TileFactory();

			for (int i = 0; i < 20; i++)
			{
				var ceramicTile = factory.GetTile("Ceramic");
				ceramicTile.Draw(e.Graphics, GetRandomNumber(), GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
			}

			for (int i = 0; i < 20; i++)
			{
				var stoneTile = factory.GetTile("Stone");
				stoneTile.Draw(e.Graphics,GetRandomNumber(), GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
			}

			toolStripStatusLabel1.Text = "Total Objects Created: " + Convert.ToString(StoneFlyweightTile.ObjectCounter + CeramicFlyweightTile.ObjectCounter);
		}


		private void DrawTiles(PaintEventArgs e)
		{
			//without the flyweight pattern applied
			for (int i = 0; i < 20; i++)
			{
				ITile ceramicTile = new CeramicTile(GetRandomNumber(), GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
				ceramicTile.Draw(e.Graphics);
			}

			for (int i = 0; i < 20; i++)
			{
				ITile stoneTile = new StoneTile(GetRandomNumber(), GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
				stoneTile.Draw(e.Graphics);
			}

			toolStripStatusLabel1.Text = "Total Objects Created: " + Convert.ToString(CeramicTile.ObjectCounter + StoneTile.ObjectCounter);
		}

		private int GetRandomNumber()
		{
			return random.Next(100);
		}
	}
}
