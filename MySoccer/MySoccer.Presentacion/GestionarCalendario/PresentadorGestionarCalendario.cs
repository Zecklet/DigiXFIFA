using MySoccer.Datos.GestionarCalendario;
using MySoccer.Dominio.GestionarUsuarios;
using MySoccer.EjeTransversal;
using MySoccer.EjeTransversal.GestionarCalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Presentacion.GestionarCalendario
{
    public class PresentadorGestionarCalendario
    {
        public ModeloGestionarCalendario GetModeloTorneo(int pTorneo)
        {
            PartidoBaseDatos mConexionBasePartido = new PartidoBaseDatos();
            List<ContenedorPartido> mPartidosRegistrados = mConexionBasePartido.GetPartidos(pTorneo);
            ModeloGestionarCalendario mModeloCalendario = new ModeloGestionarCalendario();
            mModeloCalendario.cListaPartidos = mPartidosRegistrados;
            mModeloCalendario.cTorneoSeleccionado = pTorneo;
            mModeloCalendario.cTorneos = GetTorneos();
            return mModeloCalendario;
        }

        //Falta conectarse con myhistory y obtener todos los torneos 
        public Dictionary<int, String> GetTorneos()
        {
            Dictionary<int,String> mTorneo = new Dictionary<int,string>();
            mTorneo.Add(2014,"2014");
            mTorneo.Add(2013,"2013");
            return mTorneo;
        }

        public ModeloDatosPartido GetModeloAgregarPartido(int pTorneoSeleccionado)
        {
            ModeloDatosPartido mNuevoModelo = new ModeloDatosPartido()
            {
                cEquipos = ConsultorEquipoBase.GetEquipos(),
                cSedes = ConsultorSedeBase.GetSedes(),
                cTorneoSeleccionado = pTorneoSeleccionado
            };
            return mNuevoModelo;
        }

        public void SetEquiposSedes(ref ModeloDatosPartido pModelo)
        {
            pModelo.cEquipos = ConsultorEquipoBase.GetEquipos();
            pModelo.cSedes = ConsultorSedeBase.GetSedes();
        }

        //Se llama gestionar partidos porque los agrega y los actuliza al mismo tiempo 
        public ContenedorError GestionarPartido(ModeloDatosPartido pModelo)
        {
            ContenedorError mResultado;
            if (pModelo.cIdEquipo1 != pModelo.cIdEquipo2)
            {
                PartidoBaseDatos mConexionBase = new PartidoBaseDatos();
                if (pModelo.cIdPartido == null) //si no hay identificador quiere decir que no es una actualizacion
                {
                    mConexionBase.AgregarPartido(pModelo.cFase, Convert.ToDateTime(pModelo.cFecha),
                        Convert.ToInt32(pModelo.cIdEquipo1), Convert.ToInt32(pModelo.cIdEquipo2),
                        Convert.ToInt32(pModelo.cIdSede), TimeSpan.Parse(pModelo.cHora), pModelo.cTorneoSeleccionado);
                }
                else
                {
                    mConexionBase.ActualizarPartido(Convert.ToInt32(pModelo.cIdPartido), pModelo.cFase, Convert.ToDateTime(pModelo.cFecha),
                        Convert.ToInt32(pModelo.cIdEquipo1), Convert.ToInt32(pModelo.cIdEquipo2),
                        Convert.ToInt32(pModelo.cIdSede), TimeSpan.Parse(pModelo.cHora), pModelo.cTorneoSeleccionado);
                }
                mResultado = new ContenedorError(); //inicializa un error vacio, como simbolo de que no hay error
            }
            else
            {
                mResultado = new ContenedorError(ConstantesGestionarUsuarios.kCodigoEquiposIguales);
            }
            return mResultado;
        }

        public void EliminarPartido(String pIdPartido)
        {
            PartidoBaseDatos mConexionBasePartido = new PartidoBaseDatos();
            mConexionBasePartido.EliminarPartido(Convert.ToInt32(pIdPartido));
        }

        public ModeloDatosPartido GetModeloPartido(String pIdPartido)
        {
            PartidoBaseDatos mConexionBase = new PartidoBaseDatos();
            ContenedorPartido mPartido = mConexionBase.GetPartido(Convert.ToInt32(pIdPartido));
            ModeloDatosPartido mResultadoModelo = new ModeloDatosPartido()
            {
                cIdEquipo1 = mPartido.cIdEquipo1.ToString(),
                cIdEquipo2 = mPartido.cIdEquipo2.ToString(),
                cFecha = mPartido.cFecha,
                cFase = mPartido.cFase,
                cHora = mPartido.cHora,
                cIdSede = mPartido.cIDSede.ToString(),
                cIdPartido = mPartido.cIdPartido.ToString(),
                cTorneoSeleccionado = mPartido.cIDTorneo,
            };
            SetEquiposSedes(ref mResultadoModelo);
            return mResultadoModelo;
        }
    }
}
