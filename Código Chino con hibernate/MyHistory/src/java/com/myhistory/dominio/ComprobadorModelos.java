/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloAgregarEquipo;
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import com.myhistory.ejetransversal.ModeloUsuario;

/**
 *
 * @author Ney Rojas
 */
public class ComprobadorModelos {

    private static ComprobadorModelos cInstancia = null;

    private ComprobadorModelos() {

    }

    //Entrada: ningua
    //Salida: Comprobador de error
    //Descripcion: singleton de comprabador de modelos 
    public static ComprobadorModelos getInstance() {
        if (cInstancia == null) {
            cInstancia = new ComprobadorModelos();
        }
        return cInstancia;
    }

    //Entrada: modelo con la informacion de un usuario
    //Salida: ContenedorError = contiene el error generado en caso de algun problema
    //Descripcion: Funcion que corrobora que si el modelo tiene los datos ingresados completos y distintos de nulo 
    public ContenedorError ComprobarModelo(ModeloUsuario pModelo) {
        return CrearErrorLlenarTodosCampos(!pModelo.CombrobarModelo());
    }

//Entrada: ningua
    //Salida: Contenedor errror que contiene algun error si falla la comprobacion
    //Descripcion: Retorna un error en caso de que el modelo no tenga los datos correctos
    public ContenedorError ComprobarModelo(ModeloAgregarTorneo pModelo) {
        return CrearErrorLlenarTodosCampos(pModelo.getcNombreSede().isEmpty() || pModelo.getcNombreTorneo().isEmpty());
    }

//Entrada: ningua
    //Salida: Contenedor errror que contiene algun error si falla la comprobacion
    //Descripcion: Retorna un error en caso de que el modelo no tenga los datos correctos
    public ContenedorError ComprobarModelo(ModeloAgregarEquipo pModelo) {
        return CrearErrorLlenarTodosCampos(pModelo.getcNombreEquipo().isEmpty());
    }
    //Entrada: condicion de error
    //Salida: Contenedor errror que contiene algun error si falla la comprobacion
    //Descripcion: si es true=> que hay un error y faltan datos en el modelo, false=>todos los datos estan llenos
    private ContenedorError CrearErrorLlenarTodosCampos(boolean pDesicion) {
        if (pDesicion) {
            return new ContenedorError(Constantes.kErrorCodigoLlenarTodosCampos);
        } else {
            return new ContenedorError(Constantes.kErrorCodigoNoHayError);
        }
    }
}
