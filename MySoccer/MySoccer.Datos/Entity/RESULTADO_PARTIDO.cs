//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MySoccer.Datos.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESULTADO_PARTIDO
    {
        public int PK_FK_Resultado_Partido { get; set; }
        public Nullable<int> Asistencia { get; set; }
        public Nullable<int> Marcador_Equipo_1 { get; set; }
        public Nullable<int> Marcador_Equipo_2 { get; set; }
        public int FK_Narrador { get; set; }
    }
}
