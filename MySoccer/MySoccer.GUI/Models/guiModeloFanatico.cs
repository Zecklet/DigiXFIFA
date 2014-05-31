using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySoccer.GUI.Models
{
    public class guiModeloFanatico:guiModeloUsuario
    {

        [Required(ErrorMessage = " El correo electronico no puede estar vacío.")]
        public String cCorreoElectronico { get; set; }

        public String cGenero { get; set; }
        public String cEquipo { get; set; }

        [Required(ErrorMessage = " La descripción personal no puede estar vacía.")]
        public String cDescripcion { get; set; }

        public int cPais { get; set; }

        public String cRutaImagen { get; set; }


    }
}