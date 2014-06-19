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

    public PresentadorGestionarEquipo GetPresentador() {
        if (this.cPresentador == null) {
            this.cPresentador = new PresentadorGestionarEquipo();
        }
        return this.cPresentador;
    }

    @RequestMapping(value = "/Equipo_Catalogo", method = RequestMethod.GET)
    public String VerCatalogoCatalogoEquipos(ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloCalendarioEquipos());
        return "equipo_catalogo";
    }

    @RequestMapping(value = "/Agregar_Equipos", method = RequestMethod.GET)
    public String VerAgregarEquipos(ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloAgregarEquipo());
        return "equipo";
    }

    @RequestMapping(value = "/Editar_Equipo", method = RequestMethod.GET)
    public String EditarEquipo(@ModelAttribute("Modelo") ModeloCatalogoEquipo pModeloEquipo, ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloEquipo(pModeloEquipo.getIdEquipo()));
        return "equipo";
    }

    @RequestMapping(value = "/Agregar_Nuevo_Equipo", method = RequestMethod.POST)
    public String AgregarNuevoEquipos(@ModelAttribute("Modelo") ModeloAgregarEquipo pModeloNuevo, ModelMap pMapaModelo) {
        ContenedorError mSalida = GetPresentador().AgregarEquipo(pModeloNuevo);
        if (mSalida.iscHayError()) {
            pMapaModelo.addAttribute("Modelo", pModeloNuevo);
            pMapaModelo.addAttribute("Error", mSalida);
            return "equipo";
        }
        return "redirect:Equipo_Catalogo";
    }

    @RequestMapping(value = "/Guardar_Datos_Equipo", method = RequestMethod.POST)
    public String GuardarEquipo(@ModelAttribute("Modelo") ModeloAgregarEquipo pModeloNuevo, ModelMap pMapaModelo) {
        ContenedorError mSalida = GetPresentador().ActualizarEquipo(pModeloNuevo);
        if (mSalida.iscHayError()) {
            pMapaModelo.addAttribute("Modelo", pModeloNuevo);
            pMapaModelo.addAttribute("Error", mSalida);
            return "equipo";
        }
        return "redirect:Equipo_Catalogo";
    }
}
