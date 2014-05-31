using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace MySoccer.GUI.Models
{
    public class guiModeloUsuario
    {
        public List<SelectListItem> GetGeneros()
        {
            List<SelectListItem> mListaGeneros = new List<SelectListItem> { new SelectListItem() { Text = "Masculino", Value = "1" }, new SelectListItem() { Text = "Femenino", Value = "2" } };
            return mListaGeneros;
        }

        public String cNombreSeccion { get; set; }
        public String cAccion { get; set; }

        [DisplayName("Nombre Usuario")]
        [Required(ErrorMessage = " El nombre no puede estar vacío")]
        public String cNombreUsuario { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = " La contraseña no puede estar vacío.")]
        public String cContrasena { get; set; }

        [Required(ErrorMessage = " El nombre no puede estar vacío.")]
        public String cNombre { get; set; }

        [Required(ErrorMessage = " El apellido no puede estar vacío.")]
        public String cApellido { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = " La fecha de nacimiento no puede estar vacío.")]
        public String cFechaNacimiento { get; set; }

    }

}