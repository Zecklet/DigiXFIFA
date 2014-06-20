using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos.Entity;
using MySoccer.EjeTransversal.AdministrarListaRechazados;

namespace MySoccer.Datos.AdministrarListaRechazados
{
    public class ListaRechazadosBaseDatos
    {
        public Boolean AgregarRechazado(String pPasaporte, String pNombre, String pApellido)
        {
            if (ExisteRechazado(pPasaporte))
            {
                return false;
            }
            using (var mConexion = new MY_SOCCER_CONEXION())
            {
                RECHAZADO mNuevoRechazado = new RECHAZADO()
                {
                    Nombre = pNombre,
                    Apellido = pApellido,
                    Pasaporte_XFIFA = pPasaporte,
                    Intentos_Ingreso = 0
                };

                mConexion.RECHAZADO.Add(mNuevoRechazado);
                mConexion.SaveChanges();
            }
            return true;
        }

        public List<ContenedorRechazado> GetListaRechazados()
        {
            List<ContenedorRechazado> mResultado = new List<ContenedorRechazado>();
            using (var mConexion = new MY_SOCCER_CONEXION())
            {
                foreach (var mRechazado in mConexion.RECHAZADO)
                {
                    mResultado.Add(new ContenedorRechazado()
                    {
                        cApellido = mRechazado.Apellido,
                        cNombre = mRechazado.Nombre,
                        cPasaporte = mRechazado.Pasaporte_XFIFA,
                        cIntentosIngreso = (mRechazado.Intentos_Ingreso==null) ? 0:(int) mRechazado.Intentos_Ingreso
                    });
                }
            }
            return mResultado;
        }

        public void EliminarRechazado(String pPasaporte)
        {
            using (var mConexionMySoccer = new MY_SOCCER_CONEXION())
            {
                var mRechazado = mConexionMySoccer.RECHAZADO.Where(s => s.Pasaporte_XFIFA == pPasaporte).First();
                mConexionMySoccer.RECHAZADO.Attach(mRechazado);
                mConexionMySoccer.RECHAZADO.Remove(mRechazado);

                mConexionMySoccer.SaveChanges();
            }
        }
        public Boolean ExisteRechazado(String pPasaporte)
        {
            Boolean mResultados;
            using (var mConexionMySoccer = new MY_SOCCER_CONEXION())
            {
                var mRechazado = mConexionMySoccer.RECHAZADO.Where(s => s.Pasaporte_XFIFA == pPasaporte);
                mResultados = mRechazado.Count() != 0;
            }
            return mResultados;
        }
    }
}
