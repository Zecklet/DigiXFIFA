using MySoccer.Dominio;
using MySoccer.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Pruebas
{
    class PruebaGeneradorXML
    {
        static void Main(string[] args)
        {
            Narrador mNarrador = new Narrador();
            mNarrador.cIdentificador = 2014;

            ResultadoPartido mResultadoPartido = new ResultadoPartido();
            mResultadoPartido.cMarcadorEquipo1 = 0;
            mResultadoPartido.cMarcadorEquipo2 = 4;

            List<Jugador> mTitulares1 = new List<Jugador>();
            List<Jugador> mReserva1 = new List<Jugador>();
            
            List<Jugador> mTitulares2 = new List<Jugador>();
            List<Jugador> mReserva2 = new List<Jugador>();

            for (int i = 0; i < 11; i++)
            {
                Jugador titular1 = new Jugador();
                titular1.cPasaporteXFIFA = 100+i;
                mTitulares1.Add(titular1);

                Jugador reserva1 = new Jugador();
                reserva1.cPasaporteXFIFA = 100+11+i;
                mReserva1.Add(reserva1);

                Jugador titular2 = new Jugador();
                titular2.cPasaporteXFIFA = 200 + i;
                mTitulares2.Add(titular2);

                Jugador reserva2 = new Jugador();
                reserva2.cPasaporteXFIFA = 200+11+i;
                mReserva2.Add(reserva2);
            }

            Equipo mEquipo1 = new Equipo();
            mEquipo1.cIDPais = 506;

            Equipo mEquipo2 = new Equipo();
            mEquipo2.cIDPais = 1012;

            List<ComentarioEstadistico> mComentarios = new List<ComentarioEstadistico>();

            for (int i = 0; i < 11; i++)
            {
                ComentarioEstadistico mComentario1 = new ComentarioEstadistico();
                mComentario1.cEquipo = mEquipo1;
                mComentario1.cJugador1 = mTitulares1.ElementAt(i);
                mComentario1.cJugador2 = mReserva1.ElementAt(i);
                mComentario1.cIDAccion = i;
                mComentario1.cTiempo = i * 5;
                mComentarios.Add(mComentario1);

                ComentarioEstadistico mComentario2 = new ComentarioEstadistico();
                mComentario2.cEquipo = mEquipo2;
                mComentario2.cJugador1 = mTitulares2.ElementAt(i);
                mComentario2.cJugador2 = mReserva2.ElementAt(i);
                mComentario2.cIDAccion = i;
                mComentario2.cTiempo = i * 5;
                mComentarios.Add(mComentario2);
            }

            ComentarioEstadistico mComentario = new ComentarioEstadistico();
            mComentario.cEquipo = mEquipo1;
            mComentario.cJugador1 = mReserva1.ElementAt(6);
            mComentario.cJugador2 = mTitulares1.ElementAt(6);
            mComentario.cIDAccion = 6;
            mComentario.cTiempo = 40;
            mComentarios.Add(mComentario);

            Partido mPartido = new Partido();
            mPartido.cResultadoPartido.cComentarios = mComentarios;
            mPartido.cEquipo1 = mEquipo1;
            mPartido.cEquipo2 = mEquipo2;
            mPartido.cFecha = "31/05/2014";
            mPartido.cHora = "12:40:00 AM";
            mPartido.cIDTorneo = 4018;
            mPartido.cNarrador = mNarrador;
            mPartido.cResultadoPartido.cTitularesEquipo1 = mTitulares1;
            mPartido.cResultadoPartido.cTitularesEquipo2 = mTitulares2;
            mPartido.cResultadoPartido = mResultadoPartido;

            GeneradorXML mGenXMLPba = new GeneradorXML();
            mGenXMLPba.generarXML(mPartido);

            Console.ReadLine();
        }
    }
}
