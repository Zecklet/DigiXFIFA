using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySoccer.Datos;
using MySoccer.EjeTransversal;
using MySoccer.EjeTransversal.GestionarUsuarios;


namespace MySoccer.Dominio.GestionarUsuarios
{
    public class AdministrarUsuario
    {
        private Usuario cUsuarioActual;
        private ContenedorError cContenedorError;
        private static AdministrarUsuario cInstancia;

        private AdministrarUsuario() { }

        public static AdministrarUsuario Instance
        {
            get
            {
                if (cInstancia == null)
                {
                    cInstancia = new AdministrarUsuario();
                }
                return cInstancia;
            }
        }


        //Este metodo crea un administrador 
        public int AgregarNuevoUsuario(guiModeloUsuario pDatosUsuario, int pTipoUsuario)
        {
            Usuario mNuevoUsuario = UsuariosFactory.Instance.CrearUsuario(pTipoUsuario);
            mNuevoUsuario.ColocarTodosDatosUsuario(pDatosUsuario);
            if (mNuevoUsuario.ExisteNombreUsuario(pDatosUsuario.cNombreUsuario))
            {
                return ConstantesGestionarUsuarios.kCodigoNombreUsuarioExiste; //existe el usuario y no se debe de crear, falta mandar un mensaje de error
            }
            else
            {
                mNuevoUsuario.CrearUsuarioBaseDatos();
                mNuevoUsuario.CrearCuentaBaseDatos();
                mNuevoUsuario.CrearTipoUsuarioBaseDatos();
                return 0;
            }
        }

        //Este se usa para actualizar los datos 
        public int ActualizarUsuario(guiModeloUsuario pDatosUsuario)
        {
            if (this.cUsuarioActual == null)
            {
                return -1;
            }
            if (!this.cUsuarioActual.ExisteNombreUsuario(pDatosUsuario.cNombreUsuario)
                || pDatosUsuario.cNombreUsuario == this.cUsuarioActual.GetNombreUsuario())
            {
                //Usuario mNuevoUsuario = UsuariosFactory.Instance.CrearUsuario(pDatosUsuario, this.cUsuarioActual);
                this.cUsuarioActual.ColocarTodosDatosUsuario(pDatosUsuario);
                this.cUsuarioActual.ActualizarDatosBaseDatos();
                return 0;
            }
            else
            {
                return ConstantesGestionarUsuarios.kCodigoNombreUsuarioExiste; //existe el usuario y no se debe de crear, falta mandar un mensaje de error
            }
        }



        //Funcion que devuel true si el nombre de usuario y la contrasenas son correctas
        public ContenedorError UsuarioCorrecto(String pNombreUsuario, String pContrasena)
        {
            cContenedorError = new ContenedorError(0); //inicializa un contenedor de error, sin error alguno

            Usuario mUsuario = new Administrador();
            mUsuario = UsuariosFactory.Instance.CrearUsuario(mUsuario.RecuperarTipoUsuario(pNombreUsuario)); //usando el factory de usuarios, se  recontruye el usuario completo de la base de datos



            if (mUsuario == null) //Se comprueba que el usuario exista 
            {
                cContenedorError = new ContenedorError(ConstantesGestionarUsuarios.kCodigoNombreUsuarioNoExiste);
            }
            else
            {
                mUsuario.RecuperarCuentaBaseDatos(pNombreUsuario);
                if (!mUsuario.CompararContrasena(pContrasena)) //Se comprueba la contrase del usuario
                {
                    cContenedorError = new ContenedorError(ConstantesGestionarUsuarios.kCodigoContrasenaIncorrecta);
                }
                else
                {
                    this.cUsuarioActual = mUsuario;
                    this.cUsuarioActual.RecuperarUsuarioBaseDatos();
                    this.cUsuarioActual.RecuperarDatosBaseDatos();
                }
            }
            return cContenedorError; //devuelve el valor de la consulta 
        }

        //Funcion que retorna el mensaje de error dependiendo del tipo de error
        public String GetMensajeError()
        {
            return this.cContenedorError.GetMensajeError();
        }

        //Devuele el usuario guardado para que lo use el controlador
        public Usuario GetUsuarioActual()
        {
            return this.cUsuarioActual;
        }

        public String GetNombreUsuario()
        {
            return this.cUsuarioActual.GetNombreUsuario();
        }

        public Dictionary<String, String> GetDatos()
        {
            return this.cUsuarioActual.GetDatos();
        }

        public String GetNombre()
        {
            return this.cUsuarioActual.cNombre;
        }

        public void DesactivarUsuario()
        {
            this.cUsuarioActual.DesactivarCuenta();
        }

        public void ActivarUsuario()
        {
            this.cUsuarioActual.ActivarCuenta();
        }
    }
}
