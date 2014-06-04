using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Dominio;
using MySoccer.EjeTransversal;

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


        public guiModeloUsuario GetModeloUsuario(int pTipoUsuario)
        {
            return guiModeloUsuarioFactory.GetModeloVacio(pTipoUsuario);
        }

        public ParametrosUsuario CrearParametrosDatos(guiModeloUsuario pModel)
        {
            ParametrosUsuario mParametro = new ParametrosUsuario(pModel.cNombre.ToLower(),
                pModel.cApellido, pModel.cNombreUsuario, pModel.cContrasena, pModel.cFechaNacimiento);
            return mParametro;
        }

        //Funcion que devuel true si el nombre de usuario y la contrasenas son correctas
        public Boolean UsuarioCorrecto(String pNombreUsuario, String pContrasena)
        {
            return this.cAdmiUsuarios.UsuarioCorrecto(pNombreUsuario, pContrasena);
        }

        public String GetNombreUsuario()
        {
            return this.cAdmiUsuarios.GetNombreUsuario();
        }

        public Dictionary<String, String> GetDatos()
        {
            return this.cAdmiUsuarios.GetDatos();
        }

        public int GetTipoUsuario()
        {
            return this.cAdmiUsuarios.GetUsuarioActual().cIDTipo;
        }
        //-----------------------------------------------------------------\\
        //-------------------Seccion del Administrador---------------------\\
        //-----------------------------------------------------------------\\

        public int AgregarAdministrador(guiModeloAdministrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosAdministrador(pModel.cCorreoElectronico);
            int mResultado = this.cAdmiUsuarios.AgregarNuevoUsuario(mParametro,
                ConstantesGestionarUsuarios.kUsuarioAdministrador);
            return mResultado;
        }

        public int ActualizarAdministrador(guiModeloAdministrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosAdministrador(pModel.cCorreoElectronico);
            int mResultado = this.cAdmiUsuarios.ActualizarUsuario(mParametro);
            
            return mResultado;
        }

        //-----------------------------------------------------------------\\
        //----------------------Seccion del Narrador-----------------------\\
        //-----------------------------------------------------------------\\

        public int AgregarNarrador(guiModeloNarrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosNarrador(pModel.cGenero, pModel.cDescripcion,
                   pModel.cAnosExperiencia, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.AgregarNuevoUsuario(mParametro,
                ConstantesGestionarUsuarios.kUsuarioNarrador);
            return mResultado;
        }

        public int ActualizarNarrador(guiModeloNarrador pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosNarrador(pModel.cGenero, pModel.cDescripcion,
                   pModel.cAnosExperiencia, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.ActualizarUsuario(mParametro);
            return mResultado;
        }

        public String GetRutaFotoNarrador()
        {
            return ((Narrador)this.cAdmiUsuarios.GetUsuarioActual()).cRutaFoto;
        }

        public String GetRutaFotoFanatico()
        {
            return ((Narrador)this.cAdmiUsuarios.GetUsuarioActual()).cRutaFoto;
        }

        public String GetFechaInscripcion()
        {
            return this.cAdmiUsuarios.GetUsuarioActual().cCuenta.cFechaInscripcion.ToString();
        }
        //-----------------------------------------------------------------\\
        //----------------------Seccion del Fanatico-----------------------\\
        //-----------------------------------------------------------------\\

        public int AgregarFanatico(guiModeloFanatico pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosFanatico(pModel.cGenero, pModel.cDescripcion, pModel.cCorreoElectronico,
                pModel.cPais, pModel.cEquipo, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.AgregarNuevoUsuario(mParametro, ConstantesGestionarUsuarios.kUsuarioFantatico);
            return mResultado;
        }

        public int ActualizarFanatico(guiModeloFanatico pModel)
        {
            ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
            mParametro.DatosFanatico(pModel.cGenero, pModel.cDescripcion, pModel.cCorreoElectronico,
                pModel.cPais, pModel.cEquipo, pModel.cRutaImagen);
            int mResultado = this.cAdmiUsuarios.ActualizarUsuario(mParametro);
            return mResultado;
        }
    }
}
