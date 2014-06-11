using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.EjeTransversal.GestionarCalendario
{
    public class ModeloDatosPartido
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = " La fecha de nacimiento debe seguir el formato dd/mm/yyyy, y no puede quedar vacía.")]
        [Required(ErrorMessage = " La fecha no puede estar vacia.")]
        public String cFecha { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:MM}")]
        [DataType(DataType.Time, ErrorMessage = " La hora debe seguir el formato HH:MM")]
        [Required(ErrorMessage = " La hora no puede estar vacia.")]
        public String cHora { get; set; }
        public String cIdEquipo1 { get; set; }
        public String cIdEquipo2 { get; set; }

        [Required(ErrorMessage = " La fase del equipo no puede estar vacia.")]
        public String cFase { get; set; }
        public String cIdSede { get; set; }
        public String cIdPartido { get; set; }
        public Dictionary<int,String> cEquipos { get; set; }
        public Dictionary<int,String> cSedes { get; set; }
        public int cTorneoSeleccionado { get; set; }
    }
}
