﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.GUI.Models;
using MySoccer.Presentador;
using MySoccer.Dominio;

namespace MySoccer.GUI.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario

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
            mContenedorUsuario.cAccion = "RegistrarAdministrador";
            return View(mContenedorUsuario);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult RegistrarAdministrador(guiModeloAdministrador pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //regresa a la pantalla de login
                    AdministrarUsuario mUsuarios = new AdministrarUsuario();
                    ParametrosUsuario mParametro = new ParametrosUsuario(pModel.cNombre,pModel.cApellido,
                        pModel.cNombreUsuario,pModel.cContrasena,pModel.cFechaNacimiento);
                    mParametro.DatosAdministrador(pModel.cCorreoElectronico);
                    mUsuarios.AgregarAdministrador(mParametro);
                    return View("Index");
                }
                return View("Administrador_Registro",pModel);

            }
            catch
            {
                return View("Administrador_Registro");
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
            mContenedorUsuario.cAccion = "RegistrarFanatico";
            return View(mContenedorUsuario);
        }

        // POST: que se encarga de crear un usuario de tipo narrador
        [HttpPost]
        public ActionResult RegistrarFanatico(guiModeloFanatico pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //regresa a la pantalla de login
                    return View("Index");
                }
                return View("Administrador_Fanatico", pModel);

            }
            catch
            {
                return View("Administrador_Fanatico");
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
            mContenedorUsuario.cAccion = "RegistrarNarrador";
            return View(mContenedorUsuario);
        }
        [HttpPost]
        public ActionResult RegistrarNarrador(guiModeloNarrador pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //regresa a la pantalla de login
                    return View("Index");
                }
                return View("Administrador_Fanatico", pModel);

            }
            catch
            {
                return View("Administrador_Fanatico");
            }
        }
    }
}
