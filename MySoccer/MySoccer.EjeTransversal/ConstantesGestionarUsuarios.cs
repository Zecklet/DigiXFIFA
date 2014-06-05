using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace MySoccer.EjeTransversal
{
    public class ConstantesGestionarUsuarios
    {

        //Codigo de cada tipo de usuario 
        public const int kUsuarioAdministrador = 1;
        public const int kUsuarioNarrador = 2;
        public const int kUsuarioFantatico = 3;

        //Codigo de error en html

        public const String kStringCodigoError = "Error"; //esta contante es utilizada para identificar el error en la interfaz
        //Codigo de errores

        public const int kCodigoNombreUsuarioExiste = 1;
        public const int kCodigoNombreUsuarioNoExiste = 2;
        public const int kCodigoContrasenaIncorrecta = 3;

        //Mesajes de errores

        public const String kMensajeNombreUsuarioExiste = "El nombre de usuario ingresado ya existe en el sistema.";
        public const String kMensajeNombreUsuarioNoExiste = "El nombre de usuario ingresado es incorrecto. \n Por favor intentelo de nuevo.";
        public const String kMensajeContrasenaIncorrecta = "La contraseña ingresado es incorrecto. \n Por favor intentelo de nuevo.";

        //Constantes utilizadas en la parte de cuenta 

        public static String kUbicacionLLavePrivada = HostingEnvironment.MapPath("~/Llaves/privateKeyMS.xml");
        public static String kUbicacionLLavePublica = HostingEnvironment.MapPath("~/Llaves/publicKeyMS.xml");

        

        //----------------------------------------------------------------------\\
        //Las siguientes constantes son utilizadas para crear los diccionarios y pasar los datos de los usuraios
        //----------------------------------------------------------------------\\

        //--------------------------Usuarios-------------------------

        public static readonly string[] kSexos = {"Desconocido","Masculino","Femenino"};
        public const String kStringNombre = "Nombre";
        public const String kStringApellido = "Apellido";
        public const String kStringFechaNacimiento = "FechaNacimiento";
        public const String kStringFechaInscripcion = "FechaInscripcion";

        //------------------ Admnistrador y Fanatico ------------------------

        public const String kStringCorreoElectronico = "CorreoElectronico";

        //--------------------------Narrador---------------------------------

        public const String kStringAnosExperiencia = "AnosExperiencia";

        //-------------------------Fanatico----------------------------------

        public const String kStringPais = "Pais";
        public const String kStringEquipoFavorito = "EquipoFavorito";

        //--------------------Narrador y Fanatico ---------------------------

        public const String kStringDescripcion = "Descripcion";
        public const String kStringGenero = "Genero";
        public const String kStringRutaFoto = "RutaFoto";

        //------------------------------------------------------------------\\
    }
}
