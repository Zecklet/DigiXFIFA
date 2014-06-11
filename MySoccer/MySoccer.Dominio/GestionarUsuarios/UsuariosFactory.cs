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

        public static Usuario CrearUsuario(guiModeloUsuario pDatosUsuario, int pTipoUsuario)
        {
            Usuario mNuevoUsuario = null;
            switch (pTipoUsuario)
            {
                case ConstantesGestionarUsuarios.kUsuarioAdministrador:
                    mNuevoUsuario = new Administrador(((guiModeloAdministrador)pDatosUsuario).cCorreoElectronico);
                    break;
                case ConstantesGestionarUsuarios.kUsuarioNarrador:
                    guiModeloNarrador mModeloNarrador = (guiModeloNarrador)pDatosUsuario;
                    mNuevoUsuario = new Narrador(Convert.ToInt32(mModeloNarrador.cGenero), mModeloNarrador.cRutaImagen,
                        Convert.ToInt32(mModeloNarrador.cAnosExperiencia), mModeloNarrador.cDescripcion);
                    break;
                case ConstantesGestionarUsuarios.kUsuarioFantatico:
                    guiModeloFanatico mModeloFanatico = (guiModeloFanatico)pDatosUsuario;
                    mNuevoUsuario = new Fanatico(mModeloFanatico.cCorreoElectronico, Convert.ToInt32(mModeloFanatico.cGenero),
                        mModeloFanatico.cDescripcion, mModeloFanatico.cRutaImagen, Convert.ToInt32(mModeloFanatico.cPais),
                        Convert.ToInt32(mModeloFanatico.cEquipo));
                    break;
                default:
                    break;
            }
            mNuevoUsuario.ColocarDatos(pDatosUsuario.cNombre, pDatosUsuario.cApellido, pDatosUsuario.cFechaNacimiento,
                pDatosUsuario.cNombreUsuario, pDatosUsuario.cContrasena);
            return mNuevoUsuario;
        }


        //PREGUNTAR: si una fabrica puede crear un segundo metodo de factory
        public static Usuario CrearUsuario(String pNombreUsuario)
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
        public static Usuario ActualizarUsuarios(guiModeloUsuario pDatosUsuario, Usuario pUsuario)
        {
            switch (pUsuario.cIDTipo)
            {
                case ConstantesGestionarUsuarios.kUsuarioAdministrador:
                    ((Administrador)pUsuario).CambiarDatosAdministrador(((guiModeloAdministrador) pDatosUsuario).cCorreoElectronico);
                    break;
                case ConstantesGestionarUsuarios.kUsuarioNarrador:
                    guiModeloNarrador mModeloNarrador = (guiModeloNarrador)pDatosUsuario;
                    ((Narrador)pUsuario).CambiarDatosNarrador(mModeloNarrador.cRutaImagen,
                        mModeloNarrador.cDescripcion, Convert.ToInt32(mModeloNarrador.cAnosExperiencia),
                        Convert.ToInt32(mModeloNarrador.cGenero));
                    break;
                case ConstantesGestionarUsuarios.kUsuarioFantatico:
                    guiModeloFanatico mModeloFanatico = (guiModeloFanatico)pDatosUsuario;

                    ((Fanatico)pUsuario).CambiarDatosFanatico(mModeloFanatico.cCorreoElectronico, mModeloFanatico.cRutaImagen,
                        Convert.ToInt32(mModeloFanatico.cEquipo), Convert.ToInt32(mModeloFanatico.cPais),
                        Convert.ToInt32(mModeloFanatico.cGenero), mModeloFanatico.cDescripcion);
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
