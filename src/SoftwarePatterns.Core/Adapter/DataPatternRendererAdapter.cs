using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using SoftwarePatterns.Core.Adapter.Library;

namespace SoftwarePatterns.Core.Adapter
{
	public class DataPatternRendererAdapter : IDataPatternRendererAdapter
	{
		public string ListPatterns(IEnumerable<Pattern> patterns)
		{
			var dataRenderer = new DataRenderer(new IEnumerableDbAdapter<Pattern>(patterns));
			var writer = new StringWriter();
			dataRenderer.Render(writer);

			return writer.ToString();
		}

		internal class IEnumerableDbAdapter<T> : IDbDataAdapter
		{
			private readonly IEnumerable<T> collection;

			public IEnumerableDbAdapter(IEnumerable<T> collection)
			{
				this.collection = collection;
			}

			public int Fill(DataSet dataSet)
			{
				var dataTable = collection.ToDataTable();
				dataSet.Tables.Add(dataTable);
				dataSet.AcceptChanges();

				return collection.Count();
			}

			#region Not Implmented
			public DataTable[] FillSchema(DataSet dataSet, SchemaType schemaType)
			{
				throw new System.NotImplementedException();
			}

			public IDataParameter[] GetFillParameters()
			{
				throw new System.NotImplementedException();
			}

			public int Update(DataSet dataSet)
			{
				throw new System.NotImplementedException();
			}

			public MissingMappingAction MissingMappingAction { get; set; }
			public MissingSchemaAction MissingSchemaAction { get; set; }
			public ITableMappingCollection TableMappings { get; private set; }
			public IDbCommand SelectCommand { get; set; }
			public IDbCommand InsertCommand { get; set; }
			public IDbCommand UpdateCommand { get; set; }
			public IDbCommand DeleteCommand { get; set; }
			#endregion
		}
	}
}