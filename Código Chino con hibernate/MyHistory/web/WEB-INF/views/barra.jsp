<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<c:if test="${Nombre==null}"> 
    <script>
        window.location = "Inicio";
    </script>
</c:if>
<div class="uk-width-3-6">
    <i class="uk-icon-user uk-icon-large">&nbsp;</i><a
        href="Administrador_Perfil" class="uk-link"> ${Nombre} </a>
</div>
<div class="uk-width-1-6 uk-push-2-6">
    <a class="uk-link" href="Inicio"> Cerrar sesión </a>
</div>

