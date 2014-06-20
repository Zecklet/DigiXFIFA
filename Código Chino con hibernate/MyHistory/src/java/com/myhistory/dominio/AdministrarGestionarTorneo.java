/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.dominio;

import com.myhistory.datos.BaseDatosGestionarTorneo;
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import com.myhistory.ejetransversal.ModeloCatalogoTorneo;

/**
 *
 * @author Ney Rojas
 */
public class AdministrarGestionarTorneo {
    
    private BaseDatosGestionarTorneo cBaseDatosTorneos = null;

    //Entrada: ningua
    //Salida: Base datos gestionar equipos con la conexion a la clase que se comunica con la base de datos para admnistrar los datos del torneo
    //Descripcion:inicializacion perezosa del objeto que conecta con la base de datos para los torneos
    public BaseDatosGestionarTorneo GetBaseDatosToreno() {
        if (cBaseDatosTorneos == null) {
            this.cBaseDatosTorneos = new BaseDatosGestionarTorneo();
        }
        return this.cBaseDatosTorneos;
    }
    
    //Entrada: Modelo con la informacion de un torneo a agregar
    //Salida: ninguna 
    //Descripcion:delega la actualizacion de un torneo a la clase de base de datos 
    public void ActualizarTorneo(ModeloAgregarTorneo pModelo){
        GetBaseDatosToreno().ActualizarTorneo(pModelo.getIdTorneo(),
                pModelo.getcNombreTorneo(), pModelo.getcNombreSede(),
                pModelo.getNumeroJugadores(),
                pModelo.getcEsSeleccion(),
                pModelo.getcEsCopa());
    }
    //Entrada: ningua
    //Salida: Modelo con la infomracion del catalogo de tornetos
    //Descripcion: Crear un nuevo catalgo con la lista de todos los equipos registrados 
    public ModeloCatalogoTorneo GetModeloCalendarioTorneo(){
        return new ModeloCatalogoTorneo(GetBaseDatosToreno().GetTorneos());
    }
    //Entrada: modelo agregar torneo con la infomracion de un torneo a ser agregado
    //Salida: ninguna
    //Descripcion:Delega creacion de un nuevo torneo
    public void CrearTorneo(ModeloAgregarTorneo pModelo){
        GetBaseDatosToreno().AgregarTorneo(pModelo.getcNombreTorneo(), pModelo.getcNombreSede(),
                pModelo.getNumeroJugadores(),
                pModelo.getcEsSeleccion(),
                pModelo.getcEsCopa());
    }

    //Entrada: identificador de un torneo
    //Salida: Modelo de agregar torneo con la informacion del torneo
    //Descripcion: Delega la accion de crear un nuevo torneo
    public ModeloAgregarTorneo GetModelo(String pIdentificador){
        return GetBaseDatosToreno().GetInformacionTorneo(Integer.parseInt(pIdentificador));
    }
    
}
