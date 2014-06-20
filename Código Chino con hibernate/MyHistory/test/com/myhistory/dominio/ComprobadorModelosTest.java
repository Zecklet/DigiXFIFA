/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloAdministrador;
import com.myhistory.ejetransversal.ModeloAgregarEquipo;
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import com.myhistory.ejetransversal.ModeloUsuario;
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
public class ComprobadorModelosTest {

    public ComprobadorModelosTest() {
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
     * Test of ComprobarModelo method, of class ComprobadorModelos.
     */
    @Test
    public void testComprobarModelo_ModeloUsuario() {
        System.out.println("ComprobarModelo");
        ModeloAdministrador pModelo = new ModeloAdministrador();
        pModelo.setcApellido("asa");
        pModelo.setcContrasena("asa");
        pModelo.setcFechaNacimiento("asa");
        pModelo.setcNombre("asa");
        pModelo.setcNombreUsuario("asa");
        pModelo.setcCorreoElectronico("");
        ComprobadorModelos instance = ComprobadorModelos.getInstance();
        ContenedorError expResult = new ContenedorError(Constantes.kErrorCodigoLlenarTodosCampos);
        ContenedorError result = instance.ComprobarModelo(pModelo);
        assertEquals(expResult.iscHayError(), result.iscHayError());
    }

    /**
     * Test of ComprobarModelo method, of class ComprobadorModelos.
     */
    @Test
    public void testComprobarModelo_ModeloAgregarTorneo() {
        System.out.println("ComprobarModelo");
        ModeloAgregarTorneo pModelo = new ModeloAgregarTorneo();
        pModelo.setcNombreSede("Alguna");
        pModelo.setcNombreTorneo("Superemoslo");
        ComprobadorModelos instance = ComprobadorModelos.getInstance();
        ContenedorError expResult = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        ContenedorError result = instance.ComprobarModelo(pModelo);
        assertEquals(expResult.iscHayError(), result.iscHayError());
    }

    /**
     * Test of ComprobarModelo method, of class ComprobadorModelos.
     */
    @Test
    public void testComprobarModelo_ModeloAgregarEquipo() {
        System.out.println("ComprobarModelo");
        ModeloAgregarEquipo pModelo = new ModeloAgregarEquipo(1, "Nombre", true, 1);
        ComprobadorModelos instance = ComprobadorModelos.getInstance();
        ContenedorError expResult = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        ContenedorError result = instance.ComprobarModelo(pModelo);
        assertEquals(expResult.iscHayError(), result.iscHayError());
    }

}
