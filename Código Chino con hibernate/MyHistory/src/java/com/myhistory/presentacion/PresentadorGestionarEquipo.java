/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.presentacion;

import com.myhistory.dominio.AdministrarGestionarEquipos;
import com.myhistory.dominio.ComprobadorModelos;
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloAgregarEquipo;
import com.myhistory.ejetransversal.ModeloCatalogoEquipo;

/**
 *
 * @author Ney Rojas
 */
public class PresentadorGestionarEquipo {

    AdministrarGestionarEquipos cAdministrarEquipos;

    //Constructor
    public PresentadorGestionarEquipo() {
        cAdministrarEquipos = new AdministrarGestionarEquipos();
    }
    //Entrada: ninguna
    //Salida: modelo de agregar equipo 
    //Descripcion: le solicita al administrador de equipos que cree un modelo de agregar equipos y lo retorna
    public ModeloAgregarEquipo GetModeloAgregarEquipo() {
        return cAdministrarEquipos.GetModeloAgregarEquipo();
    }
    
    //Entrada: Modelo de agregar equipos con la infomracion del nuevo equipo
    //Salida: Contenedor error 
    //Descripcion: le solicita al administrador de equipos que cree un equipo en fisico
    public ContenedorError AgregarEquipo(ModeloAgregarEquipo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
            this.cAdministrarEquipos.AgregarEquipo(pModelo);
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        }
        return mSalida;
    }

    //Entrada: ninguna 
    //Salida: ModeloCatalogoEquipo => contiene todos los torneos registrados en myhistory 
    //Descripcion: le solicita al administrador de equipos que le cree un modelo de catalogo de equipos
    public ModeloCatalogoEquipo GetModeloCalendarioEquipos() {
        return this.cAdministrarEquipos.GetModeloCatalogoEquipos();
    }

    //Entrada: pIdentificador=> id del equipo buscado
    //Salida: ModeloCatalogoEquipo => utilizado para obtener datos de la vista
    //Descripcion: le solicita al administrador de equipos que le genere un modelo de equipos sobre un equipo ya existente
    public ModeloAgregarEquipo GetModeloEquipo(int pIdentificador) {
        return this.cAdministrarEquipos.GetModeloInformacionEquipo(pIdentificador);
    }

    //Entrada: Modelo agregar equipo=> contiene todos los datos ingresados por el usuario de un equipo 
    //Salida: ContenedorError => en caso de error el sabe cual es 
    //Descripcion: le solicita al administrador de equipos que le actualice un equipo de la base
    public ContenedorError ActualizarEquipo(ModeloAgregarEquipo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
            this.cAdministrarEquipos.ActualizarEquipo(pModelo);
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        }
        return mSalida;
    }
    //Entrada: Modelo agregar equipo=> contiene todos los datos ingresados por el usuario de un equipo 
    //Salida: Modelo agregar equipos => con todos los equipos colocados
    //Descripcion: le solicita al administrador de equipos que le coloque los paises al modelo enviado
    public ModeloAgregarEquipo SetPaises(ModeloAgregarEquipo pModelo) {
        return this.cAdministrarEquipos.SetPaises(pModelo);
    }
}
