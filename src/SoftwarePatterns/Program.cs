using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Ploeh.AutoFixture;
using SoftwarePatterns.Core;
using SoftwarePatterns.Core.Adapter;
using SoftwarePatterns.Core.Bridge;
using SoftwarePatterns.Core.Builder;
using SoftwarePatterns.Core.ChainOfResponsability;
using SoftwarePatterns.Core.Command;
using SoftwarePatterns.Core.Composite;
using SoftwarePatterns.Core.Decorator;
using SoftwarePatterns.Core.EnumerationClass;
using SoftwarePatterns.Core.EventAggregator;
using SoftwarePatterns.Core.Facade;
using SoftwarePatterns.Core.Factory;

namespace SoftwarePatterns
{
	class Program
	{
		#region Adapter

		//public static void Main()
		//{
		//	var sut = new PatternRenderer();

		//	var patterns = new List<Pattern>
		//		{
		//			new Pattern { ID = 1, Name = "Builder", Description = "Build stuff"},
		//			new Pattern { ID = 2, Name = "Adapter", Description = "Makes things fit"}
		//		};

		//	var result = sut.ListPatterns(patterns);

		//	Console.Write(result);

		//	Console.ReadLine();
		//}

		#endregion

		#region Bridge

		//public static void Main()
		//{
		//	var formatter = new StandardFormatter();

		//	var documents = new List<Manuscript>();

		//	var book = new Book(formatter) {Title = "Title", Author = "Author", Text = "This is some text for the book that is stored in this field it can store a big old load of text in it"};
		//	var paper = new Paper(formatter) {Class = "A class", Student = "Phill the student", Text = "This is the papers text", References = "ref"};
		//	var faq = new FAQ(formatter) {Title = "FAQ"};
		//	faq.Questions.Add("Question One", "Answer one");
		//	faq.Questions.Add("Question Tow", "Answer Two");

		//	documents.Add(book);
		//	documents.Add(paper);
		//	documents.Add(faq);

		//	documents.ForEach(manuscript => manuscript.Print());

		//	Console.ReadLine();
		//}

		#endregion

		#region Builder
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

		#region Command

		//public static void Main(string[] args)
		//{
		//	var factory = new CommandFactory();

		//	var commands = factory.AvailableCommand;

		//	Console.WriteLine("Commands:");
		//	commands.ForEach(type => Console.WriteLine(type.Name));
		//	Console.WriteLine();

		//	Console.WriteLine("What command do you want to run?");

		//	var arguments = Console.ReadLine();

		//	var command = factory.MakeCommand(arguments);

		//	command.Execute();

		//	Console.ReadLine();
		//}

		#endregion

		#region Composite

		//public static void Main()
		//{
		//	const int goldWon = 1023;

		//	Console.WriteLine("This is a small game sim");
		//	Console.WriteLine("You have killed a monster and gained {0} gold", goldWon);

		//	var joe = new Player { Name = "Joe" };
		//	var jake = new Player { Name = "Jake" };
		//	var emily = new Player { Name = "Emily" };
		//	var sophie = new Player { Name = "Sophie" };
		//	var brian = new Player { Name = "Brian" };
		//	var bob = new Player { Name = "Bob" };
		//	var bill = new Player { Name = "Bill" };
		//	var warriors = new Group { Name = "Warriors", Members = { bob, bill } };
		//	var questers = new Group { Name = "Questers", Members = { joe, jake, emily, warriors } };

		//	var parties = new Group { Members = { questers, sophie, brian } };

		//	parties.Gold += goldWon;
		//	parties.Stats();

		//	Console.ReadKey();
		//}

		#endregion

		#region Decorator

		//public static void Main()
		//{
		//	Pizza largePizza = new LargePizza();
		//	largePizza = new Cheese(largePizza);
		//	largePizza = new Ham(largePizza);
		//	largePizza = new Peppers(largePizza);

		//	Console.WriteLine(largePizza.GetDescription());
		//	Console.WriteLine("{0:C2}", largePizza.CalculateCost());

		//	Console.ReadLine();
		//}

		#endregion

		#region EventAggregator

		//public static void Main()
		//{
		//	var fixture = new Fixture();
		//	var orders = fixture.CreateMany<Order>().ToList();

		//	//create client
		//	var ea = new SimpleEventAggregator();
		//	var client = new OrderClient(ea, orders);

		//	//create subscribers 
		//	var logger = new OrderLogger(ea);
		//	var view = new OrderViewModel(ea);

		//	var id = orders.First().Id;
		//	client.SelectOrder(id);
		//	client.SaveOrder(id);

		//	client.CreateOrder(1000, "Test order", "Test customer");

		//	Console.ReadLine();
		//}

		#endregion

		#region Facade

		//public static void Main()
		//{
		//	var facade = new TemperatureLookupFacade();
		//	var localTemperature = facade.GetTemperature("NE4 5PE");

		//	Console.WriteLine("City: {0}\n" + "Province: {1}\n" + "Celsius:{2}\n" + "Fahrenheit:{3}\n", localTemperature.City, localTemperature.Province, localTemperature.Celsius, localTemperature.Fahrenheit);
		//	Console.ReadLine();
		//}

		#endregion

		#region Factory

		public static void Main()
		{
			Console.WriteLine("Select a car");

			var carName = Console.ReadLine();

			var factory = new AutoFactory();

			var car = factory.Create(carName);

			car.TurnOn();
			car.TurnOff();

			Console.ReadLine();
		}

		#endregion

		#region Chain of responsability

		//public static void Main()
		//{
		//	var edd = new ExpenseHandler(new ExpenseApprover("Edd", 0));
		//	var jill = new ExpenseHandler(new ExpenseApprover("Jill", 100));
		//	var barry = new ExpenseHandler(new ExpenseApprover("Barry", 1000));
		//	var donald = new ExpenseHandler(new ExpenseApprover("Donald", 10000));

		//	edd.RegisterNext(jill);
		//	jill.RegisterNext(barry);
		//	barry.RegisterNext(donald);

		//	var input = Console.ReadLine();

		//	Decimal expenseReportAmount;
		//	if (decimal.TryParse(input, out expenseReportAmount))
		//	{
		//		var expenseReport = new ExpenseReport(expenseReportAmount);

		//		var response = edd.Approve(expenseReport);

		//		Console.WriteLine("This request was {0}.", response);
		//	}

		//	Console.ReadLine();
		//}

		#endregion

		#region Enumeration Class

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
