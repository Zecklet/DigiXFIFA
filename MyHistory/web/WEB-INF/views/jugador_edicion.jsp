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
        <div class="uk-width-9-10 uk-container-center">
            <div class="uk-grid">
                <br />
                <jsp:include page="barra.jsp"></jsp:include>
                </div>
                <hr class="uk-grid-divider" />
                <div class="uk-grid">
                    <div class="uk-width-2-10">
                    <jsp:include page="navegacion.jsp"></jsp:include>
                </div>
                <div class="uk-width-8-10">
                    <h1>#nombrejugador</h1>
                    <br />
                    <form class="uk-form uk-form-horizontal" id="form1" method="get"
                          action="#">
                        <h3>Información personal</h3>
                        <div class="uk-grid">
                            <div class="uk-width-1-2">
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Pasaporte</label>
                                    <div class="uk-form-controls">
                                        <input class="uk-form-width-medium" type="text" name="name"
                                               value=" " />
                                    </div>
                                </div>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Fecha de nacimiento</label>
                                    <div class="uk-form-controls">
                                        <input type="date" name="name" value="" />
                                    </div>
                                </div>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Altura</label>
                                    <div class="uk-form-controls">
                                        <input type="number" name="name" value=" " />
                                        <p>&nbsp;centímetros</p>
                                    </div>
                                </div>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Peso</label>
                                    <div class="uk-form-controls">
                                        <input type="number" name="name" value=" " />
                                        <p>&nbsp;kilogramos</p>
                                    </div>
                                </div>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Foto</label>
                                    <div class="uk-form-controls">
                                        <input type="file" name="name" value=" " />
                                    </div>
                                </div>
                            </div>
                            <div class=uk-width-1-2>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">País</label>
                                    <div class="uk-form-controls">
                                        <select>
                                            <option>#pais</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Posición</label>
                                    <div class="uk-form-controls">
                                        <select>
                                            <option>#posicion</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Equipo actual</label>
                                    <div class="uk-form-controls">
                                        <select>
                                            <option>#equipo</option>
                                        </select>
                                    </div>
                                </div>
                                <h3>Estado</h3>
                                <div class="uk-form-row">
                                    <label class="uk-form-label">Está activo</label>
                                    <div class="uk-form-controls">
                                        <input type="checkbox" name="name" value=" " />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="uk-form-row">
                            <br />
                            <div class="uk-grid">
                                <a class="uk-button uk-button-primary uk-align-right"
                                   href="Jugador_Perfil"><i class="uk-icon-times"></i>Cancelar</a>
                                <a class="uk-button uk-button-primary uk-align-right"
                                   href="Jugador_Perfil"><i class="uk-icon-check"></i>Hecho</a>&nbsp;
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </body>
</html>