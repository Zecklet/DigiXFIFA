/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.presentacion;

import com.myhistory.dominio.AdministrarUsuarios;
import com.myhistory.dominio.ComprobadorModelos;
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloUsuario;
import com.myhistory.ejetransversal.ModeloUsuarioFactory;

/**
 *
 * @author Ney Rojas
 */
public class PresentadorGestionarUsuarios {

    AdministrarUsuarios cAdiministrador;

    public PresentadorGestionarUsuarios() {
        this.cAdiministrador = new AdministrarUsuarios();
    }

    //Entrada: pTipoUsuario=> identificador del modelo de usaurio que se quiere crear 
    //Salida: ModeloUsuario=> modelo solicitado
    //Descripcion: usando la fabrica de modelo de usuarios crea el modelo solicitado
    public ModeloUsuario GetModeloUsuario(int pTipoUsuario) {
        return ModeloUsuarioFactory.getInstance().CrearModeloUsuario(pTipoUsuario);
    }

    //Entrada: Modelo de agregar usuario con la infomracion del nuevo usuario
    //Salida: Contenedor error 
    //Descripcion: le solicita al administrador de usaurios que cree un usuario en la base 
    public ContenedorError CrearUsuario(ModeloUsuario pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (mSalida.iscHayError()) {
            return mSalida;
        }
        return this.cAdiministrador.CrearNuevoUsuario(pModelo);
    }

    //Entrada: contrasena y nombre de usuario
    //Salida: Contenedor error 
    //Descripcion: le solicita al administrador de usuario que inicie sesion con los datos suministrados 
    public ContenedorError IniciarSesion(String pNombreUsuario, String pContrasena) {
        if (pNombreUsuario.isEmpty() || pContrasena.isEmpty()) { //Corrobora que los datos no sean nulos 
            return new ContenedorError(Constantes.kErrorCodigoLlenarTodosCampos); //si son nulos regresa un error respectivo
        }
        return this.cAdiministrador.IniciarSesion(pNombreUsuario, pContrasena); //si es vacio procede con el inicio de 
    }

    //Entrada:ninguna
    //Salida: ModeloUsuario
    //Descripcion: le solicita al administrador de usaurios que le del el modelo completo del usaurio que inicio sesion 
    public ModeloUsuario RecuperarModeloCompleto() {
        return this.cAdiministrador.RecuperarModelCompleto();
    }

    //Entrada:ninguna
    //Salida: ModeloUsuario
    //Descripcion: le solicita al administrador de usuarios que le de el modelo completo del usuario que inicio sesion 
    public String GetNombre() {
        return this.cAdiministrador.GetNombre();
    }

    //Entrada: ModeloUsuario
    //Salida: Contenedor error 
    //Descripcion: le solicita al administrador de usuario que actualiza el usuario que inicio sesion 
    public ContenedorError ActualizarUsuario(ModeloUsuario pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (mSalida.iscHayError()) {
            return mSalida;
        }
        return this.cAdiministrador.ActualizarUsuario(pModelo);
    }

    //Entrada: ninguna
    //Salida: ninguna
    //Descripcion: le solicita al administrador de usuario que desactive el usuario que inicio sesion 
    public void DesactivarUsuario() {
        this.cAdiministrador.DesactivarUsuario();
    }

    //Entrada: ninguna
    //Salida: ninguna
    //Descripcion: le solicita al administrador de usuario que active el usuario que inicio sesion 
    public void ActivarUsuario() {
        this.cAdiministrador.ActivarUsuario();
    }

}
