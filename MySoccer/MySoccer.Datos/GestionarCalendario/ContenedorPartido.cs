using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Datos.GestionarCalendario
{
    public class ContenedorPartido
    {
        public String cFecha { get; set; }
        public String cFase { get; set; }
        public String cHora { get; set; }
        public int cIDTorneo { get; set; }
        public int cIdEquipo1 { get; set; }
        public int cIdEquipo2 { get; set; }
        public String cNombreEquipo1 { get; set; }
        public String cNombreEquipo2 { get; set; }
        public int cIDSede { get; set; } //Evaluar si hacemos objeto sede
        public String cNombreSede { get; set; } //Evaluar si hacemos objeto sede
        public String cAsistencia { get; set; }
        public String cEstado { get; set; }
        public int cPartidoJugado { get; set; }
        public String cMarcador { get; set; }
        public int cIdPartido { get; set; }

    }
}
