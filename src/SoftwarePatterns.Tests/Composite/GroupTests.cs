using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture;
using SoftwarePatterns.Core.Composite;
using Xunit;

namespace SoftwarePatterns.Tests.Composite
{
	public class GroupTests
	{
		public class GoldProperty
		{
			[Fact]
			public void ShouldReturnValueSet()
			{
				var fixture = new Fixture();
				var players = new List<IParty>(fixture.CreateMany<Player>().ToList());
				var group = new Group { Name = "Test Group", Members = players };

				group.Gold = 1000;

				Assert.Equal(1000, group.Gold);
			}

			[Fact]
			public void ShouldSplitBetweenMembers()
			{
				var fixture = new Fixture();
				var players = new List<IParty>(fixture.CreateMany<Player>().ToList());
				var group = new Group { Name = "Test Group", Members = players };
				
				group.Gold = 1000;

				group.Members.ForEach(member => Assert.True(member.Gold >= (1000 / 3)));
			}

			[Fact]
			public void ShouldGiveFirstMemberRemander()
			{
				var fixture = new Fixture();
				var players = new List<IParty>(fixture.CreateMany<Player>().ToList());
				var group = new Group { Name = "Test Group", Members = players };

				group.Gold = 1000;

				Assert.Equal(334, group.Members.First().Gold);
			}
		}
	}
}