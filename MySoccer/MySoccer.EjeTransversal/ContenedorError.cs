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
            cMensajeError = ConstantesGestionarUsuarios.kContenedorMensajes[pTipoError];
            if (pTipoError == 0)
            {
                this.cHayError = false;
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
