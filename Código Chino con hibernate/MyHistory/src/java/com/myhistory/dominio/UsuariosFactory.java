/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.ejetransversal.Constantes;

/**
 *
 * @author Ney Rojas
 */
public class UsuariosFactory {

    private static UsuariosFactory cInstancia = null;

    //construcctor privado
    protected UsuariosFactory() {
    }

    //Entrada: ningua
    //Salida: Comprobador de error
    //Descripcion: singleton de la fabrica de usuarios 
    public static UsuariosFactory getInstance() {
        if (cInstancia == null) {
            cInstancia = new UsuariosFactory();
        }
        return cInstancia;
    }
   //Entrada: pTipoUsuario=> int del numero deseado
    //Salida: objeto de tipo usuari
    //Descripcion: Crea un usurio especifico segun el tipo de usuario seleccionado
    public Usuario CrearUsuario(int pTipoUsuario) {
        Usuario mResultado;
        switch (pTipoUsuario) {
            case Constantes.kCogidoAdministrador:
                mResultado = new Administrador();
                break;
            default:
                mResultado = null;
                break;
        }
        return mResultado;
    }
}
