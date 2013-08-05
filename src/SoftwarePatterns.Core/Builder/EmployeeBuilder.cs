namespace SoftwarePatterns.Core.Builder
{
	/// <summary>
	/// Each employee builder is expected to know what is required at each stage of the process for its given implementation type
	/// </summary>
	public abstract class EmployeeBuilder
	{
		protected Employee employee;

		public abstract void AddCertifications();
		public abstract void AddHrDetails();
		public abstract void AddPersonalDetails();
		public abstract void EnterDepartment();

		public virtual void CreateNewSandwitch()
		{
			employee = new Employee();			
		}

		public Employee GetEmployee()
		{
			return employee;
		}
	}
}