<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
         pageEncoding="ISO-8859-1"%>
<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
        <script src="styles/js/jquery.js" type="text/javascript"></script>
        <script src="styles/js/uikit.js" type="text/javascript"></script>
        <script src="styles/js/ModificarForm.js" type="text/javascript"></script>
        <link href="styles/uikit.almost-flat.css" rel="stylesheet" type="text/css"/>
        <title>MyHistory</title>
    </head>
    <body>
        <div class="uk-width-9-10 uk-height-1-1 uk-container-center">
            <div class="uk-grid">
                <br />
                <jsp:include page="barra.jsp"></jsp:include>
                </div>
                <hr class="uk-grid-divider" />
                <div class="uk-grid uk-container-center">
                    <div class="uk-width-2-10">
                    <jsp:include page="navegacion.jsp"></jsp:include>
                    </div>
                    <div class="uk-width-8-10">
                    <c:choose>
                        <c:when test="${Modelo.cIdentificador.isEmpty()}">
                            <c:set var="mAccionForm" value="Agregar_Nuevo_Equipo"/>
                            <c:set var="mNombreBoton" value="Agregar"/>
                        </c:when>
                        <c:otherwise>
                            <c:set var="mAccionForm" value="Guardar_Datos_Equipo"/>
                            <c:set var="mNombreBoton" value="Guardar"/>
                        </c:otherwise>
                    </c:choose>
                    <form:form id="frAgregarEquipo" class="uk-form uk-form-horizontal" commandName='Modelo' action="${mAccionForm}" method="post">
                        <div class="uk-push-1-10">
                            <h1>Equipo</h1>

                            <div class="uk-form-row">
                                <label class="uk-form-label">Nombre del equipo</label>
                                <div class="uk-form-controls">
                                    <form:input class="uk-form-width-medium" path="cNombreEquipo"
                                                />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Nombre del país</label>
                                <div class="uk-form-controls">
                                    <form:select class="uk-form-width-medium" path="cIdentificadorPais">
                                        <c:forEach items="${Modelo.cListaPaises}" var = "Pais" >
                                            <c:choose>
                                                <c:when test="${Modelo.cIdentificadorPais!=Pais.cIdentificador}">
                                                    <form:option value="${Pais.cIdentificador}" label="${Pais.cNombrePais}"/>
                                                </c:when>
                                                <c:otherwise>
                                                    <form:option value="${Pais.cIdentificador}" label="${Pais.cNombrePais}" selected="selected"/>
                                                </c:otherwise>
                                            </c:choose>                                            
                                        </c:forEach>
                                    </form:select>
                                    <form:hidden path="cIdentificador"/>
                                </div>
                            </div>
                            <h3>Tipo de equipo</h3>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Es una selección</label>
                                <div class="uk-form-controls">
                                    <form:checkbox class="uk-form-width-medium" path ="cEsSeleccion" />
                                </div>
                            </div>
                            <jsp:include page="mostrar_error.jsp"/>
                        </div>
                        <div class="uk-align-right">
                            <button class="uk-button uk-button-primary"> <i
                                    type = "submit" class="uk-icon-check"></i>${mNombreBoton}
                            </button> &nbsp; <a href="Equipo_Catalogo" class="uk-button uk-button-primary"> <i
                                    class="uk-icon-times"></i>Cancelar
                            </a>
                        </div>
                    </form:form>
                </div>
            </div>
        </div>
    </body>
</html>