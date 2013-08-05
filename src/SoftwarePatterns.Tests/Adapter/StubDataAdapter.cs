using System.Data;

namespace SoftwarePatterns.Tests.Adapter
{
	public class StubDataAdapter : IDbDataAdapter
	{
		public int Fill(DataSet dataSet)
		{
			var dataTable = new DataTable();
			dataTable.Columns.Add(new DataColumn("Id", typeof (int)));
			dataTable.Columns.Add(new DataColumn("Name", typeof (string)));
			dataTable.Columns.Add(new DataColumn("Description", typeof (string)));

			var dataRow = dataTable.NewRow();
			dataRow[0] = 1;
			dataRow[1] = "Adapter";
			dataRow[2] = "Adapter Description";

			dataTable.Rows.Add(dataRow);
			dataSet.Tables.Add(dataTable);
			dataSet.AcceptChanges();
			return 1;
		}


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
	}
}