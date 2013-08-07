namespace SoftwarePatterns.Core.Interpreter
{
	public interface Expression
	{
		void Interpret(Context context);
	}
}