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

        public int ObtenerUsuario(String pNombreUsuario, String pContrasena)
        {
            int mResultadoBusqueda = 0;
            Usuario mUsuario = UsuariosFactory.RecuperarUsuario(pNombreUsuario);
            //Falta la comprobación de la contrasena
            this.cUsuarioActual = mUsuario;

            if (mUsuario == null)
            {
                mResultadoBusqueda = datConstantes.kCodigoNombreUsuarioExiste;
            }
            else if (!mUsuario.CompararContrasena(pContrasena))
            {
                mResultadoBusqueda = datConstantes.kCodigoContrasenaIncorrecta;
            }
            return mResultadoBusqueda;
        }
    }
}
