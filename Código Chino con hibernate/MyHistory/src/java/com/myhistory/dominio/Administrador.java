/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.datos.BaseDatosUsuarios;
import com.myhistory.datos.BaseDatosAdministrador;
import com.myhistory.ejetransversal.ModeloAdministrador;
import com.myhistory.ejetransversal.ModeloUsuario;

/**
 *
 * @author Ney Rojas
 */
public class Administrador extends Usuario {

    private String cCorreoElectronico;

    //--------------Setters y Getters--------------\\
    public String getcCorreoElectronico() {
        return cCorreoElectronico;
    }

    public void setcCorreoElectronico(String cCorreoElectronico) {
        this.cCorreoElectronico = cCorreoElectronico;
    }

    //Entrada: modelo de usuario con la informacion del usuario
    //Salida: ninguna
    //Descripcion: toma la informacion y la guarda en sus atributos correspondientes 
    @Override
    public void ColocarDatos(ModeloUsuario pModelo) {
        this.cCorreoElectronico = ((ModeloAdministrador) pModelo).getcCorreoElectronico();
        ColocarDatosComunes(pModelo.getcNombre(), pModelo.getcApellido(), pModelo.getcFechaNacimiento(),
                pModelo.getcNombreUsuario(), pModelo.getcContrasena());
    }

    //Entrada: 
    //Salida: int 0 => no inserto, 1=> inserto
    //Descripcion:Crea en la base de datos una nueva cuenta usuado los datos de entrada y hibernate
    @Override
    public void ColocarDatosDesdeBaseDatos(ModeloUsuario pModelo) {
        ColocarDatos(pModelo);
        this.cIdentificador = pModelo.getcIdentificador();
        this.cCuenta.setcFechaInscripcion(pModelo.getcFechaInscripcion());
        this.cCuenta.setcEstado(pModelo.iscEstado());
    }

    //Entrada: ninguna
    //Salida: ninguna
    //Descripcion:toma la informacion que la tiene almacenada y la guarda en la base de datos, 
    ///es decir, crea un nuevo usuario
    @Override
    public void CrearNuevoUsuarioBaseDatos() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        CrearCuenta();
        mConexion.CrearUsuario(cIdentificador, cNombre, cApellido, cFechaNacimiento,
                this.cCorreoElectronico);
        //mConexion.CrearUsuarioEspecifico(cIdentificador, cCorreoElectronico);
    }

    //Entrada: ninguna
    //Salida: ninguna
    //Descripcion:recupera toda la informacion de la base de datos, utilizando el nombre de usuario de la cuenta 
    @Override
    public void RecuperarUsuarioEspecifico() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        ModeloAdministrador mDatosBase = (ModeloAdministrador) mConexion.RecuperarDatosUsuario(this.cCuenta.getcNombreUsuario());
        this.ColocarDatosDesdeBaseDatos(mDatosBase);
        this.cCuenta.setcFechaInscripcion(mDatosBase.getcFechaInscripcion());
        this.cIdentificador = mDatosBase.getcIdentificador();
    }

    //Entrada: ninguna
    //Salida: modelo de usuario con toda la informacion del usuario
    //Descripcion:recupera toda la informacion del usuario de la base de datos como un modelo de usuario
    @Override
    public ModeloUsuario GetModeloCompleto() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        ModeloAdministrador mResultado = (ModeloAdministrador) mConexion.RecuperarDatosUsuario(this.cCuenta.getcNombreUsuario());
        mResultado.setcContrasena("");
        return mResultado;
    }

    //Entrada: ninguna
    //Salida: ninguna
    //Descripcion: toma todoa la informacion del usuario y actualiza la informacion en la base de datos 
    @Override
    public void ActualizarUsuarioBaseDatos() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        mConexion.ActualizarCuenta(cIdentificador, this.cCuenta.getcNombreUsuario(),
                this.cCuenta.getcContrasena());
        mConexion.ActualizarUsuario(cIdentificador, cNombre, cApellido, cFechaNacimiento, cCorreoElectronico);
    }
}
