using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    class Fanatico : Usuario
    {
        public String cCorreoElectronico { get; set; }
        public Boolean cGenero { get; set; }
        public String cDescripcion { get; set; }
        public String cRutaFoto { get; set; }
        public int cIDPais { get; set; }
        public int cIDEquipoFavorito { get; set; }
    }
}
