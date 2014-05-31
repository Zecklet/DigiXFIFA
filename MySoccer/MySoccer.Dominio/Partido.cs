using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Partido
    {
        public String cFecha { get; set; }
        public String cHora { get; set; }
        public int cIDTorneo { get; set; }
        public Equipo cEquipo1 { get; set; }
        public Equipo cEquipo2 { get; set; }
        public int cIDSede { get; set; } //Evaluar si hacemos objeto sede
        public Narrador cNarrador { get; set; }
        public ResultadoPartido cResultadoPartido { get; set; }
    }
}
