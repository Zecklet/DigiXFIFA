using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.EjeTransversal
{
    public class ConstantesGestionarCalendario
    {
        //------------------------------------------------------------------\\
        //-------------------CONTANTES PARA LOS PARTIDOS--------------------\\
        //------------------------------------------------------------------\\

        public const String kStringMarcadorVacio = "0 - 0";
        public const String kStringAsistenciaVacia = "0";

        //Codigo de los estados del partido 

        public const int kCodigoPartidoNoJugado = 0;
        public const int kCodigoPartidoEnVivo = 1;
        public const int kCodigoPartidoJugado = 2;

        //String del estado de un partido 

        public static String[] kStringEstadosPartido = { "No jugado", "En vivo", "Jugado" };
    }
}
