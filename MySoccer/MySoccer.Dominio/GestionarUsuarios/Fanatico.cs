using MySoccer.Datos;
using MySoccer.EjeTransversal;
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
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioFantatico;
        }

        public Fanatico(String pCorreoElectronico, int pGenero, String pDescripcion, String pRutaFoto,
            int pIDPais, int pIDEquipo)
        {
            this.cCorreoElectronico = pCorreoElectronico;
            this.cGenero = pGenero;
            this.cDescripcion = pDescripcion;
            this.cRutaFoto = pRutaFoto;
            this.cIDPais = pIDPais;
            this.cIDEquipoFavorito = pIDEquipo;
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioFantatico;
        }
        public override void CrearTipoUsuarioBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datFanaticoBaseDatos();
            ((datFanaticoBaseDatos)mConexionBase).AgregarFanatico(this.cIdentificador, this.cDescripcion,
                this.cIDEquipoFavorito, this.cGenero, this.cRutaFoto, this.cCorreoElectronico, this.cIDPais);
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
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioFantatico;
        }

        public override Dictionary<String, String> GetDatos()
        {
            Dictionary<String, String> mDatosRetorno = GetDatosUsuario();

            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringDescripcion, this.cDescripcion);
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringGenero, ConstantesGestionarUsuarios.kSexos[this.cGenero]);
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringRutaFoto, this.cRutaFoto);
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringEquipoFavorito, this.cIDEquipoFavorito + "");
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringPais, this.cIDPais + "");
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringCorreoElectronico, this.cCorreoElectronico);

            return mDatosRetorno;
        }
        public void CambiarDatosFanatico(String pCorrecoElectronico, String pRutaFoto, int pEquipoFavorito,
            int pPais, int pGenero, String pDescripcion)
        {
            this.cCorreoElectronico = pCorrecoElectronico;
            this.cIDEquipoFavorito = pEquipoFavorito;
            this.cIDPais = pPais;
            this.cGenero = pGenero;
            this.cRutaFoto = pRutaFoto;
            this.cDescripcion = pDescripcion;
        }

        public override void ActualizarDatos(Dictionary<String, String> pNuevoDatos)
        {
            this.cCorreoElectronico = pNuevoDatos[ConstantesGestionarUsuarios.kStringCorreoElectronico];
            this.cIDPais = Convert.ToInt32(pNuevoDatos[ConstantesGestionarUsuarios.kStringPais]);
            this.cIDEquipoFavorito = Convert.ToInt32(pNuevoDatos[ConstantesGestionarUsuarios.kStringEquipoFavorito]);
            this.cRutaFoto = pNuevoDatos[ConstantesGestionarUsuarios.kStringRutaFoto];
            this.cDescripcion = pNuevoDatos[ConstantesGestionarUsuarios.kStringDescripcion];
            this.cGenero = Convert.ToInt32(pNuevoDatos[ConstantesGestionarUsuarios.kStringGenero]);
        }

        public override void ActualizarDatosBaseDatos()
        {
            this.ActualizarCuentaBaseDatos();
            this.ActualizarUsuarioBaseDatos();

            datUsuariosBaseDatos mConexionBaseDatos = new datFanaticoBaseDatos();
            ((datFanaticoBaseDatos)mConexionBaseDatos).ActualizarDatosFanatico(this.cIdentificador,
                this.cDescripcion, this.cCorreoElectronico, this.cRutaFoto, this.cGenero, this.cIDEquipoFavorito,
                this.cIDPais);
        }
    }
}
