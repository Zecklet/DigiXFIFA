/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.ejetransversal;

import javax.validation.constraints.NotNull;

/**
 *
 * @author Ney Rojas
 */
public class ModeloAdministrador extends ModeloUsuario {
    @NotNull(message=" Por favor ingrese su correo electrónico.")
    private String cCorreoElectronico;

    public String getcCorreoElectronico() {
        return cCorreoElectronico;
    }

    public void setcCorreoElectronico(String cCorreoElectronico) {
        this.cCorreoElectronico = cCorreoElectronico;
    }
    
}
