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
            //Pruebas para crear usuarios
            //datUsuariosBaseDatos mPruebaConexion = new datAdministradorBaseDatos();
            //int idNuevoUsuario = mPruebaConexion.AgregarUsuario("Ney", "Rojas", Convert.ToDateTime("07/02/1993"));
            //mPruebaConexion.AgregarCuenta(idNuevoUsuario, "neyrojas", "1234", DateTime.Now, true);
            //mPruebaConexion.VerBaseDatos();

            //Pruebas para agregar paises 
            datPaisBaseDatos mPruebaPais = new datPaisBaseDatos();
            //mPruebaPais.AgregarPais("Costa Rica");
            //mPruebaPais.AgregarPais("Japón");
            //mPruebaPais.AgregarPais("Brasil");
            //mPruebaPais.AgregarPais("Uruguay");
            mPruebaPais.GetPaises();

            //Pruebas para agregar equipos 
            datEquipoBaseDatos mPruebaEquipo = new datEquipoBaseDatos();
            //mPruebaEquipo.AgregarEquipo(19, "", DateTime.Now, "COSTARRICENSE");
            //mPruebaEquipo.AgregarEquipo(20, "", DateTime.Now, "NIPPON");
            //mPruebaEquipo.AgregarEquipo(21, "", DateTime.Now, "BRAILEÑO");
            //mPruebaEquipo.AgregarEquipo(22, "", DateTime.Now, "URUGUAYO");
            mPruebaEquipo.GetEquipos();

            System.Console.WriteLine("EL ID DEL NUEVO USUARIO ES EL SIGUIENTE ");
            Console.ReadLine();
        }
    }
}
