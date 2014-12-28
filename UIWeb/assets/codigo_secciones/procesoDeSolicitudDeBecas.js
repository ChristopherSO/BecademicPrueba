/**
* Variables Globales
**/

// Origenes de datos
var usuarios = [];
var tiposDeBecas = [];

// Variables para la inscripcion
var idUsuario = null;
var idCarrera = null;
var idTipoDeBeca = null;
var estudio = 0;
var fecha = "";

/**
* Logica para el paso de seleccion de usuario interesado
**/
function seleccionarUsuarioPorCarnet(carnet) {
    var usuarioSeleccionado = null;
    usuarios.forEach(function (usuario) {
        if (usuario.Cedula == carnet) {
            usuarioSeleccionado = usuario;
        }
    });

    var contenidoUsuario = "";
    if (usuarioSeleccionado != null) {
        idUsuario = usuarioSeleccionado.Id;
        contenidoUsuario += '<p><b>Cedula: </b> ' + usuarioSeleccionado.Cedula + '</p>';
        contenidoUsuario += '<p><b>Nombre: </b> ' + usuarioSeleccionado.Nombre + " " + usuarioSeleccionado.PrimerApellido + '</p>';
        contenidoUsuario += '<p><b>Correo: </b> ' + usuarioSeleccionado.Correo + '</p>';
    }
    $("#infoUsuario").html(contenidoUsuario);

}

/**
* Logica para el paso de selecciona de carrera.
**/
function seleccionarCarrera() {
    var contenidoCarreras = '<ul>';

    tiposDeBecas.forEach(function (item) {

        var listaCarreras = [];

        item.LstCarreras.forEach(function (carreraA) {
            var existe = false;
            listaCarreras.forEach(function (carreraB) {
                if (carreraB.Nombre == carreraA.Nombre) {
                    existe = true;
                }
            });

            if (!existe)
                listaCarreras.push(carreraA);
        });

        listaCarreras.forEach(function (carreraAElegir) {
            contenidoCarreras += '<li><input class="carreraBtn" type="radio" onchange="seleccionarTipoBeca(this)" value="' + carreraAElegir.Id + '" name="carrera"> ' + carreraAElegir.Nombre + '</li>';
        });

    });

    contenidoCarreras += '</ul>';

    $("#seleccionarCarrera").html(contenidoCarreras);
}

/**
* Logica para el paso de seleccion del tipo de beca.
**/
function seleccionarTipoBeca(item) {

    idCarrera = item.value;

    var contenidoTipoDeBeca = "<ul>";

    tiposDeBecas.forEach(function (tipo) {
        var esElegible = false;
        tipo.LstCarreras.forEach(function (carrera) {
            if (carrera.Id = item.value) {
                esElegible = true;
            }
        });
        if (esElegible)
            contenidoTipoDeBeca += '<li><input type="radio" onchange="visualizarBeneficiosYRequisitos(this)" value="' + tipo.Id + '" name="tipo"> ' + tipo.Nombre + '</li>';
    });

    contenidoTipoDeBeca += "</ul>";

    $("#seleccionarTipo").html(contenidoTipoDeBeca);

}

/**
* Logica para los pasos de visualizacion de beneficios y requisitos.
**/
function visualizarBeneficiosYRequisitos(item) {

    var tipoDeBecaElegido = {};

    tiposDeBecas.forEach(function (tipo) {
        if (tipo.Id = item.value) {
            tipoDeBecaElegido = tipo;
        }
    });

    idTipoDeBeca = tipoDeBecaElegido.Id;

    var contenidoBeneficios = "<ul>";

    tipoDeBecaElegido.LstBeneficios.forEach(function (item) {
        contenidoBeneficios += '<li><b>' + item.Nombre + '</b><br>' + item.Descripcion + '</li>';
    });

    contenidoBeneficios += "</ul>";

    $("#listaBeneficios").html(contenidoBeneficios);

    var contenidoRequisitos = "<ul>";

    tipoDeBecaElegido.LstRequisitos.forEach(function (item) {
        contenidoRequisitos += '<li><b>' + item.Nombre + '</b><br>' + item.Descripcion + '</li>';
    });

    contenidoRequisitos += "</ul>";

    $("#listaRequisitos").html(contenidoRequisitos);

}

jQuery(function ($) {

    var server = "http://localhost:14623/ModuloBecas/ServiciosSolicitudes.svc";

    /**
    * Recoleccion de datos básicos
    **/
    $.ajax({

        url: server + "/productos",
        type: "GET",
        dataType: "json",
        crossDomain: true,
        async: false,
        success: function (resultado) {
            tiposDeBecas = resultado;
        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

    /**
    * Recoleccion de datos básicos
    **/
    $.ajax({

        url: server + "/postulantes",
        type: "GET",
        dataType: "json",
        crossDomain: true,
        async: false,
        success: function (resultado) {
            usuarios = resultado;
        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

    seleccionarCarrera();

    /**
    * Evento del boton de buscar usuario por id
    **/
    $("#buscarUsuarioBtn").click(function () {

        var idUsuario = $("#id_usuario_txt").val();

        seleccionarUsuarioPorCarnet(idUsuario);

    });

    $('[data-rel=tooltip]').tooltip();


    $('#fuelux-wizard')
    .ace_wizard({
        //step: 2 //optional argument. wizard will jump to step "2" at first
    })
    .on('change', function (e, info) {
        if (info.step == 1) {
            if (idUsuario == null) return false;
        }
        if (info.step == 2) {
            if (idCarrera == null) return false;
        }
        if (info.step == 3) {
            if (idTipoDeBeca == null) return false;
        }
    })
    .on('finished', function (e) {

        $.ajax({

            url: server + "/crear",
            type: "GET",
            dataType: "json",
            crossDomain: true,
            async: false,
            data: {
                "id_usuario": idUsuario,
                "id_carrera": idCarrera,
                "id_tipo_beca": idTipoDeBeca,
                "id_estudio": estudio,
                "fecha": "2014-12-12"
            },
            success: function (resultado) {

                bootbox.dialog({
                    message: "Proceso de solicitud completo, la nueva solicitud ha quedado registrada. ",
                    buttons: {
                        "success": {
                            "label": "Aceptar",
                            "className": "btn-sm btn-primary",
                            callback: function () {
                                window.location.reload();
                            }
                        }
                    }
                });

            },// Fin de la funcion SUCCESS
            fail: function () {
                bootbox.dialog({
                    message: "En este momento nuestros servidores se encuentran bajo mantenimiento<br>Su solicitud no fue inscrita adecuadamente, por favor regrese más tarde.",
                    buttons: {
                        "success": {
                            "label": "Aceptar",
                            "className": "btn-sm btn-danger",
                            callback: function () {
                                window.location.reload();
                            }
                        }
                    }
                });
            }

        });// Fin de la llamada AJAX

    }).on('stepclick', function (e) {
        //e.preventDefault();//this will prevent clicking and selecting steps
    });


    //jump to a step
    $('#step-jump').on('click', function () {
        var wizard = $('#fuelux-wizard').data('wizard')
        wizard.currentStep = 3;
        wizard.setState();
    });
    //determine selected step
    //wizard.selectedItem().step

});