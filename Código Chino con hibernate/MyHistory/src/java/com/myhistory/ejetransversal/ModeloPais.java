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
public class ModeloPais {

    private String cNombrePais = "0";
    private String cIdentificador = "";

    public ModeloPais(int pPkPais, String pNombre) {
        this.cIdentificador = "" + pPkPais;
        this.cNombrePais = pNombre;
    }

    public String getcNombrePais() {
        return cNombrePais;
    }

    public void setcNombrePais(String cNombrePais) {
        this.cNombrePais = cNombrePais;
    }

    public String getcIdentificador() {
        return cIdentificador;
    }

    public int getIdPais() {
        return Integer.parseInt(cIdentificador);
    }

    public void setcIdentificador(String cIdentificador) {
        this.cIdentificador = cIdentificador;
    }

}
