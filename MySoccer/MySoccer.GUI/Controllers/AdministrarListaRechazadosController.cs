using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySoccer.Presentacion.AdministrarListaRechazados;
using MySoccer.EjeTransversal;

namespace MySoccer.GUI.Controllers
{
    public class AdministrarListaRechazadosController : Controller
    {
        //
        // GET: /AdministrarListaRechazados/
        PresentadorListaRechazados cPresentador;
        public AdministrarListaRechazadosController()
        {
            this.cPresentador = new PresentadorListaRechazados();
        }

        public ActionResult Administrador_ListaRechazados()
        {
            ModeloListaRechazados mModelo = this.cPresentador.GetModeloListaRechazados();
            return View(mModelo);
        }

        [HttpPost]
        public ActionResult Administrador_Rechazado_Agregar(ModeloListaRechazados pModelo)
        {
            if (ModelState.IsValid)
            {
                ContenedorError mResultado = this.cPresentador.AgregarRechazado(pModelo.cPasaporte, pModelo.cNombre, pModelo.cApellido);
                if (!mResultado.HayError())
                {
                    return RedirectToAction("Administrador_ListaRechazados");
                }
                else
                {
                    ModelState.AddModelError(ConstantesGestionarUsuarios.kStringCodigoError, mResultado.GetMensajeError());
                }
            }
            this.cPresentador.SetRechazados(ref pModelo);
            return View("Administrador_ListaRechazados", pModelo);
        }

        [HttpPost]
        public ActionResult Administrador_Rechazado_Eliminar(ModeloListaRechazados pModelo)
        {
            this.cPresentador.EliminarRechazado(pModelo.cRechzadoSeleccionado);
            return RedirectToAction("Administrador_ListaRechazados");
        }
    }
}
