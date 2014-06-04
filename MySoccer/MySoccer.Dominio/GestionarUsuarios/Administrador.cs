using MySoccer.Datos;
using MySoccer.EjeTransversal;
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
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioAdministrador;
        }

        public Administrador()
        {
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioAdministrador;
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
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioAdministrador;
        }
        public override Dictionary<String, String> GetDatos()
        {
            Dictionary<String, String> mDatosRetorno = GetDatosUsuario();

            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringCorreoElectronico, this.cCorreoElectronico);

            return mDatosRetorno;
        }

        public void CambiarDatosAdministrador(String pCorrecoElectronico)
        {
            this.cCorreoElectronico = pCorrecoElectronico;
        }

        public override void ActualizarDatos(Dictionary<String, String> pNuevoDatos)
        {
            this.cCorreoElectronico = pNuevoDatos[ConstantesGestionarUsuarios.kStringCorreoElectronico];
        }

        public override void ActualizarDatosBaseDatos()
        {
            this.ActualizarCuentaBaseDatos();
            this.ActualizarUsuarioBaseDatos();

            datUsuariosBaseDatos mConexionBaseDatos = new datAdministradorBaseDatos();
            ((datAdministradorBaseDatos)mConexionBaseDatos).ActualizarDatosAdministrador(this.cIdentificador,
                this.cCorreoElectronico);
        }
    }
}
