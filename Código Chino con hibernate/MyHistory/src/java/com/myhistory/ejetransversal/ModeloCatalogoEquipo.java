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
public class ModeloCatalogoEquipo {

    private List<ModeloAgregarEquipo> cEquipos;
    private String cEquipoSeleccionado;

    public ModeloCatalogoEquipo(){
        
    }
    
    public ModeloCatalogoEquipo(List<ModeloAgregarEquipo> pListaModelos) {
        this.cEquipos = pListaModelos;
    }

    public List<ModeloAgregarEquipo> getcEquipos() {
        return cEquipos;
    }

    public void setcEquipos(List<ModeloAgregarEquipo> cEquipos) {
        this.cEquipos = cEquipos;
    }

    public String getcEquipoSeleccionado() {
        return cEquipoSeleccionado;
    }
    
    public int getIdEquipo(){
        return Integer.parseInt(cEquipoSeleccionado);
    }

    public void setcEquipoSeleccionado(String cEquipoSeleccionado) {
        this.cEquipoSeleccionado = cEquipoSeleccionado;
    }

}
