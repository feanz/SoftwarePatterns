using System.Collections.Generic;

namespace SoftwarePatterns.Core.Interpreter
{
	public class Medication : Expression
	{
		private readonly List<Medicine> medicines;

		public Medication()
		{
			medicines = new List<Medicine>();
		}

		public Medication(List<Medicine> medicines)
		{
			this.medicines = medicines;
		}

		public void Interpret(Context context)
		{
			medicines.ForEach(medicine => medicine.Interpret(context));
		}
	}
}