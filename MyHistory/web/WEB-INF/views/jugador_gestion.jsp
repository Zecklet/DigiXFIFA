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
                <div class="uk-grid uk-container-center">
                    <div class="uk-width-2-10">
                    <jsp:include page="navegacion.jsp"></jsp:include>
                </div>
                <div class="uk-width-8-10">
                    <div class="uk-push-1-10">
                        <h1>Gestión de jugadores</h1>
                        <form class="uk-form uk-form-horizontal" id="form1" method="get"
                              action="#">
                            <h3>Agregar jugador</h3>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Nombre</label>
                                <div class="uk-form-controls">
                                    <input class="uk-form-width-medium" type="text" name="name"
                                           value=" " />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Pasaporte de X-FIFA</label>
                                <div class="uk-form-controls">
                                    <input class="uk-form-width-medium" type="text" name="name"
                                           value="" />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Fecha de nacimiento</label>
                                <div class="uk-form-controls">
                                    <input type="date" name="name" value=" " />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Altura</label>
                                <div class="uk-form-controls">
                                    <input class="uk-form-width-medium" type="text" name="name"
                                           value=" " />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Peso</label>
                                <div class="uk-form-controls">
                                    <input type="number" name="name" value=" " />
                                </div>
                            </div>
                            <div class="uk-form-row">
                                <label class="uk-form-label">Foto</label>
                                <div class="uk-form-controls">
                                    <input type="file" name="name" value=" " />
                                </div>
                            </div>
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

                            <div class="uk-form-row">
                                <div class="uk-width-1-3 uk-push-2-3">
                                    <br /> <a class="uk-button uk-button-primary" href="#"><i
                                            class="uk-icon-check"></i>Hecho</a>
                                </div>
                            </div>
                        </form>

                        <form class="uk-form uk-form-horizontal" action="#" method="post">
                            <div class="uk-form-row">
                                <label class="uk-form-label">Búsqueda de jugadores</label>
                                <div class="uk-form-controls">
                                    <input class="uk-form-width-medium" type="text" name="name"
                                           value=" " />&nbsp;
                                    <a class="uk-button uk-button-primary" href="#">
                                        <i class="uk-icon-plus"></i>Buscar
                                    </a>
                                </div>
                            </div>
                        </form>
                        <br />
                        <h3>Seleccione un jugador</h3>
                        <div class="uk-width-4-6 uk-container-center">
                            <table class="uk-table">
                                <tr>
                                    <th>Nombre de jugador</th>
                                    <th>Pasaporte de X-FIFA</th>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div class="uk-width-1-3 uk-push-2-3">
                            <a class="uk-button uk-button-primary" href="Jugador_Perfil"><i
                                    class="uk-icon-check"></i>Ver perfil</a> &nbsp;
                            <a class="uk-button uk-button-primary" href="Jugador_Edicion"><i
                                    class="uk-icon-check"></i>Modificar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </body>
</html>