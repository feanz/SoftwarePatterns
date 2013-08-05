using System;

namespace SoftwarePatterns.Core.Bridge
{
	public class Paper : Manuscript
	{
		public Paper(IFormatter formatter) : base(formatter)
		{
		}

		public string Class { get; set; }
		public string Student { get; set; }
		public string Text { get; set; }
		public string References { get; set; }

		public override void Print()
		{
			Console.WriteLine(formatter.Format("Class", Class));
			Console.WriteLine(formatter.Format("Student", Student));
			Console.WriteLine(formatter.Format("Text", Text));
			Console.WriteLine(formatter.Format("References", References));
			Console.WriteLine();
		}
	}
}