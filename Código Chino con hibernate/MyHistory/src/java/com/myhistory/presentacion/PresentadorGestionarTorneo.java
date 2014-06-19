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

    public ModeloAgregarTorneo GetModeloAgregarTorneo() {
        return new ModeloAgregarTorneo();
    }

    public ContenedorError AgregarTorneo(ModeloAgregarTorneo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
            this.cAdministrarTorneos.CrearTorneo(pModelo);
        }
        return mSalida;
    }

    public ModeloCatalogoTorneo GetModeloCalendarioTorneo() {
        return this.cAdministrarTorneos.GetModeloCalendarioTorneo();
    }

    public ModeloAgregarTorneo GetModeloTorneo(String pIdentificador) {
        return this.cAdministrarTorneos.GetModelo(pIdentificador);
    }

    public ContenedorError ActualizarTorneo(ModeloAgregarTorneo pModelo) {
        ContenedorError mSalida = ComprobadorModelos.getInstance().ComprobarModelo(pModelo);
        if (!mSalida.iscHayError()) {
            mSalida = new ContenedorError(Constantes.kErrorCodigoNoHayError);
            this.cAdministrarTorneos.ActualizarTorneo(pModelo);
        }
        return mSalida;
    }

}
