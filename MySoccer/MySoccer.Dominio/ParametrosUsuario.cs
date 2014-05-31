using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio
{
    public class ParametrosUsuario
    {
        //Introduce los datos las cuentas
        public ParametrosUsuario(String pNombre, String pApellido, String pNombreUsuario, String pConstrasena,
            String pFechaNacimiento)
        {
            this.cNombre = pNombre;
            this.cApellido = pApellido;
            this.cNombreUsuario = pNombreUsuario;
            this.cContrasena = pConstrasena;
            this.cFechaNacimiento = pFechaNacimiento;
        }

        //Introduce los datos del Administrdaor
        public void DatosAdministrador(String pCorreoElectronico)
        {
            this.cCorreoElectronico = pCorreoElectronico;
        }
        //Introduce los datos del fantaico
        public void DatosFanatico(int pGenero, String pDescripcion, String pCorreoElectronico, int pPais,
            int pEquipoFavorito, String pRutaFoto)
        {
            this.cGenero = pGenero;
            this.cDescripcion = pDescripcion;
            this.cCorreoElectronico = pCorreoElectronico;
            this.cPais = pPais;
            this.cEquipoFavorito = pEquipoFavorito;
            this.cRutaFoto = pRutaFoto;
        }
        //Introduce los datos del narrador
        public void DatosNarrador(int pGenero, String pDescripcion, int pAnosExperiencia, String pRutaFoto)
        {
            this.cGenero = pGenero;
            this.cDescripcion = pDescripcion;
            this.cAnosExperiencia = pAnosExperiencia;
            this.cRutaFoto = pRutaFoto;
        }

        public String cNombre { get; set; }
        public String cApellido { get; set; }
        public String cNombreUsuario { get; set; }
        public String cContrasena { get; set; }
        public String cFechaNacimiento { get; set; }
        public String cCorreoElectronico { get; set; }
        public String cDescripcion { get; set; }
        public int cGenero { get; set; }
        public int cPais { get; set; }
        public String cRutaFoto { get; set; }
        public int cAnosExperiencia { get; set; }
        public int cEquipoFavorito { get; set; }
    }
}
