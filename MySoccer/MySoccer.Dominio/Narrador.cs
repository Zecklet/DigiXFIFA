using MySoccer.Datos;
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


        public Narrador()
        {
        }

        public Narrador(int pGenero, String pRutaFoto, int pAnosExperiencia, String pDescripcion)
        {
            this.cAnosExperiencia = pAnosExperiencia;
            this.cRutaFoto = pRutaFoto;
            this.cDescripcion = pDescripcion;
            this.cGenero = pGenero;
            this.cIDTipo = datConstantes.kUsuarioNarrador;
        }
        public override void CrearTipoUsuarioBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datNarradorBaseDatos();
            ((datNarradorBaseDatos)mConexionBase).AgregarNarrador(this.cIdentificador,this.cAnosExperiencia,
                this.cDescripcion,this.cGenero,this.cRutaFoto);
        }

        public override void RecuperarDatosBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datNarradorBaseDatos();
            NARRADOR mNarrador = ((datNarradorBaseDatos)mConexionBase).ObtenerNarrador(this.cIdentificador);
            this.cAnosExperiencia = mNarrador.Anos_Experiencia;
            this.cDescripcion = mNarrador.Descripcion;
            this.cGenero = mNarrador.Genero;
            this.cRutaFoto = mNarrador.Foto;
            this.cIDTipo = datConstantes.kUsuarioNarrador;
        }
    }
}
