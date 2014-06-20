using MySoccer.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

            try
            {
                MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion(); //crea una nueva conexion con sql server
                mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

                mConexionMySoccer.NARRADOR.Add(mNuevoUsuario); //Agrega el usuario de tipo narrador
                mConexionMySoccer.SaveChanges(); //guarda los cambios que se le hicieron a la base de datos 

                mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e);
            }
        }
        public NARRADOR ObtenerNarrador(int pPKUsuario)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            NARRADOR mResultado = mConexionMySoccer.NARRADOR.Where(s => s.PK_FK_Narrador == pPKUsuario).First();

            mConexionMySoccer.Database.Connection.Close();
            return mResultado;
        }

        public void ActualizarDatosNarrador(int pIdentificadorUsuario, String pDescripcion,
            String pRutaFoto, int pGenero, int pAnosExperiencia)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = CrearConexion();
            mConexionMySoccer.Database.Connection.Open();

            NARRADOR mNarradorViejo = mConexionMySoccer.NARRADOR.Where(s => s.PK_FK_Narrador == pIdentificadorUsuario).First();
            mNarradorViejo.Foto = pRutaFoto;
            mNarradorViejo.Genero = pGenero;
            mNarradorViejo.Anos_Experiencia = pAnosExperiencia;
            mNarradorViejo.Descripcion = pDescripcion;

            mConexionMySoccer.NARRADOR.Attach(mNarradorViejo);

            //Variable que me ayuda con las actulizaciones de la cuenta
            var mActulizador = mConexionMySoccer.Entry(mNarradorViejo);
            mActulizador.State = EntityState.Modified;
           // mActulizador.Property(s => s.PK_FK_Narrador).IsModified = false;

            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close();
        }
    }
}
