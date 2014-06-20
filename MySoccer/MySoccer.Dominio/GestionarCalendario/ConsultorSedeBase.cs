using MySoccer.Datos.GestionarCalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio.GestionarUsuarios
{
    public sealed class ConsultorSedeBase
    {
        static private ConsultorSedeBase cFabricaUsuario = null;
        public static ConsultorSedeBase Instance
        {
            get
            {
                if (cFabricaUsuario == null)
                {
                    cFabricaUsuario = new ConsultorSedeBase();
                }
                return cFabricaUsuario;
            }
        }

        public static Dictionary<int,String> GetSedes()
        {
            datSedeBaseDatos mConexionBasePaises = new datSedeBaseDatos();
            return mConexionBasePaises.GetSedes();
        }
        public static String GetNombreSede(int pIdSede)
        {
            datSedeBaseDatos mConexionBasePaises = new datSedeBaseDatos();
            return mConexionBasePaises.GetNombreSede(pIdSede);
        }
    }
}
