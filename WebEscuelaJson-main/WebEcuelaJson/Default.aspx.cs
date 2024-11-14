using System;
using CapaDeNegocio;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["accion"] == null) return;
        switch (Request["accion"])
        {

            case "ADDUSUARIO": AddUsuario(); break;
            case "LISTUSUARIOS": ListUsuarios(); break;
            case "DELETEUSER": DeleteUser(); break;
            case "MODIFYUSER": ModifyUser(); break;
            case "FINDUSER": FindUser(); break;
            default:
                Response.Write("Invalid action");
                break;
        }
    }

    private void AddUsuario()
    {
        Usuario U = new Usuario();
        U.Nombre = Request["Nombre"];
        U.Mail = Request["Mail"];
        U.Dni = int.Parse(Request["Dni"]);
        try
        {
            U.Add();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }

    }
    private void ListUsuarios()
    {
        Usuario U = new Usuario();
        string lista = U.List();
        Response.Write(lista);

    }

    private void DeleteUser()
    {
        Usuario U = new Usuario();
        U.ID = int.Parse(Request["ID"]);

        try
        {
            U.Erase();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }
    }

    private void ModifyUser()
    {
        Usuario U = new Usuario();

        U.ID = int.Parse(Request["ID"]);
        U.Nombre = Request["Nombre"];
        U.Dni = int.Parse(Request["Dni"]);
        U.Mail = Request["Mail"];
        try
        {
            U.Modify();
            Response.Write("OK");
        }
        catch (Exception er)
        {
            Response.Write(er.Message);
        }

    }

    private void FindUser()
    {
        Usuario U = new Usuario();
        U.ID = int.Parse(Request["ID"]);

        try
        {
            string user = U.Find();
            Response.Write(user);
        }
        catch (Exception er)
        { 
            Response.Write(er.Message); 
        }
    }
} 

