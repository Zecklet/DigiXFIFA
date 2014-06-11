using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySoccer.EjeTransversal.IniciarSesion
{
    public class guiModelInicioSesion
    {
        [Required(ErrorMessage = " Por favor ingrese el nombre de usuario.")]
        public String cNombreUsuario { get; set; }

        [Required(ErrorMessage = " Por favor ingrese la contraseña del usuario.")]
        public String cConstrasena { get; set; }

        public HttpPostedFileBase cImagen { get; set; }
    }
}