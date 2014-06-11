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
                    <div class="uk-push-1-10">
                        <h1>Equipo</h1>
                        <form class="uk-form uk-form-horizontal" action="#" method="post">
                            <div class="uk-form-row">
                                <label class="uk-form-label">Nombre del equipo</label>
                                <div class="uk-form-controls">
                                    <input class="uk-form-width-medium" type="text" name="name"
                                           value=" " />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Nombre dek país</label>
                                <div class="uk-form-controls">
                                    <input class="uk-form-width-medium" type="text" name="name"
                                           value=" " />
                                </div>
                            </div>
                            <h3>Tipo de equipo</h3>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Es una selección</label>
                                <div class="uk-form-controls">
                                    <input type="checkbox" name="name" value=" " />
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="uk-align-right">
                        <a href="#" class="uk-button uk-button-primary"> <i
                                class="uk-icon-check"></i>Hecho
                        </a> &nbsp; <a href="Equipo_Catalogo" class="uk-button uk-button-primary"> <i
                                class="uk-icon-times"></i>Cancelar
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </body>
</html>