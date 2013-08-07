namespace SoftwarePatterns.Core.Interpreter
{
	public class IntensiveCarePatient : IPatientType
	{
		public void Interpret(Context context)
		{
			context.Output += "IntensiveCare";
		}
	}
}