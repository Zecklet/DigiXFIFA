using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;
using MySoccer.EjeTransversal;
using MySoccer.EjeTransversal.GestionarUsuarios;

namespace MySoccer.Dominio
{

    public sealed class UsuariosFactory
    {
        static private UsuariosFactory cFabricaUsuario = null;

        public static UsuariosFactory Instance
        {
            get
            {
                if (cFabricaUsuario == null)
                {
                    cFabricaUsuario = new UsuariosFactory();
                }
                return cFabricaUsuario;
            }
        }
            
        public Usuario CrearUsuario(int pTipoUsuario)
        {
            Usuario mNuevoUsuario = null;
            switch (pTipoUsuario)
            {
                case ConstantesGestionarUsuarios.kUsuarioAdministrador:
                    mNuevoUsuario = new Administrador();
                    break;
                case ConstantesGestionarUsuarios.kUsuarioNarrador:
                    mNuevoUsuario = new Narrador();
                    break;
                case ConstantesGestionarUsuarios.kUsuarioFantatico:
                    mNuevoUsuario = new Fanatico();
                    break;
                default:
                    break;
            }
            return mNuevoUsuario;
        }
    }
}
