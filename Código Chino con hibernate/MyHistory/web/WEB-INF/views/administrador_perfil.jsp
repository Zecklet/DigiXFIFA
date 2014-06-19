<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
         pageEncoding="ISO-8859-1"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
        <script src="styles/js/jquery.js" type="text/javascript"></script>
        <script src="styles/js/uikit.js" type="text/javascript"></script>
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
                    <c:choose>
                        <c:when test="${Modelo.cEstado}">
                            <jsp:include page="navegacion.jsp"></jsp:include>
                        </c:when>
                        <c:otherwise>
                            <jsp:include page="navegacion_desactivada.jsp"></jsp:include>
                        </c:otherwise>
                    </c:choose>
                </div>
                <div class="uk-width-8-10">
                    <div class="uk-push-1-10">
                        <h1>${Modelo.cNombre} ${Modelo.cApellido}</h1>
                    </div>
                    <br />
                    <div class="uk-grid">
                        <div class="uk-width-3-10 uk-push-1-10">
                            <label>Correo electrónico</label> <br /> <label>Fecha de
                                nacimiento</label> <br /> <label>Fecha de inscripción</label>
                        </div>
                        <div class="uk-width-5-10 uk-push-1-10">
                            <label>${Modelo.cCorreoElectronico}</label> <br /> <label>${Modelo.cFechaNacimiento}</label>
                            <br /> <label>${Modelo.cFechaInscripcion}</label> <br /> <br />
                            <div class="uk-width-1-3 uk-push-1-3">
                                <c:if test="${Modelo.cEstado}">
                                    <a class="uk-button uk-button-primary uk-text-break"
                                       href="Administrador_Perfil_Editar"><i class="uk-icon-magic">&nbsp;</i>Editar
                                        perfil</a>
                                    </c:if>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>
</html>