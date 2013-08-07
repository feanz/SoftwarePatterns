namespace SoftwarePatterns.Core.Interpreter
{
	public class Stroke : IMedicalEvent
	{
		public void Interpret(Context context)
		{
			context.Output += string.Format("I've had a strooooke!!!!!");
		}
	}
}