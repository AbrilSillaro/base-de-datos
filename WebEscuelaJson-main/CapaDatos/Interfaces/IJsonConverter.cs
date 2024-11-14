using System.Data;

namespace CapaDatos
{
    public interface IJsonConverter
    {
        string RowToJson(DataRow Dr);
        string TableToJson(DataTable Dt);
    }
}
