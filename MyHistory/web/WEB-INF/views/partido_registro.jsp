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
                        <h1>Registro de partido</h1>
                        <form class="uk-form uk-form-horizontal" action="#" method="post">
                            <div class="uk-form-row">
                                <label class="uk-form-label">Torneo</label>
                                <div class="uk-form-controls">
                                    <select>
                                        <option>#torneo1</option>
                                    </select>
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Año</label>
                                <div class="uk-form-controls">
                                    <input class="uk-form-width-medium" type="number" name="name"
                                           value=" " />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Equipos </label>
                                <div class="uk-form-controls">
                                    <select>
                                        <option>#equipo1</option>
                                    </select> &nbsp; <select>
                                        <option>#equipo2</option>
                                    </select>
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Marcador</label>
                                <div class="uk-form-controls">
                                    <input type="number" /> &nbsp; <input type="number" />
                                </div>
                            </div>
                        </form>
                    </div>
                    <ul class="uk-subnav uk-subnav-pill uk-align-center"
                        data-uk-switcher="{connect:'#equipo'}">
                        <li class="uk-active"><a href="#">Equipo 1</a></li>
                        <li><a href="#">Equipo 2</a></li>
                    </ul>
                    <ul id="equipo" class="uk-switcher">
                        <li class="uk-active">
                            <div class="uk-width-1-1">
                                <table class="uk-table">
                                    <tr>
                                        <th>Nombre del jugador</th>
                                        <th>Pasaporte de la X-FIFA</th>
                                        <th>Goles</th>
                                        <th>Asistencias</th>
                                        <th>Remates a marco</th>
                                        <th>Tiros salvados</th>
                                        <th>Recuperación de balón</th>
                                        <th>Tarjetas amarillas</th>
                                        <th>Tarjetas rojas</th>
                                        <th>Penales cometidos</th>
                                        <th>Penales detenidos</th>
                                    </tr>
                                </table>
                            </div>
                        </li>
                        <li>
                            <div class="uk-width-1-1">
                                <table class="uk-table">
                                    <tr>
                                        <th>Nombre del jugador</th>
                                        <th>Pasaporte de la X-FIFA</th>
                                        <th>Goles</th>
                                        <th>Asistencias</th>
                                        <th>Remates a marco</th>
                                        <th>tiros salvados</th>
                                        <th>Recuperación de balón</th>
                                        <th>Tarjetas amarillas</th>
                                        <th>Tarjetas rojas</th>
                                        <th>Penales cometidos</th>
                                        <th>Penales detenidos</th>
                                    </tr>
                                </table>
                            </div>
                        </li>
                    </ul>
                    <br />
                    <a class="uk-button uk-button-primary uk-align-right" href="#">
                        <i class="uk-icon-plus"></i>Hecho
                    </a>
                </div>
            </div>
        </div>
    </body>
</html>