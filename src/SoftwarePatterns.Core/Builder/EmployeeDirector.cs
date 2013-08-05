namespace SoftwarePatterns.Core.Builder
{
	/// <summary>
	/// The employee director encapsulates the process of construction.  It does not know anything about the data it only knows about order of operation.
	/// </summary>
	public class EmployeeDirector
	{
		private readonly EmployeeBuilder builder;

		public EmployeeDirector(EmployeeBuilder builder)
		{
			this.builder = builder;
		}

		public Employee CreateEmployee()
		{
			builder.CreateNewSandwitch();
			builder.AddPersonalDetails();
			builder.AddCertifications();
			builder.EnterDepartment();
			builder.AddHrDetails();

			return builder.GetEmployee();
		}
	}
}