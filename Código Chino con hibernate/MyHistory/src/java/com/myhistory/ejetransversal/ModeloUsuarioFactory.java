/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.ejetransversal;

import com.myhistory.ejetransversal.Constantes;

/**
 *
 * @author Ney Rojas
 */
public class ModeloUsuarioFactory {

    //Constructor privado
    private static ModeloUsuarioFactory cInstancia = null;

    //Entrada: ningua
    //Salida: Comprobador de error
    //Descripcion: singleton de la fabrica de usuarios 
    public static ModeloUsuarioFactory getInstance() {
        if (cInstancia == null) {
            cInstancia = new ModeloUsuarioFactory();
        }
        return cInstancia;
    }

    //Entrada: pTipoUsuario=> int del modelo deseado
    //Salida: objeto de tipo usuari
    //Descripcion: Crea un modelo de usuario especifico segun el tipo de usuario seleccionado
    public ModeloUsuario CrearModeloUsuario(int pTipoUsuario) {
        ModeloUsuario mResultado;
        switch (pTipoUsuario) {
            case Constantes.kCogidoAdministrador:
                mResultado = new ModeloAdministrador();
                break;
            default:
                mResultado = null;
                break;
        }
        return mResultado;
    }
}
