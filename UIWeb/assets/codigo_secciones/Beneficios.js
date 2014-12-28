/**
* Beneficios
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
    $("#formularioAgregarBeneficio").validationEngine();
    $("#formularioEditarBeneficio").validationEngine();

    /**
    * Evento para agregar beneficios
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para agregar nuevos beneficios
    **/
    $("#formularioAgregarBeneficio").submit(function (e) {

        e.preventDefault();

        var nuevoBeneficio = {
            "idTipoBeneficio": $("#cmbTipoBeneficio_agregar").val(),
            "nombre": $("#txtNombreBeneficio_agregar").val(),
            "descripcion": $("#txtDescripcionBeneficio_agregar").val(),
            "valor": $("#txtValorBeneficio_agregar").val()
        };

        agregarBeneficio(nuevoBeneficio);

    });

    /**
    * Evento para editar tipos de beca
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para editar Beneficio
    **/
    $("#formularioEditarBeneficio").submit(function (ev) {

        ev.preventDefault();

        var nuevoDatosBeneficio = {
            "id": $("#txtIdBeneficio_editar").val(),
            "idTipoBeneficio": $("#cmbTipoBeneficio_editar").val(),
            "nombre": $("#txtNombreBeneficio_editar").val(),
            "descripcion": $("#txtDescripcionBeneficio_editar").val(),
            "valor": $("#txtValorBeneficio_editar").val()
        };

        editarBeneficio(nuevoDatosBeneficio);
    });

});
/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var server = "http://localhost:14623/ModuloBecas/ServiciosBeneficios.svc";

/**
* Caso de uso: Listar beneficios
* Refresca el contenido de la tabla de tipos de beca
**/
function refrescarTabla() {
    // Se elimina todo contenido previamente escrito en la tabla
    $("#contenidoTabla").html("");

    $("#ventanaLoader").modal("show");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosBeneficios.svc
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
            resultado.forEach(function (beneficio) {

                /**
                * Se hace llamado a la función para tomar el TipoBeneficio al que el Beneficio está
                * asociado, para luego tomar el nombre del tipo de beneficio
                **/
                buscarTipoBeneficioPorIdBeneficio(beneficio.Id, function (tipoBeneficio) {
                    beneficio.NombreTipoBeneficio = tipoBeneficio.Nombre;
                });

                // Se comienza a construir la fila para la tabla.
                var fila = '' +
                    '<tr>' +
                        '<td>' + beneficio.Id + '</td>' +
                        '<td>' + beneficio.NombreTipoBeneficio + '</td>' +
                        '<td>' + beneficio.Nombre + '</td>' +
                        '<td>' + beneficio.Descripcion + '</td>' +
                        '<td>' + beneficio.Valor + '</td>' +
                        '<td>' +
                            '<button class="btn btn-danger btnBorrar" id="' + beneficio.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button>' +
                            '<button class="btn btn-warning btnVentanaEditar" id="' + beneficio.Id + '"><span class="glyphicon glyphicon-pencil"></span> Editar</button>' +
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
                    var idBeneficio = $(this).attr("id");

                    // Se elimina el beneficio
                    eliminarBeneficio(idBeneficio);
                });

                // Evento para el nuevo botón de editar
                $(".btnVentanaEditar").click(function () {

                    // Antes de abrir la ventana se escribirán los detalles del Beneficio pasado.
                    buscarBeneficio($(this).attr("id"), function (beneficio) {
                        $("#txtIdBeneficio_editar").val(beneficio.Id);
                        $("#cmbTipoBeneficio_editar").val(beneficio.IdTipoBeneficio);
                        $("#txtNombreBeneficio_editar").val(beneficio.Nombre);
                        $("#txtDescripcionBeneficio_editar").text(beneficio.Descripcion);
                        $("#txtValorBeneficio_editar").val(beneficio.Valor);
                        // Se abre la ventana para editar un grupo
                        $("#ventanaEditarBeneficio").modal("show");
                    });

                });// Fin del evento para el boton editar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

            // Se refrescan las opciones de los tipos de beneficios del modal Agregar nuevo beneficio
            llenarOpcionesDeTiposDeBeneficios();

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}

/**
* Caso de uso: Buscar Beneficio por Id
**/
function buscarBeneficio(id, onSuccess) {
    $.ajax({
        url: server + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nuevo Beneficio
**/
function agregarBeneficio(obj) {
    $.ajax({
        url: server + "/crear",
        type: "GET",
        data: {
            'id_tipo_beneficio': obj.idTipoBeneficio,
            'nombre': obj.nombre,
            'descripcion': obj.descripcion,
            'valor': obj.valor
        },
        success: function (resultado) {
            $("#ventanaAgregarBeneficio").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de crear el Beneficio\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Editar beneficio
**/
function editarBeneficio(obj) {
    $.ajax({

        url: server + "/actualizar",
        type: "GET",
        data: {
            'id': obj.id,
            'id_tipo_beneficio': obj.idTipoBeneficio,
            'nombre': obj.nombre,
            'descripcion': obj.descripcion,
            'valor': obj.valor
        },
        success: function (resultado) {
            $("#ventanaEditarBeneficio").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de modificar el Beneficio\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Eliminar Beneficio
**/
function eliminarBeneficio(id) {
    $.ajax({
        url: server + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar el Beneficio\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Buscar Tipo de Beneficio por Id de Beneficio
**/
function buscarTipoBeneficioPorIdBeneficio(idBeneficio, onSuccess) {
    $.ajax({
        url: server + "/tipo_beneficio?idBeneficio=" + idBeneficio,
        type: "GET",
        dataType: "json",
        async: false,
        success: onSuccess
    });
}


/*
/**
* Caso de uso: Listar tipos de beneficios
* Llena las opciones del ComboBox Tipos de beneficios
**/
function llenarOpcionesDeTiposDeBeneficios() {

    // Se eliminan todos las opciones previo a llenarlo de nuevo
    $("#cmbTipoBeneficio_agregar").html("");
    $("#cmbTipoBeneficio_agregar").append('<option value="0" style="display:none;" selected="selected" >--Seleccione un tipo de beneficio--</option>');
    $("#cmbTipoBeneficio_editar").html("");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosBeneficios.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/tipos_de_beneficios",
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
            resultado.forEach(function (tipoBeneficio) {

                // Se construye la opción para el ComboBox.
                var opcion = '<option value="' + tipoBeneficio.Id + '">' + tipoBeneficio.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbTipoBeneficio_agregar").append(opcion);
                $("#cmbTipoBeneficio_editar").append(opcion);

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}
