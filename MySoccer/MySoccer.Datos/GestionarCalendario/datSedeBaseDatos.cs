using MySoccer.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.GestionarCalendario
{
    public class datSedeBaseDatos
    {

        //Entrada:pNuevaSede: String con el nombre de la nueva sede 
        //Salida: ninguna
        //Descripcion: Agrega un nuevo sede a la base de datos de sedes 
        public void AgregarSede(String pNuevaSede)
        {
            SEDE mNuevosede = new SEDE() { Nombre = pNuevaSede }; //Se crea el nuevo sede con todos sus atributos

            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            mConexionMySoccer.SEDE.Add(mNuevosede); //Agrega un nuevo sede
            mConexionMySoccer.SaveChanges(); //guarda los cambios que se le hicieron a la base de datos 

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
        }

        //Entrada: Ninguna
        //Salida: un diccionario con el nombre del sede y su respectivo codigo
        //Descripcion: Devuel un diccionario con la lista de sede, y su respectivo codigo de sede
        public Dictionary<int, String> GetSedes()
        {
            Dictionary<int, String> mResultado = new Dictionary<int, String>(); //Se crea el objecto que sera devuel

            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //abre una conexion
            foreach (SEDE mSede in mConexionMySoccer.SEDE) //Recorre la lista de sedees existentes
            {
                mResultado.Add(mSede.PK_Sede, mSede.Nombre);//agrega un sede a la lista 
            }
            mConexionMySoccer.Database.Connection.Close();//Cierra la conexion con los sedees 
            return mResultado; //devuelve el 
        }

        public String GetNombreSede(int pIdSede)
        {
            String mResultado = "";
            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            var Equipos = from SEDE in mConexionMySoccer.SEDE
                          where SEDE.PK_Sede == pIdSede
                          select SEDE.Nombre;
            mResultado = Equipos.First();

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 

            return mResultado;
        }
    }
}
