using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Administrador : Usuario
    {
        public Administrador(String pCorreoElectronico)
        {
            this.cCorreoElectronico = pCorreoElectronico;
        }
        public String cCorreoElectronico { get; set; }
    }
}
