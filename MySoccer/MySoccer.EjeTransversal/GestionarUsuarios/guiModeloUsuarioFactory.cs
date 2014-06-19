using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySoccer.EjeTransversal.GestionarUsuarios
{
    public sealed class guiModeloUsuarioFactory
    {
        static private guiModeloUsuarioFactory cFabricaUsuario = null;

        public static guiModeloUsuarioFactory Instance
        {
            get
            {
                if (cFabricaUsuario == null)
                {
                    cFabricaUsuario = new guiModeloUsuarioFactory();
                }
                return cFabricaUsuario;
            }
        }

        public guiModeloUsuario CrearModelo(int pTipoUsuario)
        {
            guiModeloUsuario mNuevoUsuario = null;
            switch (pTipoUsuario)
            {
                case ConstantesGestionarUsuarios.kUsuarioAdministrador:
                    mNuevoUsuario = new guiModeloAdministrador();
                    break;
                case ConstantesGestionarUsuarios.kUsuarioNarrador:
                    mNuevoUsuario = new guiModeloNarrador();
                    break;
                case ConstantesGestionarUsuarios.kUsuarioFantatico:
                    mNuevoUsuario = new guiModeloFanatico();
                    break;
            }
            return mNuevoUsuario;
        }

        public static guiModeloUsuario CrearModelo(Dictionary<String, String> mDatosModelo, int pTipoUsuario)
        {
            guiModeloUsuario mNuevoUsuario = null;
            switch (pTipoUsuario)
            {
                case ConstantesGestionarUsuarios.kUsuarioAdministrador:
                    mNuevoUsuario = new guiModeloAdministrador()
                    {
                        cCorreoElectronico = mDatosModelo[ConstantesGestionarUsuarios.kStringCorreoElectronico],
                    };
                    break;
                case ConstantesGestionarUsuarios.kUsuarioNarrador:
                    mNuevoUsuario = new guiModeloNarrador()
                    {
                        cRutaImagen = mDatosModelo[ConstantesGestionarUsuarios.kStringRutaFoto],
                        cGenero = mDatosModelo[ConstantesGestionarUsuarios.kStringGenero],
                        cAnosExperiencia = mDatosModelo[ConstantesGestionarUsuarios.kStringAnosExperiencia],
                        cDescripcion = mDatosModelo[ConstantesGestionarUsuarios.kStringDescripcion]
                    };
                    break;
                case ConstantesGestionarUsuarios.kUsuarioFantatico:
                    mNuevoUsuario = new guiModeloFanatico()
                    {
                        cRutaImagen = mDatosModelo[ConstantesGestionarUsuarios.kStringRutaFoto],
                        cGenero = mDatosModelo[ConstantesGestionarUsuarios.kStringGenero],
                        cDescripcion = mDatosModelo[ConstantesGestionarUsuarios.kStringDescripcion],
                        cCorreoElectronico = mDatosModelo[ConstantesGestionarUsuarios.kStringCorreoElectronico],
                        cEquipo = mDatosModelo[ConstantesGestionarUsuarios.kStringEquipoFavorito],
                        cPais = mDatosModelo[ConstantesGestionarUsuarios.kStringPais]
                    };                   break;
                default:
                    mNuevoUsuario = new guiModeloUsuarioNull();
                    break;
            }

            mNuevoUsuario.cFechaNacimiento = mDatosModelo[ConstantesGestionarUsuarios.kStringFechaNacimiento];
            mNuevoUsuario.cFechaInscripcion = mDatosModelo[ConstantesGestionarUsuarios.kStringFechaInscripcion];
            mNuevoUsuario.cNombre = mDatosModelo[ConstantesGestionarUsuarios.kStringNombre];
            mNuevoUsuario.cApellido = mDatosModelo[ConstantesGestionarUsuarios.kStringApellido];
            mNuevoUsuario.cEstado = Convert.ToBoolean(mDatosModelo[ConstantesGestionarUsuarios.kStringEstado]);
            return mNuevoUsuario;
        }
    }
}