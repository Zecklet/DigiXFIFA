/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.presentacion;

import com.myhistory.ejetransversal.ModeloAdministrador;
import com.myhistory.ejetransversal.ModeloUsuario;

/**
 *
 * @author Ney Rojas
 */
public class GestionarUsuariosPresentador {
    
    public ModeloUsuario GetModeloUsuario(){
        return new ModeloAdministrador();
    }
    
    
}
