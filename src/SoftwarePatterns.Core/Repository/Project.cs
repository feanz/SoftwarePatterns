using System;
using System.ComponentModel.DataAnnotations;

namespace SoftwarePatterns.Core.Repository
{
	public class Project
	{
		public Project()
		{
			StartDate = DateTime.UtcNow;
		}

		public int Id { get; set; }
		
		[StringLength(200)]
		public string Name { get; set; }
		
		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public bool IsDevProject { get; set; }
	}
}