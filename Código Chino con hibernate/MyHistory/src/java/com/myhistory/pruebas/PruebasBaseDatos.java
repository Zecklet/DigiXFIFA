/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.pruebas;

import com.myhistory.datos.BaseDatosUsuarios;
import com.myhistory.datos.BaseDatosAdministrador;
import com.myhistory.datos.HibernateUtil;
import com.myhistory.ejetransversal.ModeloAdministrador;
import com.myhistory.ejetransversal.ModeloUsuario;
import com.myhistory.presentacion.PresentadorGestionarUsuarios;

import java.util.Date;
import java.util.List;
import org.hibernate.classic.Session;

/**
 *
 * @author Ney Rojas
 */
public class PruebasBaseDatos {

    public static void main(String[] args) {

        BaseDatosUsuarios x = new BaseDatosAdministrador();
//        int mResultado = x.CrearCuenta("Admi4", "Admin", new Date());
//        x.CrearUsuario(mResultado,"Alguien","Alguien",
//                new Date(),"correro");
//        if (x.ExisteUsuario("jkljoñjk")) {
//            System.out.println("SI EXISTE");
//        } else {
//            System.out.println("NO EXISTE");
//        }

        PresentadorGestionarUsuarios c = new PresentadorGestionarUsuarios();
        
       
        c.IniciarSesion("Admi4", "Admin");
        ModeloUsuario mNuevo = c.RecuperarModeloCompleto();
        System.out.println(mNuevo.getcApellido() + "-" + mNuevo.getcIdentificador());
    }
}
