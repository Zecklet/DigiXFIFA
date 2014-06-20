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

    //Entrada: Modelo con la informacion de un usuario
    //Salida: Contenedor error con la informacion de algun error en caso de que se presente alguno
    //Descripcion:Delega la opcion de crear un nuevo usuario al objeto que hace la conexion con la base, y en caso
    //de que haya algun error crea un nuevo contenedor error
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

    //Entrada: nombre de usuario y constrasena
    //Salida: Contenedor error con un mesaje de error si hay algun problema, si no lo hay puede iniciar sesion
    //Descripcion: Compara si existe el usaurio y si la contrasena es la correcta, para luego iniciar sesion
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

    //Entrada: ningua
    //Salida: Modelo usuario con la informacion total
    //Descripcion: retorna un modelo de usuario con la infomracion completa del usuario que inicio sesion
    public ModeloUsuario RecuperarModelCompleto() {
        return this.cUsuarioActual.GetModeloCompleto();
    }

    //Entrada: nombre de usario
    //Salida: true=> existe usuario, false=> no existe
    //Descripcion: solicita al objeto que conecta con la base, si el usuario ingresado existe
    private boolean ExisteUsuario(String pNombreUsuario) {
        BaseDatosUsuarios mConexion = new BaseDatosAdministrador();
        return mConexion.ExisteUsuario(pNombreUsuario);
    }

    //Entrada: ningua
    //Salida: String con el nombre del usuario que inicio sesion
    //Descripcion: obtiene el nombre de usuario que inicio sesion 
    public String GetNombre() {
        return this.cUsuarioActual.getcNombre();
    }

    //Entrada: Modelo de usuario con la infomracion ingresada por el usuario 
    //Salida: Contenedor error en caso de que sse presente algun error 
    //Descripcion: intenta actualizar un usuario, si no pudo crea un error y lo devuelve
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

//Entrada: ningua
    //Salida: ninguna
    //Descripcion: Desactiva la cuenta de usuario del sistema registrado
    public void DesactivarUsuario() {
        this.cUsuarioActual.CambiarEstado(false);
    }

//Entrada: ningua
    //Salida: Modelo usuario con la informacion total
    //Descripcion: reactiva la cuenta de usuario que inicio sesion
    public void ActivarUsuario() {
        this.cUsuarioActual.CambiarEstado(true);
    }
}
