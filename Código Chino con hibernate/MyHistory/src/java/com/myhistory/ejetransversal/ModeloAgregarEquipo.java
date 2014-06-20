/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.ejetransversal;

import java.util.List;
import java.util.Map;

/**
 *
 * @author Ney Rojas
 */
public class ModeloAgregarEquipo {

    private String cNombreEquipo;   //nombre del equipo
    private List<ModeloPais> cListaPaises; //lista de equipos que se muestran cuando se agrega un equipo
    private String cIdentificadorPais; //identificador del pais 
    private String cNombrePais;     //nombre del pais asociado al equipo
    private boolean cEsSeleccion;   //Si un equipo es de seleccion o no
    private String cIdentificador;  //identificador del equipo en la base de datos

    public ModeloAgregarEquipo() {
        this.cEsSeleccion = false;
        this.cIdentificador = "";
        this.cIdentificadorPais = "";
        this.cNombreEquipo = "";
        this.cNombrePais = "";
    }

    //----------------Construcctores-------------------\\
    public ModeloAgregarEquipo(List<ModeloPais> cListaPaises) {
        this.cListaPaises = cListaPaises;
    }

    public ModeloAgregarEquipo(String cNombreEquipo, List<ModeloPais> cListaPaises,
            String cIdentificadorPais, boolean cEsSeleccion, String cIdentificador, String cNombrePais) {
        this.cNombreEquipo = cNombreEquipo;
        this.cListaPaises = cListaPaises;
        this.cIdentificadorPais = cIdentificadorPais;
        this.cEsSeleccion = cEsSeleccion;
        this.cIdentificador = cIdentificador;
        this.cNombrePais = cNombrePais;
    }

    public ModeloAgregarEquipo(int cIdentificador, String cNombreEquipo, boolean cEsSeleccion, int cIdentificadorPais) {
        this.cNombreEquipo = cNombreEquipo;
        this.cIdentificadorPais = cIdentificadorPais + "";
        this.cEsSeleccion = cEsSeleccion;
        this.cIdentificador = cIdentificador + "";
    }
    //------------Setters y Getters---------------\\
    public String getcNombreEquipo() {
        return cNombreEquipo;
    }

    public void setcNombreEquipo(String cNombreEquipo) {
        this.cNombreEquipo = cNombreEquipo;
    }

    public List<ModeloPais> getcListaPaises() {
        return cListaPaises;
    }

    public void setcListaPaises(List<ModeloPais> cListaPaises) {
        this.cListaPaises = cListaPaises;
    }

    public String getcIdentificadorPais() {
        return cIdentificadorPais;
    }

    public int getIdPais() {
        return Integer.parseInt(cIdentificadorPais);
    }

    public void setcIdentificadorPais(String cIdentificadorPais) {
        this.cIdentificadorPais = cIdentificadorPais;
    }

    public boolean iscEsSeleccion() {
        return cEsSeleccion;
    }

    public void setcEsSeleccion(boolean cEsSeleccion) {
        this.cEsSeleccion = cEsSeleccion;
    }

    public String getcIdentificador() {
        return cIdentificador;
    }

    public int getId() {
        return Integer.parseInt(cIdentificador);
    }

    public void setcIdentificador(String cIdentificador) {
        this.cIdentificador = cIdentificador;
    }

    public String getcNombrePais() {
        return cNombrePais;
    }

    public void setcNombrePais(String cNombrePais) {
        this.cNombrePais = cNombrePais;
    }

}
