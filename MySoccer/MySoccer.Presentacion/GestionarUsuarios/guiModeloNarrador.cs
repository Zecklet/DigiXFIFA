﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySoccer.Presentacion.GestionarUsuarios
{
    public class guiModeloNarrador:guiModeloUsuario
    {

        public guiModeloNarrador()
        {
            this.cTipoUsuario = "Narrador";
        }

       // [Required(ErrorMessage = " El correo electronico no puede estar vacío.")]
       // public String cCorreoElectronico { get; set; }

        public String cGenero { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{#0}")]
        [Required(ErrorMessage = " La cantidad de años de experiencia no puede estar vacía.")]
        public String cAnosExperiencia { get; set; }

        [Required(ErrorMessage = " La descripción personal no puede estar vacía.")]
        public String cDescripcion { get; set; }

        public String cRutaImagen { get; set; }

        public HttpPostedFileBase cImagen { get; set; }

    }
}