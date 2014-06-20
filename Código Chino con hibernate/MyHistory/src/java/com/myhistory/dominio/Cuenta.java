/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.ejetransversal.Constantes;
import java.io.File;
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

    //construcctor
    public Cuenta(String pNombreUsuario, String pConstrasena) {
        Encriptador mEncriptador = null;
        try {
            mEncriptador = new Encriptador();
            this.cContrasena = mEncriptador.Encriptar(pConstrasena, Constantes.kRutaLlavePublica);
        } catch (Exception ex) {
            Logger.getLogger(Cuenta.class.getName()).log(Level.SEVERE, null, ex);
        }
        this.cNombreUsuario = pNombreUsuario;
        this.cFechaInscripcion = new Date();
    }

    //Entrada: String con la contrasena que se quiere comparar 
    //Salida: true si son las mismas
    //Descripcion: Compara la contrasena real del usuario, con la ingresada, 
    //pero antes de ello se tiene que desencriptar la constrasena original
    public boolean CompararContrasena(String pContrasena) {
        Encriptador mEncriptador; //Encriptador
        String mContrasenaUsuario = ""; //variable donde se almacena temporalmente la contrasena del usuario
        try {
            mEncriptador = new Encriptador(); //Se crea el encrpitador
            mContrasenaUsuario = mEncriptador.Desencriptar(this.cContrasena, Constantes.kRutaLlavePrivada); //Se realiza el desencriptamiento
        } catch (Exception ex) {
            Logger.getLogger(Cuenta.class.getName()).log(Level.SEVERE, null, ex);
        }
        return (mContrasenaUsuario == null ? pContrasena == null : mContrasenaUsuario.equals(pContrasena)); //se realiza la comparacion
    }

    //-------------setter y getters--------------\\
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

    //Entrada: string con la fecha de nacimiento
    //salida: ninguna
    //Descripcion: transforma un string en una fecha de nacimienot
    public void setcFechaInscripcion(String cFechaInscripcion) {
        DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy"); //formato del string de la fecha
        try {
            this.cFechaInscripcion = mFormatoFecha.parse(cFechaInscripcion); //se convierte la fecha
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
}
