/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.gui;

/**
 *
 * @author Jorge
 */
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloAgregarEquipo;
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import com.myhistory.ejetransversal.ModeloCatalogoEquipo;
import com.myhistory.ejetransversal.ModeloCatalogoTorneo;
import com.myhistory.presentacion.PresentadorGestionarEquipo;
import com.myhistory.presentacion.PresentadorGestionarTorneo;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.SessionAttributes;

@Controller
@SessionAttributes("Nombre")
public class GestionarEquiposController {

    PresentadorGestionarEquipo cPresentador;

    public GestionarEquiposController() {

    }

    //Entrada: ningua
    //Salida: Presentador de gestinar equipos
    //Descripcion: Instanciacion perezosa del presentador de gestionar equipo
    public PresentadorGestionarEquipo GetPresentador() {
        if (this.cPresentador == null) {
            this.cPresentador = new PresentadorGestionarEquipo();
        }
        return this.cPresentador;
    }

    //Salida: String con la siguiente vista
    //Descripcion: Controlador que muestra la vista donde estan todos los equipos registrados de my history
    @RequestMapping(value = "/Equipo_Catalogo", method = RequestMethod.GET)
    public String VerCatalogoCatalogoEquipos(ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloCalendarioEquipos());
        return "equipo_catalogo";
    }

    //Salida: String con la siguiente vista
    //Descripcion: Controlador que muestra la vista de agregar un nuevo equipo
    @RequestMapping(value = "/Agregar_Equipos", method = RequestMethod.GET)
    public String VerAgregarEquipos(ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloAgregarEquipo());
        return "equipo";
    }

    //Salida: String con la siguiente vista
    //Descripcion: Controlador que muestra la vista de editar un equipo seleccionado
    @RequestMapping(value = "/Editar_Equipo", method = RequestMethod.GET)
    public String EditarEquipo(@ModelAttribute("Modelo") ModeloCatalogoEquipo pModeloEquipo, ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloEquipo(pModeloEquipo.getIdEquipo()));
        return "equipo";
    }

    //Salida: String con la siguiente vista
    //Descripcion: Controlador que toma el modelo de agregar nuevo equipo y le solicita al presentador que cree el equipo
    @RequestMapping(value = "/Agregar_Nuevo_Equipo", method = RequestMethod.POST)
    public String AgregarNuevoEquipos(@ModelAttribute("Modelo") ModeloAgregarEquipo pModeloNuevo, ModelMap pMapaModelo) {
        ContenedorError mSalida = GetPresentador().AgregarEquipo(pModeloNuevo);
        if (mSalida.iscHayError()) {
            pMapaModelo.addAttribute("Modelo", GetPresentador().SetPaises(pModeloNuevo));
            pMapaModelo.addAttribute("Error", mSalida);
            return "equipo";
        }
        return "redirect:Equipo_Catalogo";
    }
    //Salida: String con la siguiente vista
    //Descripcion: Controlador que toma el modelo de agregar equipos que envia la vista y le solicita al presentador que actualice el equipo
    @RequestMapping(value = "/Guardar_Datos_Equipo", method = RequestMethod.POST)
    public String GuardarEquipo(@ModelAttribute("Modelo") ModeloAgregarEquipo pModeloNuevo, ModelMap pMapaModelo) {
        ContenedorError mSalida = GetPresentador().ActualizarEquipo(pModeloNuevo);
        if (mSalida.iscHayError()) {
            pMapaModelo.addAttribute("Modelo", GetPresentador().SetPaises(pModeloNuevo));
            pMapaModelo.addAttribute("Error", mSalida);
            return "equipo";
        }
        return "redirect:Equipo_Catalogo";
    }
}
