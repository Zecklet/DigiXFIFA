<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<%@ page session="false"%>
<html class="uk-height-1-1">
    <head>
        <script src="styles/js/jquery.js" type="text/javascript"></script>
        <script src="styles/js/uikit.js" type="text/javascript"></script>
        <link href="styles/uikit.almost-flat.css" rel="stylesheet" type="text/css"/>
        <title>MyHistory</title>
    </head>
    <body class="uk-height-1-1">
        <div class="uk-width-1-1 uk-height-1-1 uk-vertical-align">
            <div
                class="uk-width-1-3 uk-push-1-3 uk-vertical-align-middle uk-panel-box">
                <div class="uk-grid uk-panel">
                    <div class="uk-width-1-2  uk-text-center">
                        <img
                            src="images/logo.png"
                            alt="logoXFIFA" />
                    </div>
                    <div class="uk-width-1-2 uk-text-left">
                        <br /> <br />
                        <h1>MyHistory</h1>
                    </div>
                </div>
                <br />
                <form class="uk-form uk-form-horizontal" id="form1">
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
                    <div class="uk-form-row">
                        <br />
                        <div class="uk-grid">
                            <div class="uk-width-1-3 uk-push-1-3 uk-text-right">
                                <a class="uk-button uk-button-primary uk-text-break"
                                   href="Administrador_Perfil">Iniciar sesión</a>
                            </div>
                            <div class="uk-width-1-3 uk-push-1-3 uk-text-left">
                                <a class="uk-link" href="Administrador_Registro">Registrarse</a>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </body>
</html>
