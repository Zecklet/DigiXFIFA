using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MySoccer.EjeTransversal.GestionarUsuarios
{
    public class guiModeloAdministrador:guiModeloUsuario
    {
        [Required(ErrorMessage = " El correo electronico no puede estar vacío.")]
        public String cCorreoElectronico { get; set; }

        public guiModeloAdministrador()
        {
            this.cTipoUsuario = "Administrador";
        }

    }
}