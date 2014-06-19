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

    private static ModeloUsuarioFactory cInstancia = null;

    public static ModeloUsuarioFactory getInstance() {
        if (cInstancia == null) {
            cInstancia = new ModeloUsuarioFactory();
        }
        return cInstancia;
    }

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
