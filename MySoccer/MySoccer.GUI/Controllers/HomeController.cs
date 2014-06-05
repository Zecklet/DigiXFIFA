using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.Dominio;
using MySoccer.Datos;
using System.IO;
using MySoccer.Presentacion.GestionarUsuarios;
using MySoccer.Presentacion.IniciarSesion;
using MySoccer.EjeTransversal;

namespace MySoccer.GUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        [HttpPost]
        public ActionResult Index(guiModelInicioSesion pModel)
        {

            HttpPostedFileBase file = pModel.cImagen;
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/ImagenesUsuarios"), fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

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

                    guiModeloUsuario mModeloUsuario = guiModeloUsuarioFactory.RecuperarModelo(mDatos, mPresentador.GetTipoUsuario());
                    mModeloUsuario.cNombreUsuario = mPresentador.GetNombreUsuario();
                    Session["Modelo"] = mModeloUsuario;
                    Session["Usuario"] = mPresentador;
                    Session["Nombre"] = mPresentador.GetNombre();

                    return RedirectToAction(mModeloUsuario.cTipoUsuario + "_Perfil", "Usuario");
                }
                else
                {
                    ModelState.AddModelError(ConstantesGestionarUsuarios.kStringCodigoError, mResultado.GetMensajeError());
                }
            }
            return View("Index",pModel);
        }


        public ActionResult Administrador_Calendario()
        {
            return View();
        }

        public ActionResult Administrador_Equipo()
        {
            return View();
        }

        public ActionResult Administrador_ListaRechazados()
        {
            return View();
        }

        public ActionResult Administrador_Partido()
        {
            return View();
        }

        public ActionResult Administrador_Torneo()
        {
            return View();
        }


        public ActionResult Narrador_Calendario()
        {
            return View();
        }

        public ActionResult Narrador_Jugadores()
        {
            return View();
        }

        public ActionResult Narrador_Partido()
        {
            return View();
        }


        public ActionResult Narrador_Jugador()
        {
            return View();
        }

        public ActionResult Fanatico_Calendario()
        {
            return View();
        }

        public ActionResult Fanatico_Partido()
        {
            return View();
        }

        public ActionResult Fanatico_Jugador()
        {
            return View();
        }

    }
}
