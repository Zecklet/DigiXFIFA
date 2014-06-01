using System;
using System.Collections.Generic;
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

            MY_SOCCER_CON mConexionMySoccer = CrearConexion(); //Crea un nueva conexion con la base de  datos 
            mConexionMySoccer.Database.Connection.Open(); //abre la conexion a la base de datos 

            mConexionMySoccer.ADMINISTRADOR.Add(mNuevoUsuario); //Agrega el usuario a la base de datos 
            mConexionMySoccer.SaveChanges(); //Guarda los cambios de la base de datos

            mConexionMySoccer.Database.Connection.Close(); //cierra la conexion con la base de datos 
        }
        public ADMINISTRADOR ObtenerAdministrador(int pPKUsuario)
        {
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            ADMINISTRADOR mResultado = mConexionMySoccer.ADMINISTRADOR.Where(s => s.PK_FK_Administrador == pPKUsuario).ElementAt(0);

            mConexionMySoccer.Database.Connection.Close();
            return mResultado;
        }
    }
}
