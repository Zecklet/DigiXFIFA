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
                    <h1>#nombrejugador</h1>
                    <div class="uk-grid">
                        <div class="uk-width-4-10">
                            <img src="#" alt="Alternate Text" />
                        </div>
                        <div class="uk-width-6-10">
                            <h2>Datos personales</h2>
                            <div class="uk-grid">
                                <div class="uk-width-1-2">
                                    <label class="uk-form-label">Pasaporte X-FIFA</label> <br /> <label
                                        class="uk-form-label">Fecha de nacimiento</label> <br /> <label
                                        class="uk-form-label">Altura</label> <br /> <label
                                        class="uk-form-label">Peso</label> <br /> <label
                                        class="uk-form-label">Pa�s</label> <br /> <label
                                        class="uk-form-label">Posici�n</label> <br /> <label
                                        class="uk-form-label">Equipo actual</label> <br /> <label
                                        class="uk-form-label">Activo</label>
                                </div>
                                <div class="uk-grid-1-2">
                                    <label class="uk-form-label">#pasaportexfifa</label> <br /> <label
                                        class="uk-form-label">#fechadenacimiento</label> <br /> <label
                                        class="uk-form-label">#altura</label> <br /> <label
                                        class="uk-form-label">#peso</label> <br /> <label
                                        class="uk-form-label">#pa�s</label> <br /> <label
                                        class="uk-form-label">#posici�n</label> <br /> <label
                                        class="uk-form-label">#equipo actual</label> <br /> <label
                                        class="uk-form-label">#activo</label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <h2>Datos estad�sticos</h2>

                    <h3>Estad�sticas regulares</h3>
                    <table class="uk-table">
                        <tr>
                            <th>A�o</th>
                            <th>Club</th>
                            <th>J.J.</th>
                            <th>J.G.</th>
                            <th>J.E.</th>
                            <th>J.P.</th>
                            <th>T.M.</th>
                            <th>G.</th>
                            <th>R.M.</th>
                            <th>A.</th>
                            <th>R.B.</th>
                            <th>T.A.</th>
                            <th>T.R.</th>
                            <th>P.D.</th>
                            <th>P.C.</th>
                            <th>R.S</th>
                            <th>Nota X-FIFA</th>
                        </tr>
                    </table>
                    <br />
                    <h3>Selecci�n regulares</h3>
                    <table class="uk-table">
                        <tr>
                            <th>A�o</th>
                            <th>Club</th>
                            <th>J.J.</th>
                            <th>J.G.</th>
                            <th>J.E.</th>
                            <th>J.P.</th>
                            <th>T.M.</th>
                            <th>G.</th>
                            <th>R.M.</th>
                            <th>A.</th>
                            <th>R.B.</th>
                            <th>T.A.</th>
                            <th>T.R.</th>
                            <th>P.D.</th>
                            <th>P.C.</th>
                            <th>R.S</th>
                            <th>Nota X-FIFA</th>
                        </tr>
                    </table>
                    <br />
                    <div class="uk-grid">
                        <div class="uk-width-1-2">
                            <table class="uk-table">
                                <tr>
                                    <th>Acr�nimo</th>
                                    <th>Significado</th>
                                </tr>
                                <tr>
                                    <td>J.J.</td>
                                    <td>Juegos jugados</td>
                                </tr>
                                <tr>
                                    <td>J.G.</td>
                                    <td>Juegos ganados</td>
                                </tr>
                                <tr>
                                    <td>J.E.</td>
                                    <td>Juegos empatados</td>
                                </tr>
                                <tr>
                                    <td>J.P</td>
                                    <td>Juegos perdidos</td>
                                </tr>
                                <tr>
                                    <td>T.M.</td>
                                    <td>Total minutos</td>
                                </tr>
                                <tr>
                                    <td>G.</td>
                                    <td>Goles</td>
                                </tr>
                                <tr>
                                    <td>R.M.</td>
                                    <td>Remates a marco</td>
                                </tr>
                            </table>
                        </div>
                        <div class="uk-width-1-2">
                            <table class="uk-table">
                                <tr>
                                    <th>Acr�nimo</th>
                                    <th>Significado</th>
                                </tr>
                                <tr>
                                    <td>A.</td>
                                    <td>Asistencias</td>
                                </tr>
                                <tr>
                                    <td>R.B.</td>
                                    <td>Recuperaciones de bal�n</td>
                                </tr>
                                <tr>
                                    <td>T.A.</td>
                                    <td>Tarjetas amarillas</td>
                                </tr>
                                <tr>
                                    <td>T.R.</td>
                                    <td>Tarjetas rojas</td>
                                </tr>
                                <tr>
                                    <td>P.D.</td>
                                    <td>Penales detenidos</td>
                                </tr>
                                <tr>
                                    <td>P.C.</td>
                                    <td>Penales cometidos</td>
                                </tr>
                                <tr>
                                    <td>R.S.</td>
                                    <td>Remates salvados</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <br />
                </div>

            </div>
        </div>
    </body>
</html>