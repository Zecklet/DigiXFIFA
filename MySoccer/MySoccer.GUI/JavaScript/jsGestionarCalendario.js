
//Funciones que son utilizadas en la parte de gestionar calendarios 

//Toma el id introducido en la creacion de la tabla y lo guarda en un hidden, y llama al controlador
function ActualizarPartido(pIdPartido) { 
         document.getElementById("hdPartidoSelecionado").value = pIdPartido; //se guarda el id del partido
         document.frEditarPartido.submit(); //se hace submit para que llame a la pagina de actualizar el partido
     }

//Toma el id introducido en la creacion de la tabla y lo guarda en un hidden, y llama al controlador
function EliminarPartido(pIdPartido) {
    if (confirm("Esta a punto de eliminar un partido.\n Desea continuar?")) { //le solita la confirmacion al usuario
        document.getElementById("hdPartidoAEliminar").value = pIdPartido; //se guarda el id del partido
        document.frEliminarPartido.submit(); //se hace submit para que llame a la pagina de eliminar el partido
    }
}
//Llama al cntrolador para que cambie los partidos que se estan mostrando en patanlla segun el torneo
function CambiarToreno() {
    document.frCambiarTorneo.submit(); //Hace un submit forzado para que se tomen los partido registrados bajo un mismo torneo
}
