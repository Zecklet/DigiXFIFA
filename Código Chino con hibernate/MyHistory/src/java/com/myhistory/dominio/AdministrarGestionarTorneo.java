/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.myhistory.dominio;

import com.myhistory.datos.BaseDatosGestionarTorneo;
import com.myhistory.datos.tablas.Torneo;
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import com.myhistory.ejetransversal.ModeloCatalogoTorneo;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Ney Rojas
 */
public class AdministrarGestionarTorneo {
    
    private BaseDatosGestionarTorneo CrearConexionBaseDatos(){
        return new BaseDatosGestionarTorneo();
    }
    
    //Funcion que se encarga de crear un modelo con los datos de una torneo apartir de sus datos en la tabla de la base de datos
    private ModeloAgregarTorneo CrearModeloTorneo(Torneo pTablaTorneo){
        return  new ModeloAgregarTorneo(pTablaTorneo.getNombre(),
                    pTablaTorneo.getNombreSede(), ""+pTablaTorneo.getCantidadJugadores(),
                    pTablaTorneo.isDeSeleccion(), pTablaTorneo.isDeCopa(),pTablaTorneo.getPkTorneo()+"");
    }
    
    public void ActualizarTorneo(ModeloAgregarTorneo pModelo){
        BaseDatosGestionarTorneo mConexion = CrearConexionBaseDatos();
        mConexion.ActualizarTorneo(Integer.parseInt(pModelo.getcIdentificador()),
                pModelo.getcNombreTorneo(), pModelo.getcNombreSede(),
                Integer.parseInt(pModelo.getcCantidadJugadores()),
                pModelo.getcEsSeleccion(),
                pModelo.getcEsCopa());
    }
    
    public ModeloCatalogoTorneo GetModeloCalendarioTorneo(){
        BaseDatosGestionarTorneo mConexionBaseDatos = CrearConexionBaseDatos();
        List<Torneo> mResultado = mConexionBaseDatos.GetTorneos();
        List<ModeloAgregarTorneo> mListaModelos = new ArrayList<ModeloAgregarTorneo>();
        ModeloAgregarTorneo mModelo;
        for(int i=0; i< mResultado.size(); i++){
            Torneo mTemporal = mResultado.get(i);
            mModelo = CrearModeloTorneo(mTemporal);
            mListaModelos.add(mModelo);
        }
        return new ModeloCatalogoTorneo(mListaModelos);
    }
    
    public void CrearTorneo(ModeloAgregarTorneo pModelo){
        BaseDatosGestionarTorneo mConexion = CrearConexionBaseDatos();
        mConexion.AgregarTorneo(pModelo.getcNombreTorneo(), pModelo.getcNombreSede(),
                Integer.parseInt(pModelo.getcCantidadJugadores()),
                pModelo.getcEsSeleccion(),
                pModelo.getcEsCopa());
    }
    
    public ModeloAgregarTorneo GetModelo(String pIdentificador){
        BaseDatosGestionarTorneo mConexion = new BaseDatosGestionarTorneo();
        return CrearModeloTorneo(mConexion.GetTorneo(Integer.parseInt(pIdentificador)));
    }
    
}
