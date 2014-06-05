using MySoccer.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio.GestionarUsuarios
{
    public sealed class ConsultorEquipoBase
    {
        static private ConsultorEquipoBase cFabricaUsuario = null;
        public static ConsultorEquipoBase Instance
        {
            get
            {
                if (cFabricaUsuario == null)
                {
                    cFabricaUsuario = new ConsultorEquipoBase();
                }
                return cFabricaUsuario;
            }
        }

        public static Dictionary<int,String> GetEquipos()
        {
            datEquipoBaseDatos mConexionBasePaises = new datEquipoBaseDatos();
            return mConexionBasePaises.GetEquipos();
        }

        public static String GetNombreEquipo(int pIDEquipo)
        {
            datEquipoBaseDatos mConexionBaseEquipos = new datEquipoBaseDatos();
            return mConexionBaseEquipos.GetNombreEquipo(pIDEquipo);
        }

    }
}
