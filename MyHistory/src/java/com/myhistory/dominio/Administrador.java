/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.Dominio;

import com.myhistory.datos.AdministradorBaseDatos;
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
    public void CrearNuevoUsuarioBaseDatos() {
        AdministradorBaseDatos mConexion = new AdministradorBaseDatos();
        CrearCuenta();
        CrearUsuario();
        ((AdministradorBaseDatos) mConexion).CrearUsuarioEspecifico(cIdentificador, cCorreoElectronico);
    }

    @Override
    public void RecuperarUsuarioEspecifico() {
        AdministradorBaseDatos mConexion = new AdministradorBaseDatos();
        ModeloAdministrador mDatosBase = (ModeloAdministrador)mConexion.RecuperarDatosUsuario(this.cCuenta.getcNombreUsuario());
        this.ColocarDatos(mDatosBase);
        this.cCuenta.setcFechaInscripcion(mDatosBase.getcFechaInscripcion());
        this.cIdentificador = mDatosBase.getcIdentificador();
    }
}
