using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MySoccer.Servicio
{
    public class GuardarImagenes
    {
        //Entrada: El nombre de usuario es utilizado para guardar la imagen del usuario
        //Salida: Ruta final de la foto guardada
        //Descripcion: Funcion que sube un archivo enviado por el usuario
        public String GuardarImagen(String pNombreUsuario, HttpPostedFileBase pImagen)
        {
            var mPath = "";
            String mRutaImagenes = "~/ImagenesUsuarios/";
            if (pImagen != null && pImagen.ContentLength > 0)
            {
                var mExtension = ".jpg";
                mPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(mRutaImagenes), pNombreUsuario + mExtension);
                pImagen.SaveAs(mPath);
                mPath = mRutaImagenes + pNombreUsuario + mExtension;
            }
            return mPath;
        }
    }
}
