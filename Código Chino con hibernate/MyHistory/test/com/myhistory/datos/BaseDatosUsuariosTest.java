/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.ejetransversal.ModeloUsuario;
import java.util.Date;
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
public class BaseDatosUsuariosTest {

    private String cNombreUsuario;

    public BaseDatosUsuariosTest() {
    }

    @BeforeClass
    public static void setUpClass() {
    }

    @AfterClass
    public static void tearDownClass() {
    }

    @Before
    public void setUp() {
        cNombreUsuario = "Chino";
    }

    @After
    public void tearDown() {
    }

    /**
     * Test of CrearCuenta method, of class BaseDatosUsuarios.
     */
    @Test
    public void testCrearCuenta() {
        System.out.println("CrearCuenta");
        String pNombreUsuario = cNombreUsuario;
        String pContrasena = "Kenneth";
        Date pFechaInscripcion = new Date();
        BaseDatosUsuarios instance = new BaseDatosUsuariosImpl();
        String expResult = pNombreUsuario;
        String result;
        if (!instance.ExisteUsuario(pNombreUsuario)) {
            instance.CrearCuenta(pNombreUsuario, pContrasena, pFechaInscripcion);
            instance.CrearUsuario(instance.RecuperarDatosCuenta(pNombreUsuario).getcIdentificador(), pNombreUsuario, pNombreUsuario, pFechaInscripcion, pNombreUsuario);
        }
        result = instance.RecuperarDatosCuenta(pNombreUsuario).getcNombreUsuario();
        assertEquals(expResult, result);
    }

    /**
     * Test of ExisteUsuario method, of class BaseDatosUsuarios.
     */
    @Test
    public void testExisteUsuario() {
        System.out.println("ExisteUsuario");
        String pNombreUsuario = "qqq";
        BaseDatosUsuarios instance = new BaseDatosUsuariosImpl();
        boolean expResult = true;
        boolean result = instance.ExisteUsuario(pNombreUsuario);
        assertEquals(expResult, result);
    }

    /**
     * Test of CambiarEstadoUsuario method, of class BaseDatosUsuarios.
     */
    @Test
    public void testCambiarEstadoUsuario() {
        System.out.println("CambiarEstadoUsuario");

        boolean cEstado = false;
        BaseDatosUsuarios instance = new BaseDatosUsuariosImpl();
        instance.CambiarEstadoUsuario(instance.RecuperarDatosCuenta(this.cNombreUsuario).getcIdentificador(), cEstado);
        boolean result = instance.RecuperarDatosCuenta(this.cNombreUsuario).iscEstado();
        assertEquals(cEstado, result);
    }

    /**
     * Test of ActualizarUsuario method, of class BaseDatosUsuarios.
     */
    @Test
    public void testActualizarUsuario() {
        System.out.println("ActualizarUsuario");
        int pIdentificador = 0;
        String pNombre = "Alonso";
        String pApellido = "Alonso1";
        Date pFechaNacimiento = new Date();
        String pCorreo = "Alonosoo@";
        BaseDatosUsuarios instance = new BaseDatosUsuariosImpl();
        pIdentificador = instance.RecuperarDatosCuenta(this.cNombreUsuario).getcIdentificador();
        instance.ActualizarUsuario(pIdentificador, pNombre, pApellido, pFechaNacimiento, pCorreo);
        String result = instance.RecuperarDatosUsuario(this.cNombreUsuario).getcNombre();
        assertEquals(pNombre, result);
    }

    /**
     * Test of ActualizarCuenta method, of class BaseDatosUsuarios.
     */
    @Test
    public void testActualizarCuenta() {
        System.out.println("ActualizarCuenta");
        int pPKUsuario;
        String pNombreUsuario = this.cNombreUsuario;
        String pContrasena = "1234";
        BaseDatosUsuarios instance = new BaseDatosUsuariosImpl();
        pPKUsuario = instance.RecuperarDatosCuenta(pNombreUsuario).getcIdentificador();
        instance.ActualizarCuenta(pPKUsuario, pNombreUsuario, pContrasena);

        String result = instance.RecuperarDatosUsuario(this.cNombreUsuario).getcContrasena();
        assertEquals(pContrasena, result);
    }

    public class BaseDatosUsuariosImpl extends BaseDatosUsuarios {

        public ModeloUsuario RecuperarDatosUsuario(String pNombreUsuario) {
            BaseDatosAdministrador mConexion = new BaseDatosAdministrador();
            return mConexion.RecuperarDatosUsuario(pNombreUsuario);
        }
    }

}
