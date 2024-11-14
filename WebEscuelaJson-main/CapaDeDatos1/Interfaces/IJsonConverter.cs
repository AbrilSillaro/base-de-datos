using System.Data;

namespace CapaDatos1
{
    public interface IJsonConverter
    {
        string RowToJson(DataRow Dr);
        string TableToJson(DataTable Dt);
    }
}

