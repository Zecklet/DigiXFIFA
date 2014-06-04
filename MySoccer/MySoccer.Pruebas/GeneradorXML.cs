using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using MySoccer.Dominio;

namespace MySoccer.Servicio
{
    public class GeneradorXML
    {
        const int kDuracionPartido = 90;
        const int kIDSustitucion = 6;

        public XmlDocument generarXML(Partido pPartido)
        {
            String mTimeStamp = DateTime.Now.ToString();

            String mRuta = "AE.xml";

            XmlDocument mArchivo = new XmlDocument();

            XmlNode mRaiz = Estadistica(mArchivo, mTimeStamp);

            int mResultado = (pPartido.cResultadoPartido.cMarcadorEquipo1 == pPartido.cResultadoPartido.cMarcadorEquipo2) ? 0 :
                             (pPartido.cResultadoPartido.cMarcadorEquipo1 > pPartido.cResultadoPartido.cMarcadorEquipo2) ? 1 : 2;

            XmlNode mPartido = Partido(mArchivo, mRaiz, pPartido.cIDTorneo, 0, mResultado);

            int mIdEquipo1 = pPartido.cEquipo1.cIDPais;
            XmlNode mEquipo1 = Equipo(mArchivo, mPartido, mIdEquipo1);
            Jugadores(mArchivo, mEquipo1, pPartido.cResultadoPartido.cTitularesEquipo1, pPartido.cResultadoPartido.cComentarios);

            XmlNode mEquipo2 = Equipo(mArchivo, mPartido, pPartido.cEquipo2.cIDPais);
            Jugadores(mArchivo, mEquipo2, pPartido.cResultadoPartido.cTitularesEquipo2, pPartido.cResultadoPartido.cComentarios);

            foreach (ComentarioEstadistico comentario in pPartido.cResultadoPartido.cComentarios)
            {

                if (comentario.cIDAccion != 6)
                {
                    XmlNode mJugador;
                    if (comentario.cEquipo.cIDPais == mIdEquipo1)
                        mJugador = buscarJugador(mEquipo1, comentario.cJugador1.cPasaporteXFIFA);
                    else
                        mJugador = buscarJugador(mEquipo2, comentario.cJugador1.cPasaporteXFIFA);

                    Accion(mArchivo, mJugador, comentario.cTiempo, comentario.cIDAccion);

                }
            }

            mArchivo.Save(mRuta);
            return mArchivo;
        }

        private XmlNode Estadistica(XmlDocument pArchivo, String pTimestamp)
        {
            XmlNode mEstadistica = pArchivo.CreateElement("estadistica");

            XmlAttribute mTimestamp = pArchivo.CreateAttribute("timestamp");
            mTimestamp.Value = pTimestamp;
            mEstadistica.Attributes.Append(mTimestamp);

            XmlAttribute mEstado = pArchivo.CreateAttribute("estado");
            mEstado.Value = "0";
            mEstadistica.Attributes.Append(mEstado);

            pArchivo.AppendChild(mEstadistica);

            return mEstadistica;

        }

        private XmlNode Partido(XmlDocument pArchivo, XmlNode pEstadistica, int pIDTorneo, int pAno, int pResultado)
        {
            XmlNode mPartido = pArchivo.CreateElement("partido");

            XmlAttribute mAnio = pArchivo.CreateAttribute("anio");
            mAnio.Value = pAno.ToString();
            mPartido.Attributes.Append(mAnio);

            XmlAttribute mResultado = pArchivo.CreateAttribute("resultado");
            mResultado.Value = pResultado.ToString();
            mPartido.Attributes.Append(mResultado);

            pEstadistica.AppendChild(mPartido);

            return mPartido;
        }

        private XmlNode Equipo(XmlDocument pArchivo, XmlNode pPartido, int pIDPais)
        {
            XmlNode mEquipo = pArchivo.CreateElement("equipo");

            XmlAttribute mPais = pArchivo.CreateAttribute("pais");
            mPais.Value = pIDPais.ToString();
            mEquipo.Attributes.Append(mPais);

            pPartido.AppendChild(mEquipo);

            return mEquipo;

        }

        private XmlNode Jugador(XmlDocument pArchivo, XmlNode pEquipo, int pPasaporteXFIFA, int pTiempoActivo)
        {
            XmlNode mJugador = pArchivo.CreateElement("jugador");

            XmlAttribute mPasaporteXFIFA = pArchivo.CreateAttribute("pasaportexfifa");
            mPasaporteXFIFA.Value = pPasaporteXFIFA.ToString();
            mJugador.Attributes.Append(mPasaporteXFIFA);

            XmlAttribute mTiempoActivo = pArchivo.CreateAttribute("tiempoactivo");
            mTiempoActivo.Value = pTiempoActivo.ToString();
            mJugador.Attributes.Append(mTiempoActivo);

            pEquipo.AppendChild(mJugador);

            return mJugador;
        }

        private XmlNode Accion(XmlDocument pArchivo, XmlNode pJugador, int pTiempo, int pIDTipo)
        {
            Console.WriteLine("Generando accion[jugador:" + pJugador.Attributes.GetNamedItem("pasaportexfifa").Value + ", tiempo:" + pTiempo + ", tipo:" + pIDTipo + "]");
            XmlNode mAccion = pArchivo.CreateElement("accion");

            XmlAttribute mTiempo = pArchivo.CreateAttribute("tiempo");
            mTiempo.Value = pTiempo.ToString();
            mAccion.Attributes.Append(mTiempo);

            XmlAttribute mTipo = pArchivo.CreateAttribute("tipo");
            mTipo.Value = pIDTipo.ToString();
            mAccion.Attributes.Append(mTipo);

            pJugador.AppendChild(mAccion);

            return mAccion;
        }

        private ComentarioEstadistico Sustitucion(List<ComentarioEstadistico> pComentarios, Jugador pTitular)
        {
            ComentarioEstadistico mSustitucion = null;
            foreach (ComentarioEstadistico comentario in pComentarios)
            {
                if (comentario.cIDAccion == kIDSustitucion && comentario.cJugador1.cPasaporteXFIFA == pTitular.cPasaporteXFIFA)
                {
                    mSustitucion = comentario;
                    break;
                }
            }
            return mSustitucion;
        }

        private void Jugadores(XmlDocument pArchivo, XmlNode pEquipo, List<Jugador> pTitulares, List<ComentarioEstadistico> pComentarios)
        {
            foreach (Jugador titular in pTitulares)
            {
                ComentarioEstadistico mSustitucion = Sustitucion(pComentarios, titular);
                if (mSustitucion == null)
                    Jugador(pArchivo, pEquipo, titular.cPasaporteXFIFA, kDuracionPartido);
                else
                {
                    // Asumo que 1 jugador no puede volver a entrar al partido, y si entra no podría volver a salir
                    //o sino habría que cambiar la lógica!!

                    Jugador(pArchivo, pEquipo, titular.cPasaporteXFIFA, mSustitucion.cTiempo);
                    Jugador(pArchivo, pEquipo, mSustitucion.cJugador2.cPasaporteXFIFA, kDuracionPartido - mSustitucion.cTiempo);
                }
            }
        }

        private XmlNode buscarJugador(XmlNode pEquipo, int pPasaporteXFIFA)
        {
            return pEquipo.SelectSingleNode("//jugador[@pasaportexfifa='" + pPasaporteXFIFA + "']");
        }

    }
}
