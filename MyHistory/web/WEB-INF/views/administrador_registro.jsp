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
            <form class="uk-form uk-form-horizontal" id="form1" method="get"
                  action="#">
                <div class="uk-form-row">
                    <label class="uk-form-label">Nombre de usuario</label>
                    <div class="uk-form-controls">
                        <input class="uk-form-width-medium" type="text" name="name"
                               value=" " />
                    </div>
                </div>
                <div class="uk-form-row">
                    <label class="uk-form-label">Contraseña</label>
                    <div class="uk-form-controls">
                        <input class="uk-form-width-medium" type="password" name="name"
                               value="" />
                    </div>
                </div>
                <h3>Información personal</h3>
                <div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Nombre</label>
                        <div class="uk-form-controls">
                            <input class="uk-form-width-medium" type="text" name="name"
                                   value=" " />
                        </div>
                    </div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Apellido</label>
                        <div class="uk-form-controls">
                            <input class="uk-form-width-medium" type="text" name="name"
                                   value=" " />
                        </div>
                    </div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Correo electrónico</label>
                        <div class="uk-form-controls">
                            <input class="uk-form-width-medium" type="text" name="name"
                                   value=" " />
                        </div>
                    </div>
                    <div class="uk-form-row">
                        <label class="uk-form-label">Fecha de nacimiento</label>
                        <div class="uk-form-controls">
                            <input class="uk-form-width-medium" type="date" name="name"
                                   value=" " />
                        </div>
                    </div>
                </div>
                <div class="uk-form-horizontal">
                    <br />
                    <div class="uk-grid">
                        <a class="uk-button uk-button-primary uk-align-right" href="Inicio"><i
                                class="uk-icon-times"></i>Cancelar</a> <a
                            class="uk-button uk-button-primary uk-align-right" href="Inicio"><i
                                class="uk-icon-check"></i>Hecho</a>&nbsp;
                    </div>
                </div>
            </form>
        </div>
        <br />
    </body>
</html>