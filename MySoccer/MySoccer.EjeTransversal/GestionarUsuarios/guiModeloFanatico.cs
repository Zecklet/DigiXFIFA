using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySoccer.EjeTransversal.GestionarUsuarios
{
    public class guiModeloFanatico:guiModeloUsuario
    {

        public guiModeloFanatico()
        {
            this.cTipoUsuario = "Fanatico";
            this.cPais = "0";
            this.cEquipo = "0";
        }

        [Required(ErrorMessage = " El correo electronico no puede estar vacío.")]
        public String cCorreoElectronico { get; set; }

        public String cGenero { get; set; }
        public String cEquipo { get; set; }

        [Required(ErrorMessage = " La descripción personal no puede estar vacía.")]
        public String cDescripcion { get; set; }

        public String cPais { get; set; }

        public String cRutaImagen { get; set; }

        public Dictionary<int, String> cPaises { get; set; }

        public Dictionary<int, String> cEquipos { get; set; }
        public HttpPostedFileBase cImagen { get; set; }
    }
}