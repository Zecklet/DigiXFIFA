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
            Administrador mNuevoAdministrador = new Administrador(pDatosUsuario);
            this.cAdministradorTemporal = mNuevoAdministrador;
            CUENTA mNuevoUsuario = new CUENTA();
            mNuevoUsuario.Nombre_Usuario = pDatosUsuario.cNombreUsuario;
            mNuevoUsuario.Contraseña = pDatosUsuario.cContrasena;

            mNuevoUsuario.Fecha_Inscripcion = DateTime.Now;

            MY_SOCCEREntities1 mConexionMySoccer = new MY_SOCCEREntities1();
            Console.WriteLine(mNuevoUsuario.Nombre_Usuario);

            mConexionMySoccer.CUENTAs(mNuevoUsuario);



            //Luego se agregan a la base de datos
        }
        //Este metodo crea un fanatico 
        public void AgregarFanatico(ParametrosUsuario pDatosUsuario)
        {
            Fanatico mNuevoAdministrador = new Fanatico(pDatosUsuario);
        }
        //Este metodo crea un narrador
        public void AgregarNarrador(ParametrosUsuario pDatosUsuario)
        {
            Narrador mNuevoAdministrador = new Narrador(pDatosUsuario);
        }
    }

    
}
