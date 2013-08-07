namespace SoftwarePatterns.Core.Interpreter
{
	public class ManFlu : IMedicalEvent
	{
		public void Interpret(Context context)
		{
			context.Output += string.Format("I think it might be brain cancer!");
		}
	}
}