using Ploeh.AutoFixture;
using SoftwarePatterns.Core.Builder;
using Xunit;

namespace SoftwarePatterns.Tests.Builder
{
	public class ServiceDeskEmployeeBuilderTests
	{
		public class CreateEmployeeMethod
		{
			[Fact]
			public void ShouldAddEmployeeToServiceDeskDepartment()
			{
				var fixture = new Fixture();
				var builder = fixture.Create<ServiceDeskEmployeeBuilder>();
				var director = new EmployeeDirector(builder);

				var employee = director.CreateEmployee();

				Assert.Equal(Department.ServiceDesk, employee.Department);
			}
		}
	}
}