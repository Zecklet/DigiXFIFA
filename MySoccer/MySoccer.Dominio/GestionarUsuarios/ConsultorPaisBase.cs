using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio.GestionarUsuarios
{
    public sealed class ConsultorPaisBase
    {
        static private ConsultorPaisBase cFabricaUsuario = null;
        public static ConsultorPaisBase Instance
        {
            get
            {
                if (cFabricaUsuario == null)
                {
                    cFabricaUsuario = new ConsultorPaisBase();
                }
                return cFabricaUsuario;
            }
        }
    }
}
