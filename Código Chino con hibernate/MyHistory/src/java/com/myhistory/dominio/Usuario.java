/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.datos.BaseDatosUsuarios;
import com.myhistory.datos.BaseDatosAdministrador;
import com.myhistory.ejetransversal.ModeloUsuario;
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
public abstract class Usuario {

    protected String cNombre;
    protected String cApellido;
    protected Date cFechaNacimiento;
    protected Cuenta cCuenta;
    protected int cIdentificador;

    //Entrada: datos de un usuario
    //salida:ninguan
    //Descripcion: coloca los datos de un usuario
    protected void ColocarDatosComunes(String pNombre, String pApellido, String pFechaNacimiento,
            String pNombreUsuario, String pConstrasena) {
        this.cApellido = pApellido;
        DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy"); //formato para la fecha
        try {
            this.cFechaNacimiento = mFormatoFecha.parse(pFechaNacimiento); //convierte la fecha string a date
        } catch (ParseException ex) {
            Logger.getLogger(Usuario.class.getName()).log(Level.SEVERE, null, ex);
        }
        this.cNombre = pNombre;
        ColocarDatosCuenta(pNombreUsuario, pConstrasena);

    }
//Entrada: datos de una cuenta (nombre de usuario y contrena)
    //salida:ninguan
    //Descripcion: coloca los datos de una cuenta, este metodo tambien es utilizado para actualizar la cuenta 

    public void ColocarDatosCuenta(String pNombreUsuario, String pConstrasena) {
        if (this.cCuenta == null) {
            this.cCuenta = new Cuenta(pNombreUsuario, pConstrasena);
        } else {
            this.cCuenta.setcContrasena(pConstrasena);
            this.cCuenta.setcNombreUsuario(pNombreUsuario);
        }
    }

    //Entrada: ningua
    //salida:ninguan
    //Descripcion: toma todos los datos de la cuenta y los envia a la base de datos para que cree un nuevo usuario
    public void CrearCuenta() {
        BaseDatosUsuarios mConexion = new BaseDatosAdministrador();
        cIdentificador = mConexion.CrearCuenta(this.cCuenta.getcNombreUsuario(),
                this.cCuenta.getcContrasena(), this.cCuenta.getcFechaInscripcion());
    }

    //Entrada: Nombre de usuario
    //salida:ninguan
    //Descripcion: consulta la informacion de la cuenta a la base de datos 
    public void RecuperarCuentaBaseDatos(String pNombreUsuario) {
        BaseDatosUsuarios mConexion = new BaseDatosAdministrador();
        ModeloUsuario mModeloDatos = mConexion.RecuperarDatosCuenta(pNombreUsuario);
        ColocarDatosCuenta(mModeloDatos.getcNombreUsuario(), mModeloDatos.getcContrasena());
    }

    //Entrada: pContrasena del usuario
    //salida: true => contrasena igual, false=> contrasena incorrecta
    //Descripcion: le solicita a la cuenta que compare las contrasenas ingresadas 
    public boolean CompararContrasena(String pConstrasena) {
        return this.cCuenta.CompararContrasena(pConstrasena);
    }

    //-------------------Metodos Abstractos-----------------------\\
    //Esta funcion coloca absolutamente todos los datos de un usuario
    abstract public void ColocarDatos(ModeloUsuario pModelo);

    //Esta funcion actualiza los datos especificos de cada usuario
    abstract public void ColocarDatosDesdeBaseDatos(ModeloUsuario pModelo);

    //Esta funcion lo que hace es crear el usuario en la base de datos 
    abstract public void CrearNuevoUsuarioBaseDatos();

    //Esta funcion lo que hace es crear el usuario en la base de datos 
    abstract public void ActualizarUsuarioBaseDatos();

    //Recuperar los datos especificos del usuario heredado
    abstract public void RecuperarUsuarioEspecifico();

    //Recuperar el modelo completo de un usuario especifico
    abstract public ModeloUsuario GetModeloCompleto();

//-------------------------Setters y getters ------------------\\
    public int getcIdentificador() {
        return cIdentificador;
    }

    public void setcIdentificador(int cIdentificador) {
        this.cIdentificador = cIdentificador;
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

    public Date getcFechaNacimiento() {
        return cFechaNacimiento;
    }

    public void setcFechaNacimiento(String cFechaNacimiento) {
        DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy");
        try {
            this.cFechaNacimiento = mFormatoFecha.parse(cFechaNacimiento);
        } catch (ParseException ex) {
            Logger.getLogger(Usuario.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    String getNombreUsuario() {
        return this.cCuenta.getcNombreUsuario();
    }

    //Entrada: pEstado => nuevo estado que tendra la cuenta 
    //salida:ninguan
    //Descripcion: Cambia el estado de la cuenta y le solicitea a la base de datos que cambie el estado de la cuenta 
    //para que quede almacenado
    public void CambiarEstado(boolean pEstado) {
        this.cCuenta.setcEstado(pEstado);
        BaseDatosUsuarios mConexion = new BaseDatosAdministrador();
        mConexion.CambiarEstadoUsuario(cIdentificador, pEstado);
    }
    
//    //Entrada: ninguna
//    //salida:ninguan
//    //Descripcion: Cambia el estado de la cuenta y le solicitea a la base de datos que cambie el estado de la cuenta 
//    //para que quede almacenado
//    protected void CambiarEstadoUsuarioBaseDatos() {
//        BaseDatosUsuarios mConexion = new BaseDatosAdministrador();
//        mConexion.CambiarEstadoUsuario(this.cIdentificador, this.cCuenta.iscEstado());
//    }

}
