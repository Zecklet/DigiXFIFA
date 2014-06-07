using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Dominio;
using MySoccer.EjeTransversal;
using MySoccer.Dominio.GestionarUsuarios;
using System.Web;
using MySoccer.Servicio;

namespace MySoccer.Presentacion.GestionarUsuarios
{
    public class PresentadorGestionarUsuarios
    {
        private AdministrarUsuario cAdmiUsuarios;

        public PresentadorGestionarUsuarios()
        {
            this.cAdmiUsuarios = new AdministrarUsuario();
        }

        //-----------------------------------------------------------------\\
        //----------------------Funciones generales------------------------\\
        //-----------------------------------------------------------------\\


        public void DesactivarUsuario()
        {
            this.cAdmiUsuarios.DesactivarUsuario();
        }

        public void ActivarUsuario()
        {
            this.cAdmiUsuarios.ActivarUsuario();
        }
        public guiModeloUsuario GetModeloUsuario(int pTipoUsuario)
        {
            return guiModeloUsuarioFactory.GetModeloVacio(pTipoUsuario);
        }

        public ParametrosUsuario CrearParametrosDatos(guiModeloUsuario pModel)
        {
            ParametrosUsuario mParametro = new ParametrosUsuario(pModel.cNombre,
                pModel.cApellido, pModel.cNombreUsuario, pModel.cContrasena, pModel.cFechaNacimiento);
            return mParametro;
        }

        //Funcion que devuel true si el nombre de usuario y la contrasenas son correctas
        public ContenedorError UsuarioCorrecto(String pNombreUsuario, String pContrasena)
        {
            return this.cAdmiUsuarios.UsuarioCorrecto(pNombreUsuario, pContrasena);
        }

        //Obtiene el nombre de usuario del usuario que inicio sesion
        public String GetNombreUsuario()
        {
            return this.cAdmiUsuarios.GetNombreUsuario();
        }

        //obtiene los datos del usuario que se encuentra almacenado en el administrador de usuarios 
        public Dictionary<String, String> GetDatos()
        {
            return this.cAdmiUsuarios.GetDatos();
        }

        //se devuelve el tipo de usuario que inicio sesion 
        public int GetTipoUsuario()
        {
            return this.cAdmiUsuarios.GetUsuarioActual().cIDTipo;
        }

        //esta funcion settea los equipos y los paises a un modelo de tipo fanatico, pues son eliminados cuando
        //se caambia de pagina 
        public void SetPaisesEquios(ref guiModeloFanatico pModel)
        {
            pModel.cPaises = ConsultorPaisBase.GetPaises();
            pModel.cEquipos = ConsultorEquipoBase.GetEquipos();
        }

        public String GetFechaInscripcion()
        {
            return this.cAdmiUsuarios.GetUsuarioActual().cCuenta.cFechaInscripcion.ToString();
        }

        //funcion que utilizan los metodos que agregan o actualizan datos
        public ContenedorError CrearContenedor(int pTipoError)
        {
            return (new ContenedorError(pTipoError));
        }

        //Esta funcion lo que hace es tomar un modelo de fanatico y colocarle el nombre del equipo y el pais 
        public void ColocarPaisEquipo(ref guiModeloFanatico pModelo)
        {
            pModelo.cPais = ConsultorPaisBase.GetNombrePais(Convert.ToInt32(pModelo.cPais));
            pModelo.cEquipo = ConsultorEquipoBase.GetNombreEquipo(Convert.ToInt32(pModelo.cEquipo));
        }

        public String GuardarImagen(String pNombreUsuario, HttpPostedFileBase pImagen)
        {
            GuardarImagenes mGuardador = new GuardarImagenes();
            return mGuardador.GuardarImagen(pNombreUsuario, pImagen);
        }

        public String GetNombre()
        {
            return this.cAdmiUsuarios.GetNombre();
        }

        //-----------------------------------------------------------------\\
        //-------------------Seccion del Administrador---------------------\\
        //-----------------------------------------------------------------\\

        public ContenedorError AgregarAdministrador(guiModeloAdministrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosAdministrador(pModel.cCorreoElectronico);
            int mResultado = this.cAdmiUsuarios.AgregarNuevoUsuario(mParametro,
                ConstantesGestionarUsuarios.kUsuarioAdministrador);
            return CrearContenedor(mResultado);
        }

        public ContenedorError ActualizarAdministrador(guiModeloAdministrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosAdministrador(pModel.cCorreoElectronico);
            int mResultado = this.cAdmiUsuarios.ActualizarUsuario(mParametro);
            return CrearContenedor(mResultado);
        }

        //-----------------------------------------------------------------\\
        //----------------------Seccion del Narrador-----------------------\\
        //-----------------------------------------------------------------\\

        public ContenedorError AgregarNarrador(guiModeloNarrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosNarrador(pModel.cGenero, pModel.cDescripcion,
                   pModel.cAnosExperiencia, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.AgregarNuevoUsuario(mParametro,
                ConstantesGestionarUsuarios.kUsuarioNarrador);
            return CrearContenedor(mResultado);
        }

        public ContenedorError ActualizarNarrador(guiModeloNarrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosNarrador(pModel.cGenero, pModel.cDescripcion,
                   pModel.cAnosExperiencia, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.ActualizarUsuario(mParametro);
            return CrearContenedor(mResultado);
        }

        public String GetRutaFotoNarrador()
        {
            return ((Narrador)this.cAdmiUsuarios.GetUsuarioActual()).cRutaFoto;
        }
        
        //-----------------------------------------------------------------\\
        //----------------------Seccion del Fanatico-----------------------\\
        //-----------------------------------------------------------------\\

        public ContenedorError AgregarFanatico(guiModeloFanatico pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosFanatico(pModel.cGenero, pModel.cDescripcion, pModel.cCorreoElectronico,
                pModel.cPais, pModel.cEquipo, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.AgregarNuevoUsuario(mParametro, ConstantesGestionarUsuarios.kUsuarioFantatico);
            ContenedorError mError = new ContenedorError(mResultado);
            return CrearContenedor(mResultado);
        }

        public ContenedorError ActualizarFanatico(guiModeloFanatico pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosFanatico(pModel.cGenero, pModel.cDescripcion, pModel.cCorreoElectronico,
                pModel.cPais, pModel.cEquipo, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.ActualizarUsuario(mParametro);
            return CrearContenedor(mResultado);
        }

        public String GetRutaFotoFanatico()
        {
            return ((Fanatico)this.cAdmiUsuarios.GetUsuarioActual()).cRutaFoto;
        }
    }
}
