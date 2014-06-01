using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public class datNarradorBaseDatos: datUsuariosBaseDatos
    {
        public void AgregarNarrador(int pPKUsuario, int pAnosExperiencia, String pDescripcion,
            int pGenero, String pRutaFoto)
        {

            NARRADOR mNuevoUsuario = new NARRADOR //Se crea el usuario  de tipo narrador con todos sus datos
            {
                PK_FK_Narrador = pPKUsuario,
                Anos_Experiencia = pAnosExperiencia,
                Descripcion = pDescripcion,
                Genero = pGenero,
                Foto = pRutaFoto
            };

            MY_SOCCER_CON mConexionMySoccer = CrearConexion(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            mConexionMySoccer.NARRADOR.Add(mNuevoUsuario); //Agrega el usuario de tipo narrador
            mConexionMySoccer.SaveChanges(); //guarda los cambios que se le hicieron a la base de datos 

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
        }
        public NARRADOR ObtenerNarrador(int pPKUsuario)
        {
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            NARRADOR mResultado = mConexionMySoccer.NARRADOR.Where(s => s.PK_FK_Narrador == pPKUsuario).ElementAt(0);

            mConexionMySoccer.Database.Connection.Close();
            return mResultado;
        }
    }
}
