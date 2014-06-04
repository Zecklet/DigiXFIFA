using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public class datEquipoBaseDatos
    {
        //Entrada:pNuevoPais: pIdPais: id del pais al cual pertenece el equipo,
        //pRutaFoto: ruta de la foto del equipo,
        //pFechaAsociacion: fecha en la cual el equipo se asocio a la XFIFA, 
        //pFederacion:Nombre de la federacion a la cual pertenece el equipo
        //Salida: ninguna
        //Descripcion: Agrega un nuevo Equippo a la base de datos de equipos de mysoccer 
        public void AgregarEquipo(int pIdPais, String pRutaFoto, DateTime pFechaAsociacion, String pFederacion)
        {
            EQUIPO mNuevoEquipo = new EQUIPO()
            {
                PK_Equipo = pIdPais,
                FK_Pais = pIdPais, //Crea un nuevo partido con todos sus atributos
                Foto = pRutaFoto,
                Fecha_Asociacion_XFIFA = pFechaAsociacion,
                Nombre_Federacion = pFederacion
            }; //Se crea el nuevo pais con todos sus atributos

            MY_SOCCER_CON mConexionMySoccer = new MY_SOCCER_CON(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            mConexionMySoccer.EQUIPO.Add(mNuevoEquipo); //Agrega un nuevo pais
            mConexionMySoccer.SaveChanges(); //guarda los cambios que se le hicieron a la base de datos 

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
        }




        //Entrada: Ninguna
        //Salida: un diccionario con el nombre del equipo y su respectivo codigo
        //Descripcion: Devuel un diccionario con la lista de equipos, y su respectivo codigo de equipo
        public Dictionary<int,String> GetEquipos()
        {
            Dictionary<int,String> mResultado = new Dictionary<int,String>(); //Se crea el objecto que sera devuel

            MY_SOCCER_CON mConexionMySoccer = new MY_SOCCER_CON(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //abre una conexion

            var Equipos = from Equipo in mConexionMySoccer.EQUIPO //Se realiza un join con la tabla de paises par saber el nombre del equipo
                          join Pais in mConexionMySoccer.PAIS
                              on Equipo.FK_Pais equals Pais.PK_Pais
                          select new
                          {
                              NombreEquipo = Pais.Nombre,
                              CodigoEquipo = Equipo.PK_Equipo
                          };
            
            foreach (var mEquipo in Equipos) //Recorre la lista de paises existentes
            {
                mResultado.Add(mEquipo.CodigoEquipo, mEquipo.NombreEquipo); //Se guarda el dato dentro del diccionario
                Console.WriteLine(mEquipo.NombreEquipo + " ---- " + mEquipo.CodigoEquipo);
            }

            mConexionMySoccer.Database.Connection.Close();//Cierra la conexion con los paises 
            return mResultado; //devuelve el resultado 
        }

    }
}
