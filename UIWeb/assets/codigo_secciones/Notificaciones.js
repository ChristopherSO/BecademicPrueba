/**
* Notificaciones
**/

var idUsuarioLogueado = usuarioActual.Id;

/******************************
*   Inicializador del JQuery  *
******************************/
$(function () {

    // Al inicio se refrescan las notificaciones.
    refrescarNotificaciones();

});
/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var serverNotificaciones = "http://localhost:14623/ModuloNotificaciones/ServiciosNotificaciones.svc";


/**
* Caso de uso: Listar notificaciones
* Refresca el contenido de las notificaciones
**/
function refrescarNotificaciones() {

    // Se elimina todo contenido antes de llenar las notificaciones
    $("#notificaciones ul").html("");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/no_vistas?id_usuario={id_usuario}" que se encuentra en el WebGet del Webservice REST ServiciosNotificaciones.svc
    **/
    $.ajax({

        // Direccion hacia donde hacer la llamada
        url: serverNotificaciones + "/no_vistas?id_usuario=" + idUsuarioLogueado,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (listaNotificaciones) {

            // Se actualiza la cantidad de notificaciones sin ver
            var cantNotificacionesSinVer = listaNotificaciones.length
            $('#notificaciones a span').html(cantNotificacionesSinVer);

            var dropdownHeader;
            if (cantNotificacionesSinVer == 0) {

                // Se agrega la cabecera del dropdown
                dropdownHeader = '' +
                    '<li class="dropdown-header">' +
				        '<i class="icon-info-sign"></i>' +
					    '<span>No tiene notificaciones nuevas</span>' +
				    '</li>';
                $('#notificaciones ul')
                    .removeClass("navbar-pink")
                    .addClass("navbar-green")
                    .append(dropdownHeader);

            } else {

                // Se agrega la cabecera del dropdown header
                dropdownHeader = '' +
                    '<li class="dropdown-header">' +
				        '<i class="icon-warning-sign"></i>' +
					    '<span>' + cantNotificacionesSinVer + ' notificaciones nuevas</span>' +
				    '</li>';
                $('#notificaciones ul')
                    .removeClass("navbar-green")
                    .addClass("navbar-pink")
                    .append(dropdownHeader);

                /**
                * Se agregan las notificaciones.
                * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
                **/
                listaNotificaciones.forEach(function (notificacion) {

                    /**
                    * Se hace llamado a la función para tomar el IdUsuarioAutor al que la notificacion está
                    * asociada, para luego tomar el nombre del usuario.
                    **/
                    buscarUsuarioAutorPorIdNotificacion(notificacion.Id, function (usuarioAutor) {
                        notificacion.NombreUsuarioAutor = usuarioAutor.Nombre + " " + usuarioAutor.SegundoNombre + " " + usuarioAutor.PrimerApellido + " " + usuarioAutor.SegundoApellido;
                    });

                    /**
                    * Se hace llamado a la función para tomar el TipoNotificacion al que la notificacion está
                    * asociada.
                    **/
                    var tipoNotificacion;
                    buscarTipoNotificacionPorIdNotificacion(notificacion.Id, function (pTipoNotificacion) {
                        tipoNotificacion = pTipoNotificacion;
                    });

                    // Se comienza a construir la fila para el área de notificaciones.
                    var fila;
                    switch (tipoNotificacion.Id) {
                        case 1: // Veredicto
                            fila = '' +
                                '<li>' +
						            '<a class="notificacion" id="' + notificacion.Id + '" href="/Secciones/index.aspx">' +
							            '<i class="btn btn-xs no-hover ' + tipoNotificacion.Color + ' ' + tipoNotificacion.Icono + '"></i>' +
                                        notificacion.NombreUsuarioAutor + '<br>' +
                                        notificacion.Mensaje + '<br>' +
                                        fechaFormateada(notificacion.Fecha) +
                                    '</a>' +
                                '</li>';
                            break;
                        case 2: // Solicitud aprobada
                        case 3: // Solicitud rechazada
                            fila = '' +
                                '<li>' +
						            '<a class="notificacion" id="' + notificacion.Id + '" href="/Secciones/index.aspx">' +
							            '<i class="btn btn-xs no-hover ' + tipoNotificacion.Color + ' ' + tipoNotificacion.Icono + '"></i>' +
                                        notificacion.Mensaje + '<br>' +
                                        fechaFormateada(notificacion.Fecha) +
                                    '</a>' +
                                '</li>';
                            break;
                        case 4: // Mensaje
                            fila = '' +
                                '<li>' +
						            '<a class="notificacion" id="' + notificacion.Id + '" href="/Secciones/index.aspx">' +
							            '<i class="btn btn-xs no-hover ' + tipoNotificacion.Color + ' ' + tipoNotificacion.Icono + '"></i>' +
                                        notificacion.Mensaje + '<br>' +
                                        fechaFormateada(notificacion.Fecha) +
                                    '</a>' +
                                '</li>';
                            break;
                        case 5: // Cambios académicos
                            fila = '' +
                                '<li>' +
						            '<a class="notificacion" id="' + notificacion.Id + '" href="/Secciones/index.aspx">' +
							            '<i class="btn btn-xs no-hover ' + tipoNotificacion.Color + ' ' + tipoNotificacion.Icono + '"></i>' +
                                        notificacion.Mensaje + '<br>' +
                                        fechaFormateada(notificacion.Fecha) +
                                    '</a>' +
                                '</li>';
                            break;
                        default:
                            fila = '' +
                                '<li>' +
						            '<a class="notificacion" href="/Secciones/index.aspx">' +
							            '<i class="btn btn-xs no-hover ' + tipoNotificacion.Color + ' ' + tipoNotificacion.Icono + '"></i>' +
                                        notificacion.Mensaje + '<br>' +
                                        fechaFormateada(notificacion.Fecha) +
                                    '</a>' +
                                '</li>';
                            break;
                    } // Fin del switch

                    // Se ingresa agrega esta fila al área de notificaciones.
                    $('#notificaciones ul').append(fila);

                });// Fin del listaNotificaciones.forEach


                /**
                    * Dado que se estan generando notificaciones en tiempo de ejecucion 
                    * hay que decirle al JQuery que establezca los Eventos.
                    **/

                // Evento para el evento de clic sobre la notificación
                $('.notificacion').click(function () {

                    // Se obtiene el ID colocado en el atributo del enlace
                    var idNotificacion = $(this).attr("id");

                    // Se elimina la notificacion
                    marcarNotificacionComoVista(idNotificacion, idUsuarioLogueado);
                });

            } // Fin del if-else

            //// Se agrega el footer del dropdown
            //var dropdownFooter = '' +
            //    '<li class="dropdown-header">' +
            //        '<a href="/Secciones/Notificaciones/index.aspx">' +
            //            'Ver todas las notificaciones' +
            //            '<i class="icon-arrow-right"></i>' +
            //        '</a>' +
            //    '</li>';
            //$('#notificaciones ul').append(dropdownFooter);




            // Se refrescan las opciones de los tipos de beneficios del modal Agregar nuevo beneficio
            //llenarOpcionesDeTiposDeBeneficios();

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}


///**
//* Caso de uso: Buscar usuario autor por id de notificación
//**/
function buscarUsuarioAutorPorIdNotificacion(idNotificacion, onSuccess) {
    $.ajax({
        url: serverNotificaciones + "/usuarioAutor?idNotificacion=" + idNotificacion,
        type: "GET",
        dataType: "json",
        async: false,
        success: onSuccess
    });
}


///**
//* Caso de uso: Buscar TipoNotificacion por Id de Notificacion
//**/
function buscarTipoNotificacionPorIdNotificacion(idNotificacion, onSuccess) {
    $.ajax({
        url: serverNotificaciones + "/tipoNotificacion?idNotificacion=" + idNotificacion,
        type: "GET",
        dataType: "json",
        async: false,
        success: onSuccess
    });
}


/**
* Caso de uso: Ocultar notificación
**/
function marcarNotificacionComoVista(idNotificacion, idUsuario) {
    $.ajax({
        url: serverNotificaciones + "/marcarComoVista",
        type: "GET",
        data: {
            'idNotificacion': idNotificacion,
            'idUsuario': idUsuario
        },
        success: function (resultado) {
            if (resultado == true) {
                refrescarNotificaciones();
            }
        }

    });
}


// Convertir fecha de formato JSON a formato string d-MMM-yyyy
function fechaFormateada(fechaJSON) {

    var milisegundos = parseInt(fechaJSON.substr(6));
    var fecha = new Date(milisegundos);

    dia = '' + fecha.getDate(),
    mes = '' + fecha.getMonth(),
    anio = fecha.getFullYear();

    if (mes == 0) { mes = "Ene" };
    if (mes == 1) { mes = "Feb" };
    if (mes == 2) { mes = "Mar" };
    if (mes == 3) { mes = "Abr" };
    if (mes == 4) { mes = "May" };
    if (mes == 5) { mes = "Jun" };
    if (mes == 6) { mes = "Jul" };
    if (mes == 7) { mes = "Ago" };
    if (mes == 8) { mes = "Set" };
    if (mes == 9) { mes = "Oct" };
    if (mes == 10) { mes = "Nov" };
    if (mes == 11) { mes = "Dic" };

    return [dia, mes, anio].join('-');
}