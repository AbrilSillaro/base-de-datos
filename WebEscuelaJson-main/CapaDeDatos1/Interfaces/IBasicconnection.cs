using System.Data.SqlClient;


namespace CapaDatos1
{
    public interface IBasicconnection
    {
        SqlConnection MyConnection { get; set; }
        SqlCommand MyCommand { get; set; }
        string Referente { get; set; }
        string ConnectionString { get; set; }
        void OpenConnection();
    }
}

