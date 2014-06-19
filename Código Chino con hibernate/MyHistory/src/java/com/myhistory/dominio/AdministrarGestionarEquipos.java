/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.dominio;

import com.myhistory.datos.BaseDatosGestionarEquipos;
import com.myhistory.ejetransversal.ModeloAgregarEquipo;
import com.myhistory.ejetransversal.ModeloCatalogoEquipo;

/**
 *
 * @author Ney Rojas
 */
public class AdministrarGestionarEquipos {

    private BaseDatosGestionarEquipos cBaseDatosEquipos = null;

    public BaseDatosGestionarEquipos GetBaseDatosEquipo() {
        if (cBaseDatosEquipos == null) {
            this.cBaseDatosEquipos = new BaseDatosGestionarEquipos();
        }
        return this.cBaseDatosEquipos;
    }

    public void AgregarEquipo(ModeloAgregarEquipo pModeloEquipo) {
        this.GetBaseDatosEquipo().AgregarEquipos(pModeloEquipo);
    }

    public void ActualizarEquipo(ModeloAgregarEquipo pModeloEquipo) {
        this.GetBaseDatosEquipo().ActualizarEquipos(pModeloEquipo);
    }

    public ModeloAgregarEquipo GetModeloInformacionEquipo(int pIdentificador) {
        return this.GetBaseDatosEquipo().GetInformacionEquipo(pIdentificador);
    }

    public ModeloCatalogoEquipo GetModeloCatalogoEquipos() {
        return new ModeloCatalogoEquipo(this.GetBaseDatosEquipo().GetTodosEquipos());
    }

    public ModeloAgregarEquipo GetModeloAgregarEquipoPais(int pIdentificadorPais) {
        return this.GetBaseDatosEquipo().GetInformacionEquipoPais(pIdentificadorPais);
    }
    
    public ModeloAgregarEquipo GetModeloAgregarEquipoPaisPrimero(){
        return new ModeloAgregarEquipo(this.GetBaseDatosEquipo().GetListaPaises());
    }
}
