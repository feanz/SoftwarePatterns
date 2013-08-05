using System.Data;
using System.IO;

namespace SoftwarePatterns.Core.Adapter.Library
{
	/// <summary>
	/// This class represents some library code that uses IDbDataAdapters to fill data sets and render them,  Its used as an example of some historic code we need to work with.
	/// </summary>
	public class DataRenderer
	{
		private readonly IDbDataAdapter _dataAdapter;

		public DataRenderer(IDbDataAdapter dataAdapter)
		{
			_dataAdapter = dataAdapter;
		}

		public void Render(TextWriter writer)
		{
			writer.WriteLine("Render Data:");

			var dataSet = new DataSet();

			_dataAdapter.Fill(dataSet);

			foreach (DataTable table in dataSet.Tables)
			{
				foreach (DataColumn column in table.Columns)
				{
					writer.Write(column.ColumnName.PadRight(20) + " ");
				}
				writer.WriteLine();
				foreach (DataRow row in table.Rows)
				{
					for (var i = 0; i < table.Columns.Count; i++)
					{
						writer.Write(row[i].ToString().PadRight(20) + " ");
					}
					writer.WriteLine();
				}
			}
		}
	}
}