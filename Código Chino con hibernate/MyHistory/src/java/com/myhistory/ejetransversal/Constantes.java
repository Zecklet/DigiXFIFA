/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.ejetransversal;

/**
 *
 * @author Ney Rojas
 */
public final class Constantes {
    

    private Constantes() {
        // Se restringe la creacion 
    }

    //codigo que se utiliza al momento de crear usuarios
    public static final int kCogidoAdministrador = 1;

    //Codigo para los distintos errores 
    public static final int kErrorCodigoNoHayError = 0;
    public static final int kErrorCodigoUsuarioExiste = 1;
    public static final int kErrorCodigoUsuarioNoExiste = 2;
    public static final int kErrorCodigoContrasenaIncorrecta = 3;
    public static final int kErrorCodigoLlenarTodosCampos = 4;

    //Mensajes para los errores
    public static final String kErrorMensajeNoHayError = "";
    public static final String kErrorMensajeUsuarioExiste = "El nombre de usuario ingresado ya existe en el sistema.";
    public static final String kErrorMensajeUsuarioNoExiste = "El nombre de usuario no existe.";
    public static final String kErrorMensajeContrasenaIncorrecta = "La contraseña ingresada es incorrecta.";
    public static final String kErrorMensajeLlenarTodosCampos = "Por favor ingrese todos los datos.";

    //Contenedor de mensajes de error
    public static final String[] kContenedorMensajesError = {kErrorMensajeNoHayError, kErrorMensajeUsuarioExiste,
        kErrorMensajeUsuarioNoExiste, kErrorMensajeContrasenaIncorrecta,kErrorMensajeLlenarTodosCampos};

    //Queries para la base de datos 
    public static final String kQueryConsultarCuentNombreUsuario = "from Cuenta s where s.nombreUsuario = :NombreUsuario";
    public static final String kQueryConsultarCuentIdentificador = "from Cuenta s where s.pkCuenta = :Identificador";
    public static final String kQueryConsultarAdministradorIdentificador = "from Administrador s where s.pkFkCuenta = :Identificador";

    //Variables de los parametros 
    
    public static final String kQueryVariableNombreUsuario="NombreUsuario";
    public static final String kQueryVariableIdentificador="Identificador";    
}
