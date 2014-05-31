using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Dominio;
using MySoccer.GUI.Models;

namespace MySoccer.Presentador
{
    public class prePresentador
    {
        private AdministrarUsuario cAdministrarCuentas;

        public prePresentador(){
            this.cAdministrarCuentas = new AdministrarUsuario();
        }
        //Entrda: PDatosCuenta son los datos que todo usuario debe de tener
        //Salida: Vacia
        //Descripcion: Crea una instancia de ParametrosUsuario y le introduce lo datos a un PArametro que se usa para crear calses,
        public ParametrosUsuario ColocarDatosCuenta(guiModeloUsuario pDatosCuenta)
        {
            return new ParametrosUsuario(pDatosCuenta.cNombre, pDatosCuenta.cApellido, 
                pDatosCuenta.cNombreUsuario, pDatosCuenta.cContrasena, pDatosCuenta.cFechaNacimiento);
        }

        //Entrda: PDatosNuevoUsuario contiene los datos ingresados por el usuario para registrar un administrador
        //Salida: Vacia
        //Descripcion: Toma los datos entregados por el controller y los pasa a parameter que lo entiende administrar cuenta
        public void AgregarNuevoUsuario(guiModeloAdministrador pDatosNuevoUsuario)
        {
            ParametrosUsuario mParametros = ColocarDatosCuenta((guiModeloUsuario) pDatosNuevoUsuario);
            mParametros.DatosAdministrador(pDatosNuevoUsuario.cCorreoElectronico);

            this.cAdministrarCuentas.AgregarAdministrador(mParametros);
 
       }

        //Entrda: PDatosNuevoUsuario contiene los datos ingresados por el usuario para registrar un fantico
        //Salida: Vacia
        //Descripcion: Toma los datos entregados por el controller y los pasa a parameter que lo entiende administrar cuenta
        public void AgregarNuevoUsuario(guiModeloFanatico pDatosNuevoUsuario)
        {
            
            ParametrosUsuario mParametros = ColocarDatosCuenta((guiModeloUsuario)pDatosNuevoUsuario);
            mParametros.DatosFanatico( Int32.Parse(pDatosNuevoUsuario.cGenero), pDatosNuevoUsuario.cDescripcion,
            pDatosNuevoUsuario.cCorreoElectronico, pDatosNuevoUsuario.cPais,Int32.Parse(pDatosNuevoUsuario.cEquipo),
            pDatosNuevoUsuario.cRutaImagen);

            this.cAdministrarCuentas.AgregarFanatico(mParametros);

        }
        //Entrda: PDatosNuevoUsuario contiene los datos ingresados por el usuario para registrar un narrador
        //Salida: Vacia
        //Descripcion: Toma los datos entregados por el controller y los pasa a parameter que lo entiende administrar cuenta
        public void AgregarNuevoUsuario(guiModeloNarrador pDatosNuevoUsuario)
        {
            ParametrosUsuario mParametros = ColocarDatosCuenta((guiModeloUsuario)pDatosNuevoUsuario);
            mParametros.DatosNarrador(Int32.Parse(pDatosNuevoUsuario.cGenero), pDatosNuevoUsuario.cDescripcion,
            Int32.Parse(pDatosNuevoUsuario.cAnosExperiencia), pDatosNuevoUsuario.cRutaImagen);

            this.cAdministrarCuentas.AgregarNarrador(mParametros);
        }
    }
}
