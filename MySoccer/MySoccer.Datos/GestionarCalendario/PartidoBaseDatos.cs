using MySoccer.Datos.Entity;
using MySoccer.EjeTransversal;
using MySoccer.EjeTransversal.GestionarCalendario;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos.GestionarCalendario
{
    public class PartidoBaseDatos
    {
        //Entrada:pNuevaPartido: String con el nombre de la nueva Partido 
        //Salida: ninguna
        //Descripcion: Agrega un nuevo Partido a la base de datos de Partidos 
        public void AgregarPartido(String pFase, DateTime pFecha, int pIdEquipo1, int pIdEquipo2,
            int pIdSede, TimeSpan pHora, int pTorneo)
        {
            PARTIDO mNuevoPartido = new PARTIDO()
            {
                Fase = pFase,
                Fecha = pFecha,
                FK_Equipo_1 = pIdEquipo1,
                FK_Equipo_2 = pIdEquipo2,
                FK_Sede = pIdSede,
                Hora = pHora,
                PK_Partido = pTorneo,
                Estado = ConstantesGestionarCalendario.kCodigoPartidoNoJugado

            }; //Se crea el nuevo Partido con todos sus atributos

            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            mConexionMySoccer.PARTIDO.Add(mNuevoPartido); //Agrega un nuevo Partido
            mConexionMySoccer.SaveChanges(); //guarda los cambios que se le hicieron a la base de datos 

            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
        }

        //Entrada:pNuevaPartido: String con el nombre de la nueva Partido 
        //Salida: ninguna
        //Descripcion: Agrega un nuevo Partido a la base de datos de Partidos 
        public void ActualizarPartido(int pIdPartido, String pFase, DateTime pFecha, int pIdEquipo1, int pIdEquipo2,
            int pIdSede, TimeSpan pHora, int pTorneo)
        {
            PARTIDO mNuevoPartido = new PARTIDO()
            {
                Fase = pFase,
                Fecha = pFecha,
                FK_Equipo_1 = pIdEquipo1,
                FK_Equipo_2 = pIdEquipo2,
                FK_Sede = pIdSede,
                Hora = pHora,
                PK_Partido = pTorneo,
                Estado = ConstantesGestionarCalendario.kCodigoPartidoNoJugado

            }; //Se crea el nuevo Partido con todos sus atributos

            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //Abre la conexion con sqlserver 

            PARTIDO mPartidoViejo = mConexionMySoccer.PARTIDO.Where(s => s.PK_Partido == pIdPartido).First();
            mPartidoViejo.Hora = pHora;
            mPartidoViejo.Fase = pFase;
            mPartidoViejo.FK_Equipo_1 = pIdEquipo1;
            mPartidoViejo.FK_Equipo_2 = pIdEquipo2;
            mPartidoViejo.FK_Sede = pIdSede;
            mPartidoViejo.Fecha = pFecha;

            mConexionMySoccer.PARTIDO.Attach(mPartidoViejo);

            //Variable que me ayuda con las actulizaciones de la cuenta
            var mActulizador = mConexionMySoccer.Entry(mPartidoViejo);
            mActulizador.State = EntityState.Modified;
            
            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close(); //Cierra la conexion 
        }
        //Entrada: Ninguna
        //Salida: un diccionario con el nombre del Partido y su respectivo codigo
        //Descripcion: Devuel un diccionario con la lista de Partido, y su respectivo codigo de Partido
        public List<ContenedorPartido> GetPartidos(int pTorneo)
        {
            List<ContenedorPartido> mResultado = new List<ContenedorPartido>(); //Se crea el objecto que sera devuel

            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //abre una conexion

            var mPartidos = from Partido in mConexionMySoccer.PARTIDO //Se realiza un join con la tabla de paises par saber el nombre del equipo
                            join Equipo1 in mConexionMySoccer.PAIS
                                on Partido.FK_Equipo_1 equals Equipo1.PK_Pais
                            join Equipo2 in mConexionMySoccer.PAIS
                                on Partido.FK_Equipo_2 equals Equipo2.PK_Pais
                            join Sede in mConexionMySoccer.SEDE
                                on Partido.FK_Sede equals Sede.PK_Sede
                            join ResultadoPartido in mConexionMySoccer.RESULTADO_PARTIDO
                                on Partido.PK_Partido equals ResultadoPartido.PK_FK_Resultado_Partido
                                into PartidosRegistrados orderby Partido.Fecha descending
                                where Partido.FK_Torneo==pTorneo 
                                from Partidos in PartidosRegistrados.DefaultIfEmpty()
                            select new
                            {
                                NombreEquipo1 = Equipo1.Nombre,
                                NombreEquipo2 = Equipo2.Nombre,
                                NomrbreSede = Sede.Nombre,
                                Fecha = Partido.Fecha,
                                Fase = Partido.Fase,
                                Hora = Partido.Hora,
                                Estado = Partido.Estado,
                                Asistencia = (Partidos == null ? ConstantesGestionarCalendario.kStringAsistenciaVacia : (Partidos.Asistencia.ToString())),
                                Marcador = (Partidos == null ? ConstantesGestionarCalendario.kStringMarcadorVacio : (Partidos.Marcador_Equipo_1 + " - " + Partidos.Marcador_Equipo_2)),
                                IdPartido = Partido.PK_Partido
                            };

            foreach (var Partido in mPartidos) //Recorre la lista de paises existentes
            {
                mResultado.Add(new ContenedorPartido()
                {
                    cFecha = Partido.Fecha.ToShortDateString(),
                    cHora = Partido.Hora.ToString(),
                    cFase = Partido.Fase,
                    cNombreEquipo1 = Partido.NombreEquipo1,
                    cNombreEquipo2 = Partido.NombreEquipo2,
                    cNombreSede = Partido.NomrbreSede,
                    cEstado = ConstantesGestionarCalendario.kStringEstadosPartido[Partido.Estado],
                    cPartidoJugado = Partido.Estado,
                    cAsistencia = Partido.Asistencia,
                    cMarcador = Partido.Marcador,
                    cIdPartido = Partido.IdPartido
                });
            }
            mConexionMySoccer.Database.Connection.Close();//Cierra la conexion con los Partidoes 
            return mResultado; //devuelve el 
        }
        public ContenedorPartido GetPartido(int pIdPartido)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //abre una conexion

            var mPartido = mConexionMySoccer.PARTIDO.Where(s=> s.PK_Partido == pIdPartido).First();

            mConexionMySoccer.Database.Connection.Close();
            return new ContenedorPartido()
            {
                cFecha = mPartido.Fecha.ToShortDateString(),
                cIdEquipo1 = mPartido.FK_Equipo_1,
                cIdEquipo2 = mPartido.FK_Equipo_2,
                cIDSede = mPartido.FK_Sede,
                cFase = mPartido.Fase,
                cHora = mPartido.Hora.ToString(),
                cIDTorneo = mPartido.FK_Torneo,
                cIdPartido = mPartido.PK_Partido
            };
        }

        public void EliminarPartido(int pIdPartido)
        {
            MY_SOCCER_CONEXION mConexionMySoccer = new MY_SOCCER_CONEXION(); //crea una nueva conexion con sql server
            mConexionMySoccer.Database.Connection.Open(); //abre una conexion

            var mPartido = mConexionMySoccer.PARTIDO.Where(s => s.PK_Partido == pIdPartido).First();
            mConexionMySoccer.PARTIDO.Attach(mPartido);
            mConexionMySoccer.PARTIDO.Remove(mPartido);

            mConexionMySoccer.SaveChanges();
            mConexionMySoccer.Database.Connection.Close();
        }
    }
}
