using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Equipo
    {
        public int cIdentificador { get; set; }
        public String cNombreFederacion { get; set; }
        public String cRutaFoto { get; set; }
        public String cFechaAsociacionXFIFA { get; set; }
        public int cIDPais { get; set; }
        public int cIDTorneo { get; set; } //Decirle a Araña!(BD)
        public List<Jugador> cJugadores { get; set; }
    }
}
