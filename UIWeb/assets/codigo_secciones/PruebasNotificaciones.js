
var serverBecas = "http://localhost:14623/ModuloBecas/ServiciosBecas.svc";

$(function () {

    $('#btnValidarBeca').click(function () {

        var idUsuario = $('#txtIdUsuario').val();
        var idCarrera = $('#txtIdCarrera').val();

        // Se elimina el beneficio
        validarBeca(idUsuario, idCarrera);
    });


});


function validarBeca(idUsuario, idCarrera) {
    $.ajax({
        url: serverBecas + "/validarBeca",
        type: "GET",
        data: {
            'idUsuario': idUsuario,
            'idCarrera': idCarrera
        },
        success: function (mensaje) {
            alert(mensaje);
        }

    });
}