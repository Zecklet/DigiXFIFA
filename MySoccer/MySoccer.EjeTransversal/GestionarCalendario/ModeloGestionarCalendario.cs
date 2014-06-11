using MySoccer.EjeTransversal.GestionarCalendario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.EjeTransversal.GestionarCalendario
{
    public class ModeloGestionarCalendario
    {
        public List<ContenedorPartido> cListaPartidos { get; set; }
        public String cIdPartidoSeleccionado { get; set; }
        public int cIdTorneoSeleccionado { get; set; }
        public Dictionary<int,String> cTorneos { get; set; }
        public int cTorneoSeleccionado { get; set; }

    }
}
