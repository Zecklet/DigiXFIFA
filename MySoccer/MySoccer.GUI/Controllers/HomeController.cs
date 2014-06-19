using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.Dominio;
using MySoccer.Datos;
using System.IO;
using MySoccer.Presentacion.GestionarUsuarios;
using MySoccer.EjeTransversal;
using MySoccer.EjeTransversal.IniciarSesion;
using MySoccer.EjeTransversal.GestionarUsuarios;

namespace MySoccer.GUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/


        public ActionResult Index()
        {
            Session["Usuario"] = null;
            Session["Modelo"] = null;

            return View(new guiModelInicioSesion());
        }

        [HttpGet]
        public ActionResult IniciarSesion(guiModelInicioSesion pModel)
        {
            if (ModelState.IsValid)
            {
                PresentadorGestionarUsuarios mPresentador = new PresentadorGestionarUsuarios();

                //Si se retorna verdadero es por que el usuario existe y la contrasena es la correcta 
                ContenedorError mResultado = mPresentador.UsuarioCorrecto(pModel.cNombreUsuario, pModel.cConstrasena);
                if (!mResultado.HayError())
                {
                    //Que tan mal es almacenar toda la informacion del usuario

                    Dictionary<String, String> mDatos = mPresentador.GetDatos();

                    guiModeloUsuario mModeloUsuario = guiModeloUsuarioFactory.CrearModelo(mDatos, mPresentador.GetTipoUsuario());
                    mModeloUsuario.cNombreUsuario = mPresentador.GetNombreUsuario();
                    Session["Modelo"] = mModeloUsuario;
                    //Session["Usuario"] = mPresentador;
                    Session["Nombre"] = mPresentador.GetNombre();
                    Session["EstadoUsuario"] = mModeloUsuario.cEstado;
                    return RedirectToAction(mModeloUsuario.cTipoUsuario + "_Perfil", "Usuario");

                }
                else
                {
                    ModelState.AddModelError(ConstantesGestionarUsuarios.kStringCodigoError, mResultado.GetMensajeError());
                }
            }
            return View("Index", pModel);
        }
    }
}
