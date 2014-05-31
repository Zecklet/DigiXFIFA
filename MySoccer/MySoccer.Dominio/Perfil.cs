using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Perfil
    {
        //Cual es la difencia entre estos y los setter y los getter
        //protected String cNombre; 
        //protected String cApellido;
        //protected String cFechaNacimiento;
        //protected Cuenta cCuenta;

        public Perfil(String pNombre, String pApellido, String pNombreUsuario, String pConstrasena, String pFechaNacimiento)
        {
            this.cCuenta = new Cuenta(pNombreUsuario, pConstrasena);
            this.cNombre = pNombre;
            this.cApellido = pApellido;
            this.cFechaNacimiento = pFechaNacimiento;
        }
        public String cNombre { get; set; }
        public String cApellido { get; set; }
        public String cFechaNacimiento { get; set; }
        public Cuenta cCuenta { get; set; }

    }
}
