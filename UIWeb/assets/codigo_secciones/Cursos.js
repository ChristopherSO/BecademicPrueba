/**
* Cursos
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
    $("#formularioAgregarCurso").validationEngine();
    $("#formularioEditarCurso").validationEngine();

    /**
    * Evento para agregar Cursos
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para agregar nuevos Cursos
    **/
    $("#formularioAgregarCurso").submit(function (e) {

        e.preventDefault();

        var nuevoCurso = {
            "nombre": $("#txtNombreCurso_agregar").val(),
            "codigo": $("#txtCodigoCurso_agregar").val(),
            "precio": $("#txtPrecioCurso_agregar").val(),
            "cantidad_creditos": $("#txtCantidadCreditoCurso_agregar").val()
        };

        agregarCurso(nuevoCurso);
    });

    /**
    * Evento para editar curso
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para editar Curso
    **/
    $("#formularioEditarCurso").submit(function (ev) {

        ev.preventDefault();

        var nuevoDatosCurso = {

        //// Antes de abrir la ventana se escribiran los detalles del grupo pasado.
        //buscarCurso(idCurso, function (Curso) 

            "id": $("#txtIdCurso_editar").val(),
            "nombre": $("#txtNombreCurso_editar").val(),
            "codigo": $("#txtCodigoCurso_editar").val(),
            "precio": $("#txtPrecioCurso_editar").val(),
            "cantidad_creditos": $("#txtCantidadCreditoCurso_editar").val()
        };

        editarCurso(nuevoDatosCurso);
    });

});
/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var server = "http://localhost:14623/ModuloAcademico/ServiciosCurso.svc";

/**
* Caso de uso: Listar Cursos
* Refresca el contenido de la tabla de curso
**/
function refrescarTabla() {
    // Se elimina todo contenido previamente escrito en la tabla
    $("#contenidoTabla").html("");

    $("#ventanaLoader").modal("show");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosCursos.svc
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
            resultado.forEach(function (Curso) {

                /**
                * Se hace llamado a la función para tomar el Curso al que el Curso está
                * asociado, para luego tomar el nombre de Curso
                **/

                // Se comienza a construir la fila para la tabla.
                var fila = '' +
                    '<tr>' +
                        '<td>' + Curso.Id + '</td>' +
                        '<td>' + Curso.Nombre + '</td>' +
                        '<td>' + Curso.Codigo + '</td>' +
                        '<td>' + Curso.Precio + '</td>' +
                        '<td>' + Curso.CantidadCreditos + '</td>' +
                        '<td> <button class="btn btn-danger btnBorrar" id="' + Curso.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> <button class="btn btn-warning btnVentanaEditar" id="' + Curso.Id + '"><span class="glyphicon glyphicon-pencil"></span> Editar</button> </td>' +
                    '</tr>';

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla.
                $("#contenidoTabla").append(fila);

            });// Fin de la iteracion entre los objetos del resultado

            /**
            * Dado que se estan generando botones de eliminar y editar en tiempo de ejecucion 
            * hay que decirle al JQuery que vuelva nuevamente a colocarles los Eventos.
            **/

            // Evento para el nuevo boton de borrar
            $(".btnBorrar").click(function () {

                // Se obtiene el ID colocado en el atributo del boton
                var idCurso = $(this).attr("id");

                //// Se elimina el Curso
                eliminarCurso(idCurso);
            });

            // Evento para el nuevo botón de editar
            $(".btnVentanaEditar").click(function () {

                // Antes de abrir la ventana se escribirán los detalles del Curso pasado.

                // Se obtiene el ID colocado en el atributo del boton
                var idCurso = $(this).attr("id");

                // Antes de abrir la ventana se escribiran los detalles del grupo pasado.
                buscarCurso(idCurso, function (Curso) {

                    $("#txtIdCurso_editar").val(Curso.Id);

                    $("#txtNombreCurso_editar").val(Curso.Nombre);

                    $("#txtCodigoCurso_editar").val(Curso.Codigo);

                    $("#txtPrecioCurso_editar").val(Curso.Precio);

                    $("#txtCantidadCreditoCurso_editar").val(Curso.CantidadCreditos);

                    // Se abre la ventana para editar un grupo
                    $("#ventanaEditarCurso").modal("show");

                });

            });// Fin del evento para el boton editar correspondiente a esta fila

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}

/**
* Caso de uso: Buscar Curso por Id
**/
function buscarCurso(id, onSuccess) {
    $.ajax({
        url: server + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nuevo Curso
**/
function agregarCurso(obj) {
    $.ajax({
        url: server + "/crear",
        type: "GET",
        data: {
            'nombre': obj.nombre,
            'codigo': obj.codigo,
            'precio': obj.precio,
            'cantidad_creditos': obj.cantidad_creditos,
        },
        success: function (resultado) {
            $("#formularioAgregarCurso").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de crear el Curso\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Editar Curso
**/
function editarCurso(obj) {
    $.ajax({

        url: server + "/actualizar",
        type: "GET",
        data: {
            'id': obj.id,
            'nombre': obj.nombre,
            'codigo': obj.codigo,
            'precio': obj.precio,
            'cantidad_creditos': obj.cantidad_creditos,
        },
        success: function (resultado) {
            $("#ventanaEditarCurso").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de modificar el Curso\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Eliminar Curso
**/
function eliminarCurso(id) {
    $.ajax({
        url: server + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar el Curso\n\rpor favor intente más tarde.");
            }
        }

    });
}