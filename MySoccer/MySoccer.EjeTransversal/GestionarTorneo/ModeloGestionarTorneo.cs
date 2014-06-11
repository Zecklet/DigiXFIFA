using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.EjeTransversal.GestionarTorneo
{
    public class ModeloGestionarTorneo
    {
        public String cNombre { get; set; }

        public ModeloGestionarTorneo(String pNombre)
        {
            this.cNombre = pNombre;
        }
    }
}
