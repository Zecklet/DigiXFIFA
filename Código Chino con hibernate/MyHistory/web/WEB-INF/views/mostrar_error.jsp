<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<div class="uk-width-3-6">
    <c:if test="${Error!=null}">
        <font class="uk-form uk-form-horizontal" color=" red">${Error.cMensaje}</font>
    </c:if>
</div>
