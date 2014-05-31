using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;


namespace MySoccer.Dominio
{
    public class AdministrarUsuario
    {
        private Administrador cAdministradorTemporal;
        public AdministrarUsuario() {
        
        }

        //Este metodo crea un administrador 
        public void AgregarAdministrador(ParametrosUsuario pDatosUsuario)
        {
            datControlBaseDatos x = new datControlBaseDatos();
            x.AgregarUsuario();
        }
        //Este metodo crea un fanatico 
        public void AgregarFanatico(ParametrosUsuario pDatosUsuario)
        {
        }
        //Este metodo crea un narrador
        public void AgregarNarrador(ParametrosUsuario pDatosUsuario)
        {
        }
    }

    
}
