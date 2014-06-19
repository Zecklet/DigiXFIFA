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
using MySoccer.EjeTransversal.GestionarUsuarios;

namespace MySoccer.Presentacion.GestionarUsuarios
{
    public class PresentadorGestionarUsuarios
    {
        //private AdministrarUsuario cAdmiUsuarios;

        public PresentadorGestionarUsuarios()
        {
            //this.cAdmiUsuarios = new AdministrarUsuario();
        }

        //-----------------------------------------------------------------\\
        //----------------------Funciones generales------------------------\\
        //-----------------------------------------------------------------\\


        public void DesactivarUsuario()
        {
            //this.cAdmiUsuarios.DesactivarUsuario();
            AdministrarUsuario.Instance.DesactivarUsuario();

        }

        public void ActivarUsuario()
        {
            //this.cAdmiUsuarios.ActivarUsuario();
            AdministrarUsuario.Instance.ActivarUsuario();
        }
        public guiModeloUsuario GetModeloUsuario(int pTipoUsuario)
        {
            return guiModeloUsuarioFactory.Instance.CrearModelo(pTipoUsuario);
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
            return AdministrarUsuario.Instance.UsuarioCorrecto(pNombreUsuario, pContrasena);
        }

        //Obtiene el nombre de usuario del usuario que inicio sesion
        public String GetNombreUsuario()
        {
            return AdministrarUsuario.Instance.GetNombreUsuario();
        }

        //obtiene los datos del usuario que se encuentra almacenado en el administrador de usuarios 
        public Dictionary<String, String> GetDatos()
        {
            return AdministrarUsuario.Instance.GetDatos();
        }

        //se devuelve el tipo de usuario que inicio sesion 
        public int GetTipoUsuario()
        {
            return AdministrarUsuario.Instance.GetUsuarioActual().cIDTipo;
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
            return AdministrarUsuario.Instance.GetUsuarioActual().cCuenta.cFechaInscripcion.ToString();
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
            return AdministrarUsuario.Instance.GetNombre();
        }

        //-----------------------------------------------------------------\\
        //-------------------Seccion del Administrador---------------------\\
        //-----------------------------------------------------------------\\

        public ContenedorError AgregarAdministrador(guiModeloAdministrador pModel)
        {
            int mResultado = AdministrarUsuario.Instance.AgregarNuevoUsuario(pModel,
                ConstantesGestionarUsuarios.kUsuarioAdministrador);
            return CrearContenedor(mResultado);
        }

        public ContenedorError ActualizarAdministrador(guiModeloAdministrador pModel)
        {
            int mResultado = AdministrarUsuario.Instance.ActualizarUsuario(pModel);
            return CrearContenedor(mResultado);
        }

        //-----------------------------------------------------------------\\
        //----------------------Seccion del Narrador-----------------------\\
        //-----------------------------------------------------------------\\

        public ContenedorError AgregarNarrador(guiModeloNarrador pModel)
        {
            int mResultado = AdministrarUsuario.Instance.AgregarNuevoUsuario(pModel,
                ConstantesGestionarUsuarios.kUsuarioNarrador);
            return CrearContenedor(mResultado);
        }

        public ContenedorError ActualizarNarrador(guiModeloNarrador pModel)
        {
            int mResultado = AdministrarUsuario.Instance.ActualizarUsuario(pModel);
            return CrearContenedor(mResultado);
        }

        public String GetRutaFotoNarrador()
        {
            return ((Narrador)AdministrarUsuario.Instance.GetUsuarioActual()).cRutaFoto;
        }
        
        //-----------------------------------------------------------------\\
        //----------------------Seccion del Fanatico-----------------------\\
        //-----------------------------------------------------------------\\

        public ContenedorError AgregarFanatico(guiModeloFanatico pModel)
        {
            int mResultado = AdministrarUsuario.Instance.AgregarNuevoUsuario(pModel, 
                ConstantesGestionarUsuarios.kUsuarioFantatico);
            ContenedorError mError = new ContenedorError(mResultado);
            return CrearContenedor(mResultado);
        }

        public ContenedorError ActualizarFanatico(guiModeloFanatico pModel)
        {
            int mResultado = AdministrarUsuario.Instance.ActualizarUsuario(pModel);
            return CrearContenedor(mResultado);
        }

        public String GetRutaFotoFanatico()
        {
            return ((Fanatico)AdministrarUsuario.Instance.GetUsuarioActual()).cRutaFoto;
        }
    }
}
