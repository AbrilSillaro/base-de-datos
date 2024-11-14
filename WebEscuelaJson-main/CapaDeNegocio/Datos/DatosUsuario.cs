using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


namespace CapaDeNegocio
{
    internal partial class Datos : IParentSingleton<Usuario>
    {
        private static List<Usuario> listaUsuarios;
        private static int lastId;
        private static void Read()
        {

            try {
                
                string pathBase = AppDomain.CurrentDomain.BaseDirectory;
                string path = pathBase + "..\\Users\\user\\OneDrive\\Escritorio\\WebEscuelaJson-main\\WebEscuelaJson-main\\CapaDeNegocio\\Datos\\usuarios.json";
                string json= File.ReadAllText(path);    
                listaUsuarios=JsonSerializer.Deserialize <List<Usuario>>(json);
            }
            catch  (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Write()
        {

            try
            {
                string pathBase = AppDomain.CurrentDomain.BaseDirectory;
                string path= pathBase + "..\\Users\\user\\OneDrive\\Escritorio\\WebEscuelaJson-main\\WebEscuelaJson-main\\CapaDeNegocio\\Datos\\usuarios.json";
                string json=JsonSerializer.Serialize(listaUsuarios);
                File.WriteAllText(path, json);
                                            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Clear()
        {
            listaUsuarios.Clear();
        }
        public void Add(Usuario data)
        {
            Read();
            string pathBase = AppDomain.CurrentDomain.BaseDirectory;
            string pathID = pathBase + " ..\\Users\\user\\OneDrive\\Escritorio\\WebEscuelaJson - main\\WebEscuelaJson - main\\CapaDeNegocio\\Datos\\usuarioLastid.txt";
            lastId = int.Parse(File.ReadAllText(pathID));
            data.ID=++lastId;
            File.WriteAllText(pathID, lastId.ToString()); // guarda el ultimo ID en el archivo de texto
            listaUsuarios.Add(data);
            Write();
            Clear();

        
        
        
        }

        public void Erase(Usuario data)
        {
            Read();
            foreach(Usuario u in listaUsuarios)
            {
                if(data.ID==u.ID)
                {
                    listaUsuarios.Remove(data);
                    Write() ;
                    Clear();
                    return;


                }

            }
            Clear();
            throw new Exception("No se encontró el usuario a elimnar");



        }

        public Usuario Find(Usuario data)
        {
            Read();
            foreach (Usuario u in listaUsuarios)
            {
                if (data.ID == u.ID)
                {
                    Clear();
                    return u;
                    
                }

            }
            Clear();
            throw new Exception("No se encontró el usuario");
        }

        public void Modify(Usuario data)
        {
            Read();
            for (int i = 0; i < listaUsuarios.Count; i++)
            {
                if (listaUsuarios[i].ID == data.ID)
                {
                    listaUsuarios[i].Nombre = data.Nombre;
                    Write();
                    Clear();
                    return;

                }
            }
            throw new Exception("No se puede modificar el Usuario: no se encuentra en la lista");
            

        }

        public string List()
        {
            Read();
            string json = JsonSerializer.Serialize(listaUsuarios);
            return json;
        }
    }
}
