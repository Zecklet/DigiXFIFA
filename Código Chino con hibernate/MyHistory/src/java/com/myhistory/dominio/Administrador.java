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

    public String getcCorreoElectronico() {
        return cCorreoElectronico;
    }

    public void setcCorreoElectronico(String cCorreoElectronico) {
        this.cCorreoElectronico = cCorreoElectronico;
    }

    @Override
    public void ColocarDatos(ModeloUsuario pModelo) {
        this.cCorreoElectronico = ((ModeloAdministrador) pModelo).getcCorreoElectronico();
        ColocarDatosComunes(pModelo.getcNombre(), pModelo.getcApellido(), pModelo.getcFechaNacimiento(),
                pModelo.getcNombreUsuario(), pModelo.getcContrasena());
    }

    @Override
    public void ColocarDatosDesdeBaseDatos(ModeloUsuario pModelo) {
        ColocarDatos(pModelo);
        this.cIdentificador = pModelo.getcIdentificador();
        this.cCuenta.setcFechaInscripcion(pModelo.getcFechaInscripcion());
        this.cCuenta.setcEstado(pModelo.iscEstado());
    }

    @Override
    public void CrearNuevoUsuarioBaseDatos() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        CrearCuenta();
        mConexion.CrearUsuario(cIdentificador, cNombre, cApellido, cFechaNacimiento,
                this.cCorreoElectronico);
        //mConexion.CrearUsuarioEspecifico(cIdentificador, cCorreoElectronico);
    }

    @Override
    public void RecuperarUsuarioEspecifico() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        ModeloAdministrador mDatosBase = (ModeloAdministrador) mConexion.RecuperarDatosUsuario(this.cCuenta.getcNombreUsuario());
        this.ColocarDatosDesdeBaseDatos(mDatosBase);
        this.cCuenta.setcFechaInscripcion(mDatosBase.getcFechaInscripcion());
        this.cIdentificador = mDatosBase.getcIdentificador();
    }

    @Override
    public ModeloUsuario GetModeloCompleto() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        ModeloAdministrador mResultado = (ModeloAdministrador) mConexion.RecuperarDatosUsuario(this.cCuenta.getcNombreUsuario());
        mResultado.setcContrasena("");
        return mResultado;
    }

    @Override
    public void ActualizarUsuarioBaseDatos() {
        BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
        mConexion.ActualizarCuenta(cIdentificador,this.cCuenta.getcNombreUsuario(),
                this.cCuenta.getcContrasena());
        mConexion.ActualizarUsuario(cIdentificador,cNombre, cApellido, cFechaNacimiento, cCorreoElectronico);
    }
}
