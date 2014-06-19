/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.ejetransversal;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import org.springframework.format.annotation.DateTimeFormat;


/**
 *
 * @author Ney Rojas
 */
public abstract class ModeloUsuario {

    @NotNull(message=" Por favor ingrese su nombre.")
    private String cNombre;
    @NotNull(message=" Por favor ingrese su apellido.")
    private String cApellido;
    @DateTimeFormat(pattern = "dd/MM/yyyy")
    @NotNull(message=" Por favor ingrese su fecha de nacimiento con el formta (dd/MM/yyyy).")
    private String cFechaNacimiento;
    @NotNull(message=" Por favor ingrese un nombre de usuario.")
    @Size(max=30,message=" El nombre de usuario no puede tener más de 30 caracteres")
    private String cNombreUsuario;
    @NotNull(message=" Por favor ingrese una contraseña.")
    @Size(min=4, max=8,message=" La contraseña tiene un máximo de 8 caracteres y un mínimo de 4")
    private String cContrasena;
    private String cFechaInscripcion;
    private int cIdentificador;

    public int getcIdentificador() {
        return cIdentificador;
    }

    public void setcIdentificador(int cIdentificador) {
        this.cIdentificador = cIdentificador;
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

    public String getcNombre() {
        return cNombre;
    }

    public void setcNombre(String cNombre) {
        this.cNombre = cNombre;
    }

    public String getcApellido() {
        return cApellido;
    }

    public void setcApellido(String cApellido) {
        this.cApellido = cApellido;
    }

    public String getcFechaNacimiento() {
        return cFechaNacimiento;
    }

    public void setcFechaNacimiento(String cFechaNacimiento) {
        this.cFechaNacimiento = cFechaNacimiento;
    }
}
