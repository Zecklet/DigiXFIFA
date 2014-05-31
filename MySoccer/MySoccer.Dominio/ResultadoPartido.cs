using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class ResultadoPartido
    {
        public Boolean cEstado { get; set; }
        public int cAsistencia { get; set; }
        public List<Jugador> cTitularesEquipo1 { get; set; }
        public int cMarcadorEquipo1 { get; set; }
        public List<Jugador> cTitularesEquipo2 { get; set; }
        public int cMarcadorEquipo2 { get; set; }

        public List<ComentarioEstadistico> cComentarios { get; set; }
    }
}
