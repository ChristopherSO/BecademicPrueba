/**
* Veredicto
**/

/******************************
*   Inicializador del JQuery  *
******************************/
$(function () {

    var nombreIntervencion;

    switch (usuarioActual.LstRoles[0].Intervencion) {
        case 1:
            nombreIntervencion = "Departamento de registro";
            break;
        case 2:
            nombreIntervencion = "Departamento director académico";
            break;
        case 3:
            nombreIntervencion = "Departamento financiero";
            break;
        case 4:
            nombreIntervencion = "Departamento decano";
            break;
        default:
            nombreIntervencion = "";
            break
    }

    $("#txtNombreIntervencion").html(nombreIntervencion);

    // Al inicio se refresca la tabla con los ultimos datos que hayan sido agregados.
    refrescarTabla();

    /**
    * Se habilitan las validaciones de datos para los formularios
    **/
    $("#ventanaEmitirVeredicto").validationEngine();

    /**
    * Evento para emitir veredicto
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para emitir veredicto
    **/
    $("#formularioEmitirVeredicto").submit(function (e) {

        e.preventDefault();

        var resultado = ($("input[name=aprueba]:checked").val() == "si");

        var nuevoVeredicto = {
            "idSolicitud": $("#txtIdSolicitud_emitir").val(),
            "idUsuario": usuarioActual.Id,
            "comentario": $("#txtComentario_agregar").val(),
            "aprobado": resultado
        };

        agregarVeredicto(nuevoVeredicto);

        if (usuarioActual.LstRoles[0].Intervencion == 3 && resultado == true) {
            var nuevaBeca = {

                'idCarrera': $("#txtIdCarrera_emitir").val(),
                'idUsuario': $("#txtIdUsuarioEstudiante_emitir").val(),
                'idTipoBeca': $("#txtIdTipoBeca_emitir").val(),
                'estado': resultado,
                'comentario': $("#txtComentario_agregar").val()

            }

            agregarBeca(nuevaBeca);
        }

    });

});
/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var serverSolicitudes = "http://localhost:14623/ModuloBecas/ServiciosSolicitudes.svc";
var serverVeredicto = "http://localhost:14623/ModuloBecas/ServiciosAprobaciones.svc";
var serverBecas = "http://localhost:14623/ModuloBecas/ServiciosBecas.svc";

/**
* Caso de uso: Listar solicitudes
* Refresca el contenido de la tabla de tipos de beca
**/
function refrescarTabla() {
    // Se elimina todo contenido previamente escrito en la tabla
    $("#contenidoTabla").html("");

    $("#ventanaLoader").modal("show");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosBecas.svc
    **/
    $.ajax({

        // Direccion hacia donde hacer la llamada
        url: serverSolicitudes + "/fase/" + usuarioActual.LstRoles[0].Intervencion,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (solicitud) {

                // Se comienza a construir la fila para la tabla.
                var fila = '' +
                    '<tr>' +
                        '<td>' + solicitud.Id + '</td>' +
                        '<td>' + solicitud.Usuario.Nombre + " " + solicitud.Usuario.PrimerApellido + '</td>' +
                        '<td>' + solicitud.Carrera.Nombre + '</td>' +
                        '<td>' + solicitud.TipoDeBeca.Nombre + '</td>' +
                        '<td>' + solicitud.idEstudio + '</td>' +
                        '<td>' + solicitud.fecha + '</td>' +
                        '<td>' +
                            '<button class="btn btn-info btnVentanaEmitirVeredicto" idSolicitud="' + solicitud.Id + '" idUsuarioEstudiante="' + solicitud.idUsuario + '" idCarrera="' + solicitud.idCarrera + '" idTipoBeca="' + solicitud.idTipoBeca + '" ><span class="glyphicon glyphicon-pencil"></span> Emitir</button>' +
                        '</td>' +
                    '</tr>';

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla.
                $("#contenidoTabla").append(fila);

                validarUsuarioActualVeredicto()

                /**
                * Dado que se estan generando botones de emitir veredicto en tiempo de ejecucion 
                * hay que decirle al JQuery que vuelva nuevamente a colocarles los Eventos.
                **/

                //});// Fin del evento para el boton editar correspondiente a esta fila

                $(".btnVentanaEmitirVeredicto").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton

                    var idSolicitud = $(this).attr("idSolicitud"),
                        idUsuarioEstudiante = $(this).attr("idUsuarioEstudiante"),
                        idCarrera = $(this).attr("idCarrera"),
                        idTipoBeca = $(this).attr("idTipoBeca");
                    $("#txtIdSolicitud_emitir").val(idSolicitud);
                    $("#txtIdUsuarioEstudiante_emitir").val(idUsuarioEstudiante);
                    $("#txtIdCarrera_emitir").val(idCarrera);
                    $("#txtIdTipoBeca_emitir").val(idTipoBeca);

                    // Se abre la ventana para asignar carreras
                    $("#ventanaEmitirVeredicto").modal("show");

                });// Fin del boton asignar requisitos

            });// Fin de la iteracion entre los objetos del resultado

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}

/**
* Caso de uso: Buscar Beca por Id
**/
function buscarSolicitud(id, onSuccess) {
    $.ajax({
        url: serverSolicitudes + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nueva Beca
**/
function agregarVeredicto(obj) {
    $.ajax({
        url: serverVeredicto + "/crear",
        type: "GET",
        data: {
            'idSolicitud': obj.idSolicitud,
            'idUsuario': obj.idUsuario,
            'comentario': obj.comentario,
            'aprobado': obj.aprobado
        },
        success: function (resultado) {
            $("#ventanaEmitirVeredicto").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de emitir el veredicto\n\rpor favor intente más tarde.");
            }
        }

    });
}

function agregarBeca(obj) {
    $.ajax({
        url: serverBecas + "/crear",
        type: "GET",
        data: {
            'id_carrera': obj.idCarrera,
            'id_usuario': obj.idUsuario,
            'id_tipo_beca': obj.idTipoBeca,
            'estado': obj.estado,
            'comentario': obj.comentario
        },
        success: function (resultado) {
            $("#ventanaAgregarBeca").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de crear la Beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

function validarUsuarioActualVeredicto() {

    if (usuarioActual.LstRoles[0].Intervencion == 1 || usuarioActual.LstRoles[0].Intervencion == 2) {
        $("#rdgAprobar").hide();
    }

}