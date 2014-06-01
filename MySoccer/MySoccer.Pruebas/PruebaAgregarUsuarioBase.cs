using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;

namespace MySoccer.Pruebas
{
    class PruebaAgregarUsuarioBase
    {
        static void Main(string[] args)
        {
            datUsuariosBaseDatos mPruebaConexion = new datAdministradorBaseDatos();
            //int idNuevoUsuario = mPruebaConexion.AgregarUsuario("Ney", "Rojas", Convert.ToDateTime("07/02/1993"));
            //mPruebaConexion.AgregarCuenta(idNuevoUsuario, "neyrojas", "1234", DateTime.Now, true);

            mPruebaConexion.VerBaseDatos();

            System.Console.WriteLine("EL ID DEL NUEVO USUARIO ES EL SIGUIENTE ");
            Console.ReadLine();
        }
    }
}
