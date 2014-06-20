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
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import com.myhistory.ejetransversal.ModeloCatalogoTorneo;
import com.myhistory.presentacion.PresentadorGestionarTorneo;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.SessionAttributes;

@Controller
@SessionAttributes("Nombre")
public class GestionarTorneoController {

    PresentadorGestionarTorneo cPresentador;


    //Entrada: ningua
    //Salida: PresentadorGestionarTorneo
    //Descripcion: Instanciacion perezosa del presentador de gestionar torneos
    public PresentadorGestionarTorneo GetPresentador() {
        if (this.cPresentador == null) {
            this.cPresentador = new PresentadorGestionarTorneo();
        }
        return this.cPresentador;
    }
    
    //Salida: String con la siguiente vista
    //Descripcion: Controlador que muestra todos los torneos registrados en myhistory
    @RequestMapping(value = "/Torneo_Catalogo", method = RequestMethod.GET)
    public String TorneoCatalogo(ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloCalendarioTorneo());
        return "torneo_catalogo";
    }
    //Salida: String con la siguiente vista
    //Descripcion: Controlador que muestra la vista de agregar torneos
    @RequestMapping(value = "/Agregar_Torneo", method = RequestMethod.GET)
    public String AgregarPaginaTorneo(ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloAgregarTorneo());
        return "torneo";
    }
    //Salida: String con la siguiente vista
    //Descripcion: Controlador que toma los datos del modelo de la vista y le solicita al presentador que cree un torneo
    @RequestMapping(value = "/Agregar_Torneo_Nuevo", method = RequestMethod.POST)
    public String AgregarNuevoTorneo(@ModelAttribute("Modelo") ModeloAgregarTorneo pModeloNuevo,
            ModelMap pMapaModelo) {
        ContenedorError mSalida = GetPresentador().AgregarTorneo(pModeloNuevo);
        if (mSalida.iscHayError()) {
            pMapaModelo.addAttribute("Modelo", pModeloNuevo);
            pMapaModelo.addAttribute("Error", mSalida);
            return "torneo";
        }
        return "redirect:Torneo_Catalogo";
    }
    //Salida: String con la siguiente vista
    //Descripcion: Controlador que muestra la vista para editar un equipo con los datos ya guardados en la base de datos
    @RequestMapping(value = "/Editar_Torneo", method = RequestMethod.GET)
    public String EditarPaginaTorneo(@ModelAttribute("Modelo") ModeloCatalogoTorneo pModeloCalendario,
            ModelMap pMapaModelo) {
        pMapaModelo.addAttribute("Modelo", GetPresentador().GetModeloTorneo(
                pModeloCalendario.getcTorneoSeleccionado()));
        return "torneo";
    }
    //Salida: String con la siguiente vista
    //Descripcion: Controlador que toma los datos del modelo de agregar equipo y le solicita al presentador que actualice los datos
    @RequestMapping(value = "/Editar_Torneo_Guardar", method = RequestMethod.POST)
    public String EditarPaginaTorneo(@ModelAttribute("Modelo") ModeloAgregarTorneo pModelo,
            ModelMap pMapaModelo) {
        ContenedorError mSalida = GetPresentador().ActualizarTorneo(pModelo);
        if (mSalida.iscHayError()) {
            pMapaModelo.addAttribute("Modelo", pModelo);
            pMapaModelo.addAttribute("Error", mSalida);
            return "torneo";
        }
        return "redirect:Torneo_Catalogo";
    }
}
