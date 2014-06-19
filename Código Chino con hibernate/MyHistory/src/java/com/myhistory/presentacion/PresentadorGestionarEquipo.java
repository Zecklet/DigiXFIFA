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

    public PresentadorGestionarEquipo() {
        cAdministrarEquipos = new AdministrarGestionarEquipos();
    }

    public ModeloAgregarEquipo GetModeloAgregarEquipo() {
        return cAdministrarEquipos.GetModeloAgregarEquipoPaisPrimero();
    }

    public ModeloAgregarEquipo GetModeloAgregarEquipoPais(int pIdentificador) {
        return cAdministrarEquipos.GetModeloAgregarEquipoPais(pIdentificador);
    }

    public ContenedorError AgregarEquipo(ModeloAgregarEquipo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
             this.cAdministrarEquipos.AgregarEquipo(pModelo);
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        }
        return mSalida;       
    }

    public ModeloCatalogoEquipo GetModeloCalendarioEquipos() {
        return this.cAdministrarEquipos.GetModeloCatalogoEquipos();
    }

    public ModeloAgregarEquipo GetModeloEquipo(int pIdentificador) {
        return this.cAdministrarEquipos.GetModeloInformacionEquipo(pIdentificador);
    }

    public ContenedorError ActualizarEquipo(ModeloAgregarEquipo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
            this.cAdministrarEquipos.ActualizarEquipo(pModelo);
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
        }
        return mSalida;
    }
}
