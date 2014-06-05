using MySoccer.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public class datAdministradorBaseDatos:datUsuariosBaseDatos
    {
        public void AgregarAdministrador(int pPKUsuario, String pCorreoElectronico)
        {

            ADMINISTRADOR mNuevoUsuario = new ADMINISTRADOR //se crea el usuario de tipo administrador
            {
                PK_FK_Administrador = pPKUsuario,
                Correo_Electronico = pCorreoElectronico
            };

            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion(); //Crea un nueva conexion con la base de  datos 
            mConexionMySoccer.Database.Connection.Open(); //abre la conexion a la base de datos 

            mConexionMySoccer.ADMINISTRADOR.Add(mNuevoUsuario); //Agrega el usuario a la base de datos 
            mConexionMySoccer.SaveChanges(); //Guarda los cambios de la base de datos

            mConexionMySoccer.Database.Connection.Close(); //cierra la conexion con la base de datos 
        }
        public ADMINISTRADOR ObtenerAdministrador(int pPKUsuario)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            ADMINISTRADOR mResultado = mConexionMySoccer.ADMINISTRADOR.Where(s => s.PK_FK_Administrador == pPKUsuario).First(); ;



            mConexionMySoccer.Database.Connection.Close();
            return mResultado;
        }

        public void ActualizarDatosAdministrador(int pIdentificadorUsuario, String pCorreoElectronico)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            ADMINISTRADOR mAdministradorViejo = mConexionMySoccer.ADMINISTRADOR.Where(s => s.PK_FK_Administrador == pIdentificadorUsuario).First();
            mAdministradorViejo.Correo_Electronico = pCorreoElectronico;

            mConexionMySoccer.ADMINISTRADOR.Attach(mAdministradorViejo);

            //Variable que me ayuda con las actulizaciones de la cuenta
            var mActulizador = mConexionMySoccer.Entry(mAdministradorViejo);
            mActulizador.State = EntityState.Modified;
            //mActulizador.Property(s => s.PK_FK_Administrador).IsModified = false;

            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close();
        }
    }
}
