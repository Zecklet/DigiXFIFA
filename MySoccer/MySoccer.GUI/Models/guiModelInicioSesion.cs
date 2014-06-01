using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySoccer.GUI.Models
{
    public class guiModelInicioSesion
    {
        [Required(ErrorMessage = " Por favor ingrese el nombre de usuario.")]
        public String cNombreUsuario { get; set; }

        [Required(ErrorMessage = " Por favor ingrese la contraseña del usuario.")]
        public String cConstrasen { get; set; }
    }
}