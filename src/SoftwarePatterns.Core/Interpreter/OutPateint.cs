namespace SoftwarePatterns.Core.Interpreter
{
	public class OutPateint : IPatientType
	{
		public void Interpret(Context context)
		{
			context.Output += "Outpatient";
		}
	}
}