/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.dominio;

import com.myhistory.Dominio.Usuario;
import com.myhistory.ejetransversal.ModeloUsuario;
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.Dominio.UsuariosFactory;
/**
 *
 * @author Ney Rojas
 */
public class AdministradorUsuarios {
    
    private Usuario cUsuarioActual;
    
    public void CrearNuevoUsuario(ModeloUsuario pDatosModelo){
        Usuario mNuevoUsuario = UsuariosFactory.getInstance().CrearUsuario(Constantes.kCogidoAdministrador);
        mNuevoUsuario.ColocarDatos(pDatosModelo);
        mNuevoUsuario.CrearNuevoUsuarioBaseDatos();
    }
    
    public boolean UsuarioCorrecto(String pNombreUsuario, String pConstrasena){
        Usuario mNuevoUsuario = UsuariosFactory.getInstance().CrearUsuario(Constantes.kCogidoAdministrador);
        mNuevoUsuario.RecuperarCuentaBaseDatos();
        return mNuevoUsuario.CompararContrasena(pConstrasena);
    }
}
