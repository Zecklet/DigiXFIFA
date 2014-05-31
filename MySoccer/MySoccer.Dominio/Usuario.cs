using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
   public class Usuario
    {
       public int cIdentificador { get; set; }
       public String cNombre { get; set; }
       public String cApellido { get; set; }
       public String cFechaNacimiento { get; set; }
       public Cuenta cCuenta { get; set; }
       public int cIDTipo { get; set; } //Consultar si es requerido: Podría servir para asignar permisos y desplegar comentarios.

        public void DesactivarCuenta()
        {
            cCuenta.cEstado = false;
        }

        public void ActivarCuenta()
        {
            cCuenta.cEstado = true;
        }

    }

}
