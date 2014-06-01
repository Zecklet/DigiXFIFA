using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos
{
    public static class datConstantes
    {

        //Codigo de cada tipo de usuario 
        public const int kUsuarioAdministrador = 1;
        public const int kUsuarioNarrador = 2;
        public const int kUsuarioFantatico = 3;

        //Codigo de errores
        
        public const int kCodigoNombreUsuarioExiste = 1;

        //Mesajes de errores

        public const String kMensajeNombreUsuarioExiste = "El nombre de usuario ingresado ya existe en el sistema. \n Por favor intentelo de nuevo.";

    }
}
