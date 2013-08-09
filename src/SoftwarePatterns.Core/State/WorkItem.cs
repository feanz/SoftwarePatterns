using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SoftwarePatterns.Core.State
{
	public class WorkItem : ICommands
	{
		private static WorkItemContainer _container;
		private Status _state;
		private List<Type> _stateCommandTypes;
		private ICommands _stateCommands;

		public WorkItem()
		{
		}

		public string Description { get; set; }

		public int Id { get; set; }
		public string Name { get; set; }

		public Status State
		{
			get { return _state; }
			set
			{
				_state = value;
				SetStateCommands();
			}
		}

		private void LoadPossibleTypes()
		{
			_stateCommandTypes = Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.Where(type => !type.IsAbstract
					&& type.Name != typeof(WorkItem).Name.ToString(CultureInfo.InvariantCulture) 
					&&  type.GetInterface(typeof (ICommands).ToString()) != null)
				.ToList();
		}

		private void SetStateCommands()
		{
			if (_stateCommandTypes == null)
				LoadPossibleTypes();

			if (_stateCommandTypes != null)
			{
				var command = _stateCommandTypes
					.Where(type => type.Name.ToLowerInvariant().Contains(_state.ToString().ToLowerInvariant()))
					.Select(type => (ICommands) Activator.CreateInstance(type, this))
					.FirstOrDefault();

				if (command == null) throw new ArgumentException("Can't find state command for the given state");

				_stateCommands = command;
			}
		}

		public bool Delete()
		{
			var canDelete = _stateCommands.Delete();
			if (canDelete)
				_container.Remove(this);
			return canDelete;
		}

		public void Edit(string name, string description)
		{
			_stateCommands.Edit(name, description);
		}

		public void Print()
		{
			_stateCommands.Print();
		}

		public void SetState(Status newState)
		{
			_stateCommands.SetState(newState);
		}

		public static WorkItem Create()
		{
			var wi = new WorkItem {Id = -1, State = Status.Proposed};
			_container.Add(wi);
			return wi;
		}

		public static WorkItem FindById(int id)
		{
			return _container.WorkItems.FirstOrDefault(item => item.Id == id);
		}

		public static void Init(WorkItemContainer container)
		{
			_container = container;
		}
	}
}