using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    class Prueba
    {
        static void Main()
        {
            MY_SOCCER_CONEXION x = new MY_SOCCER_CONEXION();
            USUARIO mNuevoUsuario = new USUARIO();
            mNuevoUsuario.Nombre = "NEY";
            mNuevoUsuario.Apellido = "ROJAS";
            mNuevoUsuario.Fecha_Nacimiento = DateTime.Now;
            x.USUARIO.Add(mNuevoUsuario);

        }
    }
}
