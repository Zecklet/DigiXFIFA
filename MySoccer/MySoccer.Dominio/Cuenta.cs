using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class Cuenta
    {
        public Boolean cEstado { get; set; }
        public String cNombreUsuario { get; set; }
        public String cContrasena { get; set; }
        public DateTime cFechaInscripcion { get; set; }

        public Cuenta(String pNombreUsuario, String pContrasena)
        {
            this.cEstado = false;
            this.cFechaInscripcion = DateTime.Now;
            this.cNombreUsuario = pNombreUsuario;
            this.cContrasena = pContrasena;
        }

        public Boolean CompararContrasena(String pContrasena)
        {
            return (this.cContrasena == pContrasena);
        }
    }
}
