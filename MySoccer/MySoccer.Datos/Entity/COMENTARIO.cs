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
    
    public partial class COMENTARIO
    {
        public int PK_Comentario { get; set; }
        public int Tiempo { get; set; }
        public int FK_Usuario { get; set; }
        public int FK_Partido { get; set; }
    }
}