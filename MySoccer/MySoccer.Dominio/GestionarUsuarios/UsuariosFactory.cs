using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;
using MySoccer.EjeTransversal;

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
                case ConstantesGestionarUsuarios.kUsuarioAdministrador:
                    mNuevoUsuario = new Administrador(pDatosUsuario.cCorreoElectronico);
                    break;
                case ConstantesGestionarUsuarios.kUsuarioNarrador:
                    mNuevoUsuario = new Narrador(pDatosUsuario.cGenero, pDatosUsuario.cRutaFoto,
                        pDatosUsuario.cAnosExperiencia, pDatosUsuario.cDescripcion);
                    break;
                case ConstantesGestionarUsuarios.kUsuarioFantatico:
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
        public static Usuario RecuperarUsuario(String pNombreUsuario)
        {
            Usuario mNuevoUsuario = new Administrador();
            int mTipoUsuario = mNuevoUsuario.RecuperarTipoUsuario(pNombreUsuario);

            if (!mNuevoUsuario.ExisteNombreUsuario(pNombreUsuario))
            {
                return null;
            }

            switch (mTipoUsuario)
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
            mNuevoUsuario.RecuperarCuentaBaseDatos(pNombreUsuario);
            mNuevoUsuario.RecuperarUsuarioBaseDatos();
            mNuevoUsuario.RecuperarDatosBaseDatos();
            return mNuevoUsuario;
        }
        public static Usuario ActualizarUsuarios(ParametrosUsuario pDatosUsuario, Usuario pUsuario)
        {
            switch (pUsuario.cIDTipo)
            {
                case ConstantesGestionarUsuarios.kUsuarioAdministrador:
                    ((Administrador)pUsuario).CambiarDatosAdministrador(pDatosUsuario.cCorreoElectronico);
                    break;
                case ConstantesGestionarUsuarios.kUsuarioNarrador:
                    ((Narrador)pUsuario).CambiarDatosNarrador(pDatosUsuario.cRutaFoto, pDatosUsuario.cDescripcion,
                        pDatosUsuario.cAnosExperiencia, pDatosUsuario.cGenero);
                    break;
                case ConstantesGestionarUsuarios.kUsuarioFantatico:
                    ((Fanatico)pUsuario).CambiarDatosFanatico(pDatosUsuario.cCorreoElectronico,pDatosUsuario.cRutaFoto,
                        pDatosUsuario.cEquipoFavorito, pDatosUsuario.cPais, pDatosUsuario.cGenero, pDatosUsuario.cDescripcion);
                    break;
                default:
                    break;
            }
            pUsuario.CambiarDatosCuenta(pDatosUsuario.cNombreUsuario, pDatosUsuario.cContrasena);
            pUsuario.CambiarDatosUsuario(pDatosUsuario.cNombre, pDatosUsuario.cApellido, pDatosUsuario.cFechaNacimiento);
            return pUsuario;
        }
    }
}
