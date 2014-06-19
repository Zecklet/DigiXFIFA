/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.Datos;

import com.myhistory.ejetransversal.ModeloUsuario;

/**
 *
 * @author Ney Rojas
 */
public abstract class UsuariosBaseDatos {
    
    public boolean ExisteUsuario(String pNombreUsuario){
        return false;
    }
    
    public int CrearUsuario(String pNombre, String pApellido, 
            String pFechaNacimiento){
        return 0;
    }
    
    public void CrearCuenta(int pPKUsuario, String pNombreUsuario, String pContrasena, String pFechaInscripcion){
        
    }
    
    public void ActualizarUsuario(String pNombre, String pApellido, 
            String pFechaNacimiento){
        
    }
    
    public void ActualizarCuenta(int pPKUsuario, String pNombreUsuario, String pContrasena, String pFechaInscripcion){
        
    }
    
    abstract public ModeloUsuario RecuperarDatosUsuario(String pNombreUsuario);
}
