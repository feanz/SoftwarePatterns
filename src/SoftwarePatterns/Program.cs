using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
using SoftwarePatterns.Core.Interpreter;
using SoftwarePatterns.Core.Mediator;
using SoftwarePatterns.Core.NullObject;
using SoftwarePatterns.Core.Observer.IObserver;
using SoftwarePatterns.Core.Proxy;
using SoftwarePatterns.Core.Repository;
using SoftwarePatterns.Core.Rules;
using SoftwarePatterns.Core.ServiceLocator;
using SoftwarePatterns.Core.Singleton;
using SoftwarePatterns.Core.State;
using SoftwarePatterns.Core.Strategy;
using SoftwarePatterns.Core.TemplateMethod;
using SoftwarePatterns.Core.UnitOfWork;
using SoftwarePatterns.Core.Visitor;
using WorkItem = SoftwarePatterns.Core.State.WorkItem;

namespace SoftwarePatterns
{
	class Program
	{
		public static void Main()
		{
			Rule();
		}

		#region Adapter

		public static void Adapter()
		{
			var sut = new PatternRenderer();

			var patterns = new List<Pattern>
				{
					new Pattern { ID = 1, Name = "Builder", Description = "Build stuff"},
					new Pattern { ID = 2, Name = "Adapter", Description = "Makes things fit"}
				};

			var result = sut.ListPatterns(patterns);

			Console.Write(result);

			Console.ReadLine();
		}

		#endregion

		#region Bridge

		public static void Bridge()
		{
			var formatter = new StandardFormatter();

			var documents = new List<Manuscript>();

			var book = new Book(formatter) { Title = "Title", Author = "Author", Text = "This is some text for the book that is stored in this field it can store a big old load of text in it" };
			var paper = new Paper(formatter) { Class = "A class", Student = "Phill the student", Text = "This is the papers text", References = "ref" };
			var faq = new FAQ(formatter) { Title = "FAQ" };
			faq.Questions.Add("Question One", "Answer one");
			faq.Questions.Add("Question Tow", "Answer Two");

			documents.Add(book);
			documents.Add(paper);
			documents.Add(faq);

			documents.ForEach(manuscript => manuscript.Print());

			Console.ReadLine();
		}

		#endregion

		#region Builder

		public static void Builder()
		{
			Employee employee;

			//This employee object constructor is too large
			//var employee = new EmployeeConstructorTooBig("Name","email","079871656564",Department.HR,Band.Executive,true,new List<string> {"Cert 1", "Cert 2" });

			//This method of making object gives us no control over construction process
			//var employee = new EmployeePublicProperties
			//{
			//	Name = "Name",
			//	Email = "Email",
			//	Phone = "048915646131",
			//	Department = Department.HR,
			//	Band = Band.Lower,
			//	IsFullTime = true,
			//	Certifications = new List<string>
			//	{
			//		"Cert 1",
			//		"Cert 2"
			//	}
			//};

			//we can use a director class that expects a specific employee type builder
			var builder = new ServiceDeskEmployeeBuilder();
			var director = new EmployeeDirector(builder);
			employee = director.CreateEmployee();

			employee.Display();

			Console.ReadLine();
		}

		#endregion

		#region Chain of responsability

		public static void ChainOfResponsability()
		{
			var edd = new ExpenseHandler(new ExpenseApprover("Edd", 0));
			var jill = new ExpenseHandler(new ExpenseApprover("Jill", 100));
			var barry = new ExpenseHandler(new ExpenseApprover("Barry", 1000));
			var donald = new ExpenseHandler(new ExpenseApprover("Donald", 10000));

			edd.RegisterNext(jill);
			jill.RegisterNext(barry);
			barry.RegisterNext(donald);

			var input = Console.ReadLine();

			Decimal expenseReportAmount;
			if (decimal.TryParse(input, out expenseReportAmount))
			{
				var expenseReport = new ExpenseReport(expenseReportAmount);

				var response = edd.Approve(expenseReport);

				Console.WriteLine("This request was {0}.", response);
			}

			Console.ReadLine();
		}

		#endregion

		#region Command

		public static void Command()
		{
			var factory = new CommandFactory();

			var commands = factory.AvailableCommand;

			Console.WriteLine("Commands:");
			commands.ForEach(type => Console.WriteLine(type.Name));
			Console.WriteLine();

			Console.WriteLine("What command do you want to run?");

			var arguments = Console.ReadLine();

			var command = factory.MakeCommand(arguments);

			command.Execute();

			Console.ReadLine();
		}

		#endregion

		#region Composite

		public static void Composite()
		{
			const int goldWon = 1023;

			Console.WriteLine("This is a small game sim");
			Console.WriteLine("You have killed a monster and gained {0} gold", goldWon);

			var joe = new Player { Name = "Joe" };
			var jake = new Player { Name = "Jake" };
			var emily = new Player { Name = "Emily" };
			var sophie = new Player { Name = "Sophie" };
			var brian = new Player { Name = "Brian" };
			var bob = new Player { Name = "Bob" };
			var bill = new Player { Name = "Bill" };
			var warriors = new Group { Name = "Warriors", Members = { bob, bill } };
			var questers = new Group { Name = "Questers", Members = { joe, jake, emily, warriors } };

			var parties = new Group { Members = { questers, sophie, brian } };

			parties.Gold += goldWon;
			parties.Stats();

			Console.ReadKey();
		}

		#endregion

		#region Decorator

		public static void Decorator()
		{
			Pizza largePizza = new LargePizza();
			largePizza = new Cheese(largePizza);
			largePizza = new Ham(largePizza);
			largePizza = new Peppers(largePizza);

			Console.WriteLine(largePizza.GetDescription());
			Console.WriteLine("{0:C2}", largePizza.CalculateCost());

			Console.ReadLine();
		}

		#endregion

		#region Enumeration Class

		static void Enumeration()
		{
			//to stop this sort of code
			//public void ProcessBonus(Employee employee)
			//{
			//	switch (employee.Type)
			//	{
			//		case EmployeeType.Manager:
			//			employee.Bonus = 1000m;
			//			break;
			//		case EmployeeType.Servant:
			//			employee.Bonus = 0.01m;
			//			break;
			//		case EmployeeType.AssistantToTheRegionalManager:
			//			employee.Bonus = 1.0m;
			//			break;
			//		default:
			//			throw new ArgumentOutOfRangeException();
			//	}
			//}

			var employee = new Employee { Type = EmployeeType.Manager };

			ProcessBonus(employee);

			Console.WriteLine(employee.Bonus);
			Console.ReadLine();
		}

		public static void ProcessBonus(Employee employee)
		{
			employee.Bonus = employee.Type.BonusSize;
		}

		#endregion

		#region EventAggregator

		public static void EventAggregator()
		{
			var fixture = new Fixture();
			var orders = fixture.CreateMany<Core.EventAggregator.Order>().ToList();

			//create client
			var ea = new SimpleEventAggregator();
			var client = new OrderClient(ea, orders);

			//create subscribers 
			var logger = new OrderLogger(ea);
			var view = new OrderViewModel(ea);

			var id = orders.First().Id;
			client.SelectOrder(id);
			client.SaveOrder(id);

			client.CreateOrder(1000, "Test order", "Test customer");

			Console.ReadLine();
		}

		#endregion

		#region Facade

		public static void Facade()
		{
			var facade = new TemperatureLookupFacade();
			var localTemperature = facade.GetTemperature("NE4 5PE");

			Console.WriteLine("City: {0}\n" + "Province: {1}\n" + "Celsius:{2}\n" + "Fahrenheit:{3}\n", localTemperature.City, localTemperature.Province, localTemperature.Celsius, localTemperature.Fahrenheit);
			Console.ReadLine();
		}

		#endregion

		#region Factory

		public static void Factory()
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

		#region Interpretor

		public static void Interpretor()
		{
			var patient = new Patient(new PersonalDetial { Name = "Steve", DateOFfBirth = DateTime.Now.AddYears(-55), PostCode = "NE4 2KI" },
				new IntensiveCarePatient(),
				new MedicalHistory(new List<IMedicalEvent>
				{
					new HeartAttack(),
					new Stroke()
				}),
				new Diagnosis { Descrtion = "Too many tabs" },
				new Medication(new List<Medicine>
				{
					new Medicine("Aspirin"),
					new Medicine("Warm Tea")
				}));

			patient.Interpret(new Context());

			Console.ReadLine();
		}

		#endregion

		#region Mediator

		public static void Mediator()
		{
			var controller = new AircraftController();

			var aircraft = new Boeing747("1234", 10000, controller);
			var aircraft1 = new Airbus577("4567", 8000, controller);

			aircraft.Altitude += 1000;

			Console.ReadLine();
		}

		#endregion

		#region Observer

		public static void Observer()
		{
			//Simple classic pub sub model
			//var ticker = new SimpleStockTicker();

			//var google = new GoogleStockObserver(ticker);
			//var msft = new MicrosftStockObserver(ticker);

			//ticker.RunTicker();

			//Event and delegate based approach

			//var ticker = new EventStockTicker();

			//var google = new GoogleEventStockObserver(ticker);
			//var msft = new MicrosoftEventStockObserver(ticker);

			//ticker.RunTicker();

			//using IObserver<T> 

			var ticker = new ObservableStockTicker();

			var google = new GoogleObserver();
			var msft = new MicrosoftObserver();

			using (ticker.Subscribe(google))
			using (ticker.Subscribe(msft))
			{
				ticker.RunTicker();
			}

			Console.ReadLine();
		}

		#endregion

		#region Proxy

		public static void Proxy()
		{
			var order1 = new OrderCacheRepository().GetById(1);
			var order2 = new OrderCacheRepository().GetById(1);
			var order3 = new OrderCacheRepository().GetById(1);

			Console.ReadLine();
		}

		#endregion

		#region Reposiory

		public static void Reposiory()
		{
			//would use Ioc container to define what repository is returned
			var db = new ExampleDbContext();
			var repo = new EfRepository<Project>(db);

			var project = repo.GetById(1);

			var newProject = new Project { Name = "My Special Project" };
			repo.Add(newProject);

			Console.WriteLine("Project Name: {0}", project.Name);

			project.Name = "Something else";
			db.SaveChanges();

			var getBack = repo.GetById(newProject.Id);

			Console.WriteLine("Project Name: {0}", project.Name);

			Console.WriteLine("New Project Name: {0}", getBack.Name);
			Console.ReadLine();
		}

		#endregion

		#region Rule

		public static void Rule()
		{
			var customer = new DiscountCustomer
			{
				DateOfBirth = DateTime.Now.AddYears(-32).AddDays(1),
				IsVeteran = true
			};

			var customerDiscount = new DiscountCalculator();

			var discount = customerDiscount.CalculateDiscountPercentage(customer);

			Console.WriteLine("Customer discount {0}", discount);
			Console.ReadLine();
		}

		#endregion

		#region State

		public static void State()
		{
			#region Work ITems
			var workItems = new List<WorkItem>
			{
				new WorkItem {Id = 1, Name = "Do some work", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse urna lectus, fringilla condimentum cursus eget, viverra sollicitudin diam. Ut purus ante, eleifend at tortor non, laoreet aliquet nibh. Fusce pretium enim et gravida elementum. Nulla consequat rutrum euismod. Nunc et rhoncus risus. Aenean vulputate, lorem nec tincidunt euismod, quam enim condimentum nisl, ut ullamcorper lectus mauris vel erat. Aliquam feugiat, sem vel cursus semper, enim nunc lacinia metus, ut imperdiet nulla nunc eu ante.", State = Status.Active},
				new WorkItem {Id = 2, Name = "Possible Work", Description = "Proin vel eros eu felis venenatis tempor. Donec fringilla semper lacus vehicula tristique. In ac iaculis mi. Mauris eros neque, convallis vitae eleifend sed, consectetur at sapien. Integer nec cursus erat. Suspendisse sed tincidunt nunc. Nunc laoreet a mi sit amet interdum.", State = Status.Proposed},
				new WorkItem {Id = 3, Name = "Do some work", Description = "Nam et elit justo. Proin ac lacus ante. Ut dapibus velit id arcu dignissim adipiscing. Aliquam magna diam, viverra at lectus quis, dignissim blandit enim. Etiam a augue condimentum, molestie ligula nec, pellentesque metus. Nulla quis interdum odio, non placerat nunc.", State = Status.Resolved},

			};

			#endregion

			WorkItem.Init(new WorkItemContainer(workItems));

			var newWorkItem = WorkItem.Create();

			var item1 = WorkItem.FindById(1);

			item1.Print();

			item1.Edit("Somthing else", "Short description");

			item1.SetState(Status.Resolved);

			newWorkItem.Edit("New Item name", "New description");

			newWorkItem.SetState(Status.Resolved);

			newWorkItem.SetState(Status.Active);
			newWorkItem.SetState(Status.Resolved);
			newWorkItem.Delete();
			newWorkItem.SetState(Status.Closed);
			newWorkItem.Print();
			newWorkItem.Delete();

			Console.ReadLine();
		}

		#endregion

		#region Strategy

		public static void Strategy()
		{
			var order = new ShippingOrder
			{
				Name = "Test",
				Shipping = "UPS"
			};

			//use some sort of factory to determine what strategy to execute
			var shippingCostService = new ShippingCostCalculatorService(new UPSCostCalculatorStrategy());

			shippingCostService.CalculateShippingCost(order);

			Console.WriteLine("Order shipping cost: {0}", order);
			Console.ReadLine();
		}

		#endregion

		#region Service Locator

		public static void ServiceLocator()
		{
			//register with service locator
			Locator.Register<IPackageProcessor>(() => new PackageProcessor());
			Locator.Register<IPackageShipper>(() => new PackageShipper());

			var package = new Package { ID = 1, Name = "Test Package" };

			var processor = Locator.Resolve<IPackageProcessor>();
			var shipper = Locator.Resolve<IPackageShipper>();

			processor.ProcessPackage(package);
			shipper.ShipPackage(package);

			Console.ReadLine();
		}

		#endregion

		#region Singleton

		public static void SingletonPattern()
		{
			//demo thread safe access to singleton object
			var tasks = new List<Task>
			{
				Task.Factory.StartNew(() =>
				{
					var singleTon = Singleton.Instance;

					Console.WriteLine("Task 1 Singleton value {0}, on Thread:{1}", singleTon.GlobalValue, Thread.CurrentThread.ManagedThreadId);
				}),
				Task.Factory.StartNew(() =>
				{
					var singleTon = Singleton.Instance;

					Console.WriteLine("Task 2 Singleton value {0}, on Thread:{1}", singleTon.GlobalValue, Thread.CurrentThread.ManagedThreadId);
				})
			};

			Task.WaitAll(tasks.ToArray());


			Console.ReadLine();
		}

		#endregion

		#region Template Method

		public static void TemplateMethod()
		{
			var order = new ShipOrder { ID = 1, Name = "Order One" };
			var upsShipper = new UPSShipper(order);
			var fedexShipper = new FedexShipper(order);

			upsShipper.Ship();
			fedexShipper.Ship();

			Console.ReadLine();
		}

		#endregion

		#region NullObject

		public static void NullObject()
		{
			var repo = new AutomobileRepository();

			//get null object
			var car = repo.GetAutoByName("Made up car");

			//method can be called without throwing exceptions
			car.TurnOn();
			car.TurnOff();

			if (car == AutomobileBase.Null)
				Console.WriteLine("A NUll Carr");

			Console.ReadLine();
		}

		#endregion

		#region UnitOfWork

		public static void UnitOfWork()
		{
			//would use Ioc container to define the repository factories as singleton and what RepositoryProvider to return for what IRepositoryProvider we use this approch so 
			//unit of work does not have to take all the repos as constructor params
			using (IUnitOfWork uoW = new UnitOfWork(new RepositoryProvider(new RepositoryFactories())))
			{
				//here we create a new project add a work item using a different repository and commit using our unit of work
				var newProject = new Project { Name = "My Special Project" };
				uoW.Projects.Add(newProject);
				var newWorkItem = new Core.UnitOfWork.WorkItem { Name = "Test Work Item " };

				newProject.WorkItems.Add(newWorkItem);

				uoW.Commit();

				var getBack = uoW.Projects.GetById(newProject.Id);

				Console.WriteLine("New Project Name: {0}", getBack.Name);

				Console.WriteLine("New WorkItem Name: {0}", getBack.WorkItems.First().Name);

				Console.ReadLine();
			}
		}

		#endregion

		#region Visitor

		public static void Visitor()
		{
			var banksAccounts = new List<BankAccount>
			{
				new BankAccount { Amount = 4568, MonthlyInterest = 4.2m},
				new BankAccount { Amount = 106, MonthlyInterest = 4.2m},
				new BankAccount { Amount = 2145, MonthlyInterest = 4.2m}
			};

			var loans = new List<Loan>
			{
				new Loan { Owed = 4000, MonthlyPayments = 40}
			};

			var realEstates = new List<RealEstate>
			{
				new RealEstate { EstimatedValue = 79000, MonthlyRepayments = 500}
			};

			var person = new Person();
			person.Assets.AddRange(banksAccounts);
			person.Assets.AddRange(loans);
			person.Assets.AddRange(realEstates);


			var visitor = new NetWorthVisitor();

			int netWorth = 0;

			//options 1
			banksAccounts.ForEach(account => netWorth += account.Amount);
			loans.ForEach(loan => netWorth -= loan.Owed);
			realEstates.ForEach(estate => netWorth += estate.EstimatedValue);

			//option 2
			person.Assets.ForEach(asset => asset.Accept(visitor));


			Console.WriteLine("Networth: {0}", netWorth);
			Console.WriteLine("Networth: {0}", visitor.Networth);
			Console.ReadLine();
		}

		#endregion
	}
}

