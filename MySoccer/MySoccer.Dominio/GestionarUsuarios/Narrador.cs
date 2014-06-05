using MySoccer.Datos;
using MySoccer.Datos.Entity;
using MySoccer.EjeTransversal;
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
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioNarrador;
        }

        public Narrador(int pGenero, String pRutaFoto, int pAnosExperiencia, String pDescripcion)
        {
            this.cAnosExperiencia = pAnosExperiencia;
            this.cRutaFoto = pRutaFoto;
            this.cDescripcion = pDescripcion;
            this.cGenero = pGenero;
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioNarrador;
        }
        public override void CrearTipoUsuarioBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datNarradorBaseDatos();
            ((datNarradorBaseDatos)mConexionBase).AgregarNarrador(this.cIdentificador, this.cAnosExperiencia,
                this.cDescripcion, this.cGenero, this.cRutaFoto);
        }

        public override void RecuperarDatosBaseDatos()
        {
            datUsuariosBaseDatos mConexionBase = new datNarradorBaseDatos();
            NARRADOR mNarrador = ((datNarradorBaseDatos)mConexionBase).ObtenerNarrador(this.cIdentificador);
            this.cAnosExperiencia = mNarrador.Anos_Experiencia;
            this.cDescripcion = mNarrador.Descripcion;
            this.cGenero = mNarrador.Genero;
            this.cRutaFoto = mNarrador.Foto;
            this.cIDTipo = ConstantesGestionarUsuarios.kUsuarioNarrador;
        }
        public override Dictionary<String, String> GetDatos()
        {

            Dictionary<String, String> mDatosRetorno = GetDatosUsuario();

            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringDescripcion, this.cDescripcion);
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringAnosExperiencia, this.cAnosExperiencia + "");
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringGenero, ConstantesGestionarUsuarios.kSexos[this.cGenero]);
            mDatosRetorno.Add(ConstantesGestionarUsuarios.kStringRutaFoto, this.cRutaFoto);

            return mDatosRetorno;

        }
        public void CambiarDatosNarrador(String pRutaFoto, String pDescripcion,
            int pAnosExperiencia, int pGenero)
        {
            this.cRutaFoto = pRutaFoto;
            this.cDescripcion = pDescripcion;
            this.cGenero = pGenero;
            this.cAnosExperiencia = pAnosExperiencia;
        }

        public override void ActualizarDatos(Dictionary<String, String> pNuevoDatos)
        {
            this.cRutaFoto = pNuevoDatos[ConstantesGestionarUsuarios.kStringRutaFoto];
            this.cDescripcion = pNuevoDatos[ConstantesGestionarUsuarios.kStringDescripcion];
            this.cGenero = Convert.ToInt32(pNuevoDatos[ConstantesGestionarUsuarios.kStringGenero]);
            this.cAnosExperiencia = Convert.ToInt32(pNuevoDatos[ConstantesGestionarUsuarios.kStringAnosExperiencia]);
        }

        public override void ActualizarDatosBaseDatos()
        {
            this.ActualizarCuentaBaseDatos();
            this.ActualizarUsuarioBaseDatos();

            datUsuariosBaseDatos mConexionBaseDatos = new datNarradorBaseDatos();
            ((datNarradorBaseDatos)mConexionBaseDatos).ActualizarDatosNarrador(this.cIdentificador,
                this.cDescripcion, this.cRutaFoto, this.cGenero, this.cAnosExperiencia);
        }
    }
}
