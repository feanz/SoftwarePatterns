using System;
using System.Data.Entity;

namespace SoftwarePatterns.Core.Repository
{
	public class DbInitialiser : DropCreateDatabaseAlways<ExampleDbContext>
	{
		protected override void Seed(ExampleDbContext context)
		{
			context.Projects.Add(new Project { Name = "Sample", Description = "Some text goes here", StartDate = DateTime.Now.AddDays(-17), IsDevProject = false } );
			context.Projects.Add(new Project { Name = "Test", Description = "Some text goes here", StartDate = DateTime.Now.AddDays(-44), IsDevProject = true });

			base.Seed(context);
		}
	}
}