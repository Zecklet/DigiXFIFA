using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos.AdministrarListaRechazados;
using MySoccer.EjeTransversal;
using MySoccer.EjeTransversal.AdministrarListaRechazados;

namespace MySoccer.Presentacion.AdministrarListaRechazados
{
    public class PresentadorListaRechazados
    {
        public ContenedorError AgregarRechazado(String pPasaporte, String pNombre, String pApellido)
        {
            ListaRechazadosBaseDatos mConexionBase = new ListaRechazadosBaseDatos();
            ContenedorError mResultado = new ContenedorError();
            if (!mConexionBase.AgregarRechazado(pPasaporte, pNombre, pApellido))
            {
                mResultado = new ContenedorError(ConstantesGestionarUsuarios.kCodigoRechazadoYaExiste);        
            }
            return mResultado;
        }

        public ModeloListaRechazados GetModeloListaRechazados()
        {
            ListaRechazadosBaseDatos mConexionBase = new ListaRechazadosBaseDatos();
            ModeloListaRechazados mModeloResultado = new ModeloListaRechazados();
            mModeloResultado.cListaRechazados = mConexionBase.GetListaRechazados();
            return mModeloResultado;
        }

        public void EliminarRechazado(String pPasaporte)
        {
            ListaRechazadosBaseDatos mConexionBase = new ListaRechazadosBaseDatos();
            mConexionBase.EliminarRechazado(pPasaporte);
        }

        public void SetRechazados(ref ModeloListaRechazados pModelo)
        {
            ListaRechazadosBaseDatos mConexionBase = new ListaRechazadosBaseDatos();
            pModelo.cListaRechazados = mConexionBase.GetListaRechazados();
        }
    }
}
