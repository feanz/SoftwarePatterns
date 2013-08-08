using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using SoftwarePatterns.Core.UnitOfWork;

namespace SoftwarePatterns.Core.Repository
{
	public class Project
	{
		public Project()
		{
			StartDate = DateTime.UtcNow;
			WorkItems = new Collection<WorkItem>();
		}

		public int Id { get; set; }
		
		[StringLength(200)]
		public string Name { get; set; }
		
		public string Description { get; set; }

		public DateTime StartDate { get; set; }

		public bool IsDevProject { get; set; }

		public ICollection<WorkItem> WorkItems { get; set; }
	}
}