using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.EjeTransversal
{
    public class ContenedorError
    {
        private String cMensajeError;
        private Boolean cHayError = true;

        public ContenedorError()
        {
            cHayError = false;
        }

        public ContenedorError(int pTipoError)
        {
            switch (pTipoError)
            {
                case ConstantesGestionarUsuarios.kCodigoNombreUsuarioExiste:
                    cMensajeError = ConstantesGestionarUsuarios.kMensajeNombreUsuarioExiste;
                    break;
                case ConstantesGestionarUsuarios.kCodigoNombreUsuarioNoExiste:
                    cMensajeError = ConstantesGestionarUsuarios.kMensajeNombreUsuarioNoExiste;
                    break;
                case ConstantesGestionarUsuarios.kCodigoContrasenaIncorrecta:
                    cMensajeError = ConstantesGestionarUsuarios.kMensajeContrasenaIncorrecta;
                    break;
                case ConstantesGestionarUsuarios.kCodigoEquiposIguales:
                    cMensajeError = ConstantesGestionarUsuarios.kMensajeEquiposIguales;
                    break;
                default:
                    cHayError = false;
                    break;
            }
        }

        public Boolean HayError()
        {
            return this.cHayError;
        }

        public String GetMensajeError(){
            return this.cMensajeError;
        }
    }
}
