using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Fanatico : Usuario
    {
        public String cCorreoElectronico { get; set; }
        public int cGenero { get; set; }
        public String cDescripcion { get; set; }
        public String cRutaFoto { get; set; }
        public int cIDPais { get; set; }
        public int cIDEquipoFavorito { get; set; }

        public Fanatico (String pCorreoElectronico, int pGenero, String pDescripcion, String pRutaFoto,
            int pIDPais, int pIDEquipo)
        {
            this.cCorreoElectronico = pCorreoElectronico;
            this.cGenero = pGenero;
            this.cDescripcion = pDescripcion;
            this.cRutaFoto = pRutaFoto;
            this.cIDPais = pIDPais;
            this.cIDEquipoFavorito = pIDEquipo;
        }
    }
}
