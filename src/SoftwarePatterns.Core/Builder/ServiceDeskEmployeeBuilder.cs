using System.Collections.Generic;

namespace SoftwarePatterns.Core.Builder
{
	public class ServiceDeskEmployeeBuilder : EmployeeBuilder
	{
		public override void AddCertifications()
		{
			employee.Certifications = new List<string>();
		}

		public override void AddHrDetails()
		{
			employee.Band = Band.Entry;
			employee.IsFullTime = false;
		}

		public override void AddPersonalDetails()
		{
			employee.Name = "Name";
			employee.Email = "Email";
			employee.Phone = "048915646131";
		}

		public override void EnterDepartment()
		{
			employee.Department = Department.ServiceDesk;
		}
	}
}