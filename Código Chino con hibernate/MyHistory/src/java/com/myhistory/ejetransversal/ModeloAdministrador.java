/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.ejetransversal;

/**
 *
 * @author Ney Rojas
 */
public class ModeloAdministrador extends ModeloUsuario {
    private String cCorreoElectronico; //contiene el correo electronico del nuevo usuario

    //Setters y Getters 
    public String getcCorreoElectronico() {
        return cCorreoElectronico;
    }

    public void setcCorreoElectronico(String cCorreoElectronico) {
        this.cCorreoElectronico = cCorreoElectronico;
    }

     //Entrada: ninguna
    //Salida:boolean
    //Descripcion:metodo que evalue el estado de las variables, si hay alguna vacia, el modelo no es valido y devuelve false
    //cabe destacar que esto solamente se le aplica a los datos requeridos para agregar un nuevo usuario
    @Override
    public boolean CombrobarModelo() {
        return !(super.HayAlgunDatoVacio() || this.cCorreoElectronico.isEmpty());
    }
}
