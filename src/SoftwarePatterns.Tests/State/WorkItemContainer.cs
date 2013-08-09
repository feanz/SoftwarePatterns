using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SoftwarePatterns.Tests.State
{
	public class WorkItemContainer
	{
		private readonly List<WorkItem> _list = new List<WorkItem>();

		public WorkItemContainer()
		{
			WorkItems = new ReadOnlyCollection<WorkItem>(_list);
		}

		public ReadOnlyCollection<WorkItem> WorkItems { get; set; }

		public void Add(WorkItem workItem)
		{
			var maxId = _list.Max(item => item.Id);
			workItem.Id = (maxId + 1);

			_list.Add(workItem);
		}

		public void Remove(WorkItem workItem)
		{
			_list.Remove(workItem);
		}
	}
}