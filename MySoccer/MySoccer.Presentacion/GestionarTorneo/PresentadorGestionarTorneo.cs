using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Presentacion.GestionarTorneo
{
    public class PresentadorGestionarTorneo
    {

        public ModeloGestionarTorneo GetModeloTorneo(String pNombre)
        {
            return (new ModeloGestionarTorneo(pNombre));
        }
    }
}
