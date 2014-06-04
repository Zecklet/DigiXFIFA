using MySoccer.EjeTransversal;
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

        public MY_SOCCER_CON CrearConexion()
        {
            MY_SOCCER_CON mNuevaConexion = new MY_SOCCER_CON();
            return mNuevaConexion;
        }

        //Cuando crea un nuevo usuario devuelve el id del usaurio
        public int AgregarUsuario(String pNombre, String pApellido, DateTime pFechaNacmiento)
        {
            USUARIO mNuevoUsuario = new USUARIO
            {
                Nombre = pNombre,
                Apellido = pApellido,
                Fecha_Nacimiento = DateTime.Now.Date
                //Fecha_Nacimiento = Convert.ToDateTime(pFechaNacmiento)
            };

            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();

            mConexionMySoccer.USUARIO.Add(mNuevoUsuario);
            mConexionMySoccer.SaveChanges();

            mConexionMySoccer.Database.Connection.Close();

            return mNuevoUsuario.PK_Usuario;
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
            // Fecha_Nacimiento = DateTime.Now.Date };
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();

            mConexionMySoccer.CUENTA.Add(mNuevoCuenta);
            mConexionMySoccer.SaveChanges();

            mConexionMySoccer.Database.Connection.Close();
        }

        public Boolean ExisteUsuario(String pNombreUsuario)
        {
            return (ObtenerCuenta(pNombreUsuario) != null);
        }

        public void VerBaseDatos()
        {
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

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
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();
            IQueryable<CUENTA> mResultado = mConexionMySoccer.CUENTA.Where(s => s.Nombre_Usuario == pNombreUsuario);
            
            if (mResultado.Count()!=0){
                mSalida = mResultado.First();
            }

            mConexionMySoccer.Database.Connection.Close();

            return mSalida;
        }

        public USUARIO ObtenerUsuario(int pPKUsuario)
        {
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();

            IQueryable<USUARIO> mSalida = mConexionMySoccer.USUARIO.Where(s => s.PK_Usuario == pPKUsuario);

            USUARIO mResultado = (USUARIO)mSalida.First();

            mConexionMySoccer.Database.Connection.Close();

            return mResultado;
        }

        public int GetTipoUsuario(String pNombreUsuario)
        {
            int mResultado = 0;

            MY_SOCCER_CON mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            CUENTA mCuentaUsuario = ObtenerCuenta(pNombreUsuario) ;

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
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();
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
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();
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
    }
}