using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.GUI.Models;
using MySoccer.Dominio;
using MySoccer.Datos;

namespace MySoccer.GUI.Controllers
{
    public class UsuarioController : Controller
    {

        //Funciones de propocito general

        public ActionResult VolverInicio()
        {
            return View("Index", new guiModelInicioSesion());
        }

        public ParametrosUsuario CrearParametrosDatos(guiModeloUsuario pModel)
        {
            ParametrosUsuario mParametro = new ParametrosUsuario(pModel.cNombre,
    pModel.cApellido, pModel.cNombreUsuario,
    pModel.cContrasena, pModel.cFechaNacimiento);
            return mParametro;
        }

        //-----------------------------------------------------------------\\
        //Seccion del Administrador

        public ActionResult Administrador_Perfil()
        {
            return View();
        }

        public ActionResult Administrador_Registro()
        {
            guiModeloAdministrador mContenedorUsuario = new guiModeloAdministrador();
            mContenedorUsuario.cNombreSeccion = "Registrar administrador";
            mContenedorUsuario.cAccion = "Administrador_Registro";
            return View(mContenedorUsuario);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult Administrador_Registro(guiModeloAdministrador pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AdministrarUsuario mUsuarios = new AdministrarUsuario();
                    ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
                    mParametro.DatosAdministrador(pModel.cCorreoElectronico);
                    mUsuarios.AgregarNuevoUsuario(mParametro, datConstantes.kUsuarioAdministrador);
                    return VolverInicio();
                }
                System.Console.WriteLine(pModel.cNombre);
                return View("Administrador_Registro", pModel);

            }
            catch
            {
                return View("Administrador_Registro", pModel);
            }
        }

        //-----------------------------------------------------------------\\
        //Seccion del Fanatico

        public ActionResult Fanatico_Perfil()
        {
            return View();
        }

        public ActionResult Fanatico_Registro()
        {
            guiModeloFanatico mContenedorUsuario = new guiModeloFanatico();
            mContenedorUsuario.cNombreSeccion = "Registrar fanático";
            mContenedorUsuario.cAccion = "Fanatico_Registro";
            return View(mContenedorUsuario);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult Fanatico_Registro(guiModeloFanatico pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AdministrarUsuario mUsuarios = new AdministrarUsuario();
                    ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
                    mParametro.DatosFanatico(pModel.cGenero, pModel.cDescripcion, pModel.cCorreoElectronico,
                        pModel.cPais, pModel.cEquipo, pModel.cRutaImagen);
                    mUsuarios.AgregarNuevoUsuario(mParametro, datConstantes.kUsuarioFantatico);
                    return VolverInicio();
                }
                return View(pModel);

            }
            catch
            {
                return View(pModel);
            }
        }

        //-----------------------------------------------------------------\\
        //Seccion del narrador

        public ActionResult Narrador_Perfil()
        {
            return View();
        }

        //GET /Usuario/Narrador_Registro
        public ActionResult Narrador_Registro()
        {
            guiModeloNarrador mContenedorUsuario = new guiModeloNarrador();
            mContenedorUsuario.cNombreSeccion = "Registrar narrador";
            mContenedorUsuario.cAccion = "Narrador_Registro";
            return View(mContenedorUsuario);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult Narrador_Registro(guiModeloNarrador pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //regresa a la pantalla de login
                    AdministrarUsuario mUsuarios = new AdministrarUsuario();
                    ParametrosUsuario mParametro = CrearParametrosDatos(pModel);
                    mParametro.DatosNarrador(Convert.ToInt32(pModel.cGenero), pModel.cDescripcion,
                       Convert.ToInt32(pModel.cAnosExperiencia), pModel.cRutaImagen);
                    mUsuarios.AgregarNuevoUsuario(mParametro, datConstantes.kUsuarioNarrador);
                    return VolverInicio();
                }
                return View(pModel);

            }
            catch
            {
                return View(pModel);
            }
        }
    }
}
