/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.dominio;

import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author Ney Rojas
 */
public class CuentaTest {
    
    Cuenta cCuenta;
    
    public CuentaTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of CompararContrasena method, of class Cuenta.
     */
    //Prueba unitaria realizada al comparar la contrasena
    @Test
    public void testCompararContrasena() {
        System.out.println("CompararContrasena");
        String pContrasena = "Admin";
        Cuenta instance = null;
        try {
            instance = new Cuenta(pContrasena, pContrasena);
        } catch (Exception ex) {
            Logger.getLogger(CuentaTest.class.getName()).log(Level.SEVERE, null, ex);
        }
        boolean expResult = true;
        boolean result = instance.CompararContrasena(pContrasena);
        assertEquals(expResult, result);
    }
    
    //Prueba unitaria realizada sobre el nombre de usuario
    @Test
    public void testgetcNombreUsuario() {
        System.out.println("getcNombreUsuario");
        String pNombreUsuario = "Admin";
        Cuenta instance = null;
        try {
            instance = new Cuenta(pNombreUsuario, pNombreUsuario);
        } catch (Exception ex) {
            Logger.getLogger(CuentaTest.class.getName()).log(Level.SEVERE, null, ex);
        }
        String result = instance.getcNombreUsuario();
        assertEquals(pNombreUsuario, result);
    }
}
