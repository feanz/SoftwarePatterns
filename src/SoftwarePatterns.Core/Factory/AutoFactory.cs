using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SoftwarePatterns.Core.Factory
{
	public class AutoFactory
	{
		private Dictionary<string, Type> autos;

		public AutoFactory()
		{
			LoadTypeCanReturn();
		}

		public IAuto Create(string name)
		{
			var t = GetTypeToCreate(name) ?? typeof(NullAuto);

			return Activator.CreateInstance(t) as IAuto;
		}

		private Type GetTypeToCreate(string name)
		{
			return autos
				.Where(pair => pair.Key.Contains(name.ToLowerInvariant()))
				.Select(pair => autos[pair.Key])
				.FirstOrDefault();
		}

		private void LoadTypeCanReturn()
		{
			autos = new Dictionary<string, Type>();

			var types = Assembly.GetExecutingAssembly().GetTypes()
				.Where(type => type.GetInterface(typeof (IAuto).ToString()) != null);

			types.ForEach(type => autos.Add(type.Name.ToLowerInvariant(),type));
		}
	}
}