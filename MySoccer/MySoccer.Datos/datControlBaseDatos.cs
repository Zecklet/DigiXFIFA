using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public class datControlBaseDatos
    {

        public MY_SOCCER_CON CrearConexion()
        {
            MY_SOCCER_CON mNuevaConexion = new MY_SOCCER_CON();
            return mNuevaConexion;
        }

        public void AgregarUsuario()
        {
            USUARIO mNuevoUsuario = new USUARIO { Nombre = "Jorge", Apellido = "Bolaños", Fecha_Nacimiento = DateTime.Now.Date };
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();

            mConexionMySoccer.Database.Connection.Open();

            mConexionMySoccer.USUARIO.Add(mNuevoUsuario);
            mConexionMySoccer.SaveChanges();

            mConexionMySoccer.Database.Connection.Close();
        }

    }
}
