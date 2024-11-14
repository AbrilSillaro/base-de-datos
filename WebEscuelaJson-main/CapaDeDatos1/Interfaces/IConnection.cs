using System.Data;

namespace CapaDatos1
{
    public interface IConnection : IParameters
    {
        void CreateCommand(string storeprocedure, string referente);
        int Insert();
        void InsertWithoutID();
        bool Exists();
        void Update();
        void Delete();
        DataTable List();
        DataRow Find();
    }
}
