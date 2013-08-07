using System;

namespace SoftwarePatterns.Core.Interpreter
{
	public class PersonalDetial : Expression
	{
		public string Name { get; set; }
		public DateTime DateOFfBirth { get; set; }
		public string PostCode { get; set; }

		public void Interpret(Context context)
		{
			context.Output += string.Format("Name: {0}   DOB: {1}  Postcode: {2}", Name, DateOFfBirth.ToShortDateString(), PostCode);
		}
	}
}