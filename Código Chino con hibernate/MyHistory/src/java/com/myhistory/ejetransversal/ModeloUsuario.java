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
public abstract class ModeloUsuario {


    //datos que se tienen que agregar cuando se cre un nuevo usuario
    protected String cNombre;
    protected String cApellido;
    protected String cFechaNacimiento;
    protected String cNombreUsuario;
    protected String cContrasena;
    
    protected String cFechaInscripcion;
    protected int cIdentificador;
    protected boolean cEstado;

    
    //--------------------Setters y Getters----------------------- 
    public boolean iscEstado() {
        return cEstado;
    }

    public void setcEstado(boolean cEstado) {
        this.cEstado = cEstado;
    }
    
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
    //Entrada: ninguna
    //Salida:boolean
    //Descripcion:evalua si algun dato al momento de agregar usuarios tiene algun campo vacio, retorna true
    //si hay un dato vacio
    protected boolean HayAlgunDatoVacio(){
        return (this.cApellido.isEmpty() || this.cContrasena.isEmpty() || this.cFechaNacimiento.isEmpty()
                || this.cNombre.isEmpty() || this.cNombreUsuario.isEmpty());
    }
    
    //Entrada: ninguna
    //Salida:boolean
    //Descripcion:metodo que evalue el estado de las variables, si hay alguna vacia, el modelo no es valido y devuelve false
    //cabe destacar que esto solamente se le aplica a los datos requeridos para agregar un nuevo usuario
    abstract public boolean CombrobarModelo();
}
