/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.datos;

import com.myhistory.ejetransversal.ModeloUsuario;
import com.myhistory.Datos.UsuariosBaseDatos;
/**
 *
 * @author Ney Rojas
 */
public class AdministradorBaseDatos extends UsuariosBaseDatos{
    
    @Override
    public ModeloUsuario RecuperarDatosUsuario(String pNombreUsuario){
        return null;
    }
    
    public void CrearUsuarioEspecifico(int pPKIdentificador, String pNombreUsuario){
        
    }
}
