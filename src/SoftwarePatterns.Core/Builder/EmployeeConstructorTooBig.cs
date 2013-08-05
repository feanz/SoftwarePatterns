using System;
using System.Collections.Generic;

namespace SoftwarePatterns.Core.Builder
{
	/// <summary>
	/// Class issues that our constructor grows and grows and becomes difficult to work with
	/// </summary>
	public class EmployeeConstructorTooBig
	{
		private readonly string name;
		private readonly string email;
		private readonly string phone;
		private readonly Department department;
		private readonly Band band;
		private readonly bool isFullTime;
		private readonly List<string> certifications;

		public EmployeeConstructorTooBig(string name,string email, string phone, Department department, Band band, bool isFullTime, List<string> certifications)
		{
			this.name = name;
			this.email = email;
			this.phone = phone;
			this.department = department;
			this.band = band;
			this.isFullTime = isFullTime;
			this.certifications = certifications;
		}

		public void Display()
		{
			Console.WriteLine("Employee Details");
			Console.WriteLine("Name: {0}", name);
			Console.WriteLine("Email: {0}", email);
			Console.WriteLine("Phone: {0}", phone);
			Console.WriteLine("Department: {0}", department);
			Console.WriteLine("Band: {0}", band);
			Console.WriteLine("FullTime: {0}", isFullTime);

			Console.WriteLine("Certifications:");
			certifications.ForEach(s => Console.WriteLine("{0}",s));
			Console.WriteLine();
		}
	}
}