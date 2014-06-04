using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.Presentacion.GestionarUsuarios;
using MySoccer.Dominio;
using MySoccer.Datos;
using System.IO;
using MySoccer.Presentacion.IniciarSesion;
using MySoccer.EjeTransversal;

namespace MySoccer.GUI.Controllers
{
    public class UsuarioController : Controller
    {

        PresentadorGestionarUsuarios cPresentadorUsuarios;

        //-----------------------------------------------------------------\\
        //----------------------Funciones generales------------------------\\
        //-----------------------------------------------------------------\\

        //Se cambia la direccion de salto a los registro
        public void EnviarRegistro(ref guiModeloUsuario pModel)
        {
            pModel.cNombrePagina = "Usuario_Registro";
            pModel.cNombreLayout = "_Registro";
        }

        //Se cambia la direccion de salto a la pagina de editar perfil
        public void EnviarEditarPerfil(ref guiModeloUsuario pModel)
        {
            pModel.cNombrePagina = "Editar_Perfil";
            pModel.cNombreLayout = "_Editar";
        }

        public ActionResult VolverInicio()
        {
            return View("Index", new guiModelInicioSesion());
        }


        //Entrada: El nombre de usuario es utilizado para guardar la imagen del usuario
        //Descripcion: Funcion que sube un archivo enviado por el usuario
        public String GuardarArchivo(String pNombreUsuario, HttpPostedFileBase pImagen)
        {
            var mPath = "";
            String mRutaImagenes = "~/ImagenesUsuarios/";
            if (pImagen!= null && pImagen.ContentLength > 0)
            {
                var mExtension = ".jpg";
                mPath = Path.Combine(Server.MapPath(mRutaImagenes), pNombreUsuario + mExtension);
                pImagen.SaveAs(mPath);
                mPath = mRutaImagenes + pNombreUsuario + mExtension;
            }
            return mPath;
        }

        //-----------------------------------------------------------------\\
        //-------------------Seccion del Administrador---------------------\\
        //-----------------------------------------------------------------\\


        public ActionResult Administrador_Perfil()
        {
            return View((guiModeloAdministrador)Session["Modelo"]);
        }

        public ActionResult Administrador_Registro()
        {
            cPresentadorUsuarios = new PresentadorGestionarUsuarios();
            guiModeloUsuario mNuevoModelo = cPresentadorUsuarios.GetModeloUsuario(ConstantesGestionarUsuarios.kUsuarioAdministrador);
            mNuevoModelo.cNombreSeccion = "Registrar administrador";
            mNuevoModelo.cAccion = "Administrador_Nuevo_Registro";
            EnviarRegistro(ref mNuevoModelo);
            return View(mNuevoModelo);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult Administrador_Nuevo_Registro(guiModeloAdministrador pModel)
        {

            if (ModelState.IsValid)
            {
                cPresentadorUsuarios = new PresentadorGestionarUsuarios();
                cPresentadorUsuarios.AgregarAdministrador(pModel);
                return VolverInicio();
            }

            return View("Administrador_Registro", pModel);
        }

        public ActionResult Administrador_Editar_Perfil()
        {
            guiModeloUsuario mModelo = (guiModeloAdministrador)Session["Modelo"];
            EnviarEditarPerfil(ref mModelo);
            return View("Administrador_Registro", mModelo);
        }

        [HttpPost]
        public ActionResult Administrador_Guardar_Cambios(guiModeloAdministrador pModel)
        {
            PresentadorGestionarUsuarios mPresentador = (PresentadorGestionarUsuarios)Session["Usuario"];
            if (ModelState.IsValid){            
                mPresentador.ActualizarAdministrador(pModel);
                pModel.cContrasena = "";
                pModel.cFechaInscripcion = ((guiModeloUsuario)Session["Modelo"]).cFechaInscripcion;
                Session["Modelo"] = pModel;

                return RedirectToAction("Administrador_Perfil", "Usuario");

            }
            return View("Administrador_Registro", pModel);
        }

        //-----------------------------------------------------------------\\
        //----------------------Seccion del Fanatico-----------------------\\
        //-----------------------------------------------------------------\\

        public ActionResult Fanatico_Perfil()
        {
            return View((guiModeloFanatico)Session["Modelo"]);
        }

        public ActionResult Fanatico_Registro()
        {
            cPresentadorUsuarios = new PresentadorGestionarUsuarios();
            guiModeloUsuario mContenedorUsuario = cPresentadorUsuarios.GetModeloUsuario(ConstantesGestionarUsuarios.kUsuarioFantatico);
            mContenedorUsuario.cNombreSeccion = "Registrar fanático";
            mContenedorUsuario.cAccion = "Fanatico_Nuevo_Registro";
            EnviarRegistro(ref mContenedorUsuario);
            return View(mContenedorUsuario);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult Fanatico_Nuevo_Registro(guiModeloFanatico pModel)
        {
            if (ModelState.IsValid)
            {
                pModel.cRutaImagen = GuardarArchivo(pModel.cNombreUsuario, pModel.cImagen);
                cPresentadorUsuarios = new PresentadorGestionarUsuarios();
                cPresentadorUsuarios.AgregarFanatico(pModel);

                return VolverInicio();
            }
            guiModeloFanatico mModelo = (guiModeloFanatico)Session["Modelo"];
            return View("Fanatico_Registro", pModel);
        }
           
        public ActionResult Fanatico_Editar_Perfil()
        {
            guiModeloUsuario mModelo = (guiModeloUsuario)Session["Modelo"];
            EnviarEditarPerfil(ref mModelo);
            return View("Fanatico_Registro", mModelo);
        }

        [HttpPost]
        public ActionResult Fanatico_Guardar_Cambios(guiModeloFanatico pModel)
        {
            String mNuevaFoto = "";
            PresentadorGestionarUsuarios mPresentador = (PresentadorGestionarUsuarios)Session["Usuario"];
            if (ModelState.IsValid)
            {
                mNuevaFoto = GuardarArchivo(pModel.cNombreUsuario,pModel.cImagen);
                if (mNuevaFoto == "")
                {
                    mNuevaFoto = mPresentador.GetRutaFotoFanatico();
                }

                pModel.cRutaImagen = mNuevaFoto;
                mPresentador.ActualizarFanatico(pModel);

                pModel.cContrasena = ""; //Para que la contrasena no se guarde en el modelo que almaceno en la sesion
                pModel.cFechaInscripcion = ((guiModeloUsuario)Session["Modelo"]).cFechaInscripcion;
                
                Session["Modelo"] = pModel;
                
                return RedirectToAction("Fanatico_Perfil", "Usuario");

            }
            guiModeloFanatico mModelo = (guiModeloFanatico)Session["Modelo"];
            pModel.cPaises = mModelo.cPaises;
            pModel.cEquipos = mModelo.cEquipos;
            return View("Fanatico_Registro", pModel);
        }

        //-----------------------------------------------------------------\\
        //----------------------Seccion del narrador-----------------------\\
        //-----------------------------------------------------------------\\

        public ActionResult Narrador_Perfil()
        {
            return View((guiModeloNarrador)Session["Modelo"]);
        }

        //GET /Usuario/Narrador_Registro
        public ActionResult Narrador_Registro()
        {
            cPresentadorUsuarios = new PresentadorGestionarUsuarios();
            guiModeloUsuario mContenedorUsuario = cPresentadorUsuarios.GetModeloUsuario(ConstantesGestionarUsuarios.kUsuarioNarrador);
            mContenedorUsuario.cNombreSeccion = "Registrar narrador";
            mContenedorUsuario.cAccion = "Narrador_Nuevo_Registro";
            EnviarRegistro(ref mContenedorUsuario);
            return View(mContenedorUsuario);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult Narrador_Nuevo_Registro(guiModeloNarrador pModel)
        {

            if (ModelState.IsValid)
            {
                pModel.cRutaImagen = GuardarArchivo(pModel.cNombreUsuario,pModel.cImagen);
                cPresentadorUsuarios = new PresentadorGestionarUsuarios();
                cPresentadorUsuarios.AgregarNarrador(pModel);

                return VolverInicio();//regresa a la pantalla de login
            }
            return View("Narrador_Registro", pModel);
        }

        public ActionResult Narrador_Editar_Perfil()
        {
            guiModeloUsuario mModelo = (guiModeloUsuario)Session["Modelo"];
            EnviarEditarPerfil(ref (mModelo));
            return View("Narrador_Registro", mModelo);
        }

        [HttpPost]
        public ActionResult Narrador_Guardar_Cambios(guiModeloNarrador pModel)
        {
            String mNuevaFoto = ""; //donde se almacena la nueva ruta de la imagen
            PresentadorGestionarUsuarios mPresentador = (PresentadorGestionarUsuarios)Session["Usuario"];

            if (ModelState.IsValid){
                mNuevaFoto = GuardarArchivo(pModel.cNombreUsuario, pModel.cImagen);
                if (mNuevaFoto == "")
                {
                    mNuevaFoto = mPresentador.GetRutaFotoNarrador();
                }

                pModel.cRutaImagen = mNuevaFoto;
                mPresentador.ActualizarNarrador(pModel);

                pModel.cContrasena = ""; //Para que la contrasena no se guarde en el modelo que almaceno en la sesion
                pModel.cFechaInscripcion = ((guiModeloUsuario)Session["Modelo"]).cFechaInscripcion;

                Session["Modelo"] = pModel;
                
                return RedirectToAction("Narrador_Perfil", "Usuario");

            }
            return View("Narrador_Registro", pModel);
        }
    }
}
