/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.ejetransversal;

/**
 *
 * @author Ney Rojas
 */
public class ContenedorError {
    private String cMensaje;
    private boolean cHayError;
    
    public ContenedorError(int pTipoError){
        this.cHayError = (pTipoError!=0);
        this.cMensaje = Constantes.kContenedorMensajesError[pTipoError];
    }

    public String getcMensaje() {
        return cMensaje;
    }

    public void setcMensaje(String cMensaje) {
        this.cMensaje = cMensaje;
    }

    public boolean iscHayError() {
        return cHayError;
    }

    public void setcHayError(boolean cHayError) {
        this.cHayError = cHayError;
    }
    
    
}
