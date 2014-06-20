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

    //Entrada: ningua
    //Salida: Base datos gestionar equipos con la conexion a la clase que se comunica con la base de datos para admnistrar los datos del equipo x
    //Descripcion:inicializacion perezosa del objeto que conecta con la base de datos para los equipos
    public BaseDatosGestionarEquipos GetBaseDatosEquipo() {
        if (cBaseDatosEquipos == null) {
            this.cBaseDatosEquipos = new BaseDatosGestionarEquipos();
        }
        return this.cBaseDatosEquipos;
    }

    //Entrada: modelo con la informacion de una equipo
    //Salida: ninguna
    //Descripcion: delega la accion de agregar un nuevo equipo
    public void AgregarEquipo(ModeloAgregarEquipo pModeloEquipo) {
        this.GetBaseDatosEquipo().AgregarEquipos(pModeloEquipo);
    }

    //Entrada: modelo con la informacion de una equipo
    //Salida: ninguna
    //Descripcion: delega la accion de actualizar un equipo
    public void ActualizarEquipo(ModeloAgregarEquipo pModeloEquipo) {
        this.GetBaseDatosEquipo().ActualizarEquipos(pModeloEquipo);
    }

    //Entrada: pIdentificador del equipo
    //Salida: ModeloAgregarEquipo
    //Descripcion: delega la accion de obtener la infomacion de un equipo usando su identificador
    public ModeloAgregarEquipo GetModeloInformacionEquipo(int pIdentificador) {
        return this.GetBaseDatosEquipo().GetInformacionEquipo(pIdentificador);
    }
    
    //Entrada: ninguna
    //Salida: ModeloCatalgo de equipos con la informacion de todos los equipos
    //Descripcion: crea un catalgo de equipos con la informacion de todos los eequipos
    public ModeloCatalogoEquipo GetModeloCatalogoEquipos() {
        return new ModeloCatalogoEquipo(this.GetBaseDatosEquipo().GetTodosEquipos());
    }
    //Entrada: ninguna
    //Salida: ModeloCatalgo de equipos con la informacion de todos los equipos
    //Descripcion: crea un catalgo de equipos con la informacion de todos los eequipos
    public ModeloAgregarEquipo GetModeloAgregarEquipo() {
        return SetPaises(new ModeloAgregarEquipo());
    }
    
    //Entrada: Modeloagregarequipo con la informacion de un equipo
    //Salida: mismo modelo pero con los paises seteador
    //Descripcion: coloca la lista de paises a un modelo de agregar equipos de entrada
    public ModeloAgregarEquipo SetPaises(ModeloAgregarEquipo pModelo) {
        ModeloAgregarEquipo mModeloResultado = pModelo;
        mModeloResultado.setcListaPaises(GetBaseDatosEquipo().GetListaPaises());
        return mModeloResultado;
    }
}
