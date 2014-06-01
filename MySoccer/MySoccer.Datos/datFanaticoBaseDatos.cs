using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public class datFanaticoBaseDatos : datUsuariosBaseDatos
    {
        public void AgregarFanatico(int pPKUsuario, String pDescripcion, int pEquipoFavorito,
           int pGenero, String pRutaFoto, String pCorreoElectronico, int pPais)
        {
            FANATICO mNuevoUsuario = new FANATICO //Se crea el usuario  de tipo fanatico con todos sus datos
         {
             PK_FK_Fanatico = pPKUsuario,
             Genero = pGenero,
             Descripcion = pDescripcion,
             FK_Equipo_Favorito = pEquipoFavorito,
             Foto = pRutaFoto,
             Correo_Electronico = pCorreoElectronico,
             FK_Pais = pPais 
         };

            MY_SOCCER_CON mConexionMySoccer = CrearConexion(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            mConexionMySoccer.FANATICO.Add(mNuevoUsuario); //Agrega el usuario de tipo Fanatico
            mConexionMySoccer.SaveChanges(); //guarda los cambios que se le hicieron a la base de datos 

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
        }
        public FANATICO ObtenerFanatico(int pPKUsuario)
        {
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            FANATICO mResultado = mConexionMySoccer.FANATICO.Where(s => s.PK_FK_Fanatico == pPKUsuario).ElementAt(0);

            mConexionMySoccer.Database.Connection.Close();
            return mResultado;
        }
    }
}
