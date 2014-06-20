package com.myhistory.presentacion;

import com.myhistory.dominio.AdministrarGestionarTorneo;
import com.myhistory.dominio.ComprobadorModelos;
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import com.myhistory.ejetransversal.ModeloCatalogoTorneo;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Ney Rojas
 */
public class PresentadorGestionarTorneo {

    AdministrarGestionarTorneo cAdministrarTorneos;

    public PresentadorGestionarTorneo() {
        cAdministrarTorneos = new AdministrarGestionarTorneo();
    }

    //Entrada: ninguna
    //Salida: ModeloAgregarTorneo 
    //Descripcion: crea un nuevo modelo e agregar equipo para pasarlo a la vista
    public ModeloAgregarTorneo GetModeloAgregarTorneo() {
        return new ModeloAgregarTorneo();
    }

    //Entrada: Modelo de agregar torneo con la infomracion del nuevo equipo
    //Salida: Contenedor error 
    //Descripcion: le solicita al administrador de torneos que cree un torneo en la base 
    public ContenedorError AgregarTorneo(ModeloAgregarTorneo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
            this.cAdministrarTorneos.CrearTorneo(pModelo);
        }
        return mSalida;
    }

    //Entrada: ninguna 
    //Salida: ModeloCatalogoTorneo => contiene todos los torneos registrados en myhistory 
    //Descripcion: le solicita al administrador de torneo que le cree un modelo de catalogo de torneo
    public ModeloCatalogoTorneo GetModeloCalendarioTorneo() {
        return this.cAdministrarTorneos.GetModeloCalendarioTorneo();
    }

    //Entrada: pIdentificador=> id del torneo buscado
    //Salida: ModeloCatalogoTorneo => utilizado para obtener datos de la vista
    //Descripcion: le solicita al administrador de equipos que le genere un modelo de torneo usando el idetificador del torneo
    public ModeloAgregarTorneo GetModeloTorneo(String pIdentificador) {
        return this.cAdministrarTorneos.GetModelo(pIdentificador);
    }

    //Entrada: Modelo toreno equipo=> contiene todos los datos ingresados por el usuario de un torneo 
    //Salida: ContenedorError => en caso de error el sabe cual es 
    //Descripcion: le solicita al administrador de equipos que le actualice un toreno de la base
    public ContenedorError ActualizarTorneo(ModeloAgregarTorneo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
            this.cAdministrarTorneos.ActualizarTorneo(pModelo);
        }
        return mSalida;
    }

}
