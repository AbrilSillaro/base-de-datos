using CapaDatos1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeNegocio
{
    internal partial class Singleton : ParentSingleton // permite utilizar métodos y atributos de la capa de datos 
    {
        static Singleton instance = new Singleton();
        private Singleton() { }
        public static Singleton GetInstance => instance;
    }
}
