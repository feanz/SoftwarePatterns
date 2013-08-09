using System;

namespace SoftwarePatterns.Core.ServiceLocator
{
	public interface IPackageShipper
	{
		void ShipPackage(Package package);
	}

	public class PackageShipper : IPackageShipper
	{
		public void ShipPackage(Package package)
		{
			Console.WriteLine("Ship package name {0}", package.Name);
		}
	}
}