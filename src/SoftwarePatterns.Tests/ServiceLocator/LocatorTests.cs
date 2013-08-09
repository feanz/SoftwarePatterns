using System.Collections.Generic;
using SoftwarePatterns.Core.ServiceLocator;
using Xunit;

namespace SoftwarePatterns.Tests.ServiceLocator
{
	public class LocatorTests
	{
		public class ResetMethod
		{
			[Fact]
			public void ShouldRemoveAllRegisteredServices()
			{
				Locator.Register<IPackageProcessor>(() => new PackageProcessor());

				Locator.Reset();

				Assert.Throws<KeyNotFoundException>(() => Locator.Resolve<IPackageProcessor>());
			}
		}

		public class ResolveMethod
		{
			[Fact]
			public void ShouldReturnTypeRegisterd()
			{
				Locator.Register<IPackageProcessor>(() => new PackageProcessor());

				var actual = Locator.Resolve<IPackageProcessor>();

				Assert.IsAssignableFrom(typeof (IPackageProcessor), actual);
				Assert.IsAssignableFrom(typeof (PackageProcessor), actual);
			}
		}
	}
}