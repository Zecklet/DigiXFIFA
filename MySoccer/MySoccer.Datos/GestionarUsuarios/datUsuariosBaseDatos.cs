using MySoccer.Datos.Entity;
using MySoccer.EjeTransversal;
using MySoccer.EjeTransversal.GestionarUsuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public abstract class datUsuariosBaseDatos
    {

        public MY_SOCCER_CONEXION CrearConexion()
        {
            MY_SOCCER_CONEXION mNuevaConexion = new MY_SOCCER_CONEXION();
            return mNuevaConexion;
        }

        //Cuando crea un nuevo usuario devuelve el id del usaurio
        public int AgregarUsuario(String pNombre, String pApellido, DateTime pFechaNacmiento)
        {
            int mResultado = 0;
            USUARIO mNuevoUsuario = new USUARIO
            {
                Nombre = pNombre,
                Apellido = pApellido,
                Fecha_Nacimiento = DateTime.Now.Date
                //Fecha_Nacimiento = Convert.ToDateTime(pFechaNacmiento)
            };

            try
            {
                MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();

                mConexionMySoccer.Database.Connection.Open();

                mConexionMySoccer.USUARIO.Add(mNuevoUsuario);
                mConexionMySoccer.SaveChanges();

                mResultado = mNuevoUsuario.PK_Usuario;
                mConexionMySoccer.Database.Connection.Close();
            }
            catch (Exception e)
            {
                mResultado = -1;
            }
            return mResultado;
        }

        public void AgregarCuenta(int pPKUsuario, String pNombreUsuario, String pContrasena, DateTime pFechaInscripcion
            , Boolean pEstado)
        {

            CUENTA mNuevoCuenta = new CUENTA
            {
                PK_FK_Cuenta = pPKUsuario,
                Nombre_Usuario = pNombreUsuario,
                Contraseña = pContrasena,
                Fecha_Inscripcion = pFechaInscripcion,
                Estado = pEstado
            };
            try
            {
                MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();

                mConexionMySoccer.Database.Connection.Open();

                mConexionMySoccer.CUENTA.Add(mNuevoCuenta);
                mConexionMySoccer.SaveChanges();

                mConexionMySoccer.Database.Connection.Close();
            }
            catch (Exception e)
            {

            }
        }

        public Boolean ExisteUsuario(String pNombreUsuario)
        {
            return (ObtenerCuenta(pNombreUsuario) != null);
        }

        public void VerBaseDatos()
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();

            foreach (CUENTA mCuenta in mConexionMySoccer.CUENTA)
            {
                Console.WriteLine(mCuenta.Nombre_Usuario + " --- " + mCuenta.PK_FK_Cuenta);
            }

            mConexionMySoccer.Database.Connection.Close();

        }

        public CUENTA ObtenerCuenta(String pNombreUsuario)
        {
            CUENTA mSalida = null;
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();
            IQueryable<CUENTA> mResultado = mConexionMySoccer.CUENTA.Where(cuenta => cuenta.Nombre_Usuario == pNombreUsuario);

            if (mResultado.Count() != 0)
            {
                mSalida = mResultado.First();
            }

            mConexionMySoccer.Database.Connection.Close();

            return mSalida;
        }

        public USUARIO ObtenerUsuario(int pPKUsuario)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();

            IQueryable<USUARIO> mSalida = mConexionMySoccer.USUARIO.Where(s => s.PK_Usuario == pPKUsuario);

            USUARIO mResultado = (USUARIO)mSalida.First();

            mConexionMySoccer.Database.Connection.Close();

            return mResultado;
        }

        public int GetTipoUsuario(String pNombreUsuario)
        {
            int mResultado = 0;

            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            CUENTA mCuentaUsuario = ObtenerCuenta(pNombreUsuario);

            if (mCuentaUsuario != null)
            {
                int mIdCuenta = mCuentaUsuario.PK_FK_Cuenta;
                if (mConexionMySoccer.ADMINISTRADOR.Where(s => s.PK_FK_Administrador == mIdCuenta).Count() != 0)
                {
                    mResultado = ConstantesGestionarUsuarios.kUsuarioAdministrador;
                }
                else if (mConexionMySoccer.NARRADOR.Where(s => s.PK_FK_Narrador == mIdCuenta).Count() != 0)
                {
                    mResultado = ConstantesGestionarUsuarios.kUsuarioNarrador;
                }
                else if (mConexionMySoccer.FANATICO.Where(s => s.PK_FK_Fanatico == mIdCuenta).Count() != 0)
                {
                    mResultado = ConstantesGestionarUsuarios.kUsuarioFantatico;
                }
            }

            mConexionMySoccer.Database.Connection.Close();

            return mResultado;
        }

        public void ActualizarCuenta(int pIdentificadorCuenta, String pNombreUsuario, String pContrasena)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            CUENTA mCuentaVieja = mConexionMySoccer.CUENTA.Where(s => s.PK_FK_Cuenta == pIdentificadorCuenta).First();
            mCuentaVieja.Nombre_Usuario = pNombreUsuario;
            mCuentaVieja.Contraseña = pContrasena;

            mConexionMySoccer.CUENTA.Attach(mCuentaVieja);

            var mActulizarCuenta = mConexionMySoccer.Entry(mCuentaVieja);
            mActulizarCuenta.State = EntityState.Modified;
            mActulizarCuenta.Property(s => s.Fecha_Inscripcion).IsModified = false;
            mActulizarCuenta.Property(s => s.Estado).IsModified = false;

            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close();
        }

        public void ActualizarUsuario(int pIdentificadorUsuario, String pNombre, String pApellido,
            DateTime pFechaNacimiento)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            USUARIO mUsuarioViejo = mConexionMySoccer.USUARIO.Where(s => s.PK_Usuario == pIdentificadorUsuario).First();
            mUsuarioViejo.Nombre = pNombre;
            mUsuarioViejo.Apellido = pApellido;
            mUsuarioViejo.Fecha_Nacimiento = pFechaNacimiento;

            mConexionMySoccer.USUARIO.Attach(mUsuarioViejo);

            //Variable que me ayuda con las actulizaciones de la cuenta
            var mActulizador = mConexionMySoccer.Entry(mUsuarioViejo);
            mActulizador.State = EntityState.Modified;

            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close();
        }

        public void CambiarEstadoCuenta(String pNombreUsuario, Boolean pEstadoNuevo)
        {
            using (var mConexion = CrearConexion())
            {
                CUENTA mCuentaVieja = mConexion.CUENTA.Where(s => s.Nombre_Usuario == pNombreUsuario).First();
                mCuentaVieja.Estado = pEstadoNuevo;

                mConexion.CUENTA.Attach(mCuentaVieja);

                //Variable que me ayuda con las actulizaciones de la cuenta
                var mActulizador = mConexion.Entry(mCuentaVieja);
                mActulizador.State = EntityState.Modified;
                mActulizador.Property(s => s.Contraseña).IsModified = false;
                mActulizador.Property(s => s.Fecha_Inscripcion).IsModified = false;
                mActulizador.Property(s => s.Nombre_Usuario).IsModified = false;
                mConexion.SaveChanges();
            }
        }

        //abstract public void AgregarUsuarioEspecifico(guiModeloUsuario pModelo);
        //abstract public guiModeloUsuario RecuperarUsuarioEspecifico(int pPkUsuario);
        //abstract public void ActualizarUsuarioEspecifico(guiModeloUsuario pModelo);

    }
}