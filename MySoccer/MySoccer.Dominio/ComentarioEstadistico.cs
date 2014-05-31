using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class ComentarioEstadistico
    {
        public int cTiempo { get; set; } //Consultar si puede ser float! (Sr.DM)
        public int cIDAccion { get; set; }
        public Jugador cJugador1 { get; set; }
        public Jugador cJugador2 { get; set; }
        public Equipo cEquipo { get; set; }

    }
}
