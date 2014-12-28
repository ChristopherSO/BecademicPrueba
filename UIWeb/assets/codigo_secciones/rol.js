/**
* Roles
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
    $("#formularioAgregarRol").validationEngine();
    $("#formularioEditarRol").validationEngine();


    /**
    * Evento para agregar usuarios
    * Este evento se dispara cuando alguien presiona el boton de guardar en el formulario para agregar nuevos usuarios
    **/
    $("#formularioAgregarRol").submit(function (e) {

        e.preventDefault();

        var nuevoRol = {
            "nombre": $("#txtNombreRol_agregar").val(), "descripcion": $("#txtDescripcionRol_agregar").val(), "fase": $("#cmbFaseRol_agregar").val()
        };

        agregarRol(nuevoRol);

    });

    /**
    * Evento para editar usuarios
    * Este evento se dispara cuando alguien presiona el boton de editar en el formulario para editar usuario
    **/
    $("#formularioEditarUsuario").submit(function (ev) {

        ev.preventDefault();

        var nuevoDatosRol = {
            "id": $("#txtIdRol_editar").val(), "nombre": $("#txtNombreRol_editar").val(), 
            "descripcion": $("#txtDescripcionRol_editar").val(), "fase": $("#cmbFaseRol_editar").val()
        };

        editarRol(nuevoDatosRol);

    });


    $("#btnAsignarPermiso").submit(function (e) {

        e.preventDefault();

        var obj = { "idPermiso": $("#cmbPermisoRol").val() };

        asignarRol(obj);


    });


});
/******************************
******************************/

/**
Variable global que indentifica la direccion del webservice hacia el cual se deben hacer las peticiones
**/
var server = "http://localhost:14623/ModuloSeguridad/ServiciosRol.svc";

/**
Variable global que identifica el usuario al que se le sera asignado o removido un rol
**/
var idUser;

/**
* Caso de uso: Listar usuarios
* Refresca el contenido de la tabla de usuarios
**/
function refrescarTabla() {
    // Se elimina todo contenido previamente escrito en la tabla
    $("#contenidoTabla").html("");

    $("#ventanaLoader").modal("show");

    /**
    Llamada JQuery/AJAX
    Esta llamada hace una peticion GET hacia el UriTemplate = "/todos" que se encuentra en el WebGet del Webservice REST ServicioUsuario.svc
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
                // Se añade la columna para el seg nombre.
                fila += "<td>" + item.Descripcion + "</td>";
                //Se agrega el boton para mostrar los roles de un usuario.
                fila += '<td> <button class="btn btn-info btnPermisos" id="' + item.Id + '" data-toggle="modal" data-target="#ventanaPermisoRol"><span class="glyphicon glyphicon-tag" ></span> Permisos</button> </td>';
                // Se añade la columna para los botones de borrar y editar.
                fila += '<td> <button class="btn btn-danger btnBorrar" id="' + item.Id + '"> <span class="glyphicon glyphicon-trash"></span> Borrar</button>  <button class="btn btn-warning btnVentanaEditar" id="' + item.Id + '"><span class="glyphicon glyphicon-pencil"></span> Editar</button> </td>';
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
                    var idRol = $(this).attr("id");

                    // Se elimina el grupo
                    eliminarRol(idRol);


                });// Fin del boton eliminar correspondiente a esta fila


                // Evento para el nuevo boton de editar
                $(".btnVentanaEditar").click(function () {

                    // Antes de abrir la ventana se escribiran los detalles del usuario pasado.
                    buscarRol($(this).attr("id"), function (resultado) {

                        $("#txtIdRol_editar").val(resultado.Id)

                        $("#txtNombreRol_editar").val(resultado.Nombre);

                        $("#txtDescripcionRol_editar").val(resultado.Descripcion);

                        $("#cmbFaseRol_editar").val(resultado.Intervencion);

                        // Se abre la ventana para editar un grupo
                        $("#ventanaEditarRol").modal("show");

                    });

                });// Fin del evento para el boton editar correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

            $("#ventanaLoader").modal("hide");


            // Evento para el nuevo boton de roles
            $(".btnPermisos").click(function () {

                // Se obtiene el ID colocado en el atributo del boton
                var idRol = $(this).attr("id");

                // Lista permisos de este rol

                listarPermisoRol(idRol);


            });// Fin del boton roles correspondiente a esta fila

        }// Fin de la funcion SUCCESS



    });// Fin de la llamada AJAX

}


/**
* Caso de uso: Listar roles de un usuario
**/
function listarPermisoRol(idRol) {


    $.ajax({

        url: server + "/permisoRol/" + idRol,
        type: "GET",
        dataType: "json",
        crossDomain: true,

        success: function (resultado) {

            $("#tablaPermisoRol").empty();


            resultado.forEach(function (item) {

                // Se comienza a construir la fila para la tabla.
                var fila = "<tr>";
                // Se añade la columna para el id.
                fila += "<td>" + item.Id + "</td>";
                // Se añade la columna para el nombre.
                fila += "<td>" + item.Nombre + "</td>";
                // Se añade la columna para la descripcion.
                fila += "<td>" + item.Descripcion + "</td>";
                 // Se añade la columna para la descripcion.
                fila += "<td>" + item.Categoria + "</td>";
                //Se agrega el boton para mostrar los roles de un usuario.
                fila += '<td> <button class="btn btn-danger btnRemover" id="' + item.Id + '"> <span class="glyphicon glyphicon-trash"></span> Remover</button></td>';
                // Se termina de construir la fila.
                fila += "</tr>";

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de Grupos Musicales.
                $("#tablaPermisoRol").append(fila);

                /**
                * Dado que se estan generando botones de eliminar y editar en tiempo de ejecucion 
                * hay que decirle al JQuery que vuelva nuevamente a colocarles los Eventos.
                **/

                //Función que va a llenar el combobox con los nombres de los permisos.

                nombresPermiso();



                // Evento para el nuevo boton de remover
                $(".btnRemover").click(function () {

                    // Se obtiene el ID colocado en el atributo del boton
                    var idRol = $(this).attr("id");

                    // Se elimina el rol
                    removerPermisoRol(idPermiso,idRol);


                });// Fin del boton remover correspondiente a esta fila

            });// Fin de la iteracion entre los objetos del resultado

            $("#ventanaLoader").modal("hide");


        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX


}

function asignarPermisoRol(obj) {

    $.ajax({
        url: server + "/asignarPermiso",
        type: "GET",
        data: {
            'idPermiso': obj.idPermiso, 'idRol': idUser
        },

        success: function (resultado) {
            if (resultado == true) {
            }
            else {
                alert("Disculpe, hubo un error al momento de modificar el Rol por favor intente más tarde.");
            }
        }

    });
}

/**
* Caso de uso: Buscar usuario por Id
**/
function buscarRol(id, onSuccess) {
    $.ajax({
        url: server + "/detalles/" + id,
        type: "GET",
        dataType: "json",
        success: onSuccess
    });
}

/**
* Caso de uso: Agregar nuevo usuario
**/
function agregarRol(obj) {
    $.ajax({
        url: server + "/crear",
        type: "GET",
        data: {
            'nombre': obj.nombre, 'descripcion': obj.descripcion, 'fase': obj.fase},
            

        success: function (resultado) {
            $("#ventanaAgregarRol").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de crear el Rol por favor intente más tarde.");
            }
        }

    });
}

/**
* Llena las options del drop down menu
**/

function nombresPermiso() {

    $.ajax({

        url: server + "/permisos",
        type: "GET",
        dataType: "json",
        crossDomain: true,

        success: function (resultado) {

            $("#cmbPermisoRol").empty();

            resultado.forEach(function (item) {

                // Se comienza a construir la opcion para la tabla.
                var option = '<option value="' + item.Id + '">' + item.Nombre + '</option>';

                // Se ingresa esta columna dentro del espacio reservado para las filas dentro de la tabla de Grupos Musicales.
                $("#cmbPermisoRol").append(option);


            });// Fin de la iteracion entre los objetos del resultado

        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

}



/**
* Caso de uso: Editar usuario
**/
function editarRol(obj) {
    $.ajax({

        url: server + "/actualizar",
        type: "GET",
        data: {
            'id': obj.id, 'nombre': obj.nombre, 'descripcion': obj.descripcion, 'fase': obj.fase
        },
        success: function (resultado) {
            $("#ventanaEditarRol").modal("hide");
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de modificar el Rol por favor intente más tarde.");
            }
        }

    });
}


/**
* Caso de uso: Eliminar usuario
**/
function eliminarRol(id) {
    $.ajax({
        url: server + "/borrar/" + id,
        type: "GET",
        success: function (resultado) {
            if (resultado == true) {
                refrescarTabla();
            }
            else {
                alert("Disculpe, hubo un error al momento de eliminar el Rol por favor intente más tarde.");
            }
        }

    });

}