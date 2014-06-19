<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
         pageEncoding="ISO-8859-1"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>

    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
        <script src="styles/js/jquery.js" type="text/javascript"></script>
        <script src="styles/js/uikit.js" type="text/javascript"></script>
        <link href="styles/uikit.almost-flat.css" rel="stylesheet" type="text/css">
        <script type="text/javascript" src="styles/js/GestionarUsuarios.js" charset="UTF-8"></script>

        <link rel="stylesheet" type="text/css" href="styles/jquery.datetimepicker.css" />
        <script type="text/javascript" src="styles/js/jquery.datetimepicker.js"></script>
        <script type="text/javascript" src="styles/js/calendario.js"></script>

        <title>MyHistory</title>
    </head>
    <body>
        <div class="uk-width-9-10 uk-height-1-1 uk-container-center">
            <c:set var="EstoyEditar" value="${Nombre != ''}"/>
            <c:if test="${EstoyEditar}">
                <div class="uk-grid">
                    <br />
                    <jsp:include page="barra.jsp"/>
                </div>
                <hr class="uk-grid-divider" />
            </c:if>
            <div class="uk-grid uk-container-center">
                <c:choose>

                    <c:when test="${EstoyEditar}">
                        <div class="uk-width-2-10">
                            <jsp:include page="navegacion.jsp"/>
                        </div>
                        <div class="uk-width-1-6 uk-push-1-6 ">
                            <c:set var="MetodoForm" value="Administrador_Perfil_Guardar"/>
                            <c:set var="hrefCancelar" value="Administrador_Perfil"/>
                            <c:set var="Titulo" value="Editar Perfil"/>
                        </c:when>
                        <c:otherwise>
                            <div class="uk-width-1-3 uk-push-1-3">
                                <c:set var="MetodoForm" value="Administrador_Registro_Nuevo"/>
                                <c:set var="hrefCancelar" value="Inicio"/>
                                <c:set var="Titulo" value="Registrar Administrador"/>
                            </c:otherwise>
                        </c:choose>
                        <div class="uk-push-1-7">
                            <br />
                            <h1>${Titulo}</h1>
                            <br />
                        </div>
                        <!--<form class="uk-form uk-form-horizontal" method="post" 
                              modelAttribute="Administrador" commandName="Administrador"
                              action="Administrador_Registro_Nuevo">
                        -->
                        <div class="uk-grid uk-push-1-5">    
                            <form:form name= "frRegistro" id = "frRegistro" class="uk-form uk-form-horizontal" method='post' action='${MetodoForm}' commandName='Modelo'>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Nombre de usuario</label>
                                    <div class="uk-form-controls">
                                        <form:input class="uk-form-width-medium" type="text" path="cNombreUsuario"
                                                    value="${Modelo.cNombreUsuario}" />
                                    </div>
                                </div>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Contraseña</label>
                                    <div class="uk-form-controls">
                                        <form:input class="uk-form-width-medium" type="password" path="cContrasena"
                                                    value="${Modelo.cContrasena}" />
                                    </div>
                                </div>
                                <h3>Información personal</h3>
                                <div>
                                    <div class="uk-form-row">
                                        <label class="uk-form-label">Nombre</label>
                                        <div class="uk-form-controls">
                                            <form:input class="uk-form-width-medium" type="text" path="cNombre"
                                                        value="${Modelo.cNombre}" />
                                        </div>
                                    </div>
                                    <div class="uk-form-row">
                                        <label class="uk-form-label">Apellido</label>
                                        <div class="uk-form-controls">
                                            <form:input class="uk-form-width-medium" type="text" path="cApellido"
                                                        value="${Modelo.cApellido}" />
                                        </div>
                                    </div>
                                    <div class="uk-form-row">
                                        <label class="uk-form-label">Correo electrónico</label>
                                        <div class="uk-form-controls">
                                            <form:input class="uk-form-width-medium" type="text" path="cCorreoElectronico"
                                                        value="${Modelo.cCorreoElectronico}" />
                                        </div>
                                    </div>
                                    <div class="uk-form-row">
                                        <label class="uk-form-label">Fecha de nacimiento</label>
                                        <div class="uk-form-controls">
                                            <form:input id ="datetimepicker_mask" class="uk-form-width-medium"  type="text" path="cFechaNacimiento"
                                                        value="${Modelo.cFechaNacimiento}" />
                                        </div>
                                    </div>
                                </div>
                                <div class="uk-form-horizontal">
                                    <br />
                                    <c:if test="${EstoyEditar}"> 
                                        <input type = "button" class="uk-button uk-button-primary uk-align-right" onclick="DesactivarUsuario('Administrador_Desactivar', 'frRegistro');" value = "Darse de Baja">
                                    </c:if>
                                        <jsp:include page="mostrar_error.jsp"/>
                                    <div class="uk-grid">
                                        <a class="uk-button uk-button-primary uk-align-right" href="${hrefCancelar}"><i class="uk-icon-times"></i>Cancelar</a> 
                                        <form:button class="uk-button uk-button-primary uk-align-right" >
                                            <i class="uk-icon-check" type="submit" ></i>Hecho</form:button>&nbsp;
                                        </div>
                                    </div>
                            </form:form>
                        </div>
                    </div>
                </div>
            </div>
            <br />
    </body>
</html>