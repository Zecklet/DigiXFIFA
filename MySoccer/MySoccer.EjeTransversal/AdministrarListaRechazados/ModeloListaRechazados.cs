using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.EjeTransversal.AdministrarListaRechazados
{
    public class ModeloListaRechazados
    {
        [Required(ErrorMessage = " El nombre no puede ser vacío.")]
        public String cNombre { get; set; }
        [Required(ErrorMessage = " El apellido no puede ser vacío.")]
        public String cApellido { get; set; }
        [Required(ErrorMessage = " El pasaporte no puede ser vacío.")]
        [MinLength(10, ErrorMessage = " El pasaporte es de diez digitos.")]
        [MaxLength(10, ErrorMessage = " El pasaporte es de diez digitos.")]
        [Range(0,9999999999,ErrorMessage = " El pasaporte tiene que ser un numero entero, mayor a cero.")]
        public String cPasaporte { get; set; }
        public List<ContenedorRechazado> cListaRechazados { get; set; }
        public String cRechzadoSeleccionado { get; set; }

    }
}
