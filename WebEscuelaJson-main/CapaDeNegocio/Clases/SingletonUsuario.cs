using CapaDatos1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    internal partial class Singleton : ISingletonUsuario
    {
        public ISingletonUsuario ISU { get => this; } // devuelve un objeto que implemente la interfaz


        #region IGenericSingletonUsuario
        void IGenericSingleton<Usuario>.Add(Usuario Data)
        {
            if (Data.DniExist()) throw new Exception("Existe otro usuario con el mismo Dni");
            if (Data.MailExist()) throw new Exception("Existe otro usuario con el mismo Mail");

            IConnection.CreateCommand("Usuarios_Insert", "Usuario");
            IConnection.ParameterAddVarChar("Nombre", Data.Nombre);
            IConnection.ParameterAddInt("Dni", Data.Dni);
            IConnection.ParameterAddVarChar("Mail", Data.Mail);
            Data.ID = IConnection.Insert();
        }

        void IGenericSingleton<Usuario>.Erase(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Delete", "Usuarios");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.Delete();
        }

        string IGenericSingleton<Usuario>.Find(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_Find", "Usuario");
            IConnection.ParameterAddInt("ID", Data.ID);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }

        void IGenericSingleton<Usuario>.Modify(Usuario Data)
        {
            if (Data.DniExist()) throw new Exception("");
            if (Data.MailExist()) throw new Exception("");

            IConnection.CreateCommand("Usuarios_Update", "Usuario");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.ParameterAddVarChar("Nombre", Data.Nombre);
            IConnection.ParameterAddInt("Dni", Data.Dni);
            IConnection.ParameterAddVarChar("Mail", Data.Mail);
            IConnection.Update();
        }
        #endregion

        #region SingletonUsuario
        public string FindByDni(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByDni", "Usuario");
            IConnection.ParameterAddInt("Dni", Data.Dni);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }

        string ISingletonUsuario.FindByMail(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_FindByMail", "Usuario");
            IConnection.ParameterAddVarChar("Mail",Data.Mail);
            DataRow Dr = IConnection.Find();
            return IJsonConverter.RowToJson(Dr);
        }

        string ISingletonUsuario.List()
        {
            try
            {
                IConnection.CreateCommand("Usuarios_List", "Usuario");
                DataTable Dt = IConnection.List();
                return IJsonConverter.TableToJson(Dt);
            }
            catch (Exception)
            {
                throw new Exception("ERROR: No se pudo listar los alumnos");
            }
        }

        string ISingletonUsuario.Login(Usuario Data)
        {
            throw new NotImplementedException();
        }

        bool ISingletonUsuario.MailExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_MailExists", "Usuarios");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.ParameterAddVarChar("Mail", Data.Mail);
            return IConnection.Exists();
        }
        bool ISingletonUsuario.DniExists(Usuario Data)
        {
            IConnection.CreateCommand("Usuarios_DniExists", "Usuario");
            IConnection.ParameterAddInt("ID", Data.ID);
            IConnection.ParameterAddInt("Dni", Data.Dni);
            return IConnection.Exists();
        }
        #endregion
    }
}
