/**
* Sistema de logeo de usuarios
**/
var server = "http://localhost:14623/ModuloSeguridad/ServiciosUsuario.svc";

$(function () {

    $("#ingresarBtn").click(function (e) {
        
        e.preventDefault();

        $.ajax({
            url: server + "/logeo",
            type: "GET",
            async: true,
            dataType: "json",
            data: {
                correo: $("#txtCorreo").val(),
                clave: $("#txtClave").val()
            },
            success: function (respuesta) {
                
                if (respuesta.Id > 0)
                {
                    $.sessionStorage.set("usuario_actual", respuesta);
                    window.location = '/Secciones/index.aspx';
                }
                else
                {
                    alert("Correo o contraseña incorrectos.");
                }

            }
        });

    });

    $("#logOutBtn").click(function (e) {
        $.removeAllStorages();
        window.location = '/index.aspx';
    });

    $("#recuperarBtn").click(function (e) {
        e.preventDefault();

        $.ajax({
            url: server + "/recuperar",
            type: "GET",
            async: true,
            dataType: "json",
            data: {
                correo: $("#txtRecuperar").val()
            },
            success: function (respuesta) {

                if (respuesta) {
                    alert("Su nueva contraseña ha sido enviada por correo electrónico");
                }
                else {
                    alert("El correo proporcionado no corresponde al de ningun usuario registrado en nuestro sistema.");
                }

            }
        });
    });

});

function usuarioLogeado()
{
    if ($.sessionStorage.isSet("usuario_actual"))
    {
        return $.sessionStorage.get("usuario_actual");
    }
    else
    {
        window.location = '/index.aspx';
    }
}

function validarPermisos()
{
    var usuarioActual = usuarioLogeado();

    var listaPermisos = Array();

    usuarioActual.LstRoles.forEach(function (rol) {
        rol.LstPermisos.forEach(function (permiso) {
            listaPermisos.push(permiso.Id);
        });
    });

    $(".validarPermiso").each(function (index) {
        if($(this).data("permiso"))
        {
            if (listaPermisos.indexOf($(this).data("permiso")) <= -1) {
                $(this).css({ "display": "none" });
            }
            console.log($(this));
        }
    });
}