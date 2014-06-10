
//Funciones que son utilizadas en la parte de administrar lista de rechazados 

//Toma el id introducido en la creacion de la tabla y lo guarda en un hidden, y llama al controlador
function EliminarRechazado(pIdRechazado, pElementoHidden, pElementoForm) {
    if (confirm("Esta a punto de eliminar un partido.\n Desea continuar?")) { //le solita la confirmacion al usuario
        pElementoHidden.value = pIdRechazado; //se guarda el id que se quiera guardar
        pElementoForm.submit(); //se hace un submit forzado al form enviado
    }
}