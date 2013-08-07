using System.Collections.Generic;

namespace SoftwarePatterns.Core.Interpreter
{
	public class MedicalHistory : Expression
	{
		private readonly List<IMedicalEvent> events;

		public MedicalHistory(List<IMedicalEvent> events)
		{
			this.events = events;
		}

		public MedicalHistory()
		{
			events = new List<IMedicalEvent>();
		}

		public void Interpret(Context context)
		{
			foreach (var e in events)
				e.Interpret(context);
		}
	}
}