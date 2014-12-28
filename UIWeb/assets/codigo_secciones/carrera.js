/**
* Carreras
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
    $("#formularioAgregarCarrera").validationEngine();
    $("#formularioEditarCarrera").validationEngine();


    /**
    * Evento para agregar grupos musicales
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para agregar nuevos tipos de beca
    **/
    $("#formularioAgregarCarrera").submit(function (e) {

        e.preventDefault();

        var nuevaCarrera = {
            "nombre": $("#txtNombreCarrera_agregar").val(),
            "descripcion": $("#txtDescripcionCarrera_agregar").val(),
            "color": $("#txtColorCarrera_agregar").val(),
            "icono": $("#txtIconoCarrera_agregar").val()
        };

        agregarCarrera(nuevaCarrera);

    });

    /**
    * Evento para editar tipos de beca
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para editar tipo de beca
    **/
    $("#formularioEditarCarrera").submit(function (ev) {

        ev.preventDefault();

        var nuevoDatosCarrera = {
            "id": $("#txtIdCarrera_editar").val(),
            "nombre": $("#txtNombreCarrera_editar").val(),
            "descripcion": $("#txtDescripcionCarrera_editar").val(),
            "icono": $("#txtIconoCarrera_editar").val(),
            "color": $("#txtColorCarrera_editar").val()
        };

        editarCarrera(nuevoDatosCarrera);

    });


    $("#formularioCursosCarrera").submit(function (eve) {

        eve.preventDefault();

        var datosCursosCarrera = {
            "idCurso": $("#txtIdCursoMarcado").val(),
            "idCarrera": $("#txtIdCursoCarrera").val(),
            "periodo": $("#txtPeriodo_asignar").val()
        };

        asignarCursoCarrera(datosCursosCarrera);

    });

    $("#formularioDirectoresCarrera").submit(function (even) {

        even.preventDefault();

        var datosDirectorCarrera = {
            "idDirector": $("#cmbDirector_asignar").val(),
            "idCarrera": $("#txtIdDirectorCarrera").val()
        };

        asignarDirectorCarrera(datosDirectorCarrera);

    });

    $("#formularioEstudiantesCarrera").submit(function (even) {

        even.preventDefault();

        var datosEstudianteCarrera = {
            "idEstudiante": $("#txtIdEstudianteMarcado").val(),
            "idCarrera": $("#txtIdEstudianteCarrera").val()
        };

        asignarEstudianteCarrera(datosEstudianteCarrera);

    });

});

/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var server = "http://localhost:14623/ModuloAcademico/ServiciosCarrera.svc";

/**
* Caso de uso: Listar tipos de beca
* Refresca el contenido de la tabla de tipos de beca
**/
function refrescarTabla() {
    // Se elimina todo contenido previamente escrito en la tabla
    $("#contenidoTabla").html("");

    $("#ventanaLoader").modal("show");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServicioTipoBeca.svc
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
            resultado.forEach(function (item) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + item.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + item.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                fila += "<td>" + item.Descripcion + "</td>";
                // Se añade la columna para el icono.
                fila += "<td>" + item.Icono + "</td>";
                // Se añade la columna para el color.
                fila += "<td>" + item.Color + "</td>";
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-danger btnBorrar" id="' + item.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button>  <button class="btn btn-warning btnVentanaEditar" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Editar</button>  <button class="btn btn-info btnVentanaAsignarCurso" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Cursos</button>  <button class="btn btn-info btnVentanaAsignarDirector" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Director académico</button>  <button class="btn btn-info btnVentanaAsignarEstudiante" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Estudiantes</button> </td>';
                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de Grupos Musicales.
                $("#contenidoTabla").append(fila);

                /**
                * Dado que se estan generando botones de eliminar y editar en tiempo de ejecucion 
                * hay que decirle al JQuery que vuelva nuevamente a colocarles los Eventos.
                **/

                // Evento para el nuevo boton de borrar
                $(".btnBorrar").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idCarrera = $(this).attr("id");

                    // Se elimina el grupo
                    eliminarCarrera(idCarrera);


                });// Fin del boton eliminar correspondiente a esta fila

                // Evento para el nuevo boton de editar
                $(".btnVentanaEditar").click(function () {

                    // Antes de abrir la ventana se escribiran los detalles del tipo de beca pasado.
                    buscarCarrera($(this).attr("id"), function (resultado) {

                        $("#txtIdCarrera_editar").val(resultado.Id);

                        $("#txtNombreCarrera_editar").val(resultado.Nombre);

                        $("#txtDescripcionCarrera_editar").val(resultado.Descripcion);

                        $("#txtIconoCarrera_editar").val(resultado.Icono);

                        $("#txtColorCarrera_editar").val(resultado.Color);

                        // Se abre la ventana para editar un grupo
                        $("#ventanaEditarCarrera").modal("show");

                    });

                });// Fin del evento para el boton editar correspondiente a esta fila


                // Evento para el nuevo boton de asignar carreras
                $(".btnVentanaAsignarCurso").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idCurso = $(this).attr("id");

                    // Se actualiza la tabla beneficio beca
                    actualizarCursosCarrera(idCurso);

                    $("#txtIdCursoCarrera").val(idCurso);

                    // Se abre la ventana para asignar beneficios
                    $("#ventanaCursosCarrera").modal("show");

                });// Fin del boton asignar curso

                // Evento para el nuevo boton de asignar directores academicos
                $(".btnVentanaAsignarDirector").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idDirector = $(this).attr("id");

                    // Se actualiza la tabla beneficio beca
                    actualizarDirectoresCarrera(idDirector);

                    $("#txtIdDirectorCarrera").val(idDirector);

                    // Se abre la ventana para asignar beneficios
                    $("#ventanaDirectoresCarrera").modal("show");

                });// Fin del boton asignar director

                $(".btnVentanaAsignarEstudiante").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idEstudiante = $(this).attr("id");

                    // Se actualiza la tabla beneficio beca
                    actualizarEstudiantesCarrera(idEstudiante);

                    $("#txtIdEstudianteCarrera").val(idEstudiante);

                    // Se abre la ventana para asignar beneficios
                    $("#ventanaEstudiantesCarrera").modal("show");

                });// Fin del boton asignar carreras


            });// Fin de la iteracion entre los objetos del resultado

            actualizarCursos();
            actualizarDirectores();
            actualizarEstudiantes();

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX


}



function actualizarCursosCarrera(idCarrera) {

    /**
    Llamada JQuery/AJAX
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/listarCursosCarrera/" + idCarrera,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaCursosCarrera").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (curso) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + curso.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + curso.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-danger btnBorrarCurso" id="' + curso.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTablaCursosCarrera").append(fila);

                // Evento para el nuevo boton de borrar
                $(".btnBorrarCurso").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idCurso = $(this).attr("id");

                    // Se elimina el beneficio de beca
                    eliminarCursoCarrera(idCurso, idCarrera);
                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}


function actualizarDirectoresCarrera(idCarrera) {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/listarDirectorCarrera/" + idCarrera,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaDirectoresCarrera").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (director) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + director.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + director.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-danger btnBorrarDirector" id="' + director.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTablaDirectoresCarrera").append(fila);

                // Evento para el nuevo boton de borrar
                $(".btnBorrarDirector").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idDirector = $(this).attr("id");

                    // Se elimina el beneficio de beca
                    eliminarDirectorCarrera(idDirector, idCarrera);
                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

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
        url: server + "/listarEstudianteCarrera/" + idCarrera,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaEstudiantesCarrera").html("");

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
                fila += '<td> <button class="btn btn-danger btnBorrarEstudiante" id="' + estudiante.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTablaEstudiantesCarrera").append(fila);

                // Evento para el nuevo boton de borrar
                $(".btnBorrarEstudiante").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idEstudiante = $(this).attr("id");

                    // Se elimina el beneficio de beca
                    eliminarEstudianteCarrera(idEstudiante, idCarrera);
                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}


function actualizarCursos() {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/cursos",
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaCursos").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (curso) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + curso.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + curso.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-info btnMarcarCurso" id="' + curso.Id + '"> <span class="glyphicon glyphicon-trash"></span> Seleccionar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTablaCursos").append(fila);

                $(".btnMarcarCurso").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idCursoMarcadoActual = $(this).attr("id");

                    $("#txtIdCursoMarcado").val(idCursoMarcadoActual);

                    // Se elimina el beneficio de beca
                    // eliminarCursoCarrera(idCurso, idCarrera);
                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}


function actualizarDirectores() {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/directores",
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
            resultado.forEach(function (director) {

                var opcion = '<option value="' + director.Id + '">' + director.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbDirector_asignar").append(opcion);

               

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}


function actualizarEstudiantes() {

    
    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/estudiantes",
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaEstudiantes").html("");

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
                fila += '<td> <button class="btn btn-info btnMarcarEstudiante" id="' + estudiante.Id + '"> <span class="glyphicon glyphicon-trash"></span> Seleccionar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTablaEstudiantes").append(fila);

                 //Evento para el nuevo boton de borrar
                $(".btnMarcarEstudiante").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idEstudianteMarcadoActual = $(this).attr("id");

                    $("#txtIdEstudianteMarcado").val(idEstudianteMarcadoActual);


                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado


        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}




/**
* Caso de uso: Buscar tipo de beca por Id
**/
function buscarCarrera(id, onSuccess) {
    $.ajax({
        url: server + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nueva carrera
**/
function agregarCarrera(obj) {
    $.ajax({
        url: server + "/crear",
        type: "GET",
        data: {
            'nombre': obj.nombre,
            'descripcion': obj.descripcion,
            'icono': obj.icono,
            'color': obj.color
        },
        success: function (resultado) {
            $("#ventanaAgregarCarrera").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de crear la carrera\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Editar grupo musical
**/
function editarCarrera(obj) {
    $.ajax({

        url: server + "/actualizar",
        type: "GET",
        data: { 'id': obj.id, 'nombre': obj.nombre, 'descripcion': obj.descripcion, 'icono': obj.icono, 'color': obj.color },
        success: function (resultado) {
            $("#ventanaEditarCarrera").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                refrescarTabla();
            }
        }

    });
}

/**
* Caso de uso: Eliminar carrera
**/
function eliminarCarrera(id) {
    $.ajax({
        url: server + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar la carrera\n\rpor favor intente más tarde.");
            }
        }

    });

}

function asignarCursoCarrera(datos) {
    $.ajax({
        url: server + "/asignarCursoCarrera",
        type: "GET",
        data: {
            'idCurso': datos.idCurso,
            'idCarrera': datos.idCarrera,
            'periodo': datos.periodo
        },
        success: function (resultado) {
            if (resultado == true) {
                alert("Se ha asignado exitosamente el curso.");
                actualizarCursosCarrera(datos.idCarrera);
                $("#ventanaCursosCarrera").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de asignar el curso a la carrera\n\rpor favor intente más tarde.");
            }
        }

    });
}


function eliminarCursoCarrera(idCurso, idCarrera) {
    $.ajax({
        url: server + "/borrarCursoCarrera/" + idCurso + "/" + idCarrera,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                actualizarCursosCarrera(idCarrera);
                $("#ventanaCursosCarrera").modal("show");
            }
            else {
                actualizarCursosCarrera(idCarrera);
            }
        }
    });
}


function asignarDirectorCarrera(datos) {
    $.ajax({
        url: server + "/asignarDirectorCarrera",
        type: "GET",
        data: { 'idDirector': datos.idDirector, 'idCarrera': datos.idCarrera},
        success: function (resultado) {
            if (resultado == true) {
                alert("Se ha asignado exitosamente el director académico.");
                actualizarDirectoresCarrera(datos.idCarrera);
                $("#ventanaDirectoresCarrera").modal("show");
            }
            else {
            }
        }

    });
}

function eliminarDirectorCarrera(idDirector, idCarrera) {
    $.ajax({
        url: server + "/borrarDirectorCarrera/" + idDirector + "/" + idCarrera,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                actualizarDirectoresCarrera(idCarrera);
                $("#ventanaDirectoresCarrera").modal("show");
            }
            else {

                $("#ventanaDirectoresCarrera").modal("show");
                actualizarDirectoresCarrera(idCarrera);
            }
        }
    });
}


function asignarEstudianteCarrera(datos) {

    $.ajax({
        url: server + "/asignarEstudianteCarrera",
        type: "GET",
        data: { 'idEstudiante': datos.idEstudiante, 'idCarrera': datos.idCarrera },
        success: function (resultado) {
            if (resultado == true) {
                alert("Se ha asignado exitosamente el director académico.");
                actualizarEstudiantesCarrera(datos.idCarrera);
                $("#ventanaEstudiantesCarrera").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de asignar el curso a la carrera\n\rpor favor intente más tarde.");
            }
        }

    });
}


function eliminarEstudianteCarrera(idEstudiante, idCarrera) {

    $.ajax({
        url: server + "/borrarEstudianteCarrera/" + idEstudiante + "/" + idCarrera,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                actualizarEstudiantesCarrera(idCarrera);
                $("#ventanaEstudiantesCarrera").modal("show");
            }
            else {
                actualizarEstudiantesCarrera(idCarrera);
                $("#ventanaEstudiantesCarrera").modal("show");
            }
        }
    });
}


