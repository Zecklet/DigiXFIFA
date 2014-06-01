using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;


namespace MySoccer.Dominio
{
    public class AdministrarUsuario
    {
        private Usuario cUsuarioActual;
        public AdministrarUsuario() {
            
        }

        //Este metodo crea un administrador 
        public int AgregarNuevoUsuario(ParametrosUsuario pDatosUsuario, int pTipoUsuario)
        {
            Usuario mNuevoUsuario = UsuariosFactory.CrearUsuario(pDatosUsuario, pTipoUsuario);
            if (mNuevoUsuario.ExisteNombreUsuario(pDatosUsuario.cNombreUsuario))
            {
                return datConstantes.kCodigoNombreUsuarioExiste; //existe el usuario y no se debe de crear, falta mandar un mensaje de error
            }
            else
            {
                mNuevoUsuario.CrearUsuarioBaseDatos();
                mNuevoUsuario.CrearCuentaBaseDatos();
                mNuevoUsuario.CrearTipoUsuarioBaseDatos();
                return 0;
            }
        }

        public Usuario ObtenerUsuario(String pNombreUsuario, String pContrasena)
        {
            Usuario mUsuario = UsuariosFactory.RecuperarUsuario(pNombreUsuario);
            //Falta la comprobación de la contrasena
            this.cUsuarioActual = mUsuario;
            return mUsuario;
        }
    }

    
}
