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

import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class HomeController {
    
    @RequestMapping(value="/")
    public String Index(ModelMap pMap){
        return "redirect:Inicio";
    }
   
    @RequestMapping(value = "/Estadisticas")
    public String CargarEstadisticas(ModelMap model) {
        return "estadisticas";
    }
    
    @RequestMapping(value = "/Jugador_Edicion")
    public String EditarJugador(ModelMap model) {
        return "jugador_edicion";
    }
    
    @RequestMapping(value = "/Jugador_Gestion")
    public String GestionarJugador(ModelMap model) {
        return "jugador_gestion";
    }
    
    @RequestMapping(value = "/Jugador_Perfil")
    public String VerPerfilJugador(ModelMap model) {
        return "jugador_perfil";
    }
    
    @RequestMapping(value = "/Partido_Registro")
    public String RegistrarPartido(ModelMap model) {
        return "partido_registro";
    }
   
    
}
