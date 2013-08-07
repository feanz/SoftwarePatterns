namespace SoftwarePatterns.Core.Interpreter
{
	public class HeartAttack : IMedicalEvent
	{
		public void Interpret(Context context)
		{
			context.Output += string.Format("Sudden pain in chest");
		}
	}
}