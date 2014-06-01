using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;

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

        public static Usuario CrearUsuario(ParametrosUsuario pDatosUsuario, int pTipoUsuario)
        {
            Usuario mNuevoUsuario = null;
            switch (pTipoUsuario)
            {
                case datConstantes.kUsuarioAdministrador:
                    mNuevoUsuario = new Administrador(pDatosUsuario.cCorreoElectronico);
                    break;
                case datConstantes.kUsuarioNarrador:
                    mNuevoUsuario = new Narrador(pDatosUsuario.cGenero, pDatosUsuario.cRutaFoto,
                        pDatosUsuario.cAnosExperiencia, pDatosUsuario.cDescripcion);
                    break;
                case datConstantes.kUsuarioFantatico:
                    mNuevoUsuario = new Fanatico(pDatosUsuario.cCorreoElectronico,pDatosUsuario.cGenero,
                        pDatosUsuario.cDescripcion,pDatosUsuario.cRutaFoto,pDatosUsuario.cPais,pDatosUsuario.cEquipoFavorito);
                    break;
                default:
                    break;
            }
            mNuevoUsuario.ColocarDatos(pDatosUsuario.cNombre, pDatosUsuario.cApellido, pDatosUsuario.cFechaNacimiento,
                pDatosUsuario.cNombreUsuario, pDatosUsuario.cContrasena);
            return mNuevoUsuario;
        }


        //PREGUNTAR: si una fabrica puede crear un segundo metodo de factory
        //
        public static Usuario RecuperarUsuario(String pNombreUsuario)
        {
            Usuario mNuevoUsuario = new Administrador();
            int mTipoUsuario = mNuevoUsuario.RecuperarTipoUsuario(pNombreUsuario);

            if (!mNuevoUsuario.ExisteNombreUsuario(pNombreUsuario))
            {
                return null;
            }
            mNuevoUsuario.RecuperarUsuarioBaseDatos();

            switch (mTipoUsuario)
            {
                case datConstantes.kUsuarioAdministrador:
                    mNuevoUsuario = new Administrador();
                    mNuevoUsuario.RecuperarCuentaBaseDatos(pNombreUsuario);
                    break;
                case datConstantes.kUsuarioNarrador:
                    break;
                case datConstantes.kUsuarioFantatico:
                    break;
                default:
                    break;
            }
            mNuevoUsuario.RecuperarDatosBaseDatos();
            mNuevoUsuario.RecuperarUsuarioBaseDatos();
            mNuevoUsuario.RecuperarDatosBaseDatos();
            return mNuevoUsuario;
        }
    }
}
