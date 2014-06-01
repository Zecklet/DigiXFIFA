using System;
using System.Collections.Generic;
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
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();
            IQueryable<CUENTA> mResultado = mConexionMySoccer.CUENTA.Where(s => s.Nombre_Usuario == pNombreUsuario);

            mConexionMySoccer.Database.Connection.Close();
            
            if (mResultado.Count()!=0){
                return mResultado.ElementAt(0);
            }
            else{
                return null;
            }
        }

        public USUARIO ObtenerUsuario(int pPKUsuario)
        {
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();

            USUARIO mResultado = mConexionMySoccer.USUARIO.Where(s => s.PK_Usuario == pPKUsuario).ElementAt(0);

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
                if (mConexionMySoccer.ADMINISTRADOR.Where(s => s.PK_FK_Administrador == mIdCuenta) != null)
                {
                    mResultado = datConstantes.kUsuarioAdministrador;
                }
                else if (mConexionMySoccer.NARRADOR.Where(s => s.PK_FK_Narrador == mIdCuenta) != null)
                {
                    mResultado = datConstantes.kUsuarioNarrador;
                }
                else if (mConexionMySoccer.FANATICO.Where(s => s.PK_FK_Fanatico == mIdCuenta) != null)
                {
                    mResultado = datConstantes.kUsuarioFantatico;
                }
            }

            mConexionMySoccer.Database.Connection.Close();

            return mResultado;
        }
    }
}
