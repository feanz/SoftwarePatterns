using System;
using System.Collections.Generic;
using System.Linq;
using SoftwarePatterns.Core.Builder;
using SoftwarePatterns.Core.EnumerationClass;

namespace SoftwarePatterns
{
	class Program
	{
		#region Builder Examples
		//*****Builder Examples
		//static void Main(string[] args)
		//{
		//	Employee employee;

		//	//This employee object constructor is too large
		//	//var employee = new EmployeeConstructorTooBig("Name","email","079871656564",Department.HR,Band.Executive,true,new List<string> {"Cert 1", "Cert 2" });
			
		//	//This method of making object gives us no control over construction process
		//	//var employee = new EmployeePublicProperties
		//	//{
		//	//	Name = "Name",
		//	//	Email = "Email",
		//	//	Phone = "048915646131",
		//	//	Department = Department.HR,
		//	//	Band = Band.Lower,
		//	//	IsFullTime = true,
		//	//	Certifications = new List<string>
		//	//	{
		//	//		"Cert 1",
		//	//		"Cert 2"
		//	//	}
		//	//};

		//	//we can use a director class that expects a specific employee type builder
		//	var builder = new ServiceDeskEmployeeBuilder();
		//	var director = new EmployeeDirector(builder);
		//	employee = director.CreateEmployee();

		//	employee.Display();

		//	Console.ReadLine();
		//}

		#endregion 

		#region Enumeration Class
		//*********EnumerationClass examples
		//static void Main()
		//{
		//	//to stop this sort of code
		//	//public void ProcessBonus(Employee employee)
		//	//{
		//	//	switch (employee.Type)
		//	//	{
		//	//		case EmployeeType.Manager:
		//	//			employee.Bonus = 1000m;
		//	//			break;
		//	//		case EmployeeType.Servant:
		//	//			employee.Bonus = 0.01m;
		//	//			break;
		//	//		case EmployeeType.AssistantToTheRegionalManager:
		//	//			employee.Bonus = 1.0m;
		//	//			break;
		//	//		default:
		//	//			throw new ArgumentOutOfRangeException();
		//	//	}
		//	//}

		//	var employee = new Employee {Type = EmployeeType.Manager};

		//	ProcessBonus(employee);

		//	Console.WriteLine(employee.Bonus);
		//	Console.ReadLine();
		//}

		//public static void ProcessBonus(Employee employee)
		//{
		//	employee.Bonus = employee.Type.BonusSize;
		//}
		#endregion
	}
}
