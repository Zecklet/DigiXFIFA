/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.ejetransversal.ModeloAgregarEquipo;
import com.myhistory.ejetransversal.ModeloPais;
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
public class BaseDatosGestionarEquiposTest {

    private ModeloAgregarEquipo cModelo;
    
    public BaseDatosGestionarEquiposTest() {
    }

    @BeforeClass
    public static void setUpClass() {
    }

    @AfterClass
    public static void tearDownClass() {
    }

    @Before
    public void setUp() {
        cModelo = new ModeloAgregarEquipo(1, "HOLA", true, 1);
    }

    @After
    public void tearDown() {
    }

    /**
     * Test of AgregarEquipos method, of class BaseDatosGestionarEquipos.
     */
    @Test
    public void testAgregarEquipos() {
        System.out.println("AgregarEquipos");
        ModeloAgregarEquipo pDatosEquipo = this.cModelo;
        BaseDatosGestionarEquipos instance = new BaseDatosGestionarEquipos();
        boolean mEsperado = true;
        boolean mResultado = instance.AgregarEquipos(pDatosEquipo);
        assertEquals(mEsperado, mResultado);
    }

    /**
     * Test of ActualizarEquipos method, of class BaseDatosGestionarEquipos.
     */
    @Test
    public void testActualizarEquipos() {
        System.out.println("ActualizarEquipos");
        ModeloAgregarEquipo pDatosEquipo = this.cModelo;
        BaseDatosGestionarEquipos instance = new BaseDatosGestionarEquipos();
        boolean mEsperado = true;
        boolean mResultado = instance.ActualizarEquipos(pDatosEquipo);
        assertEquals(mEsperado, mResultado);
    }

}
