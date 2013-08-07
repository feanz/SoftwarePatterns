using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SoftwarePatterns.Core.Flyweight
{
	public class TileFactory
	{
		private static Dictionary<string, IFlyweightTile> tiles;
		private static readonly object padlock = new object();

		public TileFactory()
		{
			FillFactory();
		}

		public IFlyweightTile GetTile(string name)
		{
			return tiles.Where(pair => pair.Key.ToLowerInvariant().Contains(name.ToLowerInvariant())).Select(pair => pair.Value).FirstOrDefault();
		}

		private static void FillFactory()
		{
			lock (padlock)
			{
				if (tiles == null)
				{
					tiles = Assembly
						.GetExecutingAssembly()
						.GetTypes()
						.Where(type => type.GetInterface(typeof(IFlyweightTile).ToString()) != null)
						.Select(type => new KeyValuePair<string, IFlyweightTile>(type.Name, Activator.CreateInstance(type) as IFlyweightTile))
						.ToDictionary(pair => pair.Key, pair => pair.Value);
				}
			}
		}
	}
}