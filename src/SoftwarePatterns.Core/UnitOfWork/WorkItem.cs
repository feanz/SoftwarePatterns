using SoftwarePatterns.Core.Repository;

namespace SoftwarePatterns.Core.UnitOfWork
{
	public class WorkItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Project Project { get; set; }
		public int ProjectId { get; set; }
	}
}