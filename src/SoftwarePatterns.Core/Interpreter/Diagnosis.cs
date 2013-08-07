namespace SoftwarePatterns.Core.Interpreter
{
	public class Diagnosis : Expression
	{
		public string Descrtion { get; set; }

		public void Interpret(Context context)
		{
			context.Output += Descrtion;
		}
	}
}