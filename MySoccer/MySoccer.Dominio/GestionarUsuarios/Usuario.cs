using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;
using MySoccer.EjeTransversal;
using MySoccer.Datos.Entity;

namespace MySoccer.Dominio
{
    public abstract class Usuario
    {

        public String cTipoUsuario { get; set; }
        public int cIdentificador { get; set; }
        public String cNombre { get; set; }
        public String cApellido { get; set; }
        public DateTime cFechaNacimiento { get; set; }
        public Cuenta cCuenta { get; set; }
        public int cIDTipo { get; set; } //Consultar si es requerido: Podría servir para asignar permisos y desplegar comentarios.

        public void ColocarDatos(String pNombre, String pApellido, String pFechaNacimiento, String pNombreUsuario, String pContrasena)
        {
            this.cNombre = pNombre;
            this.cApellido = pApellido;
            this.cFechaNacimiento = Convert.ToDateTime(cFechaNacimiento);
            this.cCuenta = new Cuenta(pNombreUsuario, pContrasena);
        }

        public Boolean CompararContrasena(String pContrasena)
        {
            return this.cCuenta.CompararContrasena(pContrasena);
        }
        public Boolean ExisteNombreUsuario(String pNombreUsuario)
        {
            datUsuariosBaseDatos mConexionBaseDatos = new datAdministradorBaseDatos();
            return mConexionBaseDatos.ExisteUsuario(pNombreUsuario);
        }

        public void CrearUsuarioBaseDatos()
        {
            datUsuariosBaseDatos mConexionBaseDatos = new datAdministradorBaseDatos();
            this.cIdentificador = mConexionBaseDatos.AgregarUsuario(this.cNombre, this.cApellido, this.cFechaNacimiento);
        }

        public void CrearCuentaBaseDatos()
        {
            datUsuariosBaseDatos mConexionBaseDatos = new datAdministradorBaseDatos();
            mConexionBaseDatos.AgregarCuenta(this.cIdentificador, this.cCuenta.cNombreUsuario, this.cCuenta.cContrasena,
                this.cCuenta.cFechaInscripcion, true);
        }

        public int RecuperarTipoUsuario(String pNombreUsuario)
        {
            datUsuariosBaseDatos mConexionBaseDatos = new datAdministradorBaseDatos();
            return mConexionBaseDatos.GetTipoUsuario(pNombreUsuario.ToLower());
        }

        public void RecuperarCuentaBaseDatos(String pNombreUsuario)
        {
            datUsuariosBaseDatos mConexionBase = new datNarradorBaseDatos();
            CUENTA mCuentaBuscada = mConexionBase.ObtenerCuenta(pNombreUsuario);
            this.cCuenta = new Cuenta(mCuentaBuscada.Nombre_Usuario, mCuentaBuscada.Contraseña,
                mCuentaBuscada.Estado, mCuentaBuscada.Fecha_Inscripcion);
            this.cIdentificador = mCuentaBuscada.PK_FK_Cuenta;
        }

        public void RecuperarUsuarioBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datNarradorBaseDatos();
            USUARIO mUsuario = mConexionBase.ObtenerUsuario(this.cIdentificador);
            this.cNombre = mUsuario.Nombre;
            this.cApellido = mUsuario.Apellido;
            this.cFechaNacimiento = mUsuario.Fecha_Nacimiento;
        }

        public void SetIdTipo(int pTipo)
        {
            this.cIDTipo = pTipo;
        }

        public void DesactivarCuenta()
        {
            this.cCuenta.cEstado = false;
            datUsuariosBaseDatos mConexionUsuarios = new datAdministradorBaseDatos();
            mConexionUsuarios.CambiarEstadoCuenta(this.cCuenta.GetNombreUsuario(),false);
        }

        public void ActivarCuenta()
        {
            cCuenta.cEstado = true;
            datUsuariosBaseDatos mConexionUsuarios = new datAdministradorBaseDatos();
            mConexionUsuarios.CambiarEstadoCuenta(this.cCuenta.GetNombreUsuario(), true);
        }

        public String GetNombreUsuario()
        {
            return cCuenta.GetNombreUsuario();
        }

        public String GetNombre()
        {
            return this.cNombre;
        }

        public Dictionary<String, String> GetDatosUsuario()
        {
            Dictionary<String, String> mDatosRetorno = new Dictionary<String, String>();
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringNombre, this.cNombre);
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringApellido, this.cApellido);
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringFechaNacimiento, this.cFechaNacimiento.Date.ToShortDateString());
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringFechaInscripcion, this.cCuenta.cFechaInscripcion.Date.ToShortDateString());
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringEstado, this.cCuenta.cEstado.ToString());
            return mDatosRetorno;
        }

        public void CambiarDatosCuenta(String pNombreUsuario, String pContrasena)
        {
            this.cCuenta.CambiarUsuario(pNombreUsuario);
            this.cCuenta.CambiarContrasena(pContrasena);
        }

        public void CambiarDatosUsuario(String pNombre, String pApellido, String pFechaNacimiento)
        {
            this.cNombre = pNombre;
            this.cApellido = pApellido;
            this.cFechaNacimiento = Convert.ToDateTime(pFechaNacimiento);
        }

        protected void ActualizarCuentaBaseDatos(){
            datUsuariosBaseDatos mConexion = new datAdministradorBaseDatos();
            mConexion.ActualizarCuenta(this.cIdentificador, this.cCuenta.GetNombreUsuario(), this.cCuenta.GetContrasena());
        }
        protected void ActualizarUsuarioBaseDatos(){
            datUsuariosBaseDatos mConexion = new datAdministradorBaseDatos();
            mConexion.ActualizarUsuario(this.cIdentificador, this.cNombre, this.cApellido,
                this.cFechaNacimiento);
        }


        //Metodos para que sean sobreescritos 
        abstract public void CrearTipoUsuarioBaseDatos();
        abstract public void RecuperarDatosBaseDatos();
        abstract public Dictionary<String, String> GetDatos();

        //Esta funcion solamente recibe los datos especificos de cada usuario
        abstract public void ActualizarDatos(Dictionary<String, String> pNuevoDatos);

        //Este metodo actualiza los datos del usuario el la base de datos 
        abstract public void ActualizarDatosBaseDatos();

    }

}
