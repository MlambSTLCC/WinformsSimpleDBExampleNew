using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace Hold
{
    class SimpleDB
    {
        public string FilePath { get; set; }
        public DataSet Ds { get; set; }

        private string filePath = Assembly.GetExecutingAssembly().Location
            .ToString().Replace(".exe", "_Data.xml");

        public SimpleDB(DataSet ds = null, string p_filePath = "")
        {
            this.Ds = ds;
            if (p_filePath.Length > 0)
                this.FilePath = p_filePath;
            else
                this.FilePath = filePath;
        }

        public int Insert(ref DataTable dt, Dictionary<string, object> dictValues)
        {
            var insertRow = dt.Rows.Add();

            // Will not error out if column name <> dictionary property value:
            foreach (DataColumn dc in dt.Columns)
                if (dictValues.ContainsKey(dc.ColumnName))
                    insertRow[dc.ColumnName] = dictValues[dc.ColumnName];

            return (int)insertRow[0];
        }

        public void Update(ref DataTable dt, Dictionary<string, object> dictValues)
        {
            var keyColumnName = dt.Columns[0].ColumnName;
            if (!dictValues.ContainsKey(keyColumnName))
                return;

            var updateRow = dt.Rows.Find(new object[] { (int)dictValues[keyColumnName] });

            if (updateRow == null)
                return;

            // Will not error out if column name <> dictionary property value:
            foreach (DataColumn dc in dt.Columns)
                if (dictValues.ContainsKey(dc.ColumnName)
                    && dc.ColumnName != keyColumnName)  // don't update key!
                    updateRow[dc.ColumnName] = dictValues[dc.ColumnName];
        }

        public void Delete(ref DataTable dt, int id)
        {
            var deleteRow = dt.Rows.Find(id);

            if (deleteRow != null)
                dt.Rows.Remove(deleteRow);
        }

        public void Save()
        {
            try
            {
                Ds.WriteXml(FilePath, XmlWriteMode.WriteSchema);
                Ds.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Load()
        {
            try
            {
                Ds.ReadXml(FilePath);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable CreateIdentityColumnTable(string tableName)
        {
            var dt = new DataTable(tableName);

            DataColumn keyColumn = dt.Columns.Add("Id", typeof(Int32));
            keyColumn.AutoIncrement = true;
            keyColumn.AutoIncrementSeed = 1;
            keyColumn.AutoIncrementStep = 1;
            keyColumn.ReadOnly = true;

            // Set the primary key to the identity column
            dt.PrimaryKey = new DataColumn[] { keyColumn };

            return dt;
        }
    }
}
