/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.ejetransversal.Constantes;
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
public class EncriptadorTest {

    public EncriptadorTest() {
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
     * Test of Encriptar method, of class Encriptador.
     */
    @Test
    public void testEncriptarDesencriptar() throws Exception {
        System.out.println("Encriptar y Desencriptar");
        String pTexto = "Soy el encriptado";
        String pDireccionLlavePublica = Constantes.kRutaLlavePublica;
        String pDireccionLlavePrivada = Constantes.kRutaLlavePrivada;
        Encriptador instance = new Encriptador();
        String mTextoEncriptado = instance.Encriptar(pTexto, pDireccionLlavePublica);
        String result = instance.Desencriptar(mTextoEncriptado, pDireccionLlavePrivada);
        String expResult = pTexto;
        assertEquals(expResult, result);
    }
}
