/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.ejetransversal;

import java.util.List;

/**
 *
 * @author Ney Rojas
 */
public class ModeloCatalogoTorneo {

    private List<ModeloAgregarTorneo> cTorneos;
    private String cTorneoSeleccionado;

    public ModeloCatalogoTorneo(){
        
    }
    
    public ModeloCatalogoTorneo(List<ModeloAgregarTorneo> pListaModelos) {
        this.cTorneos = pListaModelos;
    }

    
    //Setters y Getters 
    public String getcTorneoSeleccionado() {
        return cTorneoSeleccionado;
    }

    public void setcTorneoSeleccionado(String cTorneoSeleccionado) {
        this.cTorneoSeleccionado = cTorneoSeleccionado;
    }

    public List<ModeloAgregarTorneo> getcTorneos() {
        return cTorneos;
    }

    public void setcTorneos(List<ModeloAgregarTorneo> cTorneos) {
        this.cTorneos = cTorneos;
    }
}
