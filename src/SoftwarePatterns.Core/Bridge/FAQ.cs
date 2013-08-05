using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Bridge
{
	public class FAQ : Manuscript
	{
		public FAQ(IFormatter formatter) : base(formatter)
		{
			Questions = new Dictionary<string, string>();
		}

		public Dictionary<string, string> Questions { get; set; }
		public string Title { get; set; }

		public override void Print()
		{
			Console.WriteLine(formatter.Format("Title", Title));

			Questions.ForEach(q =>
			{
				Console.WriteLine(formatter.Format("Question", q.Key));
				Console.WriteLine(formatter.Format("Answer", q.Value));
			});

			Console.WriteLine();
		}
	}
}