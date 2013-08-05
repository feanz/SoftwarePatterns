using System;
using System.Linq;

namespace SoftwarePatterns.Core.Bridge
{
	public class Book : Manuscript
	{
		public Book() : this(new StandardFormatter())
		{
		}

		public Book(IFormatter formatter) : base(formatter)
		{
		}

		public string Author { get; set; }
		public string Text { get; set; }
		public string Title { get; set; }

		public override void Print()
		{
			Console.WriteLine(formatter.Format("Title", Title));
			Console.WriteLine(formatter.Format("Author", Author));
			Console.WriteLine(formatter.Format("Text", Text));
			Console.WriteLine();
		}
	}
}