using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class ComentarioTexto
    {
        public Usuario cAutor { get; set; }
        public int cTiempo { get; set; }
        public String cTexto { get; set; }
    }
}
