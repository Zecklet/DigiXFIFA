using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;

namespace MySoccer.Dominio
{
    public abstract class Usuario
    {
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
                this.cCuenta.cFechaInscripcion, this.cCuenta.cEstado);
        }

        public int RecuperarTipoUsuario(String pNombreUsuario)
        {
            datUsuariosBaseDatos mConexionBaseDatos = new datAdministradorBaseDatos();
            return mConexionBaseDatos.GetTipoUsuario(pNombreUsuario);
        }

        public void RecuperarCuentaBaseDatos(String pNombreUsuario)
        {
            datUsuariosBaseDatos mConexionBase = new datNarradorBaseDatos();
            CUENTA mCuentaBuscada = mConexionBase.ObtenerCuenta(pNombreUsuario);
            this.cCuenta.cNombreUsuario = mCuentaBuscada.Nombre_Usuario;
            this.cCuenta.cContrasena = mCuentaBuscada.Contraseña;
            this.cCuenta.cFechaInscripcion = mCuentaBuscada.Fecha_Inscripcion;
            this.cCuenta.cEstado = mCuentaBuscada.Estado;
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

        abstract public void CrearTipoUsuarioBaseDatos();
        abstract public void RecuperarDatosBaseDatos();

        public void SetIdTipo(int pTipo)
        {
            this.cIDTipo = pTipo;
        }

        public void DesactivarCuenta()
        {
            this.cCuenta.cEstado = false;
        }

        public void ActivarCuenta()
        {
            cCuenta.cEstado = true;
        }

    }

}
