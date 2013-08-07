namespace SoftwarePatterns.Core.Interpreter
{
	public class Medicine : Expression
	{
		private readonly string name;

		public Medicine(string name)
		{
			this.name = name;
		}

		public void Interpret(Context context)
		{
			context.Output += name;
		}
	}
}