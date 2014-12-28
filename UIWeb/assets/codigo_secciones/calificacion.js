/**
* Calificaciones
**/

/******************************
*   Inicializador del JQuery  *
******************************/

$(function () {

    // Al inicio se refresca la tabla con los ultimos datos que hayan sido agregados.
   
    /**
    * Se habilitan las validaciones de datos para los formularios
    **/
    $("#ventanaFiltrarEstudiantes").validationEngine();
    $("#ventanaAgregarCalificacion").validationEngine();
    $("#ventanaEditarCalificacion").validationEngine();


    $("#formularioFiltrarEstudiantes").submit(function (ev) {

        ev.preventDefault();

            

    });


    $("#formularioAgregarCalificacion").submit(function (e) {

        e.preventDefault();

        var nuevaCalificacion = {
            "idUsuario": $("#txtIdEstudiante_Agregar").val(),
            "idCurso": $("#cmbCursos_listar").val(),
            "nota": $("#txtNota_agregar").val(),
            "periodo": $("#txtPeriodo_agregar").val(),
            "annio": $("#txtAnnio_agregar").val(),
            "comentarios": $("#txtComentarios_agregar").val(),
        };

        agregarCalificacion(nuevaCalificacion);

    });

    $("#formularioEditarCalificacion").submit(function (eve) {

        eve.preventDefault();

        var nuevaCalificacion = {
            "idCalificacion": $("#txtIdCalificacion_editar").val(),
            "idCurso": $("#cmbCursos_editar").val(),
            "nota": $("#txtNota_editar").val(),
            "periodo": $("#txtPeriodo_editar").val(),
            "annio": $("#txtAnnio_editar").val(),
            "comentarios": $("#txtComentarios_editar").val(),
        };

        editarCalificacion(nuevaCalificacion);

    });

    actualizarCarreras();

    

});

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/

var serverCarreras = "http://localhost:14623/ModuloAcademico/ServicioCarrera.svc";

/**
* Caso de uso: actualizar carreras
* Refresca el contenido de el combobox de carreras
**/

function actualizarCarreras() {
    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: serverCarreras + "/todos",
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
            resultado.forEach(function (carrera) {

                var opcion = '<option value="' + carrera.Id + '">' + carrera.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbCarreras_listar").append(opcion); 

            });// Fin de la iteracion entre los objetos del resultado

            $(".btnListarEstudiante").click(function () {

                // Se obtiene el ID colocado en el atributo del boton
                var idCarreraActual = $("#cmbCarreras_listar").val();

                $("#txtIdCarrera_Filtrar").val(idCarreraActual);

                actualizarEstudiantesCarrera(idCarreraActual);


            });// Fin del boton eliminar correspondiente a esta fila

            

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}


function actualizarEstudiantesCarrera(idCarrera) {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: serverCarreras + "/listarEstudianteCarrera/" + idCarrera,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {
            $("#contenidoTablaEstudiantesCarreraCalificacion").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (estudiante) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + estudiante.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + estudiante.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-warning btnVerCalificaciones" id="' + estudiante.Id + '"> <span class="glyphicon glyphicon-trash"></span> Ver calificaciones</button>  <button class="btn btn-warning btnAgregarCalificacion" id="' + estudiante.Id + '"> <span class="glyphicon glyphicon-trash"></span> Agregar calificación</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTablaEstudiantesCarreraCalificacion").append(fila);

                // Evento para el nuevo boton de borrar

            });// Fin de la iteracion entre los objetos del resultado


                $(".btnAgregarCalificacion").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var pidEstudiante = $(this).attr("id");

                    $("#txtIdEstudiante_Agregar").val(pidEstudiante);

                    $("#ventanaAgregarCalificacion").modal("show");

                    actualizarCursosCarrera();


                });// Fin del boton eliminar correspondiente a esta fila


                $(".btnVerCalificaciones").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idEstudiante = $(this).attr("id");

                    $("#txtIdEstudiante_Filtrar").val(idEstudiante);


                    actualizarCalificaciones();

                    $("#ventanaFiltrarEstudiantes").modal("hide");


                });// Fin del boton eliminar correspondiente a esta fila


     

        }// Fin de la funcion SUCCESS



    });// Fin de la llamada AJAX

    $("#ventanaFiltrarEstudiantes").modal("show");
}


function actualizarCursosCarrera() {

    var idCarreraActual = $("#txtIdCarrera_Filtrar").val();
    /**
    Llamada JQuery/AJAX
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: serverCarreras + "/listarCursosCarrera/" + idCarreraActual,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#cmbCursos_listar").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (curso) {

                var opcion = '<option value="' + curso.Id + '">' + curso.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbCursos_listar").append(opcion); 

            });// Fin de la iteracion entre los objetos del resultado

                // Evento para el nuevo boton de borrar

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}



function actualizarCursosCarreraEditar() {

    var pidCarreraActual = $("#txtIdCarrera_Filtrar").val();
    /**
    Llamada JQuery/AJAX
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: serverCarreras + "/listarCursosCarrera/" + pidCarreraActual,
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
            resultado.forEach(function (curso) {

                var opcion = '<option value="' + curso.Id + '">' + curso.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbCursos_Editar").append(opcion);

            });// Fin de la iteracion entre los objetos del resultado

            // Evento para el nuevo boton de borrar

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var serverCalificaciones = "http://localhost:14623/ModuloAcademico/ServicioCalificacion.svc";


function actualizarCalificaciones() {

    var idEstudiante = $("#txtIdEstudiante_Filtrar").val();
    var idCarrera = $("#txtIdCarrera_Filtrar").val();

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: serverCalificaciones + "/todos/" + idEstudiante + "/" + idCarrera,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTabla").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (calificacion) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + calificacion.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + calificacion.IdUsuario + "</td>";
                fila += "<td>" + calificacion.IdCurso + "</td>";
                fila += "<td>" + calificacion.Nota + "</td>";
                fila += "<td>" + calificacion.Periodo + "</td>";
                fila += "<td>" + calificacion.Annio + "</td>";
                fila += "<td>" + calificacion.Comentarios + "</td>";
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-warning btnEditarCalificacion" id="' + calificacion.Id + '"> <span class="glyphicon glyphicon-trash"></span> Editar</button>   <button class="btn btn-danger btnBorrarCalificacion" id="' + calificacion.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTabla").append(fila);

                // Evento para el nuevo boton de borrar
                

            });// Fin de la iteracion entre los objetos del resultado

            $(".btnEditarCalificacion").click(function () {

                // Antes de abrir la ventana se escribiran los detalles del tipo de beca pasado.
                buscarCalificacion($(this).attr("id"), function (resultado) {

                    actualizarCursosCarreraEditar();

                    $("#txtIdCalificacion_editar").val(resultado.Id);

                    $("#txtNota_editar").val(resultado.Nota);

                    $("#txtPeriodo_editar").val(resultado.Periodo);

                    $("#txtAnnio_editar").val(resultado.Annio);

                    $("#txtComentarios_editar").val(resultado.Comentarios);

                    

                    // Se abre la ventana para editar un grupo
                    $("#ventanaEditarCalificacion").modal("show");

                });

            });// Fin del evento para el boton editar correspondiente a esta fila
              

            $(".btnBorrarCalificacion").click(function () {

                // Se obtiene el ID colocado en el atributo del boton
                var idCalificacion = $(this).attr("id");

                // Se elimina el grupo
                eliminarCalificacion(idCalificacion);


            });// Fin del boton eliminar correspondiente a esta fila

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}


function buscarCalificacion(id, onSuccess) {
    $.ajax({
        url: serverCalificaciones + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });


}



/**
* Caso de uso: Agregar nueva calificacion
**/
function agregarCalificacion(obj) {
    alert("entra aesta mierda");
    alert(obj.idCurso);
    alert(obj.idUsuario);
    $.ajax({
        url: serverCalificaciones + "/crear",
        type: "GET",
        data: {
            'idUsuario': obj.idUsuario,
            'idCurso': obj.idCurso,
            'nota': obj.nota,
            'periodo': obj.periodo,
            'annio': obj.annio,
            'comentarios': obj.comentarios
        },
        success: function (resultado) {
            $("#ventanaFiltrarEstudiantes").modal("hide");
                actualizarCalificaciones();

            }

    });
}


function editarCalificacion(obj) {
    $.ajax({

        url: serverCalificaciones + "/actualizar",
        type: "GET",
        data: {
            'idCalificacion': obj.idCalificacion,
            'idCurso': obj.idCurso,
            'nota': obj.nota,
            'periodo': obj.periodo,
            'annio': obj.annio,
            'comentarios': obj.comentarios
        },
        success: function (resultado) {
            $("#ventanaEditarCalificacion").modal("hide");
            actualizarCalificaciones();
        }

    });
}


function eliminarCalificacion(id) {
    $.ajax({
        url: serverCalificaciones + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            actualizarCalificaciones();
        }

    });

}

