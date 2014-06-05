using MySoccer.Presentacion.GestionarUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.Presentacion.GestionarCalendario;

namespace MySoccer.GUI.Controllers
{
    public class GestionarCalendarioController : Controller
    {
        //
        // GET: /GestionarCalendario/

        PresentadorGestionarCalendario cPresentador;

        public GestionarCalendarioController()
        {
            cPresentador = new PresentadorGestionarCalendario();
        }

        public ActionResult Administrador_Calendario()
        {
            return View(this.cPresentador.GetModeloTorneo());
        }
        public ActionResult Administrador_Partido()
        {
            return View(this.cPresentador.GetModeloTorneo());
        }


    }
}
