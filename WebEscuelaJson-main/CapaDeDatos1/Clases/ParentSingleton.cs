
namespace CapaDatos1
{
    public class ParentSingleton // se accede a la capa de negocios 
    {
        public IConnection IConnection => Connection.GetInstance;  // permite acceder a la conexion 

        public IJsonConverter IJsonConverter
        {
            get => new JsonConverter();
        }
    }
}
