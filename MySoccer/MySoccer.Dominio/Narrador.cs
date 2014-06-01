using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Narrador : Usuario
    {
        public int cGenero { get; set; }
        public String cRutaFoto { get; set; }
        public int cAnosExperiencia { get; set; }
        public String cDescripcion { get; set; }



        public Narrador(int pGenero, String pRutaFoto, int pAnosExperiencia, String pDescripcion)
        {
            this.cAnosExperiencia = pAnosExperiencia;
            this.cRutaFoto = pRutaFoto;
            this.cDescripcion = pDescripcion;
            this.cGenero = pGenero;
        }
    }
}
