using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySoccer.GUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
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
