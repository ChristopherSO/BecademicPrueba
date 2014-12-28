/**
* Becas
**/

/******************************
*   Inicializador del JQuery  *
******************************/
$(function () {

    // Al inicio se refresca la tabla con los ultimos datos que hayan sido agregados.
    refrescarTabla();

    /**
    * Se habilitan las validaciones de datos para los formularios
    **/
    $("#formularioAgregarBeca").validationEngine();
    $("#formularioEditarBeca").validationEngine();

    /**
    * Evento para agregar becas
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para agregar nuevas becas
    **/
    $("#formularioAgregarBeca").submit(function (e) {

        e.preventDefault();

        var nuevaBeca = {
            "idCarrera": $("#txtCarrera_agregar").val(),
            "fechaAprobacion": $("#txtFechaAprobacion_agregar").val(),
            "idUsuario": $("#txtUsuario_agregar").val(),
            "idTipoBeca": $("#txtTipoBeca_agregar").val(),
            "estado": $("#txtEstado_agregar").val(),
            "comentario": $("#txtComentario_agregar").val()
        };

        agregarBeca(nuevaBeca);

    });

    /**
    * Evento para editar tipos de beca
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para editar Beca
    **/
    $("#formularioEditarBeca").submit(function (ev) {

        ev.preventDefault();

        var nuevoDatosBeca = {
            "id": $("#txtIdBeca_editar").val(),
            "idCarrera": $("#txtCarrera_editar").val(),
            "fechaAprobacion": $("#txtFechaAprobacion_editar").val(),
            "idUsuario": $("#txtUsuario_editar").val(),
            "idTipoBeca": $("#txtTipoBeca_editar").val(),
            "estado": $('#rdgEstado_editar label.active input').val(),
            "comentario": $("#txtComentario_editar").val()
        };

        editarBeca(nuevoDatosBeca);
    });

});
/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var server = "http://localhost:14623/ModuloBecas/ServiciosBecas.svc";

/**
* Caso de uso: Listar becas
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
        url: server + "/todos",
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
            resultado.forEach(function (beca) {

                /**
                * Se hace llamado a la función para tomar el IdCarrera al que la beca está
                * asociada, para luego tomar el nombre de la carrera.
                **/
                buscarCarreraPorIdBeca(beca.Id, function (carrera) {
                    beca.NombreCarrera = carrera.Nombre;
                });

                /**
                * Se hace llamado a la función para tomar el IdUsuario al que la beca está
                * asociada, para luego tomar el nombre del usuario.
                **/
                buscarUsuarioPorIdBeca(beca.Id, function (usuario) {
                    beca.NombreUsuario = usuario.Nombre + " " + usuario.SegundoNombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                });

                /**
                * Se hace llamado a la función para tomar el IdCarrera al que la beca está
                * asociada, para luego tomar el nombre de la carrera.
                **/
                buscarTipoBecaPorIdBeca(beca.Id, function (tipoBeca) {
                    beca.NombreTipoBeca = tipoBeca.Nombre;
                });

                // Se comienza a construir la fila para la tabla.
                var fila = '' +
                    '<tr>' +
                        '<td>' + beca.Id + '</td>' +
                        '<td>' + beca.NombreCarrera + '</td>' +
                        '<td>' + fechaFormateada(beca.FechaAprobacion) + '</td>' +
                        '<td>' + beca.NombreUsuario + '</td>' +
                        '<td>' + beca.NombreTipoBeca + '</td>' +
                        '<td>' + estado(beca.Estado) + '</td>' +
                        '<td>' + beca.Comentario + '</td>' +
                        '<td>' + /* Las becas no se eliminan, sino solo se les cambia su estado
                            '<button class="btn btn-danger btnBorrar" id="' + beca.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button>' + */
                            '<button class="btn btn-warning btnVentanaEditar" id="' + beca.Id + '"><span class="glyphicon glyphicon-pencil"></span> Cambiar estado</button>' +
                        '</td>' +
                    '</tr>';

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla.
                $("#contenidoTabla").append(fila);

                /**
                * Dado que se estan generando botones de eliminar y editar en tiempo de ejecucion 
                * hay que decirle al JQuery que vuelva nuevamente a colocarles los Eventos.
                **/

                /* Las becas no se eliminan, sino solo se les cambia su estado
                // Evento para el nuevo boton de borrar
                $(".btnBorrar").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idBeca = $(this).attr("id");

                    // Se elimina el beca
                    eliminarBeca(idBeca);
                });
                */

                // Evento para el nuevo botón de editar
                $(".btnVentanaEditar").click(function () {

                    // Antes de abrir la ventana se escribirán los detalles de la Beca pasado.
                    buscarBeca($(this).attr("id"), function (beca) {
                        $("#txtIdBeca_editar").val(beca.Id);
                        $("#txtCarrera_editar").val(beca.IdCarrera);
                        $("#txtFechaAprobacion_editar").val(fechaSQL(beca.FechaAprobacion));
                        $("#txtUsuario_editar").val(beca.IdUsuario);
                        $("#txtTipoBeca_editar").val(beca.IdTipoBeca);
                        if (beca.Estado == true) {
                            $("#rdgEstado_editar").children().first().addClass("active");
                            $("#rdgEstado_editar").children().last().removeClass("active");
                        } else {
                            $("#rdgEstado_editar").children().last().addClass("active");
                            $("#rdgEstado_editar").children().first().removeClass("active");
                        }
                        $("#txtComentario_editar").val(beca.Comentario);
                        // Se abre la ventana para editar un grupo
                        $("#ventanaEditarBeca").modal("show");
                    });

                });// Fin del evento para el boton editar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

            // Se refrescan las opciones de los tipos de beneficios del modal Agregar nuevo beneficio
            //llenarOpcionesDeTiposDeBeneficios();

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}

/**
* Caso de uso: Buscar Beca por Id
**/
function buscarBeca(id, onSuccess) {
    $.ajax({
        url: server + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nueva Beca
**/
function agregarBeca(obj) {
    $.ajax({
        url: server + "/crear",
        type: "GET",
        data: {
            'id_carrera': obj.idCarrera,
            'fecha_aprobacion': obj.fechaAprobacion,
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

/**
* Caso de uso: Editar beca
**/
function editarBeca(obj) {
    $.ajax({

        url: server + "/actualizar",
        type: "GET",
        data: {
            'id': obj.id,
            'id_carrera': obj.idCarrera,
            'fecha_aprobacion': obj.fechaAprobacion,
            'id_usuario': obj.idUsuario,
            'id_tipo_beca': obj.idTipoBeca,
            'estado': obj.estado,
            'comentario': obj.comentario
        },
        success: function (resultado) {
            $("#ventanaEditarBeca").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                //alert("Disculpe, hubo un error al momento de modificar la Beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Eliminar Beca
**/
function eliminarBeca(id) {
    $.ajax({
        url: server + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar la Beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

///**
//* Caso de uso: Buscar Carrera por Id de Beca
//**/
function buscarCarreraPorIdBeca(idBeca, onSuccess) {
    $.ajax({
        url: server + "/carrera?idBeca=" + idBeca,
        type: "GET",
        dataType: "json",
        async: false,
        success: onSuccess
    });
}

///**
//* Caso de uso: Buscar Usuario por Id de Beca
//**/
function buscarUsuarioPorIdBeca(idBeca, onSuccess) {
    $.ajax({
        url: server + "/usuario?idBeca=" + idBeca,
        type: "GET",
        dataType: "json",
        async: false,
        success: onSuccess
    });
}

///**
//* Caso de uso: Buscar TipoBeca por Id de Beca
//**/
function buscarTipoBecaPorIdBeca(idBeca, onSuccess) {
    $.ajax({
        url: server + "/tipoBeca?idBeca=" + idBeca,
        type: "GET",
        dataType: "json",
        async: false,
        success: onSuccess
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

// Convertir fecha de formato JSON a formato string yyyy-MM-dd
function fechaSQL(fechaJSON) {

    var milisegundos = parseInt(fechaJSON.substr(6));
    var fecha = new Date(milisegundos);

    dia = '' + fecha.getDate(),
    mes = '' + (fecha.getMonth() + 1),
    anio = fecha.getFullYear();

    if (dia.length < 2) dia = '0' + dia;
    if (mes.length < 2) mes = '0' + mes;

    return [anio, mes, dia].join('-');
}

// Texto a mostrar en el estado
function estado(bool) {
    if (bool == true) {
        return 'Activo';
    } else {
        return 'Inactivo'
    }
}