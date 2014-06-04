using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            FANATICO mResultado = mConexionMySoccer.FANATICO.Where(s => s.PK_FK_Fanatico == pPKUsuario).First();

            mConexionMySoccer.Database.Connection.Close();
            return mResultado;
        }

        public void ActualizarDatosFanatico(int pIdentificadorUsuario, String pDescripcion, String pCorreoElectronico,
            String pRutaFoto, int pGenero, int pEquipoFavorito, int pPais)
        {
            MY_SOCCER_CON mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            FANATICO mFanaticoViejo = mConexionMySoccer.FANATICO.Where(s => s.PK_FK_Fanatico == pIdentificadorUsuario).First();
            mFanaticoViejo.Correo_Electronico = pCorreoElectronico;
            mFanaticoViejo.Foto = pRutaFoto;
            mFanaticoViejo.Genero = pGenero;
            mFanaticoViejo.FK_Equipo_Favorito = pEquipoFavorito;
            mFanaticoViejo.Descripcion = pDescripcion;
            mFanaticoViejo.FK_Pais = pPais;

            mConexionMySoccer.FANATICO.Attach(mFanaticoViejo);

            //Variable que me ayuda con las actulizaciones de la cuenta
            var mActulizador = mConexionMySoccer.Entry(mFanaticoViejo);
            mActulizador.State = EntityState.Modified;
            //mActulizador.Property(s => s.PK_FK_Fanatico).IsModified = false;

            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close();
        }
    }
}
