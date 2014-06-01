using MySoccer.Datos;
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

        public Fanatico()
        {
        }
        
        public Fanatico (String pCorreoElectronico, int pGenero, String pDescripcion, String pRutaFoto,
            int pIDPais, int pIDEquipo)
        {
            this.cCorreoElectronico = pCorreoElectronico;
            this.cGenero = pGenero;
            this.cDescripcion = pDescripcion;
            this.cRutaFoto = pRutaFoto;
            this.cIDPais = pIDPais;
            this.cIDEquipoFavorito = pIDEquipo;
            this.cIDTipo = datConstantes.kUsuarioFantatico;
        }
        public override void CrearTipoUsuarioBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datFanaticoBaseDatos();
            ((datFanaticoBaseDatos)mConexionBase).AgregarFanatico(this.cIdentificador, this.cDescripcion,
                this.cIDEquipoFavorito,this.cGenero, this.cRutaFoto, this.cCorreoElectronico,this.cIDPais);
        }

        public override void RecuperarDatosBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datFanaticoBaseDatos();
            FANATICO mFanatico = ((datFanaticoBaseDatos)mConexionBase).ObtenerFanatico(this.cIdentificador);
            this.cIDEquipoFavorito = mFanatico.FK_Equipo_Favorito;
            this.cDescripcion = mFanatico.Descripcion;
            this.cGenero = mFanatico.Genero;
            this.cRutaFoto = mFanatico.Foto;
            this.cIDPais = mFanatico.FK_Pais;
            this.cCorreoElectronico = mFanatico.Correo_Electronico;
            this.cIDTipo = datConstantes.kUsuarioFantatico;
        }
    }
}
