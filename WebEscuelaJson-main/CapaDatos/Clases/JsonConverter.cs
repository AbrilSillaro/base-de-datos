using System.Collections.Generic;
using System.Data;
using System.Text.Json;


namespace CapaDatos
{
    public class JsonConverter : IJsonConverter
    {
        public string RowToJson(DataRow row)
        {
            var rowDict = new Dictionary<string, object>();

            foreach (DataColumn column in row.Table.Columns)
            {
                rowDict.Add(column.ColumnName, row[column]);
            }

            var jsonRow = JsonSerializer.Serialize(rowDict);
            return jsonRow;
        }

        public string TableToJson(DataTable dt)
        {
            List<Dictionary<string,object>> ListDict = new List<Dictionary<string,object>>();
            foreach(DataRow row in dt.Rows)
            {
                Dictionary<string, object> rowDict = new Dictionary<string, object>();
                
                foreach (DataColumn column in dt.Columns)
                {
                    rowDict.Add(column.ColumnName, row[column]);
                }
                ListDict.Add(rowDict);
            }

            string JsonList = JsonSerializer.Serialize(ListDict);
            return JsonList;
        }
    }
}
