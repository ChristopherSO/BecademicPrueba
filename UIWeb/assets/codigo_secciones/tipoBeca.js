/**
* Tipo de becas
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
    $("#formularioAgregarTipoBeca").validationEngine();
    $("#formularioEditarTipoBeca").validationEngine();
    $("#formularioBeneficiosBeca").validationEngine();


    /**
    * Evento para agregar grupos musicales
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para agregar nuevos tipos de beca
    **/
    $("#formularioAgregarTipoBeca").submit(function (e) {

        e.preventDefault();

        var resultado;
        if ($("#ckbSocioeconomico_agregar").is(':checked')) {
            resultado = true;
        } else {
            resultado = false;
        }

        var nuevoTipoBeca = { "cantidad": $("#txtCantidadTipoBeca_agregar").val(), "color": $("#txtColorTipoBeca_agregar").val(), "descripcion": $("#txtDescripcionTipoBeca_agregar").val(), "icono": $("#txtIconoTipoBeca_agregar").val(), "nombre": $("#txtNombreTipoBeca_agregar").val(), "socioeconomico": resultado };

        agregarTipoBeca(nuevoTipoBeca);

    });

    /**
    * Evento para editar tipos de beca
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para editar tipo de beca
    **/
    $("#formularioEditarTipoBeca").submit(function (ev) {

        ev.preventDefault();

        var resultado;
        if ($("#ckbSocioeconomico_editar").is(':checked')) {
            resultado = true;
        } else {
            resultado = false;
        }

        var nuevoDatosTipoBeca = { "color": $("#txtColor_editar").val(), "descripcion": $("#txtDescripcionTipoBeca_editar").val(), "icono": $("#txtIcono_editar").val(), "id": $("#txtIdTipoBeca_editar").val(), "nombre": $("#txtNombreTipoBeca_editar").val(), "socioeconomico": resultado, "cantidad": $("#txtCantidadTipoBeca_editar").val() };

        editarTipoBeca(nuevoDatosTipoBeca);
    });

    /**
    * Evento para asignar beneficios beca
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para asignar beneficios beca
    **/
    $("#formularioBeneficiosBeca").submit(function (eve) {

        eve.preventDefault();

        var datosBeneficioBeca = { "idTipoBeca": $("#txtIdTipoBecaBeneficio").val(), "idBeneficio": $("#cmbBeneficio_asignar").val() };

        asignarBeneficioBeca(datosBeneficioBeca);

    });

    /**
    * Evento para asignar requisitos beca
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para asignar requisitos beca
    **/
    $("#formularioRequisitosBeca").submit(function (even) {

        even.preventDefault();

        var datosRequisitosBeca = { "idTipoBeca": $("#txtIdTipoBecaRequisito").val(), "idRequisito": $("#cmbRequisito_asignar").val() };

        asignarRequisitoBeca(datosRequisitosBeca);

    });

    /**
    * Evento para asignar carreras beca
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para asignar carreras beca
    **/
    $("#formularioCarrerasBeca").submit(function (even) {

        even.preventDefault();

        var datosCarrerasBeca = { "idTipoBeca": $("#txtIdTipoBecaCarrera").val(), "idCarrera": $("#cmbCarrera_asignar").val() };

        asignarCarreraBeca(datosCarrerasBeca);

    });

});

/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var server = "http://localhost:14623/ModuloBecas/ServicioTipoBeca.svc";

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
                // Se añade la columna para los botones de borrar, editar y asignar beneficio, requisito y carrera.
                fila += '<td> <button class="btn btn-danger btnBorrar validarPermiso" data-permiso="5" id="' + item.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> <button class="btn btn-warning btnVentanaEditar" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Editar</button>  <button class="btn btn-info btnVentanaAsignarBeneficio" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Beneficios</button>  <button class="btn btn-info btnVentanaAsignarRequisito" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Requisitos</button>  <button class="btn btn-info btnVentanaAsignarCarrera" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Carreras</button> </td>';
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
                    var idTipoBeca = $(this).attr("id");

                    // Se elimina el tipo de beca
                    eliminarTipoBeca(idTipoBeca);


                });// Fin del boton eliminar correspondiente a esta fila

                // Evento para el nuevo boton de asignar beneficios
                $(".btnVentanaAsignarBeneficio").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idTipoBeca = $(this).attr("id");

                    // Se actualiza la tabla beneficio beca
                    actualizarBeneficioBeca(idTipoBeca);

                    $("#txtIdTipoBecaBeneficio").val(idTipoBeca);

                    // Se abre la ventana para asignar beneficios
                    $("#ventanaBeneficiosBeca").modal("show");

                });// Fin del boton asignar beneficios

                // Evento para el nuevo boton de asignar requisitos
                $(".btnVentanaAsignarRequisito").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idTipoBeca = $(this).attr("id");

                    $("#txtIdTipoBecaRequisito").val(idTipoBeca);

                    // Se actualiza la tabla requisito beca
                    actualizarRequisitoBeca(idTipoBeca);

                    // Se abre la ventana para asignar requisitos
                    $("#ventanaRequisitosBeca").modal("show");

                });// Fin del boton asignar requisitos

                // Evento para el nuevo boton de asignar carreras
                $(".btnVentanaAsignarCarrera").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idTipoBeca = $(this).attr("id");

                    $("#txtIdTipoBecaCarrera").val(idTipoBeca);

                    // Se actualiza la tabla carrera beca
                    actualizarCarreraBeca(idTipoBeca);

                    // Se abre la ventana para asignar carreras
                    $("#ventanaCarrerasBeca").modal("show");

                });// Fin del boton asignar requisitos

                // Evento para el nuevo boton de editar
                $(".btnVentanaEditar").click(function () {

                    // Antes de abrir la ventana se escribiran los detalles del tipo de beca pasado.
                    buscarTipoBeca($(this).attr("id"), function (resultado) {

                        $("#txtIdTipoBeca_editar").val(resultado.Id);

                        $("#txtNombreTipoBeca_editar").val(resultado.Nombre);

                        $("#txtDescripcionTipoBeca_editar").text(resultado.Descripcion);

                        $("#txtIcono_editar").val(resultado.Icono);

                        $("#txtColor_editar").val(resultado.Color);

                        //$("#ckbSocioeconomico_editar").val(resultado.Socioeconomico)

                        if (resultado.Socioeconomico == true) {
                            //$("#ckbSocioeconomico_editar").prop("checked");
                            $("#ckbSocioeconomico_editar").prop('checked', true);
                        } else {
                            $("#ckbSocioeconomico_editar").prop('checked', false);
                        }

                        $("#ckbSocioeconomico_editar").val(resultado.Socioeconomico);

                        $("#txtCantidadTipoBeca_editar").val(resultado.Cantidad);

                        // Se abre la ventana para editar un tipo de beca
                        $("#ventanaEditarTipoBeca").modal("show");

                    });

                });// Fin del evento para el boton editar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

            //Carga los datos a los combo box de los beneficios, requisitos y carreras
            actualizarBeneficios();
            actualizarRequisitos();
            actualizarCarreras();

            $("#ventanaLoader").modal("hide");

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

/**
* Llena el combobox de los beneficios registrados en el sistema
**/
function actualizarBeneficioBeca(idTipoBeca) {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/consultarBeneficiosBeca/" + idTipoBeca,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaBeneficiosBeca").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (beneficio) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + beneficio.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + beneficio.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                fila += "<td>" + beneficio.Descripcion + "</td>";
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-danger btnBorrarBeneficio" id="' + beneficio.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de beneficios de beca.
                $("#contenidoTablaBeneficiosBeca").append(fila);

                // Evento para el nuevo boton de borrar
                $(".btnBorrarBeneficio").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idBeneficio = $(this).attr("id");

                    // Se elimina el beneficio de beca
                    eliminarBeneficioBeca(idTipoBeca, idBeneficio);
                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

/**
* Llena el combobox de los requisitos registrados en el sistema
**/
function actualizarRequisitoBeca(idTipoBeca) {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarRequisitosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/consultarRequisitosBeca/" + idTipoBeca,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaRequisitosBeca").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (requisito) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + requisito.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + requisito.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                fila += "<td>" + requisito.Descripcion + "</td>";
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-danger btnBorrarRequisito" id="' + requisito.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de Requisitos de beca.
                $("#contenidoTablaRequisitosBeca").append(fila);

                // Evento para el nuevo boton de borrar
                $(".btnBorrarRequisito").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idRequisito = $(this).attr("id");

                    // Se elimina el beneficio de beca
                    eliminarRequisitoBeca(idTipoBeca, idRequisito);
                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

/**
* Llena el combobox de las carreras registradas en el sistema
**/
function actualizarCarreraBeca(idTipoBeca) {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/consultarBeneficiosBeca/" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/consultarCarrerasBeca/" + idTipoBeca,
        // Tipo de metodo a utilziar
        type: "GET",
        // Tipo de retorno esperado
        dataType: "json",
        // Es de servidor a servidor?
        crossDomain: true,
        // En caso de exito al recuperar informacion de la direccion del webservice
        success: function (resultado) {

            $("#contenidoTablaCarrerasBeca").html("");

            /**
            * Dado que el resultado es una coleccion de cadenas JSON, se puede iterar a travez de ellas mediante el metodo forEach
            **/
            resultado.forEach(function (carrera) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + carrera.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + carrera.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                fila += "<td>" + carrera.Descripcion + "</td>";
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-danger btnBorrarCarrera" id="' + carrera.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button> </td>';

                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de Requisitos de beca.
                $("#contenidoTablaCarrerasBeca").append(fila);

                // Evento para el nuevo boton de borrar
                $(".btnBorrarCarrera").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idCarrera = $(this).attr("id");

                    // Se elimina el beneficio de beca
                    eliminarCarreraBeca(idTipoBeca, idCarrera);
                });// Fin del boton eliminar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

function actualizarBeneficios() {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/beneficios",
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
            resultado.forEach(function (beneficio) {

                // Se construye la opción para el ComboBox.
                var opcion = '<option value="' + beneficio.Id + '">' + beneficio.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbBeneficio_asignar").append(opcion);

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

function actualizarRequisitos() {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/requisitos",
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
            resultado.forEach(function (requisito) {

                // Se construye la opción para el ComboBox.
                var opcion = '<option value="' + requisito.Id + '">' + requisito.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbRequisito_asignar").append(opcion);

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

function actualizarCarreras() {

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServiciosTipoBeca.svc
    **/
    $.ajax({
        // Direccion hacia donde hacer la llamada
        url: server + "/carreras",
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
            resultado.forEach(function (carrera) {

                // Se construye la opción para el ComboBox.
                var opcion = '<option value="' + carrera.Id + '">' + carrera.Nombre + '</option>';

                // Se ingresa esta opción dentro del ComboBox tanto del modal agregar como del modal editar.
                $("#cmbCarrera_asignar").append(opcion);

            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX
}

/**
* Caso de uso: Buscar tipo de beca por Id
**/
function buscarTipoBeca(id, onSuccess) {
    $.ajax({
        url: server + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nuevo tipo de beca
**/
function agregarTipoBeca(obj) {
    $.ajax({
        url: server + "/crear",
        type: "GET",
        data: { 'nombre': obj.nombre, 'descripcion': obj.descripcion, 'icono': obj.icono, 'color': obj.color, 'socioeconomico': obj.socioeconomico, 'cantidad': obj.cantidad },
        success: function (resultado) {
            $("#ventanaAgregarTipoBeca").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de crear el tipo de beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Asignar beneficio a tipo de beca
**/
function asignarBeneficioBeca(datos) {
    $.ajax({
        url: server + "/asignarBeneficioBeca",
        type: "GET",
        data: { 'idTipoBeca': datos.idTipoBeca, 'idBeneficio': datos.idBeneficio },
        success: function (resultado) {
            if (resultado == true) {
                alert("Se ha asignado exitosamente el beneficio");
                actualizarBeneficioBeca(datos.idTipoBeca);
                $("#ventanaBeneficiosBeca").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de asignar el beneficio al tipo de beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Asignar requisito a tipo de beca
**/
function asignarRequisitoBeca(datos) {
    $.ajax({
        url: server + "/asignarRequisitoBeca",
        type: "GET",
        data: { 'idTipoBeca': datos.idTipoBeca, 'idRequisito': datos.idRequisito },
        success: function (resultado) {
            if (resultado == true) {
                alert("Se ha asignado exitosamente el requisito");
                actualizarRequisitoBeca(datos.idTipoBeca);
                $("#ventanaRequisitosBeca").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de asignar el requisito al tipo de beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Asignar carrera a tipo de beca
**/
function asignarCarreraBeca(datos) {
    $.ajax({
        url: server + "/asignarCarreraBeca",
        type: "GET",
        data: { 'idTipoBeca': datos.idTipoBeca, 'idCarrera': datos.idCarrera },
        success: function (resultado) {
            if (resultado == true) {
                alert("Se ha asignado exitosamente la carrera");
                actualizarRequisitoBeca(datos.idTipoBeca);
                $("#ventanaCarrerasBeca").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de asignar la carrera al tipo de beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Editar grupo musical
**/
function editarTipoBeca(obj) {
    $.ajax({

        url: server + "/actualizar",
        type: "GET",
        data: { 'id': obj.id, 'nombre': obj.nombre, 'descripcion': obj.descripcion, 'icono': obj.icono, 'color': obj.color, 'socioeconomico': obj.socioeconomico, 'cantidad': obj.cantidad },
        success: function (resultado) {
            $("#ventanaEditarTipoBeca").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de modificar el tipo de beca\n\rpor favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Eliminar tipo de beca
**/
function eliminarTipoBeca(id) {
    $.ajax({
        url: server + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar el tipo de beca\n\rpor favor intente más tarde.");
            }
        }
    });
}

/**
* Caso de uso: Eliminar beneficio de beca
**/
function eliminarBeneficioBeca(idTipoBeca, idBeneficio) {
    $.ajax({
        url: server + "/eliminarBeneficioBeca/" + idTipoBeca + "/" + idBeneficio,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                actualizarBeneficioBeca(idTipoBeca);
                $("#ventanaBeneficiosBeca").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar el beneficio de beca\n\rpor favor intente más tarde.");
            }
        }
    });
}

/**
* Caso de uso: Eliminar requisito de beca
**/
function eliminarRequisitoBeca(idTipoBeca, idRequisito) {
    $.ajax({
        url: server + "/eliminarRequisitoBeca/" + idTipoBeca + "/" + idRequisito,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                actualizarRequisitoBeca(idTipoBeca);
                $("#ventanaRequisitosBeca").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar el requisito de beca\n\rpor favor intente más tarde.");
            }
        }
    });
}

/**
* Caso de uso: Eliminar carrera de beca
**/
function eliminarCarreraBeca(idTipoBeca, idCarrera) {
    $.ajax({
        url: server + "/eliminarCarreraBeca/" + idTipoBeca + "/" + idCarrera,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                actualizarCarreraBeca(idTipoBeca);
                $("#ventanaCarrerasBeca").modal("show");
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar la carrera de beca\n\rpor favor intente más tarde.");
            }
        }
    });
}