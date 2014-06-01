using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Dominio;

namespace MySoccer.Pruebas
{
    class PruebaUsuarioFactory
    {
        static void Main2(string[] args)
        {
            ParametrosUsuario mParametros = new ParametrosUsuario("Ney","Rojas","neyrojas","1234","1993-02-07");
            mParametros.DatosAdministrador("neyrojas@outlook.com");
            Usuario mNuevoUsuario = UsuariosFactory.CrearUsuario(mParametros, 0);

            System.Console.WriteLine(((Administrador) mNuevoUsuario).cCorreoElectronico);
            Console.ReadLine();
        }
    }
}
