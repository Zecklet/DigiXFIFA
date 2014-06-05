using MySoccer.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public class datPaisBaseDatos
    {

        //Entrada:pNuevoPais: String con el nombre del nuevo pais
        //Salida: ninguna
        //Descripcion: Agrega un nuevo pais a la base de datos de paises 
        public void AgregarPais(String pNuevoPais)
        {
            PAIS mNuevoPais = new PAIS() { Nombre = pNuevoPais }; //Se crea el nuevo pais con todos sus atributos

            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            mConexionMySoccer.PAIS.Add(mNuevoPais); //Agrega un nuevo pais
            mConexionMySoccer.SaveChanges(); //guarda los cambios que se le hicieron a la base de datos 

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
        }

        //Entrada: Ninguna
        //Salida: un diccionario con el nombre del pais y su respectivo codigo
        //Descripcion: Devuel un diccionario con la lista de pais, y su respectivo codigo de pais
        public Dictionary<int, String> GetPaises()
        {
            Dictionary<int, String> mResultado = new Dictionary<int, String>(); //Se crea el objecto que sera devuel

            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //abre una conexion
            foreach (PAIS mPais in mConexionMySoccer.PAIS) //Recorre la lista de paises existentes
            {
                mResultado.Add(mPais.PK_Pais, mPais.Nombre);//agrega un pais a la lista 
                Console.WriteLine(mPais.Nombre + " ---- " + mPais.PK_Pais);
            }

            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close();//Cierra la conexion con los paises 
            return mResultado; //devuelve el 
        }

        public String GetNombrePais(int pIdPais)
        {
            String mResultado = "";
            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            var Equipos = from Pais in mConexionMySoccer.PAIS
                          where Pais.PK_Pais == pIdPais
                          select Pais.Nombre;
            mResultado = Equipos.First();

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 

            return mResultado;
        }
    }
}
