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
public class ModeloAgregarTorneo {

    private String cNombreTorneo;
    private String cNombreSede;
    private String cCantidadJugadores;
    private boolean cEsSeleccion;
    private boolean cEsCopa;
    private String cIdentificador;


    public ModeloAgregarTorneo(String pNombreTorneo, String pNombreSede, String pCantidadJugadores,
            boolean pEsSeleccion, boolean pEsCopa, String pIdentificador) {
        this.cNombreTorneo = pNombreTorneo;
        this.cNombreSede = pNombreSede;
        this.cCantidadJugadores = pCantidadJugadores;
        this.cEsSeleccion = pEsSeleccion;
        this.cEsCopa = pEsCopa;
        this.cIdentificador = pIdentificador;
    }

    public ModeloAgregarTorneo() {
    }

    public String getcNombreTorneo() {
        return cNombreTorneo;
    }

    public void setcNombreTorneo(String cNombreTorneo) {
        this.cNombreTorneo = cNombreTorneo;
    }

    public String getcNombreSede() {
        return cNombreSede;
    }

    public void setcNombreSede(String cNombreSede) {
        this.cNombreSede = cNombreSede;
    }

    public String getcCantidadJugadores() {
        return cCantidadJugadores;
    }

    public void setcCantidadJugadores(String cCantidadJugadores) {
        this.cCantidadJugadores = cCantidadJugadores;
    }

    public boolean getcEsSeleccion() {
        return cEsSeleccion;
    }

    public void setcEsSeleccion(boolean cEsSeleccion) {
        this.cEsSeleccion = cEsSeleccion;
    }

    public boolean getcEsCopa() {
        return cEsCopa;
    }

    public void setcEsCopa(boolean cEsCopa) {
        this.cEsCopa = cEsCopa;
    }

    public String getcIdentificador() {
        return cIdentificador;
    }

    public void setcIdentificador(String cIdentificador) {
        this.cIdentificador = cIdentificador;
    }
}
