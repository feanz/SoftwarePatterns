using System;

namespace SoftwarePatterns.Core.ServiceLocator
{
	public class PackageProcessor : IPackageProcessor
	{
		public void ProcessPackage(Package package)
		{
			Console.WriteLine("Process package name {0}", package.Name);
		}
	}
}