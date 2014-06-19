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
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ContenedorError;
import com.myhistory.ejetransversal.ModeloAdministrador;
import com.myhistory.ejetransversal.ModeloUsuario;
import com.myhistory.presentacion.PresentadorGestionarUsuarios;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpSession;
import org.springframework.context.annotation.Scope;
//import javax.validation.Valid;
//import javax.validation.Valid;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.validation.BindingResult;
import org.springframework.validation.annotation.Validated;
import org.springframework.validation.Validator;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.SessionAttributes;

@Controller
@SessionAttributes({"Nombre", "Presentador"})
public class GestionarUsuarioController {

    PresentadorGestionarUsuarios cPresentador;

    public GestionarUsuarioController() {
        cPresentador = new PresentadorGestionarUsuarios();
    }

    public void ColocarPresentador(HttpSession pSession) {
        this.cPresentador = (PresentadorGestionarUsuarios) pSession.getAttribute("Presentador");
    }

    @ModelAttribute("Presentador")
    public PresentadorGestionarUsuarios getPresentador() {
        if (cPresentador == null) {
            this.cPresentador = new PresentadorGestionarUsuarios();
        }
        return cPresentador;
    }

    @ModelAttribute("Modelo")
    public ModeloUsuario getModeloAdministrador() {
        return cPresentador.GetModeloUsuario(Constantes.kCogidoAdministrador);
    }

    @RequestMapping(value = "/Inicio")
    public String Inicio(ModelMap pModeloMapa) {
        ModeloAdministrador Modelo = (ModeloAdministrador) getModeloAdministrador();
        pModeloMapa.addAttribute("Modelo", Modelo);
        pModeloMapa.addAttribute("Nombre", "");
        return "inicio";
    }

    @RequestMapping(value = "/Administrador_Registro", method = RequestMethod.GET)
    public String RegistrarAdmin(ModelMap pModeloMapa) {
        pModeloMapa.addAttribute("Nombre", "");
        ModeloAdministrador Modelo = (ModeloAdministrador) getModeloAdministrador();
        pModeloMapa.addAttribute("Modelo", Modelo); //se le envia el modelo a la vista
        return "administrador_registro";
    }

    //Descripcion: Lo que hace es el controlodor de agregar un nuevo usuario
    @RequestMapping(value = "/Administrador_Registro_Nuevo", method = RequestMethod.POST)
    public String RegistrarAdminNuevo(@ModelAttribute("Modelo") ModeloAdministrador pModeloUsuario,
            ModelMap pModeloMapa) {
        String mSalida = "administrador_registro"; //si no hay ningun problema en la inserción vuelve al inicio
        ContenedorError mResultadoCreacion = getPresentador().CrearUsuario(pModeloUsuario); //se inteta crear un nuevo usuario
        if (mResultadoCreacion.iscHayError()) { //se pregunta si existe algun error en la creacion
            pModeloMapa.addAttribute("Error", mResultadoCreacion); //cuando hay un error lo envia a la vista
        } else {
            mSalida = "redirect:Inicio"; //si no hubieron errores al momento de agregar un nuevo usuario, pasa a la pagina de inicio
        }
        return mSalida; //retorna la salida de la pagina a la cual tiene que ir
    }

    //Controlador encargado de iniciar sesion en el sistema 
    @RequestMapping(value = "/Iniciar_Sesion", method = RequestMethod.POST)
    public String Iniciar_Sesion(@ModelAttribute("Modelo") ModeloAdministrador pModelo,
            BindingResult pResultado, ModelMap pModeloMapa) {
        ContenedorError mResultado = this.cPresentador.IniciarSesion(pModelo.getcNombreUsuario(),
                pModelo.getcContrasena()); //realiza el intento de iniciar sesion 
        if (mResultado.iscHayError()) { //comprueba de que no haya error 
            pModelo.setcContrasena(""); // se reinicia el valor de la contrasena
            pModeloMapa.addAttribute("Modelo", pModelo); //se le envia de nuevo el modelo ingresado
            pModeloMapa.addAttribute("Error", mResultado); //se le envia el error a la vista
            return "inicio"; //se devuelve al inicio
        }
        pModeloMapa.addAttribute("Presentador", this.cPresentador); //agrega el presentador al session
        return "redirect:Administrador_Perfil"; //ingresa a la pagina de perfiles
    }

    @RequestMapping(value = "/Administrador_Perfil", method = RequestMethod.GET)
    public String Administrador_Perfil(ModelMap pModeloMapa) {
        ModeloUsuario mModelo = this.cPresentador.RecuperarModeloCompleto();
        pModeloMapa.addAttribute("Nombre", mModelo.getcNombre());
        pModeloMapa.addAttribute("Modelo", mModelo);
        return "administrador_perfil";
    }

    @RequestMapping(value = "/Administrador_Perfil_Editar", method = RequestMethod.GET)
    public String Administrador_Perfil_Editar(ModelMap pModeloMapa) {
        pModeloMapa.addAttribute("Modelo", this.cPresentador.RecuperarModeloCompleto());
        return "administrador_registro";
    }

    @RequestMapping(value = "/Administrador_Perfil_Guardar", method = RequestMethod.POST)
    public String Administrador_Perfil_Guardar(@ModelAttribute("Modelo") ModeloAdministrador pModeloUsuario,
            BindingResult pResultado, HttpSession pSession) {

        ContenedorError mResultadoCreacion = cPresentador.ActualizarUsuario(pModeloUsuario);
        if (mResultadoCreacion.iscHayError()) {
            return "administrador_registro";
        } else {
            return "redirect:Administrador_Perfil";
        }
    }

    @RequestMapping(value = "/Administrador_Desactivar", method = RequestMethod.POST)
    public String Administrador_Desactivar() {
        cPresentador.DesactivarUsuario();
        return "redirect:Inicio";
    }

    @RequestMapping(value = "/Administrador_Activar", method = RequestMethod.POST)
    public String Administrador_Activar() {
        cPresentador.ActivarUsuario();
        return "redirect:Administrador_Perfil";
    }

}
