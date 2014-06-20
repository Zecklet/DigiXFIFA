/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.datos;

import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import java.util.List;
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
public class BaseDatosGestionarTorneoTest {
    
    public BaseDatosGestionarTorneoTest() {
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
     * Test of AgregarTorneo method, of class BaseDatosGestionarTorneo.
     */
    @Test
    public void testAgregarTorneo() {
        System.out.println("AgregarTorneo");
        String pNombreTorneo = "Hola";
        String pNombreSede = "Hola";
        int pCantidad = 23;
        boolean pEsSeleccion = false;
        boolean pEsCopa = false;
        BaseDatosGestionarTorneo instance = new BaseDatosGestionarTorneo();        
        boolean mEsperado = true;
        boolean mResultado = instance.AgregarTorneo(pNombreTorneo, pNombreSede, pCantidad, pEsSeleccion, pEsCopa);
        assertEquals(mEsperado, mResultado);
    }

    /**
     * Test of ActualizarTorneo method, of class BaseDatosGestionarTorneo.
     */
    @Test
    public void testActualizarTorneo() {
        System.out.println("ActualizarTorneo");
        int pIdentificador = 1;
        String pNombreTorneo = "Prueba unit";
        String pNombreSede = "Prueba unit";
        int pCantidad = 24;
        boolean pEsSeleccion = false;
        boolean pEsCopa = false;
        BaseDatosGestionarTorneo instance = new BaseDatosGestionarTorneo();        
        boolean mEsperado = true;
        boolean mResultado = instance.ActualizarTorneo(pIdentificador, pNombreTorneo, pNombreSede, pCantidad, pEsSeleccion, pEsCopa);
        assertEquals(mEsperado, mResultado);    }    
}
