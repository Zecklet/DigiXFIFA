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

    public ModeloUsuario GetModeloUsuario(int pTipoUsuario) {
        return ModeloUsuarioFactory.getInstance().CrearModeloUsuario(pTipoUsuario);
    }

    public ContenedorError CrearUsuario(ModeloUsuario pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (mSalida.iscHayError()) {
            return mSalida;
        }
        return this.cAdiministrador.CrearNuevoUsuario(pModelo);
    }

    //Se encarga de iniciar sesion de un usuario 
    public ContenedorError IniciarSesion(String pNombreUsuario, String pContrasena) {
        if (pNombreUsuario.isEmpty() || pContrasena.isEmpty()) { //Corrobora que los datos no sean nulos 
            return new ContenedorError(Constantes.kErrorCodigoLlenarTodosCampos); //si son nulos regresa un error respectivo
        }
        return this.cAdiministrador.IniciarSesion(pNombreUsuario, pContrasena); //si es vacio procede con el inicio de 
    }

    public ModeloUsuario RecuperarModeloCompleto() {
        return this.cAdiministrador.RecuperarModelCompleto();
    }

    public String GetNombre() {
        return this.cAdiministrador.GetNombre();
    }

    public ContenedorError ActualizarUsuario(ModeloUsuario pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (mSalida.iscHayError()) {
            return mSalida;
        }
        return this.cAdiministrador.ActualizarUsuario(pModelo);
    }

    public void DesactivarUsuario() {
        this.cAdiministrador.DesactivarUsuario();
    }

    public void ActivarUsuario() {
        this.cAdiministrador.ActivarUsuario();
    }

 
}
