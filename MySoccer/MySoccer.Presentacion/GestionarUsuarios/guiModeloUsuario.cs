using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySoccer.Presentacion.GestionarUsuarios
{
    public class guiModeloUsuario
    {
        public Dictionary<int, String> GetGeneros()
        {
            Dictionary<int,String> mListaGeneros = new Dictionary<int,string>();
            mListaGeneros.Add(1,"Masculino");
            mListaGeneros.Add(2, "Femenino");
            return mListaGeneros;
        }

        public String cTipoUsuario { get; set; }

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
        public String cFechaInscripcion { get; set; }
        //Codigo utilizado para la seccion de acciones de la pagina 
        public String cNombreSeccion { get; set; }
        public String cAccion { get; set; }
        public String cNombrePagina { get; set; }
        public String cNombreLayout { get; set; }
    }

}