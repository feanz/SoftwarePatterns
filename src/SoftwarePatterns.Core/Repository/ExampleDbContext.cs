using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SoftwarePatterns.Core.Repository
{
	public class ExampleDbContext : DbContext 
	{
		static ExampleDbContext()
		{
			Database.SetInitializer(new DbInitialiser());
		}

		public ExampleDbContext()
			: base(nameOrConnectionString: "DefaultConnection") { }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Project> Projects { get; set; }
	}
}