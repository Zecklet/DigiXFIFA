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
import com.myhistory.ejetransversal.ModeloAdministrador;
import javax.validation.Valid;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

@Controller
public class GestionarUsuarioController {

    @RequestMapping(value = "/Administrador_Registro", method = RequestMethod.GET)
    public String RegistrarAdmin(ModelMap model) {
        ModeloAdministrador Modelo = new ModeloAdministrador();
        Modelo.setcNombre("HOLA");
        model.addAttribute("Modelo", Modelo);
        return "administrador_registro";
    }

    @RequestMapping(value = "/Administrador_Registro_Nuevo", method = RequestMethod.POST)

    public String RegistrarAdminNuevo(@Valid ModeloAdministrador pModeloUsuario,
            BindingResult errors, ModelMap model) {
        if (errors.hasErrors()) {
            model.addAttribute("Modelo", pModeloUsuario);
            return "administrador_registro";
        }
        else{
            return  "redirect:Inicio";
        }

        
    }
}
