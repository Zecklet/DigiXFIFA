<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
         pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
        <script src="styles/js/jquery.js" type="text/javascript"></script>
        <script src="styles/js/uikit.js" type="text/javascript"></script>
        <link href="styles/uikit.almost-flat.css" rel="stylesheet" type="text/css"/>
        <title>MyHistory</title>
    </head>
    <body class="uk-height-1-1">
        <div class="uk-width-1-3 uk-push-1-3">
            <br />
            <h1>Administrador</h1>
            <br />
            <form class="uk-form uk-form-horizontal" method="post" 
                  modelAttribute="Administrador" commandName="Administrador"
                  action="Administrador_Registro_Nuevo">
                <div class="uk-form-row">
                    <label class="uk-form-label">Nombre de usuario</label>
                    <div class="uk-form-controls">
                        <input class="uk-form-width-medium" type="text" name="cNombreUsuario"
                               path="cNombre" value="${Modelo.cNombre}" />
                    </div>
                </div>
                <div class="uk-form-row">
                    <label class="uk-form-label">Contraseña</label>
                    <div class="uk-form-controls">
                        <input class="uk-form-width-medium" type="password" name="cContrasena"
                               value="${Modelo.cContrasena}" />
                    </div>
                </div>
                <h3>Información personal</h3>
                <div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Nombre</label>
                        <div class="uk-form-controls">
                            <input class="uk-form-width-medium" type="text" name="cNombre"
                                   value="${Modelo.cNombre}" />
                            <input type="ex">
                        </div>
                        
                    </div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Apellido</label>
                        <div class="uk-form-controls">
                            
                            <input class="uk-form-width-medium" type="text" name="cApellido"
                                   value="${Modelo.cApellido}" />
                        </div>
                    </div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Correo electrónico</label>
                        <div class="uk-form-controls">
                            <input class="uk-form-width-medium" type="text" name="cCorreoElectronico"
                                   value="${Modelo.cCorreoElectronico}" />
                        </div>
                    </div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Fecha de nacimiento</label>
                        <div class="uk-form-controls">
                            <input class="uk-form-width-medium" type="date" name="cFechaNacimiento"
                                   value="${Modelo.cFechaNacimiento}" />
                        </div>
                    </div>
                </div>
                <div class="uk-form-horizontal">
                    <br />
                    <div class="uk-grid">
                        <a class="uk-button uk-button-primary uk-align-right" href="Inicio"><i
                                class="uk-icon-times"></i>Cancelar</a> 
                        <button class="uk-button uk-button-primary uk-align-right" >
                            <i class="uk-icon-check" type="submit" >
                            </i>Hecho</button>&nbsp;
                            
                    </div>
                </div>
            </form>
        </div>
        <br />
    </body>
</html>