using System;
using System.Collections.Generic;
using SoftwarePatterns.Core.EnumerationClass;

namespace SoftwarePatterns.Core.Builder
{
	/// <summary>
	/// This class is created to solve the problem of the employee with the large constructor by making all fields public properties.
	/// However the issues with this is that we can no longer control the order or process of construction this is solved using director and builders
	/// The employee object is now only concerned with data not process or logic around how it is made
	/// </summary>
	public class Employee
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public Department Department { get; set; }
		public Band Band { get; set; }
		public bool IsFullTime { get; set; }
		public List<string> Certifications { get; set; }
		public EmployeeType Type { get; set; }
		public decimal  Bonus { get; set; }

		public void Display()
		{
			Console.WriteLine("Employee Details");
			Console.WriteLine("Name: {0}", Name);
			Console.WriteLine("Email: {0}", Email);
			Console.WriteLine("Phone: {0}", Phone);
			Console.WriteLine("Department: {0}", Department);
			Console.WriteLine("Band: {0}", Band);
			Console.WriteLine("FullTime: {0}", IsFullTime);

			Console.WriteLine("Certifications:");
			Certifications.ForEach(s => Console.WriteLine("{0}",s));
			Console.WriteLine();
		} 
	}

}