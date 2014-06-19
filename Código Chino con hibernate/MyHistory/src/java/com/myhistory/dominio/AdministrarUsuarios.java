/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.datos.BaseDatosUsuarios;
import com.myhistory.dominio.Usuario;
import com.myhistory.datos.BaseDatosAdministrador;
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloUsuario;

/**
 *
 * @author Ney Rojas
 */
public class AdministrarUsuarios {

    private Usuario cUsuarioActual;

    public ContenedorError CrearNuevoUsuario(ModeloUsuario pDatosModelo) {
        ContenedorError mResultado = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        if (!ExisteUsuario(pDatosModelo.getcNombreUsuario())) {
            Usuario mNuevoUsuario = UsuariosFactory.getInstance().CrearUsuario(Constantes.kCogidoAdministrador);
            mNuevoUsuario.ColocarDatos(pDatosModelo);
            mNuevoUsuario.CrearNuevoUsuarioBaseDatos();
        } else {
            mResultado = new ContenedorError(Constantes.kErrorCodigoUsuarioExiste);
        }
        return mResultado;
    }

    public ContenedorError IniciarSesion(String pNombreUsuario, String pConstrasena) {
        ContenedorError mResultado = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        if (!ExisteUsuario(pNombreUsuario)) {
            mResultado = new ContenedorError(Constantes.kErrorCodigoUsuarioNoExiste);
        } else {
            Usuario mNuevoUsuario = UsuariosFactory.getInstance().CrearUsuario(Constantes.kCogidoAdministrador);
            mNuevoUsuario.RecuperarCuentaBaseDatos(pNombreUsuario);
            if (!mNuevoUsuario.CompararContrasena(pConstrasena)) {
                mResultado = new ContenedorError(Constantes.kErrorCodigoContrasenaIncorrecta);
            } else {
                this.cUsuarioActual = mNuevoUsuario;
                this.cUsuarioActual.RecuperarUsuarioEspecifico();
            }
        }
        return mResultado;
    }

    public ModeloUsuario RecuperarModelCompleto() {
        return this.cUsuarioActual.GetModeloCompleto();
    }

    private boolean ExisteUsuario(String pNombreUsuario) {
        BaseDatosUsuarios mConexion = new BaseDatosAdministrador();
        return mConexion.ExisteUsuario(pNombreUsuario);
    }

    public String GetNombre() {
        return this.cUsuarioActual.getcNombre();
    }

    public ContenedorError ActualizarUsuario(ModeloUsuario pModelo) {
        ContenedorError mResultado = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        if (!this.cUsuarioActual.getNombreUsuario().equals(pModelo.getcNombreUsuario())
                && ExisteUsuario(pModelo.getcNombreUsuario())) {
            mResultado = new ContenedorError(Constantes.kErrorCodigoUsuarioNoExiste);
        } else {
            this.cUsuarioActual.ColocarDatos(pModelo);
            this.cUsuarioActual.ActualizarUsuarioBaseDatos();
        }
        return mResultado;
    }

    public void DesactivarUsuario() {
        this.cUsuarioActual.CambiarEstado(false);
    }

    public void ActivarUsuario() {
        this.cUsuarioActual.CambiarEstado(true);
    }
}

