/**
* Requisitos
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
    $("#formularioAgregarRequisito").validationEngine();
    $("#formularioEditarRequisito").validationEngine();

    /**
    * Evento para agregar Requisitos
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para agregar nuevos Requisitos
    **/
    $("#formularioAgregarRequisito").submit(function (e) {

        e.preventDefault();

        var nuevoRequisito = {
            "tipoRequisito": $("#cmbTipoRequisito_agregar").val(),
            "nombre": $("#txtNombreRequisito_agregar").val(),
            "descripcion": $("#txtDescripcionRequisito_agregar").val()
        };

        agregarRequisito(nuevoRequisito);

    });

    /**
    * Evento para editar tipos de requisito
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para editar Requisito
    **/
    $("#formularioEditarRequisito").submit(function (ev) {

        ev.preventDefault();

        var nuevoDatosRequisito = {
            "id": $("#txtIdRequisito_editar").val(),
            "tipoRequisito": $("#cmbTipoRequisito_editar").val(),
            "nombre": $("#txtNombreRequisito_editar").val(),
            "descripcion": $("#txtDescripcionRequisito_editar").val()
        };

        editarRequisito(nuevoDatosRequisito);
    });

});
/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var server = "http://localhost:14623/ModuloBecas/ServiciosRequisitos.svc";

/**
* Caso de uso: Listar Requisitos
* Refresca el contenido de la tabla de tipos de beca
**/
function refrescarTabla() {
    // Se elimina todo contenido previamente escrito en la tabla
    $("#contenidoTabla").html("");

    $("#ventanaLoader").modal("show");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosRequisitos.svc
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
            resultado.forEach(function (Requisito) {

                /**
                * Se hace llamado a la función para tomar el TipoRequisito al que el Requisito está
                * asociado, para luego tomar el nombre del tipo de Requisito
                **/
                buscarTipoRequisitoPorIdRequisito(Requisito.Id, function (tipoRequisito) {
                    Requisito.NombreTipoRequisito = tipoRequisito.Nombre;
                });

                // Se comienza a construir la fila para la tabla.
                var fila = '' +
                    '<tr>' +
                        '<td>' + Requisito.Id + '</td>' +
                        '<td>' + Requisito.NombreTipoRequisito + '</td>' +
                        '<td>' + Requisito.Nombre + '</td>' +
                        '<td>' + Requisito.Descripcion + '</td>' +
                        '<td>' +
                            '<button class="btn btn-danger btnBorrar" id="' + Requisito.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button>' +
                            '<button class="btn btn-warning btnVentanaEditar" id="' + Requisito.Id + '"><span class="glyphicon glyphicon-pencil"></span> Editar</button>' +
                        '</td>' +
                    '</tr>';

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla.
                $("#contenidoTabla").append(fila);

                /**
                * Dado que se estan generando botones de eliminar y editar en tiempo de ejecucion 
                * hay que decirle al JQuery que vuelva nuevamente a colocarles los Eventos.
                **/

                // Evento para el nuevo boton de borrar
                $(".btnBorrar").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idRequisito = $(this).attr("id");

                    // Se elimina el Requisito
                    eliminarRequisito(idRequisito);
                });

                // Evento para el nuevo botón de editar
                $(".btnVentanaEditar").click(function () {

                    // Antes de abrir la ventana se escribirán los detalles del Requisito pasado.
                    buscarRequisito($(this).attr("id"), function (Requisito) {
                        $("#txtIdRequisito_editar").val(Requisito.Id);
                        $("#cmbTipoRequisito_editar").val(Requisito.IdTipoRequisito);
                        $("#txtNombreRequisito_editar").val(Requisito.Nombre);
                        $("#txtDescripcionRequisito_editar").val(Requisito.Descripcion);
                        // Se abre la ventana para editar un grupo
                        $("#ventanaEditarRequisito").modal("show");
                    });

                });// Fin del evento para el boton editar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

            // Se refrescan las opciones de los tipos de Requisitos del modal Agregar nuevo Requisito
            llenarOpcionesDeTiposDeRequisitos();

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}

/**
* Caso de uso: Buscar Requisito por Id
**/
function buscarRequisito(id, onSuccess) {
    $.ajax({
        url: server + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nuevo Requisito
**/
function agregarRequisito(obj) {
    $.ajax({
        url: server + "/crear",
        type: "GET",
        data: {
            'nombre': obj.nombre,
            'tipoRequisito': obj.tipoRequisito,
            'descripcion': obj.descripcion
        },
        success: function (resultado) {
            $("#ventanaAgregarRequisito").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de crear el Requisito\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Editar Requisito
**/
function editarRequisito(obj) {
    $.ajax({

        url: server + "/actualizar",
        type: "GET",
        data: {
            'id': obj.id,
            'nombre': obj.nombre,
            'tipoRequisito': obj.tipoRequisito,
            'descripcion': obj.descripcion
        },
        success: function (resultado) {
            $("#ventanaEditarRequisito").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de modificar el Requisito\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Eliminar Requisito
**/
function eliminarRequisito(id) {
    $.ajax({
        url: server + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar el Requisito\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Buscar Tipo de Requisito por Id de Requisito
**/
function buscarTipoRequisitoPorIdRequisito(idRequisito, onSuccess) {
    $.ajax({
        url: server + "/tipo_Requisito?idRequisito=" + idRequisito,
        type: "GET",
        dataType: "json",
        async: false,
        success: onSuccess
    });
}


/*
/**
* Caso de uso: Listar tipos de Requisitos
* Llena las opciones del ComboBox Tipos de Requisitos
**/
function llenarOpcionesDeTiposDeRequisitos() {

    // Se eliminan todos las opciones previo a llenarlo de nuevo
    $("#cmbTipoRequisito_agregar").html("");
    $("#cmbTipoRequisito_agregar").append('<option value="0" style="display:none;" selected="selected" >--Seleccione un tipo de Requisito--</option>');
    $("#cmbTipoRequisito_editar").html("");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosRequisitos.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/tipos_de_Requisitos",
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // La función es asíncrona?
        async: false,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (tipoRequisito) {

                // Se construye la opción para el ComboBox.
                var opcion = '<option value="' + tipoRequisito.Id + '">' + tipoRequisito.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbTipoRequisito_agregar").append(opcion);
                $("#cmbTipoRequisito_editar").append(opcion);

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}