using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{

    

    public class UsuariosFactory
    {
        const String kUsuarioAdministrador = "Administrador";
        const String kUsuarioNarrador = "Narrador";
        const String kUsuarioFantatico = "Fanatico";

        public UsuariosFactory()
        {

        }

        public Usuario CrearUsuario(ParametrosUsuario pDatosUsuario, String pTipoUsuario)
        {
            Usuario mNuevoUsuario = null;
            switch (pTipoUsuario)
            {
                case "Administrador":
                    mNuevoUsuario = new Administrador(pDatosUsuario.cCorreoElectronico);
                    break;
                case kUsuarioNarrador:
                    mNuevoUsuario = new Narrador(pDatosUsuario.cGenero, pDatosUsuario.cRutaFoto,
                        pDatosUsuario.cAnosExperiencia, pDatosUsuario.cDescripcion);
                    break;
                case kUsuarioFantatico:
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
    }
}
