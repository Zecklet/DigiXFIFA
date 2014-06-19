/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ney Rojas
 */
public class Cuenta {

    private String cNombreUsuario;
    private String cContrasena;
    private Date cFechaInscripcion;
    private boolean cEstado;

    public Cuenta(String pNombreUsuario, String pConstrasena) {
        this.cContrasena = pConstrasena;
        this.cNombreUsuario = pNombreUsuario;
        this.cFechaInscripcion = new Date();
    }

    public boolean CompararContrasena(String pContrasena) {
        return (this.cContrasena == null ? pContrasena == null : this.cContrasena.equals(pContrasena));
    }

    public String getcNombreUsuario() {
        return cNombreUsuario;
    }

    public void setcNombreUsuario(String cNombreUsuario) {
        this.cNombreUsuario = cNombreUsuario;
    }

    public String getcContrasena() {
        return cContrasena;
    }

    public void setcContrasena(String cContrasena) {
        this.cContrasena = cContrasena;
    }

    public Date getcFechaInscripcion() {
        return cFechaInscripcion;
    }

    public void setcFechaInscripcion(String cFechaInscripcion) {
        DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy");
        try {
            this.cFechaInscripcion = mFormatoFecha.parse(cFechaInscripcion);
        } catch (ParseException ex) {
            Logger.getLogger(Cuenta.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public boolean iscEstado() {
        return cEstado;
    }

    public void setcEstado(boolean cEstado) {
        this.cEstado = cEstado;
    }

    void DesactivarUsuario() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

}
