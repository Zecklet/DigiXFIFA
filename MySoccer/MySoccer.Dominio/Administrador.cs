using MySoccer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Administrador : Usuario
    {
        public Administrador(String pCorreoElectronico)
        {
            this.cCorreoElectronico = pCorreoElectronico;
            this.cIDTipo = datConstantes.kUsuarioAdministrador;
        }

        public Administrador()
        {
        }
        public String cCorreoElectronico { get; set; }


        public override void CrearTipoUsuarioBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datAdministradorBaseDatos();
            ((datAdministradorBaseDatos)mConexionBase).AgregarAdministrador(this.cIdentificador, this.cCorreoElectronico);
        }

        public override void RecuperarDatosBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datAdministradorBaseDatos();
            ADMINISTRADOR mAdministrador = ((datAdministradorBaseDatos)mConexionBase).ObtenerAdministrador(this.cIdentificador);
            this.cCorreoElectronico = mAdministrador.Correo_Electronico;
            this.cIDTipo = datConstantes.kUsuarioAdministrador;
        }
    }
}
