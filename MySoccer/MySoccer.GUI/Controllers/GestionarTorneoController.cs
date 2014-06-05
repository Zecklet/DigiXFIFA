using MySoccer.Dominio;
using MySoccer.Presentacion.GestionarTorneo;
using MySoccer.Presentacion.GestionarUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySoccer.GUI.Controllers
{
    public class GestionarTorneoController : Controller
    {
        //
        // GET: /GestionarTorneo/

        PresentadorGestionarTorneo cGestionarUsuario;

        public GestionarTorneoController()
        {
            this.cGestionarUsuario = new PresentadorGestionarTorneo();
        }

        public ActionResult Administrador_Torneo()
        {
            return View(this.cGestionarUsuario.GetModeloTorneo(((PresentadorGestionarUsuarios) Session["Usuario"]).GetNombre()));
        }

    }
}
