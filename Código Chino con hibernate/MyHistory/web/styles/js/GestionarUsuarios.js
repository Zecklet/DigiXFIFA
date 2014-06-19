
function DesactivarUsuario(pDireccionSalto, pIdForm) {
    if (confirm("¿Está seguro que desea darse de baja del sistema?")) {
        document.getElementById(pIdForm).action = pDireccionSalto;
        document.getElementById(pIdForm).submit();
    }
}