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

       public void ColocarDatos(String pNombre, String pApellido, String pFechaNacimiento, String pNombreUsuario, String pContrasena)
       {
           this.cNombre = pNombre;
           this.cApellido = pApellido;
           this.cFechaNacimiento = cFechaNacimiento;
           this.cCuenta = new Cuenta(pNombreUsuario, pContrasena);
       }

       public void SetIdTipo(int pTipo)
       {
           this.cIDTipo = pTipo;
       }

        public void DesactivarCuenta()
        {
            this.cCuenta.cEstado = false;
        }

        public void ActivarCuenta()
        {
            cCuenta.cEstado = true;
        }

    }

}
