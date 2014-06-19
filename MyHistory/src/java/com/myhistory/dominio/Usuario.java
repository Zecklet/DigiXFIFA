/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.Dominio;

import com.myhistory.Datos.UsuariosBaseDatos;
import com.myhistory.datos.AdministradorBaseDatos;
import com.myhistory.ejetransversal.ModeloUsuario;

/**
 *
 * @author Ney Rojas
 */
public abstract class Usuario {

    protected String cNombre;
    protected String cApellido;
    protected String cFechaNacimiento;
    protected Cuenta cCuenta;
    protected int cIdentificador;

    protected void ColocarDatosComunes(String pNombre, String pApellido, String pFechaNacimiento,
            String pNombreUsuario, String pConstrasena) {
        this.cApellido = pApellido;
        this.cFechaNacimiento = pFechaNacimiento;
        this.cNombre = pNombre;
        if (this.cCuenta == null) {
            this.cCuenta = new Cuenta(pNombreUsuario, pConstrasena);
        } else {
            this.cCuenta.setcContrasena(pConstrasena);
            this.cCuenta.setcNombreUsuario(pNombreUsuario);
        }
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

    public void CrearCuenta() {
        UsuariosBaseDatos mConexion = new AdministradorBaseDatos();
        mConexion.CrearCuenta(cIdentificador, this.cCuenta.getcNombreUsuario(),
                this.cCuenta.getcContrasena(), this.cCuenta.getcFechaInscripcion());
    }

    public void CrearUsuario() {
        UsuariosBaseDatos mConexion = new AdministradorBaseDatos();
        cIdentificador = mConexion.CrearUsuario(cNombre, cApellido, cFechaNacimiento);
    }

    public void RecuperarCuentaBaseDatos() {

    }

    public void RecuperarUsuarioBaseDatos() {

    }

    public boolean CompararContrasena(String pConstrasena) {
        return this.cCuenta.CompararContrasena(pConstrasena);
    }

    //-------------------Metodos Abstractos-----------------------\\
    //Esta funcion coloca absolutamente todos los datos de un usuario
    abstract public void ColocarDatos(ModeloUsuario pModelo);

    //Esta funcion lo que hace es crear el usuario en la base de datos 
    abstract public void CrearNuevoUsuarioBaseDatos();

    //Recuperar los datos especificos del usuario heredado
    abstract public void RecuperarUsuarioEspecifico();

}
