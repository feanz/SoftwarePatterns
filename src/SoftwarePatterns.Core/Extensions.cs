using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace SoftwarePatterns.Core
{
	public static class Extensions
	{
		public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
		{
			foreach (var c in collection)
			{
				action(c);
			}
		}

		public static void ForEach<T>(this IEnumerable<T> collection, Action<T, int> action)
		{
			var i = 0;
			foreach (var c in collection)
			{
				action(c, i++);
			}
		}

		public static DataTable ToDataTable<T>(this IEnumerable<T> data)
		{
			var properties = TypeDescriptor.GetProperties(typeof(T));
			var table = new DataTable();

			foreach (var prop in properties.Cast<PropertyDescriptor>())
			{
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			}

			foreach (var item in data)
			{
				var row = table.NewRow();
				foreach (var prop in properties.Cast<PropertyDescriptor>())
				{
					row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
				}
				table.Rows.Add(row);
			}
			return table;
		}

	}
}