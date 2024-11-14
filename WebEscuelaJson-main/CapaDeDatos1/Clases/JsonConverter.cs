using System.Collections.Generic;
using System.Data;
using System.Text.Json;


namespace CapaDatos1
{
    public class JsonConverter : IJsonConverter
    {
        public string RowToJson(DataRow row) // se convierte una fila en un json
        {
            var rowDict = new Dictionary<string, object>();  // se crea un diccionario

            foreach (DataColumn column in row.Table.Columns)
            {
                rowDict.Add(column.ColumnName, row[column]); // agrega el dato al diccionario. almacena nombre,mail, id y dni 
            }

            var jsonRow = JsonSerializer.Serialize(rowDict); // serealiza el diccionario 

            return jsonRow; // devuelve un json
        }

        public string TableToJson(DataTable dt)
        {
            List<Dictionary<string, object>> ListDict = new List<Dictionary<string, object>>(); // crea una lista para almacenar datos de cada celda de la tabla
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> rowDict = new Dictionary<string, object>(); // por cada fila se crea un diccionario 

                foreach (DataColumn column in dt.Columns)
                {
                    rowDict.Add(column.ColumnName, row[column]); // agrega el valor del dato
                }
                ListDict.Add(rowDict); // se agrega el diccionario a la lista
            }

            string JsonList = JsonSerializer.Serialize(ListDict); 

            return JsonList;
        }
    }
}

