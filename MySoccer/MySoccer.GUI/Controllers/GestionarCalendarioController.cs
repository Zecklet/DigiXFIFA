using MySoccer.Presentacion.GestionarUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.Presentacion.GestionarCalendario;
using MySoccer.EjeTransversal;

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
        [HttpGet]
        public ActionResult Administrador_Calendario()
        {
            return View(this.cPresentador.GetModeloTorneo(this.cPresentador.GetTorneos().First().Key));
        }

        [HttpGet]
        public ActionResult Administrador_Cambiar_Calendario(ModeloGestionarCalendario pModelo)
        {
            return View("Administrador_Calendario",this.cPresentador.GetModeloTorneo(pModelo.cTorneoSeleccionado));
        }

        [HttpGet]
        public ActionResult Administrador_Partido(ModeloGestionarCalendario pModelo)
        {
            return View(this.cPresentador.GetModeloAgregarPartido(pModelo.cTorneoSeleccionado));
        }

        [HttpPost]
        public ActionResult Administrador_Gestionar_Partido(ModeloDatosPartido pModelo)
        {
            ContenedorError mResultado;
            if (ModelState.IsValid)
            {
                //en este metodo se crean o actualizan los partidos 
                mResultado = this.cPresentador.GestionarPartido(pModelo);
                if (!mResultado.HayError())
                {
                    return RedirectToAction("Administrador_Calendario");
                }
                else
                {
                    ModelState.AddModelError(ConstantesGestionarUsuarios.kStringCodigoError, mResultado.GetMensajeError());
                }
            }
            this.cPresentador.SetEquiposSedes(ref pModelo);
            return View("Administrador_Partido", pModelo);
        }

        [HttpPost]
        public ActionResult Administrador_Eliminar_Partido(ModeloGestionarCalendario pModelo)
        {
            this.cPresentador.EliminarPartido(pModelo.cIdPartidoSeleccionado);
            return RedirectToAction("Administrador_Calendario");
        }


        [HttpGet]
        public ActionResult Administrador_Partido_Editar(ModeloGestionarCalendario pModelo)
        {

            return View("Administrador_Partido", this.cPresentador.GetModeloPartido(pModelo.cIdPartidoSeleccionado));
        }
    }
}
