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

    public static ComprobadorModelos getInstance() {
        if (cInstancia == null) {
            cInstancia = new ComprobadorModelos();
        }
        return cInstancia;
    }

    //Salida: ContenedorError = contiene el error generado en caso de algun problema
    //Descripcion: Funcion que corrobora que si el modelo tiene los datos ingresados completos y distintos de nulo 
    public ContenedorError ComprobarModelo(ModeloUsuario pModelo) {
        ContenedorError mResultado = new ContenedorError(Constantes.kErrorCodigoNoHayError); //Contenedor de no error
        if (!pModelo.CombrobarModelo()) { //si e modelo tiene algo vacio, crea su respectivo error
            mResultado = new ContenedorError(Constantes.kErrorCodigoLlenarTodosCampos); //crea un error
        }
        return mResultado;
    }

    public ContenedorError ComprobarModelo(ModeloAgregarTorneo pModelo) {
        if (pModelo.getcNombreSede().isEmpty() || pModelo.getcNombreTorneo().isEmpty()) {
            return new ContenedorError(Constantes.kErrorCodigoLlenarTodosCampos);
        } else {
            return new ContenedorError(Constantes.kErrorCodigoNoHayError);
        }
    }

    public ContenedorError ComprobarModelo(ModeloAgregarEquipo pModelo) {
        if (pModelo.getcNombreEquipo().isEmpty()) {
            return new ContenedorError(Constantes.kErrorCodigoLlenarTodosCampos);
        } else {
            return new ContenedorError(Constantes.kErrorCodigoNoHayError);
        }
    }
}
