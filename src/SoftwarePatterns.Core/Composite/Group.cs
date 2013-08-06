using System.Collections.Generic;

namespace SoftwarePatterns.Core.Composite
{
	public class Group : IParty
	{
		public Group()
		{
			Members = new List<IParty>();
		}

		public string Name { get; set; }
		public List<IParty> Members { get; set; }

		public int Gold
		{
			get
			{
				var totalGold = 0;
				Members.ForEach(person => totalGold += person.Gold);
				return totalGold;
			}
			set
			{
				var split = value / Members.Count;
				var leftOver = value % Members.Count;
				Members.ForEach(person =>
				{
					person.Gold = split + leftOver;
					leftOver = 0;
				});
			}
		}

		public void Stats()
		{
			Members.ForEach(person => person.Stats());
		}
	}
}