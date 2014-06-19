/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.Dominio;

import com.myhistory.ejetransversal.Constantes;


/**
 *
 * @author Ney Rojas
 */

public class UsuariosFactory {

    private static UsuariosFactory cInstancia = null;
    
   protected UsuariosFactory() {
      // Exists only to defeat instantiation.
   }
   public static UsuariosFactory getInstance() {
      if(cInstancia == null) {
         cInstancia = new UsuariosFactory();
      }
      return cInstancia;
   }
    
    public Usuario CrearUsuario(int pTipoUsuario){
        Usuario mResultado;
        switch(pTipoUsuario){
            case Constantes.kCogidoAdministrador:
                mResultado = new Administrador();
                break;
            default:
                mResultado = null;
                break;
        }
        return mResultado;
    }
}
