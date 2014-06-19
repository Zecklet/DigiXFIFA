/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.Dominio;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 *
 * @author Ney Rojas
 */
public class Cuenta {
    private String cNombreUsuario;
    private String cContrasena;
    private String cFechaInscripcion;

    public Cuenta(String pNombreUsuario, String pConstrasena){
        this.cContrasena = pConstrasena;
        this.cNombreUsuario  = pNombreUsuario;
        DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy");
        this.cFechaInscripcion = mFormatoFecha.format(new Date());
    }

    public boolean CompararContrasena(String pContrasena){
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

    public String getcFechaInscripcion() {
        return cFechaInscripcion;
    }

    public void setcFechaInscripcion(String cFechaInscripcion) {
        this.cFechaInscripcion = cFechaInscripcion;
    }
    
}
