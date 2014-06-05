using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Presentacion.GestionarCalendario
{
    public class ModeloDatosPartido
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = " La fecha de nacimiento debe seguir el formtato dd/mm/yyyy, y no puede quedar vacía.")]
        [Required]
        public String cFecha { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = " La fecha de nacimiento debe seguir el formtato dd/mm/yyyy, y no puede quedar vacía.")]
        [Required]
        public String cHora { get; set; }
        public String cIdEquipo1 { get; set; }
        public String cIdEquipo2 { get; set; }
        public String cFase { get; set; }
        public String cIdFase { get; set; }

        public Dictionary<int,String> cEquipos { get; set; }
        public Dictionary<int,String> cSedes { get; set; }
    }
}
