using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;
using MySoccer.Datos.GestionarCalendario;

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
            mPruebaPais.AgregarPais("Costa Rica");
            mPruebaPais.AgregarPais("Japón");
            mPruebaPais.AgregarPais("Brasil");
            mPruebaPais.AgregarPais("Uruguay");
            mPruebaPais.AgregarPais("Panamá");
            mPruebaPais.AgregarPais("China");
            mPruebaPais.GetPaises();

//            Pruebas para agregar equipos 
            datEquipoBaseDatos mPruebaEquipo = new datEquipoBaseDatos();
            mPruebaEquipo.AgregarEquipo(1,1, "", DateTime.Now, "COSTARRICENSE");
            mPruebaEquipo.AgregarEquipo(2,2, "", DateTime.Now, "NIPPON");
            mPruebaEquipo.AgregarEquipo(3,3, "", DateTime.Now, "BRAILEÑO");
            mPruebaEquipo.AgregarEquipo(4,4, "", DateTime.Now, "URUGUAYO");
            mPruebaEquipo.GetEquipos();

            //Pruebas para agregar sedes
            datSedeBaseDatos mPruebaSede = new datSedeBaseDatos();
            mPruebaSede.AgregarSede("Francia");
            mPruebaSede.AgregarSede("Brasil");
            mPruebaSede.AgregarSede("Costa Rica");
            mPruebaSede.AgregarSede("México");
            mPruebaSede.GetSedes();

            System.Console.WriteLine("EL ID DEL NUEVO USUARIO ES EL SIGUIENTE ");
            Console.ReadLine();
        }
    }
}
