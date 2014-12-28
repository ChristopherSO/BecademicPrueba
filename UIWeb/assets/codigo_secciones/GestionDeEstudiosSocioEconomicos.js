/**
* Variables globales
**/
var listaSolicitudes = [];

/**
* Lista todas las solicitudes que requiren un estudio socioeconomico
**/
function listarSolicitudes()
{
    var contenidoTabla = "";
    // Recorre la cadena de todas las solicitudes para determinar cuales ocupan un estudio socioeconomico
    listaSolicitudes.forEach(function (solicitud) {
        if (solicitud.TipoDeBeca.Socioeconomico)
        {
            contenidoTabla += '<tr>';

            contenidoTabla += '<td>' + solicitud.Usuario.Nombre + '</td>';
            contenidoTabla += '<td>' + solicitud.TipoDeBeca.Nombre + '</td>';
            contenidoTabla += '<td>' + solicitud.Carrera.Nombre + '</td>';
            
            if (solicitud.EstudioSocioEconomico.Id > 0)
            {
                if (solicitud.EstudioSocioEconomico.esElegible) {
                    contenidoTabla += '<td><span class="badge badge-success">Sí es elegible.</span></td>';
                }
                else
                {
                    contenidoTabla += '<td><span class="badge badge-danger">No es elegible.</span></td>';
                }
                contenidoTabla += '<td><button class="btn btn-warning">Ver resultados</button></td>';
            }
            else
            {
                contenidoTabla += '<td><span class="badge badge-warning">Estudio pendiente.</span></td>';
                contenidoTabla += '<td><button class="btn btn-primary realizarEstudioBtn" data-idsolicitud="' + solicitud.Id + '" data-toggle="modal" data-target="#formularioSocioEconomico">Realizar un estudio</button></td>';
            }

            contenidoTabla += '</tr>';
        }

        $('#formularioSocioEconomico').on('show.bs.modal', function (event) {
            var button = $(event.relatedTarget);
            var idsolicitud = button.data('idsolicitud');
            
            
            $("#idsolicitud_txt").val(idsolicitud);

        })
        
    });
    $("#tablaSolicitudes").html(contenidoTabla);
}

/**
* Visualizar estudios socioeconomicos
**/
function visualizarEstudioSocioEconomico(id)
{

}

/**
* Init
**/
$(function () {

    var server = "http://localhost:14623/ModuloBecas/ServiciosSolicitudes.svc";
    var serverEstudios = "http://localhost:14623/ModuloBecas/ServiciosEstudios.svc";

    /**
    * Recoleccion de datos básicos
    **/
    $.ajax({

        url: server + "/todos",
        type: "GET",
        dataType: "json",
        crossDomain: true,
        async: false,
        success: function (resultado) {
            listaSolicitudes = resultado;
        }// Fin de la funcion SUCCESS

    });// Fin de la llamada AJAX

    console.log(listaSolicitudes);

    listarSolicitudes();

    /**
    Logica del estudio socioeconomico
    **/
    $('#fecha_nacimiento_txt').datepicker();

    $("#formularioEstudioSocioEconomico").validationEngine();

    /**
	* Manejo de la fecha	
	*/
    $("#fecha_nacimiento_txt").change(function (e) {

        var fecha_actual = new Date();
        var fecha_nacimiento = new Date($(this).val());

        if (fecha_actual > fecha_nacimiento) {
            var diferenciaDeFechas = Date.now() - fecha_nacimiento.getTime();
            var fechaDiferenciada = new Date(diferenciaDeFechas);
            var resultado = Math.abs(fechaDiferenciada.getUTCFullYear() - 1970);

            $("#edad_txt").val(resultado);
        }
        else {
            $("#edad_txt").val(0);
        }

    });

    /**
	 * Script que genera de forma dinamica la seleccion de provincias, cantones y distritos
	 */
    var ubicaciones = new gestorDeUbicaciones();

    ubicaciones.listarProvincias().forEach(function (provincia) {

        $("#provinciaSelect").append('<option data-peso="' + provincia.peso + '" value="' + provincia.id + '">' + provincia.nombre + '</option>');

        ubicaciones.listarCantonesDeProvincia(provincia.id).forEach(function (canton) {

            $("#cantonSelect").append('<option value="' + canton.canton + '">' + canton.nombre + '</option>');

        });

        ubicaciones.listarDistritosDeCanton(provincia.id, 1).forEach(function (distrito) {

            $("#distritoSelect").append('<option value="' + distrito.distrito + '">' + distrito.nombre + '</option>');

        });

    });

    $("#provinciaSelect").change(function (e) {

        $("#cantonSelect").html("");
        $("#distritoSelect").html("");

        ubicaciones.listarCantonesDeProvincia($("#provinciaSelect").val()).forEach(function (canton) {

            $("#cantonSelect").append('<option value="' + canton.canton + '">' + canton.nombre + '</option>');

        });

        ubicaciones.listarDistritosDeCanton($("#provinciaSelect").val(), $("#cantonSelect").val()).forEach(function (distrito) {

            $("#distritoSelect").append('<option value="' + distrito.distrito + '">' + distrito.nombre + '</option>');

        });

    });

    $("#cantonSelect").change(function (e) {

        $("#distritoSelect").html("");

        ubicaciones.listarDistritosDeCanton($("#provinciaSelect").val(), $("#cantonSelect").val()).forEach(function (distrito) {

            $("#distritoSelect").append('<option value="' + distrito.distrito + '">' + distrito.nombre + '</option>');

        });

    });

    /**
	 * Funcionalidad basica para el formulario socioeconomico
	 */
    $("#formularioEstudioSocioEconomico").submit(function (e) {

        e.preventDefault();

        /**
		 * Datos informativos del solicitante
		 */
        var nombre = $("#nombre_txt").val();
        var apellidos = $("#apellidos_txt").val();
        var cedula = $("#cedula_txt").val();
        var fecha = $("#fecha_nacimiento_txt").val();
        var edad = $("#edad_txt").val();
        var nacionalidad = $("#nacionalidadSelect").val();
        var provincia = $("#provinciaSelect option:selected").text();
        var canton = $("#cantonSelect option:selected").text();
        var distrito = $("#distritoSelect option:selected").text();
        var zona = $('input[name="zona"]:checked').val();
        var piso = $("#pisoSelect").val();
        var cieloraso = $("#cielorasoSelect").val();
        var pared = $("#paredSelect").val();
        var techo = $("#techoSelect").val();
        var num_computadoras = $('input[name="cantidadComputadoras"]:checked').val();
        var num_tv = $('input[name="cantidadTv"]:checked').val();
        var num_cuartos = $('input[name="cantidadCuartos"]:checked').val();
        var num_camas = $('input[name="cantidadCamas"]:checked').val();
        var num_banos = $('input[name="cantidadBanos"]:checked').val();
        var num_agua = $('input[name="aguaRadio"]:checked').val();
        var num_electricidad = $('input[name="electricidadRadio"]:checked').val();


        /**
		 * Pesos seleccionados para el estudio socio economico
		 */
        var peso_nacionalidad = $("#nacionalidadSelect option:selected").data("peso");
        var peso_provincia = $("#provinciaSelect option:selected").data("peso");
        var peso_zona = $("input[name=zona]:checked").data("peso");
        var peso_piso = $("#pisoSelect option:selected").data("peso");
        var peso_cieloraso = $("#cielorasoSelect option:selected").data("peso");
        var peso_pared = $("#paredSelect option:selected").data("peso");
        var peso_techo = $("#techoSelect option:selected").data("peso");
        var peso_computadoras = $("input[name=cantidadComputadoras]:checked").data("peso");
        var peso_tv = $("input[name=cantidadTv]:checked").data("peso");
        var peso_cuartos = $("input[name=cantidadCuartos]:checked").data("peso");
        var peso_camas = $("input[name=cantidadCamas]:checked").data("peso");
        var peso_banos = $("input[name=cantidadBanos]:checked").data("peso");
        var peso_agua = $("input[name=aguaRadio]:checked").data("peso");
        var peso_electricidad = $("input[name=electricidadRadio]:checked").data("peso");

        /**
		 * Calificar el estudio socioeconomico
		 */
        var pesos = Array(peso_nacionalidad, peso_provincia, peso_zona, peso_piso, peso_cieloraso, peso_pared, peso_techo, peso_computadoras, peso_tv, peso_cuartos, peso_camas, peso_banos, peso_agua, peso_electricidad);
        var total_pesos = 0;
        pesos.forEach(function (peso) {
            total_pesos += peso;
        });
        var promedio_de_pesos = (total_pesos / pesos.length);

        /**
        *	Recorriendo a la familia
        */
        var total_ingresos = 0;
        var cantidadIntegrantes = 0;
        var resumen_integrantes_familia = "<h3>Integrantes e ingresos familiares</h3>";
        var pension = false;
        $(".familia .integrante").each(function () {

            if ($(this).find(".tipo").val() == "pension") {
                pension = true;
            }

            if ($(this).find(".tipo").val() != "no_aporta") {
                total_ingresos += parseInt($(this).find(".ingreso").val());
            }

            if ($(this).find(".vive:checked").val() != "No") {
                cantidadIntegrantes++;
            }

            resumen_integrantes_familia += '<div class="alert alert-info"><p><b>Nombre:</b> ' + $(this).find(".campoNombre .nombre").val() + "<br>";
            resumen_integrantes_familia += "<b>Ingreso:</b> " + $(this).find(".campoIngreso .ingreso").val() + "<br>";
            resumen_integrantes_familia += "<b>Tipo:</b> " + $(this).find(".campoTipo .tipo").val() + "<br>";
            resumen_integrantes_familia += "<b>Vive con el solicitante:</b> " + $(this).find(".vive:checked").val() + "</p></div>";


        });
        var promedio_de_ingresos = (total_ingresos / cantidadIntegrantes);

        resumen_integrantes_familia += '<div class="alert alert-warning"><p>Ingresos totales familiares: ' + total_ingresos + "</p>";
        resumen_integrantes_familia += "<p>Promedio de ingresos: " + promedio_de_ingresos + "</p></div>";

        /**
        * Verificacion de validacion
        */
        var veredicto = false;
        var reporteVeredicto = '<div class="alert alert-danger"><h3>No califica</h3>El usuario interesado NO califica para obtener la beca.</div>';
        if (promedio_de_pesos > 2.35) {
            if (promedio_de_ingresos < 60000) {
                veredicto = true;
                reporteVeredicto = '<div class="alert alert-success"><h3>Califica</h3>El usuario interesado califica para obtener la beca.</div>';
            }
            else if (promedio_de_ingresos < 75000 && pension) {
                veredicto = true;
                reporteVeredicto = '<div class="alert alert-success"><h3>Califica</h3>El usuario interesado califica para obtener la beca.</div>';
            }
            else {
                veredicto = false;
                reporteVeredicto = '<div class="alert alert-danger"><h3>No califica</h3>El usuario interesado NO califica para obtener la beca.</div>';
            }
        }

        /**
		 * Generar reporte
		 */
        var resumen_socioeconomico = "";

        resumen_socioeconomico += "<h1>Estudio socioeconomico</h1>";
        resumen_socioeconomico += reporteVeredicto;
        //resumen_socioeconomico += "<p>Nombre: " + nombre + "</p>";
        //resumen_socioeconomico += "<p>Apellidos: " + apellidos + "</p>";
        //resumen_socioeconomico += "<p>Cedula: " + cedula + "</p>";
        //resumen_socioeconomico += "<p>Fecha: " + fecha + "</p>";
        //resumen_socioeconomico += "<p>Edad: " + edad + "</p>";
        //resumen_socioeconomico += "<p>Nacionalidad: " + nacionalidad + "</p>";
        //resumen_socioeconomico += "<p>Provincia: " + provincia + "</p>";
        //resumen_socioeconomico += "<p>Canton: " + canton + "</p>";
        //resumen_socioeconomico += "<p>Distrito: " + distrito + "</p>";
        //resumen_socioeconomico += "<p>Zona: " + zona + "</p>";
        //resumen_socioeconomico += "<p>Piso: " + piso + "</p>";
        //resumen_socioeconomico += "<p>Cieloraso: " + cieloraso + "</p>";
        //resumen_socioeconomico += "<p>Pared: " + pared + "</p>";
        //resumen_socioeconomico += "<p>Techo: " + techo + "</p>";
        //resumen_socioeconomico += "<p>Numero de computadoras: " + num_computadoras + "</p>";
        //resumen_socioeconomico += "<p>Numero de televisores: " + num_tv + "</p>";
        //resumen_socioeconomico += "<p>Numero de cuartos: " + num_cuartos + "</p>";
        //resumen_socioeconomico += "<p>Numero de camas: " + num_camas + "</p>";
        //resumen_socioeconomico += "<p>Numero de baños: " + num_banos + "</p>";
        //resumen_socioeconomico += "<p>Agua potable: " + num_agua + "</p>";
        //resumen_socioeconomico += "<p>Electricidad: " + num_electricidad + "</p>";
        //resumen_socioeconomico += resumen_integrantes_familia;
        //resumen_socioeconomico += reporteVeredicto;

        var fechaHoy = new Date();
        var fechaEstudio = fechaHoy.getFullYear() + "-" + fechaHoy.getMonth() + "-" + fechaHoy.getDay();
        var idDeSolicitud = $("#idsolicitud_txt").attr("value");
        $.ajax({
            url: serverEstudios + "/crear",
            type: "GET",
            data: {
                'id_funcionario': usuarioActual.Id,
                'id_solicitud': idDeSolicitud,
                'es_elegible': veredicto,
                'fecha': fechaEstudio,
                'resumen': resumen_socioeconomico,
            },
            success: function (resultado) {
                $("#formularioSocioEconomico").modal("hide");
                if (resultado == true) {
                    listarSolicitudes();
                }
                else {
                    alert("Disculpe, hubo un error al momento de realizar el estudio socioeconomico.");
                }
            }

        });


    });

    $(".tipo").change(function (e) {

        if ($(".tipo").val() == "no_aporta") {
            $(".tipo").parent().parent().find(".campoIngreso").css({ "display": "none" });
        }
        else {
            $(".tipo").parent().parent().find(".campoIngreso").css({ "display": "inline" });
        }

    });

    $("#agregarOtroIntegrante").click(function (e) {
        e.preventDefault();

        var codigo = Math.floor((Math.random() * 100) + 1);
        $(".familia").append('<div class="integrante row" id="int' + codigo + '"><div class="form-group campoNombre col-xs-3"><label>Nombre</label><input type="text" class="nombre form-control validate[required,custom[onlyLetterSp]]"></div><div class="form-group campoTipo col-xs-4"><label>Tipo</label><select class="tipo form-control validate[required]"><option value="salario">Salario.</option><option value="pension">Pension.</option><option value="no_aporta">No aporta.</option></select></div><div class="form-group campoIngreso col-xs-3"><label>Ingreso</label><input type="text" class="ingreso form-control validate[required,custom[integer]]" value="0"></div><div class="form-group col-xs-2"><label>Acciones</label><button type="button" class="btn btn-danger eliminarIntegranteBtn" data-eliminar="#int' + codigo + '">Eliminar</button></div><div class="form-group campoVive col-xs-12"><label>Vive bajo el mismo techo que el solicitante: </label><div class="radio-inline"><label><input type="radio" class="vive validate[groupRequired[viveRadio]]" name="viveRadioint' + codigo + '" data-peso="1.5" value="Si" checked>S&iacute;</label></div><div class="radio-inline"><label><input type="radio" class="vive validate[groupRequired[viveRadio]]" name="viveRadioint' + codigo + '" data-peso="3" value="No">No</label></div></div><hr></div>');

        $(".eliminarIntegranteBtn").click(function (e) {

            var objEliminar = $(this).attr("data-eliminar");
            $(objEliminar).remove();

        });

        $(".tipo").change(function (e) {

            if ($(".tipo").val() == "no_aporta") {
                $(".tipo").parent().parent().find(".campoIngreso").css({ "display": "none" });
            }
            else {
                $(".tipo").parent().parent().find(".campoIngreso").css({ "display": "inline" });
            }

        });


    });

    $("#calcularEstudio").click(function (e) {

        e.preventDefault();

        if ($("#formularioEstudioSocioEconomico").validationEngine('validate')) {
            $("#formularioEstudioSocioEconomico").submit();
        }

    });

});

function gestorDeUbicaciones() {
    this.listarProvincias = function () {
        return this.provincias;
    }

    this.listarCantonesDeProvincia = function (idProvincia) {

        var listaFiltrada = [];

        this.cantones.forEach(function (item) {

            if (item.provincia == idProvincia) {
                listaFiltrada.push(item);
            }

        });

        return listaFiltrada;

    }

    this.listarDistritosDeCanton = function (idProvincia, idCanton) {

        var listaFiltrada = [];

        this.distritos.forEach(function (item) {

            if (item.canton == idCanton && item.provincia == idProvincia) {
                listaFiltrada.push(item);
            }

        });

        return listaFiltrada;

    }

    this.provincias = [

		{ id: 1, nombre: "SAN JOSE", peso: 1 },
		{ id: 2, nombre: "ALAJUELA", peso: 2 },
		{ id: 3, nombre: "CARTAGO", peso: 2 },
		{ id: 4, nombre: "HEREDIA", peso: 1 },
		{ id: 5, nombre: "GUANACASTE", peso: 3 },
		{ id: 6, nombre: "PUNTARENAS", peso: 3 },
		{ id: 7, nombre: "LIMON", peso: 3 }

    ];

    this.cantones = [
		{ provincia: 1, canton: 1, nombre: "SAN JOSE" },
		{ provincia: 1, canton: 2, nombre: "ESCAZU" },
		{ provincia: 1, canton: 3, nombre: "DESAMPARADOS" },
		{ provincia: 1, canton: 4, nombre: "PURISCAL" },
		{ provincia: 1, canton: 5, nombre: "TARRAZU" },
		{ provincia: 1, canton: 6, nombre: "ASERRI" },
		{ provincia: 1, canton: 7, nombre: "MORA" },
		{ provincia: 1, canton: 8, nombre: "GOICOECHEA" },
		{ provincia: 1, canton: 9, nombre: "SANTA ANA" },
		{ provincia: 1, canton: 10, nombre: "ALAJUELITA" },
		{ provincia: 1, canton: 11, nombre: "VAZQUEZ DE CORONADO" },
		{ provincia: 1, canton: 12, nombre: "ACOSTA" },
		{ provincia: 1, canton: 13, nombre: "TIBAS" },
		{ provincia: 1, canton: 14, nombre: "MORAVIA" },
		{ provincia: 1, canton: 15, nombre: "MONTES DE OCA" },
		{ provincia: 1, canton: 16, nombre: "TURRUBARES" },
		{ provincia: 1, canton: 17, nombre: "DOTA" },
		{ provincia: 1, canton: 18, nombre: "CURRIDABAT" },
		{ provincia: 1, canton: 19, nombre: "PEREZ ZELEDON" },
		{ provincia: 1, canton: 20, nombre: "LEON CORTES" },
		{ provincia: 2, canton: 1, nombre: "ALAJUELA" },
		{ provincia: 2, canton: 2, nombre: "SAN RAMON" },
		{ provincia: 2, canton: 3, nombre: "GRECIA" },
		{ provincia: 2, canton: 4, nombre: "SAN MATEO" },
		{ provincia: 2, canton: 5, nombre: "ATENAS" },
		{ provincia: 2, canton: 6, nombre: "NARANJO" },
		{ provincia: 2, canton: 7, nombre: "PALMARES" },
		{ provincia: 2, canton: 8, nombre: "POAS" },
		{ provincia: 2, canton: 9, nombre: "OROTINA" },
		{ provincia: 2, canton: 10, nombre: "SAN CARLOS" },
		{ provincia: 2, canton: 11, nombre: "ZARCERO" },
		{ provincia: 2, canton: 12, nombre: "VALVERDE VEGA" },
		{ provincia: 2, canton: 13, nombre: "UPALA" },
		{ provincia: 2, canton: 14, nombre: "LOS CHILES" },
		{ provincia: 2, canton: 15, nombre: "GUATUSO" },
		{ provincia: 3, canton: 1, nombre: "CARTAGO" },
		{ provincia: 3, canton: 2, nombre: "PARAISO" },
		{ provincia: 3, canton: 3, nombre: "LA UNION" },
		{ provincia: 3, canton: 4, nombre: "JIMENEZ" },
		{ provincia: 3, canton: 5, nombre: "TURRIALBA" },
		{ provincia: 3, canton: 6, nombre: "ALVARADO" },
		{ provincia: 3, canton: 7, nombre: "OREAMUNO" },
		{ provincia: 3, canton: 8, nombre: "EL GUARCO" },
		{ provincia: 4, canton: 1, nombre: "HEREDIA" },
		{ provincia: 4, canton: 2, nombre: "BARVA" },
		{ provincia: 4, canton: 3, nombre: "SANTO DOMINGO" },
		{ provincia: 4, canton: 4, nombre: "SANTA BARBARA" },
		{ provincia: 4, canton: 5, nombre: "SAN RAFAEL" },
		{ provincia: 4, canton: 6, nombre: "SAN ISIDRO" },
		{ provincia: 4, canton: 7, nombre: "BELEN" },
		{ provincia: 4, canton: 8, nombre: "FLORES" },
		{ provincia: 4, canton: 9, nombre: "SAN PABLO" },
		{ provincia: 4, canton: 10, nombre: "SARAPIQUI" },
		{ provincia: 5, canton: 1, nombre: "LIBERIA" },
		{ provincia: 5, canton: 2, nombre: "NICOYA" },
		{ provincia: 5, canton: 3, nombre: "SANTA CRUZ" },
		{ provincia: 5, canton: 4, nombre: "BAGACES" },
		{ provincia: 5, canton: 5, nombre: "CARRILLO" },
		{ provincia: 5, canton: 6, nombre: "CAÑAS" },
		{ provincia: 5, canton: 7, nombre: "ABANGARES" },
		{ provincia: 5, canton: 8, nombre: "TILARAN" },
		{ provincia: 5, canton: 9, nombre: "NANDAYURE" },
		{ provincia: 5, canton: 10, nombre: "LA CRUZ" },
		{ provincia: 5, canton: 11, nombre: "HOJANCHA" },
		{ provincia: 6, canton: 1, nombre: "PUNTARENAS" },
		{ provincia: 6, canton: 2, nombre: "ESPARZA" },
		{ provincia: 6, canton: 3, nombre: "BUENOS AIRES" },
		{ provincia: 6, canton: 4, nombre: "MONTES DE ORO" },
		{ provincia: 6, canton: 5, nombre: "OSA" },
		{ provincia: 6, canton: 6, nombre: "AGUIRRE" },
		{ provincia: 6, canton: 7, nombre: "GOLFITO" },
		{ provincia: 6, canton: 8, nombre: "COTO BRUS" },
		{ provincia: 6, canton: 9, nombre: "PARRITA" },
		{ provincia: 6, canton: 10, nombre: "CORREDORES" },
		{ provincia: 6, canton: 11, nombre: "GARABITO" },
		{ provincia: 7, canton: 1, nombre: "LIMON" },
		{ provincia: 7, canton: 2, nombre: "POCOCI" },
		{ provincia: 7, canton: 3, nombre: "SIQUIRRES" },
		{ provincia: 7, canton: 4, nombre: "TALAMANCA" },
		{ provincia: 7, canton: 5, nombre: "MATINA" },
		{ provincia: 7, canton: 6, nombre: "GUACIMO" }

    ];

    this.distritos = [

		{ provincia: 1, canton: 1, distrito: 1, nombre: "CARMEN" },
		{ provincia: 1, canton: 1, distrito: 1, nombre: "CARMEN" },
		{ provincia: 1, canton: 1, distrito: 2, nombre: "MERCED" },
		{ provincia: 1, canton: 1, distrito: 2, nombre: "MERCED" },
		{ provincia: 1, canton: 1, distrito: 3, nombre: "HOSPITAL" },
		{ provincia: 1, canton: 1, distrito: 3, nombre: "HOSPITAL" },
		{ provincia: 1, canton: 1, distrito: 4, nombre: "CATEDRAL" },
		{ provincia: 1, canton: 1, distrito: 4, nombre: "CATEDRAL" },
		{ provincia: 1, canton: 1, distrito: 5, nombre: "ZAPOTE" },
		{ provincia: 1, canton: 1, distrito: 5, nombre: "ZAPOTE" },
		{ provincia: 1, canton: 1, distrito: 6, nombre: "SAN FRANCISCO DE DOS RIOS" },
		{ provincia: 1, canton: 1, distrito: 6, nombre: "SAN FRANCISCO DE DOS RIOS" },
		{ provincia: 1, canton: 1, distrito: 7, nombre: "URUCA" },
		{ provincia: 1, canton: 1, distrito: 7, nombre: "URUCA" },
		{ provincia: 1, canton: 1, distrito: 8, nombre: "MATA REDONDA" },
		{ provincia: 1, canton: 1, distrito: 8, nombre: "MATA REDONDA" },
		{ provincia: 1, canton: 1, distrito: 9, nombre: "PAVAS" },
		{ provincia: 1, canton: 1, distrito: 9, nombre: "PAVAS" },
		{ provincia: 1, canton: 1, distrito: 10, nombre: "HATILLO" },
		{ provincia: 1, canton: 1, distrito: 10, nombre: "HATILLO" },
		{ provincia: 1, canton: 1, distrito: 11, nombre: "SAN SEBASTIAN" },
		{ provincia: 1, canton: 1, distrito: 11, nombre: "SAN SEBASTIAN" },
		{ provincia: 1, canton: 2, distrito: 1, nombre: "ESCAZU" },
		{ provincia: 1, canton: 2, distrito: 1, nombre: "ESCAZU" },
		{ provincia: 1, canton: 2, distrito: 2, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 2, distrito: 2, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 2, distrito: 3, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 2, distrito: 3, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 3, distrito: 1, nombre: "DESAMPARADOS" },
		{ provincia: 1, canton: 3, distrito: 1, nombre: "DESAMPARADOS" },
		{ provincia: 1, canton: 3, distrito: 2, nombre: "SAN MIGUEL" },
		{ provincia: 1, canton: 3, distrito: 2, nombre: "SAN MIGUEL" },
		{ provincia: 1, canton: 3, distrito: 3, nombre: "SAN JUAN DE DIOS" },
		{ provincia: 1, canton: 3, distrito: 3, nombre: "SAN JUAN DE DIOS" },
		{ provincia: 1, canton: 3, distrito: 4, nombre: "SAN RAFAEL ARRIBA" },
		{ provincia: 1, canton: 3, distrito: 4, nombre: "SAN RAFAEL ARRIBA" },
		{ provincia: 1, canton: 3, distrito: 5, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 3, distrito: 5, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 3, distrito: 6, nombre: "FRAILES" },
		{ provincia: 1, canton: 3, distrito: 6, nombre: "FRAILES" },
		{ provincia: 1, canton: 3, distrito: 7, nombre: "PATARRA" },
		{ provincia: 1, canton: 3, distrito: 7, nombre: "PATARRA" },
		{ provincia: 1, canton: 3, distrito: 8, nombre: "SAN CRISTOBAL" },
		{ provincia: 1, canton: 3, distrito: 8, nombre: "SAN CRISTOBAL" },
		{ provincia: 1, canton: 3, distrito: 9, nombre: "ROSARIO" },
		{ provincia: 1, canton: 3, distrito: 9, nombre: "ROSARIO" },
		{ provincia: 1, canton: 3, distrito: 10, nombre: "DAMAS" },
		{ provincia: 1, canton: 3, distrito: 10, nombre: "DAMAS" },
		{ provincia: 1, canton: 3, distrito: 11, nombre: "SAN RAFAEL ABAJO" },
		{ provincia: 1, canton: 3, distrito: 11, nombre: "SAN RAFAEL ABAJO" },
		{ provincia: 1, canton: 3, distrito: 12, nombre: "GRAVILIAS" },
		{ provincia: 1, canton: 3, distrito: 12, nombre: "GRAVILIAS" },
		{ provincia: 1, canton: 3, distrito: 13, nombre: "LOS GUIDO" },
		{ provincia: 1, canton: 4, distrito: 1, nombre: "SANTIAGO" },
		{ provincia: 1, canton: 4, distrito: 1, nombre: "SANTIAGO" },
		{ provincia: 1, canton: 4, distrito: 2, nombre: "MERCEDES SUR" },
		{ provincia: 1, canton: 4, distrito: 2, nombre: "MERCEDES SUR" },
		{ provincia: 1, canton: 4, distrito: 3, nombre: "BARBACOAS" },
		{ provincia: 1, canton: 4, distrito: 3, nombre: "BARBACOAS" },
		{ provincia: 1, canton: 4, distrito: 4, nombre: "GRIFO ALTO" },
		{ provincia: 1, canton: 4, distrito: 4, nombre: "GRIFO ALTO" },
		{ provincia: 1, canton: 4, distrito: 5, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 4, distrito: 5, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 4, distrito: 6, nombre: "CANDELARITA" },
		{ provincia: 1, canton: 4, distrito: 6, nombre: "CANDELARITA" },
		{ provincia: 1, canton: 4, distrito: 7, nombre: "DESAMPARADITOS" },
		{ provincia: 1, canton: 4, distrito: 7, nombre: "DESAMPARADITOS" },
		{ provincia: 1, canton: 4, distrito: 8, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 4, distrito: 8, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 4, distrito: 9, nombre: "CHIRES" },
		{ provincia: 1, canton: 4, distrito: 9, nombre: "CHIRES" },
		{ provincia: 1, canton: 5, distrito: 1, nombre: "SAN MARCOS" },
		{ provincia: 1, canton: 5, distrito: 1, nombre: "SAN MARCOS" },
		{ provincia: 1, canton: 5, distrito: 2, nombre: "SAN LORENZO" },
		{ provincia: 1, canton: 5, distrito: 2, nombre: "SAN LORENZO" },
		{ provincia: 1, canton: 5, distrito: 3, nombre: "SAN CARLOS" },
		{ provincia: 1, canton: 5, distrito: 3, nombre: "SAN CARLOS" },
		{ provincia: 1, canton: 6, distrito: 1, nombre: "ASERRI" },
		{ provincia: 1, canton: 6, distrito: 1, nombre: "ASERRI" },
		{ provincia: 1, canton: 6, distrito: 2, nombre: "TARBACA" },
		{ provincia: 1, canton: 6, distrito: 2, nombre: "TARBACA" },
		{ provincia: 1, canton: 6, distrito: 3, nombre: "VUELTA DE JORCO" },
		{ provincia: 1, canton: 6, distrito: 3, nombre: "VUELTA DE JORCO" },
		{ provincia: 1, canton: 6, distrito: 4, nombre: "SAN GABRIEL" },
		{ provincia: 1, canton: 6, distrito: 4, nombre: "SAN GABRIEL" },
		{ provincia: 1, canton: 6, distrito: 5, nombre: "LEGUA" },
		{ provincia: 1, canton: 6, distrito: 5, nombre: "LEGUA" },
		{ provincia: 1, canton: 6, distrito: 6, nombre: "MONTERREY" },
		{ provincia: 1, canton: 6, distrito: 6, nombre: "MONTERREY" },
		{ provincia: 1, canton: 6, distrito: 7, nombre: "SALITRILLOS" },
		{ provincia: 1, canton: 7, distrito: 1, nombre: "COLON" },
		{ provincia: 1, canton: 7, distrito: 1, nombre: "COLON" },
		{ provincia: 1, canton: 7, distrito: 2, nombre: "GUAYABO" },
		{ provincia: 1, canton: 7, distrito: 2, nombre: "GUAYABO" },
		{ provincia: 1, canton: 7, distrito: 3, nombre: "TABARCIA" },
		{ provincia: 1, canton: 7, distrito: 3, nombre: "TABARCIA" },
		{ provincia: 1, canton: 7, distrito: 4, nombre: "PIEDRAS NEGRAS" },
		{ provincia: 1, canton: 7, distrito: 4, nombre: "PIEDRAS NEGRAS" },
		{ provincia: 1, canton: 7, distrito: 5, nombre: "PICAGRES" },
		{ provincia: 1, canton: 7, distrito: 5, nombre: "PICAGRES" },
		{ provincia: 1, canton: 7, distrito: 6, nombre: "JARIS" },
		{ provincia: 1, canton: 8, distrito: 1, nombre: "GUADALUPE" },
		{ provincia: 1, canton: 8, distrito: 1, nombre: "GUADALUPE" },
		{ provincia: 1, canton: 8, distrito: 2, nombre: "SAN FRANCISCO" },
		{ provincia: 1, canton: 8, distrito: 2, nombre: "SAN FRANCISCO" },
		{ provincia: 1, canton: 8, distrito: 3, nombre: "CALLE BLANCOS" },
		{ provincia: 1, canton: 8, distrito: 3, nombre: "CALLE BLANCOS" },
		{ provincia: 1, canton: 8, distrito: 4, nombre: "MATA DE PLATANO" },
		{ provincia: 1, canton: 8, distrito: 4, nombre: "MATA DE PLATANO" },
		{ provincia: 1, canton: 8, distrito: 5, nombre: "IPIS" },
		{ provincia: 1, canton: 8, distrito: 5, nombre: "IPIS" },
		{ provincia: 1, canton: 8, distrito: 6, nombre: "RANCHO REDONDO" },
		{ provincia: 1, canton: 8, distrito: 6, nombre: "RANCHO REDONDO" },
		{ provincia: 1, canton: 8, distrito: 7, nombre: "PURRAL" },
		{ provincia: 1, canton: 8, distrito: 7, nombre: "PURRAL" },
		{ provincia: 1, canton: 9, distrito: 1, nombre: "SANTA ANA" },
		{ provincia: 1, canton: 9, distrito: 1, nombre: "SANTA ANA" },
		{ provincia: 1, canton: 9, distrito: 2, nombre: "SALITRAL" },
		{ provincia: 1, canton: 9, distrito: 2, nombre: "SALITRAL" },
		{ provincia: 1, canton: 9, distrito: 3, nombre: "POZOS" },
		{ provincia: 1, canton: 9, distrito: 3, nombre: "POZOS" },
		{ provincia: 1, canton: 9, distrito: 4, nombre: "URUCA" },
		{ provincia: 1, canton: 9, distrito: 4, nombre: "URUCA" },
		{ provincia: 1, canton: 9, distrito: 5, nombre: "PIEDADES" },
		{ provincia: 1, canton: 9, distrito: 5, nombre: "PIEDADES" },
		{ provincia: 1, canton: 9, distrito: 6, nombre: "BRASIL" },
		{ provincia: 1, canton: 9, distrito: 6, nombre: "BRASIL" },
		{ provincia: 1, canton: 10, distrito: 1, nombre: "ALAJUELITA" },
		{ provincia: 1, canton: 10, distrito: 1, nombre: "ALAJUELITA" },
		{ provincia: 1, canton: 10, distrito: 2, nombre: "SAN JOSECITO" },
		{ provincia: 1, canton: 10, distrito: 2, nombre: "SAN JOSECITO" },
		{ provincia: 1, canton: 10, distrito: 3, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 10, distrito: 3, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 10, distrito: 4, nombre: "CONCEPCION" },
		{ provincia: 1, canton: 10, distrito: 4, nombre: "CONCEPCION" },
		{ provincia: 1, canton: 10, distrito: 5, nombre: "SAN FELIPE" },
		{ provincia: 1, canton: 10, distrito: 5, nombre: "SAN FELIPE" },
		{ provincia: 1, canton: 11, distrito: 1, nombre: "SAN ISIDRO" },
		{ provincia: 1, canton: 11, distrito: 1, nombre: "SAN ISIDRO" },
		{ provincia: 1, canton: 11, distrito: 2, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 11, distrito: 2, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 11, distrito: 3, nombre: "DULCE NOMBRE DE JESUS" },
		{ provincia: 1, canton: 11, distrito: 3, nombre: "DULCE NOMBRE DE JESUS" },
		{ provincia: 1, canton: 11, distrito: 4, nombre: "PATALILLO" },
		{ provincia: 1, canton: 11, distrito: 4, nombre: "PATALILLO" },
		{ provincia: 1, canton: 11, distrito: 5, nombre: "CASCAJAL" },
		{ provincia: 1, canton: 11, distrito: 5, nombre: "CASCAJAL" },
		{ provincia: 1, canton: 12, distrito: 1, nombre: "SAN IGNACIO" },
		{ provincia: 1, canton: 12, distrito: 1, nombre: "SAN IGNACIO" },
		{ provincia: 1, canton: 12, distrito: 2, nombre: "GUAITIL" },
		{ provincia: 1, canton: 12, distrito: 2, nombre: "GUAITIL" },
		{ provincia: 1, canton: 12, distrito: 3, nombre: "PALMICHAL" },
		{ provincia: 1, canton: 12, distrito: 3, nombre: "PALMICHAL" },
		{ provincia: 1, canton: 12, distrito: 4, nombre: "CANGREJAL" },
		{ provincia: 1, canton: 12, distrito: 4, nombre: "CANGREJAL" },
		{ provincia: 1, canton: 12, distrito: 5, nombre: "SABANILLAS" },
		{ provincia: 1, canton: 12, distrito: 5, nombre: "SABANILLAS" },
		{ provincia: 1, canton: 13, distrito: 1, nombre: "SAN JUAN" },
		{ provincia: 1, canton: 13, distrito: 1, nombre: "SAN JUAN" },
		{ provincia: 1, canton: 13, distrito: 2, nombre: "CINCO ESQUINAS" },
		{ provincia: 1, canton: 13, distrito: 2, nombre: "CINCO ESQUINAS" },
		{ provincia: 1, canton: 13, distrito: 3, nombre: "ANSELMO LLORENTE" },
		{ provincia: 1, canton: 13, distrito: 3, nombre: "ANSELMO LLORENTE" },
		{ provincia: 1, canton: 13, distrito: 4, nombre: "LEON XIII" },
		{ provincia: 1, canton: 13, distrito: 4, nombre: "LEON XIII" },
		{ provincia: 1, canton: 13, distrito: 5, nombre: "COLIMA" },
		{ provincia: 1, canton: 14, distrito: 1, nombre: "SAN VICENTE" },
		{ provincia: 1, canton: 14, distrito: 1, nombre: "SAN VICENTE" },
		{ provincia: 1, canton: 14, distrito: 2, nombre: "SAN JERONIMO" },
		{ provincia: 1, canton: 14, distrito: 2, nombre: "SAN JERONIMO" },
		{ provincia: 1, canton: 14, distrito: 3, nombre: "TRINIDAD" },
		{ provincia: 1, canton: 14, distrito: 3, nombre: "TRINIDAD" },
		{ provincia: 1, canton: 15, distrito: 1, nombre: "SAN PEDRO" },
		{ provincia: 1, canton: 15, distrito: 1, nombre: "SAN PEDRO" },
		{ provincia: 1, canton: 15, distrito: 2, nombre: "SABANILLA" },
		{ provincia: 1, canton: 15, distrito: 2, nombre: "SABANILLA" },
		{ provincia: 1, canton: 15, distrito: 3, nombre: "MERCEDES" },
		{ provincia: 1, canton: 15, distrito: 3, nombre: "MERCEDES" },
		{ provincia: 1, canton: 15, distrito: 4, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 15, distrito: 4, nombre: "SAN RAFAEL" },
		{ provincia: 1, canton: 16, distrito: 1, nombre: "SAN PABLO" },
		{ provincia: 1, canton: 16, distrito: 1, nombre: "SAN PABLO" },
		{ provincia: 1, canton: 16, distrito: 2, nombre: "SAN PEDRO" },
		{ provincia: 1, canton: 16, distrito: 2, nombre: "SAN PEDRO" },
		{ provincia: 1, canton: 16, distrito: 3, nombre: "SAN JUAN DE MATA" },
		{ provincia: 1, canton: 16, distrito: 3, nombre: "SAN JUAN DE MATA" },
		{ provincia: 1, canton: 16, distrito: 4, nombre: "SAN LUIS" },
		{ provincia: 1, canton: 16, distrito: 4, nombre: "SAN LUIS" },
		{ provincia: 1, canton: 16, distrito: 5, nombre: "CARARA" },
		{ provincia: 1, canton: 17, distrito: 1, nombre: "SANTA MARIA" },
		{ provincia: 1, canton: 17, distrito: 1, nombre: "SANTA MARIA" },
		{ provincia: 1, canton: 17, distrito: 2, nombre: "JARDIN" },
		{ provincia: 1, canton: 17, distrito: 2, nombre: "JARDIN" },
		{ provincia: 1, canton: 17, distrito: 3, nombre: "COPEY" },
		{ provincia: 1, canton: 17, distrito: 3, nombre: "COPEY" },
		{ provincia: 1, canton: 18, distrito: 1, nombre: "CURRIDABAT" },
		{ provincia: 1, canton: 18, distrito: 1, nombre: "CURRIDABAT" },
		{ provincia: 1, canton: 18, distrito: 2, nombre: "GRANADILLA" },
		{ provincia: 1, canton: 18, distrito: 2, nombre: "GRANADILLA" },
		{ provincia: 1, canton: 18, distrito: 3, nombre: "SANCHEZ" },
		{ provincia: 1, canton: 18, distrito: 3, nombre: "SANCHEZ" },
		{ provincia: 1, canton: 18, distrito: 4, nombre: "TIRRASES" },
		{ provincia: 1, canton: 18, distrito: 4, nombre: "TIRRASES" },
		{ provincia: 1, canton: 19, distrito: 1, nombre: "SAN ISIDRO DE EL GENERAL" },
		{ provincia: 1, canton: 19, distrito: 1, nombre: "SAN ISIDRO DE EL GENERAL" },
		{ provincia: 1, canton: 19, distrito: 2, nombre: "GENERAL" },
		{ provincia: 1, canton: 19, distrito: 2, nombre: "GENERAL" },
		{ provincia: 1, canton: 19, distrito: 3, nombre: "DANIEL FLORES" },
		{ provincia: 1, canton: 19, distrito: 3, nombre: "DANIEL FLORES" },
		{ provincia: 1, canton: 19, distrito: 4, nombre: "RIVAS" },
		{ provincia: 1, canton: 19, distrito: 4, nombre: "RIVAS" },
		{ provincia: 1, canton: 19, distrito: 5, nombre: "SAN PEDRO" },
		{ provincia: 1, canton: 19, distrito: 5, nombre: "SAN PEDRO" },
		{ provincia: 1, canton: 19, distrito: 6, nombre: "PLATANARES" },
		{ provincia: 1, canton: 19, distrito: 6, nombre: "PLATANARES" },
		{ provincia: 1, canton: 19, distrito: 7, nombre: "PEJIBAYE" },
		{ provincia: 1, canton: 19, distrito: 7, nombre: "PEJIBAYE" },
		{ provincia: 1, canton: 19, distrito: 8, nombre: "CAJON" },
		{ provincia: 1, canton: 19, distrito: 8, nombre: "CAJON" },
		{ provincia: 1, canton: 19, distrito: 9, nombre: "BARU" },
		{ provincia: 1, canton: 19, distrito: 9, nombre: "BARU" },
		{ provincia: 1, canton: 19, distrito: 10, nombre: "RIO NUEVO" },
		{ provincia: 1, canton: 19, distrito: 10, nombre: "RIO NUEVO" },
		{ provincia: 1, canton: 19, distrito: 11, nombre: "PARAMO" },
		{ provincia: 1, canton: 19, distrito: 11, nombre: "PARAMO" },
		{ provincia: 1, canton: 20, distrito: 1, nombre: "SAN PABLO" },
		{ provincia: 1, canton: 20, distrito: 1, nombre: "SAN PABLO" },
		{ provincia: 1, canton: 20, distrito: 2, nombre: "SAN ANDRES" },
		{ provincia: 1, canton: 20, distrito: 2, nombre: "SAN ANDRES" },
		{ provincia: 1, canton: 20, distrito: 3, nombre: "LLANO BONITO" },
		{ provincia: 1, canton: 20, distrito: 3, nombre: "LLANO BONITO" },
		{ provincia: 1, canton: 20, distrito: 4, nombre: "SAN ISIDRO" },
		{ provincia: 1, canton: 20, distrito: 4, nombre: "SAN ISIDRO" },
		{ provincia: 1, canton: 20, distrito: 5, nombre: "SANTA CRUZ" },
		{ provincia: 1, canton: 20, distrito: 5, nombre: "SANTA CRUZ" },
		{ provincia: 1, canton: 20, distrito: 6, nombre: "SAN ANTONIO" },
		{ provincia: 1, canton: 20, distrito: 6, nombre: "SAN ANTONIO" },
		{ provincia: 2, canton: 1, distrito: 1, nombre: "ALAJUELA" },
		{ provincia: 2, canton: 1, distrito: 1, nombre: "ALAJUELA" },
		{ provincia: 2, canton: 1, distrito: 2, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 1, distrito: 2, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 1, distrito: 3, nombre: "CARRIZAL" },
		{ provincia: 2, canton: 1, distrito: 3, nombre: "CARRIZAL" },
		{ provincia: 2, canton: 1, distrito: 4, nombre: "SAN ANTONIO" },
		{ provincia: 2, canton: 1, distrito: 4, nombre: "SAN ANTONIO" },
		{ provincia: 2, canton: 1, distrito: 5, nombre: "GUACIMA" },
		{ provincia: 2, canton: 1, distrito: 5, nombre: "GUACIMA" },
		{ provincia: 2, canton: 1, distrito: 6, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 1, distrito: 6, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 1, distrito: 7, nombre: "SABANILLA" },
		{ provincia: 2, canton: 1, distrito: 7, nombre: "SABANILLA" },
		{ provincia: 2, canton: 1, distrito: 8, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 1, distrito: 8, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 1, distrito: 9, nombre: "RIO SEGUNDO" },
		{ provincia: 2, canton: 1, distrito: 9, nombre: "RIO SEGUNDO" },
		{ provincia: 2, canton: 1, distrito: 10, nombre: "DESAMPARADOS" },
		{ provincia: 2, canton: 1, distrito: 10, nombre: "DESAMPARADOS" },
		{ provincia: 2, canton: 1, distrito: 11, nombre: "TURRUCARES" },
		{ provincia: 2, canton: 1, distrito: 11, nombre: "TURRUCARES" },
		{ provincia: 2, canton: 1, distrito: 12, nombre: "TAMBOR" },
		{ provincia: 2, canton: 1, distrito: 12, nombre: "TAMBOR" },
		{ provincia: 2, canton: 1, distrito: 13, nombre: "GARITA" },
		{ provincia: 2, canton: 1, distrito: 13, nombre: "GARITA" },
		{ provincia: 2, canton: 1, distrito: 14, nombre: "SARAPIQUI (SAN MIGUEL)" },
		{ provincia: 2, canton: 1, distrito: 14, nombre: "SARAPIQUI (SAN MIGUEL)" },
		{ provincia: 2, canton: 2, distrito: 1, nombre: "SAN RAMON" },
		{ provincia: 2, canton: 2, distrito: 1, nombre: "SAN RAMON" },
		{ provincia: 2, canton: 2, distrito: 2, nombre: "SANTIAGO" },
		{ provincia: 2, canton: 2, distrito: 2, nombre: "SANTIAGO" },
		{ provincia: 2, canton: 2, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 2, canton: 2, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 2, canton: 2, distrito: 4, nombre: "PIEDADES NORTE" },
		{ provincia: 2, canton: 2, distrito: 4, nombre: "PIEDADES NORTE" },
		{ provincia: 2, canton: 2, distrito: 5, nombre: "PIEDADES SUR" },
		{ provincia: 2, canton: 2, distrito: 5, nombre: "PIEDADES SUR" },
		{ provincia: 2, canton: 2, distrito: 6, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 2, distrito: 6, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 2, distrito: 7, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 2, distrito: 7, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 2, distrito: 8, nombre: "ANGELES" },
		{ provincia: 2, canton: 2, distrito: 8, nombre: "ANGELES" },
		{ provincia: 2, canton: 2, distrito: 9, nombre: "ALFARO" },
		{ provincia: 2, canton: 2, distrito: 9, nombre: "ALFARO" },
		{ provincia: 2, canton: 2, distrito: 10, nombre: "VOLIO" },
		{ provincia: 2, canton: 2, distrito: 10, nombre: "VOLIO" },
		{ provincia: 2, canton: 2, distrito: 11, nombre: "CONCEPCION" },
		{ provincia: 2, canton: 2, distrito: 11, nombre: "CONCEPCION" },
		{ provincia: 2, canton: 2, distrito: 12, nombre: "ZAPOTAL" },
		{ provincia: 2, canton: 2, distrito: 12, nombre: "ZAPOTAL" },
		{ provincia: 2, canton: 2, distrito: 13, nombre: "PEÑAS BLANCAS" },
		{ provincia: 2, canton: 2, distrito: 13, nombre: "PEÑAS BLANCAS" },
		{ provincia: 2, canton: 3, distrito: 1, nombre: "GRECIA" },
		{ provincia: 2, canton: 3, distrito: 1, nombre: "GRECIA" },
		{ provincia: 2, canton: 3, distrito: 2, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 3, distrito: 2, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 3, distrito: 3, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 3, distrito: 3, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 3, distrito: 4, nombre: "SAN ROQUE" },
		{ provincia: 2, canton: 3, distrito: 4, nombre: "SAN ROQUE" },
		{ provincia: 2, canton: 3, distrito: 5, nombre: "TACARES" },
		{ provincia: 2, canton: 3, distrito: 5, nombre: "TACARES" },
		{ provincia: 2, canton: 3, distrito: 6, nombre: "RIO CUARTO" },
		{ provincia: 2, canton: 3, distrito: 6, nombre: "RIO CUARTO" },
		{ provincia: 2, canton: 3, distrito: 7, nombre: "PUENTE DE PIEDRA" },
		{ provincia: 2, canton: 3, distrito: 7, nombre: "PUENTE DE PIEDRA" },
		{ provincia: 2, canton: 3, distrito: 8, nombre: "BOLIVAR" },
		{ provincia: 2, canton: 3, distrito: 8, nombre: "BOLIVAR" },
		{ provincia: 2, canton: 4, distrito: 1, nombre: "SAN MATEO" },
		{ provincia: 2, canton: 4, distrito: 1, nombre: "SAN MATEO" },
		{ provincia: 2, canton: 4, distrito: 2, nombre: "DESMONTE" },
		{ provincia: 2, canton: 4, distrito: 2, nombre: "DESMONTE" },
		{ provincia: 2, canton: 4, distrito: 3, nombre: "JESUS MARIA" },
		{ provincia: 2, canton: 4, distrito: 3, nombre: "JESUS MARIA" },
		{ provincia: 2, canton: 5, distrito: 1, nombre: "ATENAS" },
		{ provincia: 2, canton: 5, distrito: 1, nombre: "ATENAS" },
		{ provincia: 2, canton: 5, distrito: 2, nombre: "JESUS" },
		{ provincia: 2, canton: 5, distrito: 2, nombre: "JESUS" },
		{ provincia: 2, canton: 5, distrito: 3, nombre: "MERCEDES" },
		{ provincia: 2, canton: 5, distrito: 3, nombre: "MERCEDES" },
		{ provincia: 2, canton: 5, distrito: 4, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 5, distrito: 4, nombre: "SAN ISIDRO" },
		{ provincia: 2, canton: 5, distrito: 5, nombre: "CONCEPCION" },
		{ provincia: 2, canton: 5, distrito: 5, nombre: "CONCEPCION" },
		{ provincia: 2, canton: 5, distrito: 6, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 5, distrito: 6, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 5, distrito: 7, nombre: "SANTA EULALIA" },
		{ provincia: 2, canton: 5, distrito: 7, nombre: "SANTA EULALIA" },
		{ provincia: 2, canton: 5, distrito: 8, nombre: "ESCOBAL" },
		{ provincia: 2, canton: 6, distrito: 1, nombre: "NARANJO" },
		{ provincia: 2, canton: 6, distrito: 1, nombre: "NARANJO" },
		{ provincia: 2, canton: 6, distrito: 2, nombre: "SAN MIGUEL" },
		{ provincia: 2, canton: 6, distrito: 2, nombre: "SAN MIGUEL" },
		{ provincia: 2, canton: 6, distrito: 3, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 6, distrito: 3, nombre: "SAN JOSE" },
		{ provincia: 2, canton: 6, distrito: 4, nombre: "CIRRI SUR" },
		{ provincia: 2, canton: 6, distrito: 4, nombre: "CIRRI SUR" },
		{ provincia: 2, canton: 6, distrito: 5, nombre: "SAN JERONIMO" },
		{ provincia: 2, canton: 6, distrito: 5, nombre: "SAN JERONIMO" },
		{ provincia: 2, canton: 6, distrito: 6, nombre: "SAN JUAN" },
		{ provincia: 2, canton: 6, distrito: 6, nombre: "SAN JUAN" },
		{ provincia: 2, canton: 6, distrito: 7, nombre: "ROSARIO" },
		{ provincia: 2, canton: 6, distrito: 7, nombre: "ROSARIO" },
		{ provincia: 2, canton: 6, distrito: 8, nombre: "PALMITOS" },
		{ provincia: 2, canton: 6, distrito: 8, nombre: "PALMITOS" },
		{ provincia: 2, canton: 7, distrito: 1, nombre: "PALMARES" },
		{ provincia: 2, canton: 7, distrito: 1, nombre: "PALMARES" },
		{ provincia: 2, canton: 7, distrito: 2, nombre: "ZARAGOZA" },
		{ provincia: 2, canton: 7, distrito: 2, nombre: "ZARAGOZA" },
		{ provincia: 2, canton: 7, distrito: 3, nombre: "BUENOS AIRES" },
		{ provincia: 2, canton: 7, distrito: 3, nombre: "BUENOS AIRES" },
		{ provincia: 2, canton: 7, distrito: 4, nombre: "SANTIAGO" },
		{ provincia: 2, canton: 7, distrito: 4, nombre: "SANTIAGO" },
		{ provincia: 2, canton: 7, distrito: 5, nombre: "CANDELARIA" },
		{ provincia: 2, canton: 7, distrito: 5, nombre: "CANDELARIA" },
		{ provincia: 2, canton: 7, distrito: 6, nombre: "ESQUIPULAS" },
		{ provincia: 2, canton: 7, distrito: 6, nombre: "ESQUIPULAS" },
		{ provincia: 2, canton: 7, distrito: 7, nombre: "GRANJA" },
		{ provincia: 2, canton: 7, distrito: 7, nombre: "GRANJA" },
		{ provincia: 2, canton: 8, distrito: 1, nombre: "SAN PEDRO" },
		{ provincia: 2, canton: 8, distrito: 1, nombre: "SAN PEDRO" },
		{ provincia: 2, canton: 8, distrito: 2, nombre: "SAN JUAN" },
		{ provincia: 2, canton: 8, distrito: 2, nombre: "SAN JUAN" },
		{ provincia: 2, canton: 8, distrito: 3, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 8, distrito: 3, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 8, distrito: 4, nombre: "CARRILLOS" },
		{ provincia: 2, canton: 8, distrito: 4, nombre: "CARRILLOS" },
		{ provincia: 2, canton: 8, distrito: 5, nombre: "SABANA REDONDA" },
		{ provincia: 2, canton: 8, distrito: 5, nombre: "SABANA REDONDA" },
		{ provincia: 2, canton: 9, distrito: 1, nombre: "OROTINA" },
		{ provincia: 2, canton: 9, distrito: 1, nombre: "OROTINA" },
		{ provincia: 2, canton: 9, distrito: 2, nombre: "MASTATE" },
		{ provincia: 2, canton: 9, distrito: 2, nombre: "MASTATE" },
		{ provincia: 2, canton: 9, distrito: 3, nombre: "HACIENDA VIEJA" },
		{ provincia: 2, canton: 9, distrito: 3, nombre: "HACIENDA VIEJA" },
		{ provincia: 2, canton: 9, distrito: 4, nombre: "COYOLAR" },
		{ provincia: 2, canton: 9, distrito: 4, nombre: "COYOLAR" },
		{ provincia: 2, canton: 9, distrito: 5, nombre: "CEIBA" },
		{ provincia: 2, canton: 9, distrito: 5, nombre: "CEIBA" },
		{ provincia: 2, canton: 10, distrito: 1, nombre: "QUESADA" },
		{ provincia: 2, canton: 10, distrito: 1, nombre: "QUESADA" },
		{ provincia: 2, canton: 10, distrito: 2, nombre: "FLORENCIA" },
		{ provincia: 2, canton: 10, distrito: 2, nombre: "FLORENCIA" },
		{ provincia: 2, canton: 10, distrito: 3, nombre: "BUENAVISTA" },
		{ provincia: 2, canton: 10, distrito: 3, nombre: "BUENAVISTA" },
		{ provincia: 2, canton: 10, distrito: 4, nombre: "AGUAS ZARCAS" },
		{ provincia: 2, canton: 10, distrito: 4, nombre: "AGUAS ZARCAS" },
		{ provincia: 2, canton: 10, distrito: 5, nombre: "VENECIA" },
		{ provincia: 2, canton: 10, distrito: 5, nombre: "VENECIA" },
		{ provincia: 2, canton: 10, distrito: 6, nombre: "PITAL" },
		{ provincia: 2, canton: 10, distrito: 6, nombre: "PITAL" },
		{ provincia: 2, canton: 10, distrito: 7, nombre: "FORTUNA" },
		{ provincia: 2, canton: 10, distrito: 7, nombre: "FORTUNA" },
		{ provincia: 2, canton: 10, distrito: 8, nombre: "TIGRA" },
		{ provincia: 2, canton: 10, distrito: 8, nombre: "TIGRA" },
		{ provincia: 2, canton: 10, distrito: 9, nombre: "PALMERA" },
		{ provincia: 2, canton: 10, distrito: 9, nombre: "PALMERA" },
		{ provincia: 2, canton: 10, distrito: 10, nombre: "VENADO" },
		{ provincia: 2, canton: 10, distrito: 10, nombre: "VENADO" },
		{ provincia: 2, canton: 10, distrito: 11, nombre: "CUTRIS" },
		{ provincia: 2, canton: 10, distrito: 11, nombre: "CUTRIS" },
		{ provincia: 2, canton: 10, distrito: 12, nombre: "MONTERREY" },
		{ provincia: 2, canton: 10, distrito: 12, nombre: "MONTERREY" },
		{ provincia: 2, canton: 10, distrito: 13, nombre: "POCOSOL" },
		{ provincia: 2, canton: 10, distrito: 13, nombre: "POCOSOL" },
		{ provincia: 2, canton: 11, distrito: 1, nombre: "ZARCERO" },
		{ provincia: 2, canton: 11, distrito: 1, nombre: "ZARCERO" },
		{ provincia: 2, canton: 11, distrito: 2, nombre: "LAGUNA" },
		{ provincia: 2, canton: 11, distrito: 2, nombre: "LAGUNA" },
		{ provincia: 2, canton: 11, distrito: 3, nombre: "TAPEZCO" },
		{ provincia: 2, canton: 11, distrito: 3, nombre: "TAPEZCO" },
		{ provincia: 2, canton: 11, distrito: 4, nombre: "GUADALUPE" },
		{ provincia: 2, canton: 11, distrito: 4, nombre: "GUADALUPE" },
		{ provincia: 2, canton: 11, distrito: 5, nombre: "PALMIRA" },
		{ provincia: 2, canton: 11, distrito: 5, nombre: "PALMIRA" },
		{ provincia: 2, canton: 11, distrito: 6, nombre: "ZAPOTE" },
		{ provincia: 2, canton: 11, distrito: 6, nombre: "ZAPOTE" },
		{ provincia: 2, canton: 11, distrito: 7, nombre: "BRISAS" },
		{ provincia: 2, canton: 12, distrito: 1, nombre: "SARCHI NORTE" },
		{ provincia: 2, canton: 12, distrito: 1, nombre: "SARCHI NORTE" },
		{ provincia: 2, canton: 12, distrito: 2, nombre: "SARCHI SUR" },
		{ provincia: 2, canton: 12, distrito: 2, nombre: "SARCHI SUR" },
		{ provincia: 2, canton: 12, distrito: 3, nombre: "TORO AMARILLO" },
		{ provincia: 2, canton: 12, distrito: 3, nombre: "TORO AMARILLO" },
		{ provincia: 2, canton: 12, distrito: 4, nombre: "SAN PEDRO" },
		{ provincia: 2, canton: 12, distrito: 4, nombre: "SAN PEDRO" },
		{ provincia: 2, canton: 12, distrito: 5, nombre: "RODRIGUEZ" },
		{ provincia: 2, canton: 12, distrito: 5, nombre: "RODRIGUEZ" },
		{ provincia: 2, canton: 13, distrito: 1, nombre: "UPALA" },
		{ provincia: 2, canton: 13, distrito: 1, nombre: "UPALA" },
		{ provincia: 2, canton: 13, distrito: 2, nombre: "AGUAS CLARAS" },
		{ provincia: 2, canton: 13, distrito: 2, nombre: "AGUAS CLARAS" },
		{ provincia: 2, canton: 13, distrito: 3, nombre: "SAN JOSE O PIZOTE" },
		{ provincia: 2, canton: 13, distrito: 3, nombre: "SAN JOSE O PIZOTE" },
		{ provincia: 2, canton: 13, distrito: 4, nombre: "BIJAGUA" },
		{ provincia: 2, canton: 13, distrito: 4, nombre: "BIJAGUA" },
		{ provincia: 2, canton: 13, distrito: 5, nombre: "DELICIAS" },
		{ provincia: 2, canton: 13, distrito: 5, nombre: "DELICIAS" },
		{ provincia: 2, canton: 13, distrito: 6, nombre: "DOS RIOS" },
		{ provincia: 2, canton: 13, distrito: 6, nombre: "DOS RIOS" },
		{ provincia: 2, canton: 13, distrito: 7, nombre: "YOLILLAL" },
		{ provincia: 2, canton: 13, distrito: 7, nombre: "YOLILLAL" },
		{ provincia: 2, canton: 13, distrito: 8, nombre: "CANALETE" },
		{ provincia: 2, canton: 14, distrito: 1, nombre: "LOS CHILES" },
		{ provincia: 2, canton: 14, distrito: 1, nombre: "LOS CHILES" },
		{ provincia: 2, canton: 14, distrito: 2, nombre: "CAÑO NEGRO" },
		{ provincia: 2, canton: 14, distrito: 2, nombre: "CAÑO NEGRO" },
		{ provincia: 2, canton: 14, distrito: 3, nombre: "EL AMPARO" },
		{ provincia: 2, canton: 14, distrito: 3, nombre: "EL AMPARO" },
		{ provincia: 2, canton: 14, distrito: 4, nombre: "SAN JORGE" },
		{ provincia: 2, canton: 14, distrito: 4, nombre: "SAN JORGE" },
		{ provincia: 2, canton: 15, distrito: 1, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 15, distrito: 1, nombre: "SAN RAFAEL" },
		{ provincia: 2, canton: 15, distrito: 2, nombre: "BUENAVISTA" },
		{ provincia: 2, canton: 15, distrito: 2, nombre: "BUENAVISTA" },
		{ provincia: 2, canton: 15, distrito: 3, nombre: "COTE" },
		{ provincia: 2, canton: 15, distrito: 3, nombre: "COTE" },
		{ provincia: 2, canton: 15, distrito: 4, nombre: "VILLA KATIRA" },
		{ provincia: 3, canton: 1, distrito: 1, nombre: "ORIENTAL" },
		{ provincia: 3, canton: 1, distrito: 1, nombre: "ORIENTAL" },
		{ provincia: 3, canton: 1, distrito: 2, nombre: "OCCIDENTAL" },
		{ provincia: 3, canton: 1, distrito: 2, nombre: "OCCIDENTAL" },
		{ provincia: 3, canton: 1, distrito: 3, nombre: "CARMEN" },
		{ provincia: 3, canton: 1, distrito: 3, nombre: "CARMEN" },
		{ provincia: 3, canton: 1, distrito: 4, nombre: "SAN NICOLAS" },
		{ provincia: 3, canton: 1, distrito: 4, nombre: "SAN NICOLAS" },
		{ provincia: 3, canton: 1, distrito: 5, nombre: "AGUA CALIENTE O SAN FRANCISCO" },
		{ provincia: 3, canton: 1, distrito: 5, nombre: "AGUA CALIENTE O SAN FRANCISCO" },
		{ provincia: 3, canton: 1, distrito: 6, nombre: "GUADALUPE O ARENILLA" },
		{ provincia: 3, canton: 1, distrito: 6, nombre: "GUADALUPE O ARENILLA" },
		{ provincia: 3, canton: 1, distrito: 7, nombre: "CORRALILLO" },
		{ provincia: 3, canton: 1, distrito: 7, nombre: "CORRALILLO" },
		{ provincia: 3, canton: 1, distrito: 8, nombre: "TIERRA BLANCA" },
		{ provincia: 3, canton: 1, distrito: 8, nombre: "TIERRA BLANCA" },
		{ provincia: 3, canton: 1, distrito: 9, nombre: "DULCE NOMBRE" },
		{ provincia: 3, canton: 1, distrito: 9, nombre: "DULCE NOMBRE" },
		{ provincia: 3, canton: 1, distrito: 10, nombre: "LLANO GRANDE" },
		{ provincia: 3, canton: 1, distrito: 10, nombre: "LLANO GRANDE" },
		{ provincia: 3, canton: 1, distrito: 11, nombre: "QUEBRADILLA" },
		{ provincia: 3, canton: 1, distrito: 11, nombre: "QUEBRADILLA" },
		{ provincia: 3, canton: 2, distrito: 1, nombre: "PARAISO" },
		{ provincia: 3, canton: 2, distrito: 1, nombre: "PARAISO" },
		{ provincia: 3, canton: 2, distrito: 2, nombre: "SANTIAGO" },
		{ provincia: 3, canton: 2, distrito: 2, nombre: "SANTIAGO" },
		{ provincia: 3, canton: 2, distrito: 3, nombre: "OROSI" },
		{ provincia: 3, canton: 2, distrito: 3, nombre: "OROSI" },
		{ provincia: 3, canton: 2, distrito: 4, nombre: "CACHI" },
		{ provincia: 3, canton: 2, distrito: 4, nombre: "CACHI" },
		{ provincia: 3, canton: 2, distrito: 5, nombre: "LLANOS DE SANTA LUCIA" },
		{ provincia: 3, canton: 2, distrito: 5, nombre: "LLANOS DE SANTA LUCIA" },
		{ provincia: 3, canton: 3, distrito: 1, nombre: "TRES RIOS" },
		{ provincia: 3, canton: 3, distrito: 1, nombre: "TRES RIOS" },
		{ provincia: 3, canton: 3, distrito: 2, nombre: "SAN DIEGO" },
		{ provincia: 3, canton: 3, distrito: 2, nombre: "SAN DIEGO" },
		{ provincia: 3, canton: 3, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 3, canton: 3, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 3, canton: 3, distrito: 4, nombre: "SAN RAFAEL" },
		{ provincia: 3, canton: 3, distrito: 4, nombre: "SAN RAFAEL" },
		{ provincia: 3, canton: 3, distrito: 5, nombre: "CONCEPCION" },
		{ provincia: 3, canton: 3, distrito: 5, nombre: "CONCEPCION" },
		{ provincia: 3, canton: 3, distrito: 6, nombre: "DULCE NOMBRE" },
		{ provincia: 3, canton: 3, distrito: 6, nombre: "DULCE NOMBRE" },
		{ provincia: 3, canton: 3, distrito: 7, nombre: "SAN RAMON" },
		{ provincia: 3, canton: 3, distrito: 7, nombre: "SAN RAMON" },
		{ provincia: 3, canton: 3, distrito: 8, nombre: "RIO AZUL" },
		{ provincia: 3, canton: 3, distrito: 8, nombre: "RIO AZUL" },
		{ provincia: 3, canton: 4, distrito: 1, nombre: "JUAN VIÑAS" },
		{ provincia: 3, canton: 4, distrito: 1, nombre: "JUAN VIÑAS" },
		{ provincia: 3, canton: 4, distrito: 2, nombre: "TUCURRIQUE" },
		{ provincia: 3, canton: 4, distrito: 2, nombre: "TUCURRIQUE" },
		{ provincia: 3, canton: 4, distrito: 3, nombre: "PEJIBAYE" },
		{ provincia: 3, canton: 4, distrito: 3, nombre: "PEJIBAYE" },
		{ provincia: 3, canton: 5, distrito: 1, nombre: "TURRIALBA" },
		{ provincia: 3, canton: 5, distrito: 1, nombre: "TURRIALBA" },
		{ provincia: 3, canton: 5, distrito: 2, nombre: "LA SUIZA" },
		{ provincia: 3, canton: 5, distrito: 2, nombre: "LA SUIZA" },
		{ provincia: 3, canton: 5, distrito: 3, nombre: "PERALTA" },
		{ provincia: 3, canton: 5, distrito: 3, nombre: "PERALTA" },
		{ provincia: 3, canton: 5, distrito: 4, nombre: "SANTA CRUZ" },
		{ provincia: 3, canton: 5, distrito: 4, nombre: "SANTA CRUZ" },
		{ provincia: 3, canton: 5, distrito: 5, nombre: "SANTA TERESITA" },
		{ provincia: 3, canton: 5, distrito: 5, nombre: "SANTA TERESITA" },
		{ provincia: 3, canton: 5, distrito: 6, nombre: "PAVONES" },
		{ provincia: 3, canton: 5, distrito: 6, nombre: "PAVONES" },
		{ provincia: 3, canton: 5, distrito: 7, nombre: "TUIS" },
		{ provincia: 3, canton: 5, distrito: 7, nombre: "TUIS" },
		{ provincia: 3, canton: 5, distrito: 8, nombre: "TAYUTIC" },
		{ provincia: 3, canton: 5, distrito: 8, nombre: "TAYUTIC" },
		{ provincia: 3, canton: 5, distrito: 9, nombre: "SANTA ROSA" },
		{ provincia: 3, canton: 5, distrito: 9, nombre: "SANTA ROSA" },
		{ provincia: 3, canton: 5, distrito: 10, nombre: "TRES EQUIS" },
		{ provincia: 3, canton: 5, distrito: 10, nombre: "TRES EQUIS" },
		{ provincia: 3, canton: 5, distrito: 11, nombre: "LA ISABEL" },
		{ provincia: 3, canton: 5, distrito: 12, nombre: "CHIRRIPO" },
		{ provincia: 3, canton: 6, distrito: 1, nombre: "PACAYAS" },
		{ provincia: 3, canton: 6, distrito: 1, nombre: "PACAYAS" },
		{ provincia: 3, canton: 6, distrito: 2, nombre: "CERVANTES" },
		{ provincia: 3, canton: 6, distrito: 2, nombre: "CERVANTES" },
		{ provincia: 3, canton: 6, distrito: 3, nombre: "CAPELLADES" },
		{ provincia: 3, canton: 6, distrito: 3, nombre: "CAPELLADES" },
		{ provincia: 3, canton: 7, distrito: 1, nombre: "SAN RAFAEL" },
		{ provincia: 3, canton: 7, distrito: 1, nombre: "SAN RAFAEL" },
		{ provincia: 3, canton: 7, distrito: 2, nombre: "COT" },
		{ provincia: 3, canton: 7, distrito: 2, nombre: "COT" },
		{ provincia: 3, canton: 7, distrito: 3, nombre: "POTRERO CERRADO" },
		{ provincia: 3, canton: 7, distrito: 3, nombre: "POTRERO CERRADO" },
		{ provincia: 3, canton: 7, distrito: 4, nombre: "CIPRESES" },
		{ provincia: 3, canton: 7, distrito: 4, nombre: "CIPRESES" },
		{ provincia: 3, canton: 7, distrito: 5, nombre: "SANTA ROSA" },
		{ provincia: 3, canton: 7, distrito: 5, nombre: "SANTA ROSA" },
		{ provincia: 3, canton: 8, distrito: 1, nombre: "TEJAR" },
		{ provincia: 3, canton: 8, distrito: 1, nombre: "TEJAR" },
		{ provincia: 3, canton: 8, distrito: 2, nombre: "SAN ISIDRO" },
		{ provincia: 3, canton: 8, distrito: 2, nombre: "SAN ISIDRO" },
		{ provincia: 3, canton: 8, distrito: 3, nombre: "TOBOSI" },
		{ provincia: 3, canton: 8, distrito: 3, nombre: "TOBOSI" },
		{ provincia: 3, canton: 8, distrito: 4, nombre: "PATIO DE AGUA" },
		{ provincia: 3, canton: 8, distrito: 4, nombre: "PATIO DE AGUA" },
		{ provincia: 4, canton: 1, distrito: 1, nombre: "HEREDIA" },
		{ provincia: 4, canton: 1, distrito: 1, nombre: "HEREDIA" },
		{ provincia: 4, canton: 1, distrito: 2, nombre: "MERCEDES" },
		{ provincia: 4, canton: 1, distrito: 2, nombre: "MERCEDES" },
		{ provincia: 4, canton: 1, distrito: 3, nombre: "SAN FRANCISCO" },
		{ provincia: 4, canton: 1, distrito: 3, nombre: "SAN FRANCISCO" },
		{ provincia: 4, canton: 1, distrito: 4, nombre: "ULLOA" },
		{ provincia: 4, canton: 1, distrito: 4, nombre: "ULLOA" },
		{ provincia: 4, canton: 1, distrito: 5, nombre: "VARABLANCA" },
		{ provincia: 4, canton: 1, distrito: 5, nombre: "VARABLANCA" },
		{ provincia: 4, canton: 2, distrito: 1, nombre: "BARVA" },
		{ provincia: 4, canton: 2, distrito: 1, nombre: "BARVA" },
		{ provincia: 4, canton: 2, distrito: 2, nombre: "SAN PEDRO" },
		{ provincia: 4, canton: 2, distrito: 2, nombre: "SAN PEDRO" },
		{ provincia: 4, canton: 2, distrito: 3, nombre: "SAN PABLO" },
		{ provincia: 4, canton: 2, distrito: 3, nombre: "SAN PABLO" },
		{ provincia: 4, canton: 2, distrito: 4, nombre: "SAN ROQUE" },
		{ provincia: 4, canton: 2, distrito: 4, nombre: "SAN ROQUE" },
		{ provincia: 4, canton: 2, distrito: 5, nombre: "SANTA LUCIA" },
		{ provincia: 4, canton: 2, distrito: 5, nombre: "SANTA LUCIA" },
		{ provincia: 4, canton: 2, distrito: 6, nombre: "SAN JOSE DE LA MONTAÑA" },
		{ provincia: 4, canton: 2, distrito: 6, nombre: "SAN JOSE DE LA MONTAÑA" },
		{ provincia: 4, canton: 3, distrito: 1, nombre: "SANTO DOMINGO" },
		{ provincia: 4, canton: 3, distrito: 1, nombre: "SANTO DOMINGO" },
		{ provincia: 4, canton: 3, distrito: 2, nombre: "SAN VICENTE" },
		{ provincia: 4, canton: 3, distrito: 2, nombre: "SAN VICENTE" },
		{ provincia: 4, canton: 3, distrito: 3, nombre: "SAN MIGUEL" },
		{ provincia: 4, canton: 3, distrito: 3, nombre: "SAN MIGUEL" },
		{ provincia: 4, canton: 3, distrito: 4, nombre: "PARACITO" },
		{ provincia: 4, canton: 3, distrito: 4, nombre: "PARACITO" },
		{ provincia: 4, canton: 3, distrito: 5, nombre: "SANTO TOMAS" },
		{ provincia: 4, canton: 3, distrito: 5, nombre: "SANTO TOMAS" },
		{ provincia: 4, canton: 3, distrito: 6, nombre: "SANTA ROSA" },
		{ provincia: 4, canton: 3, distrito: 6, nombre: "SANTA ROSA" },
		{ provincia: 4, canton: 3, distrito: 7, nombre: "TURES" },
		{ provincia: 4, canton: 3, distrito: 7, nombre: "TURES" },
		{ provincia: 4, canton: 3, distrito: 8, nombre: "PARA" },
		{ provincia: 4, canton: 3, distrito: 8, nombre: "PARA" },
		{ provincia: 4, canton: 4, distrito: 1, nombre: "SANTA BARBARA" },
		{ provincia: 4, canton: 4, distrito: 1, nombre: "SANTA BARBARA" },
		{ provincia: 4, canton: 4, distrito: 2, nombre: "SAN PEDRO" },
		{ provincia: 4, canton: 4, distrito: 2, nombre: "SAN PEDRO" },
		{ provincia: 4, canton: 4, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 4, canton: 4, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 4, canton: 4, distrito: 4, nombre: "JESUS" },
		{ provincia: 4, canton: 4, distrito: 4, nombre: "JESUS" },
		{ provincia: 4, canton: 4, distrito: 5, nombre: "SANTO DOMINGO" },
		{ provincia: 4, canton: 4, distrito: 5, nombre: "SANTO DOMINGO" },
		{ provincia: 4, canton: 4, distrito: 6, nombre: "PURABA" },
		{ provincia: 4, canton: 4, distrito: 6, nombre: "PURABA" },
		{ provincia: 4, canton: 5, distrito: 1, nombre: "SAN RAFAEL" },
		{ provincia: 4, canton: 5, distrito: 1, nombre: "SAN RAFAEL" },
		{ provincia: 4, canton: 5, distrito: 2, nombre: "SAN JOSECITO" },
		{ provincia: 4, canton: 5, distrito: 2, nombre: "SAN JOSECITO" },
		{ provincia: 4, canton: 5, distrito: 3, nombre: "SANTIAGO" },
		{ provincia: 4, canton: 5, distrito: 3, nombre: "SANTIAGO" },
		{ provincia: 4, canton: 5, distrito: 4, nombre: "ANGELES" },
		{ provincia: 4, canton: 5, distrito: 4, nombre: "ANGELES" },
		{ provincia: 4, canton: 5, distrito: 5, nombre: "CONCEPCION" },
		{ provincia: 4, canton: 5, distrito: 5, nombre: "CONCEPCION" },
		{ provincia: 4, canton: 6, distrito: 1, nombre: "SAN ISIDRO" },
		{ provincia: 4, canton: 6, distrito: 1, nombre: "SAN ISIDRO" },
		{ provincia: 4, canton: 6, distrito: 2, nombre: "SAN JOSE" },
		{ provincia: 4, canton: 6, distrito: 2, nombre: "SAN JOSE" },
		{ provincia: 4, canton: 6, distrito: 3, nombre: "CONCEPCION" },
		{ provincia: 4, canton: 6, distrito: 3, nombre: "CONCEPCION" },
		{ provincia: 4, canton: 6, distrito: 4, nombre: "SAN FRANCISCO" },
		{ provincia: 4, canton: 6, distrito: 4, nombre: "SAN FRANCISCO" },
		{ provincia: 4, canton: 7, distrito: 1, nombre: "SAN ANTONIO" },
		{ provincia: 4, canton: 7, distrito: 1, nombre: "SAN ANTONIO" },
		{ provincia: 4, canton: 7, distrito: 2, nombre: "RIBERA" },
		{ provincia: 4, canton: 7, distrito: 2, nombre: "RIBERA" },
		{ provincia: 4, canton: 7, distrito: 3, nombre: "ASUNCION" },
		{ provincia: 4, canton: 7, distrito: 3, nombre: "ASUNCION" },
		{ provincia: 4, canton: 8, distrito: 1, nombre: "SAN JOAQUIN" },
		{ provincia: 4, canton: 8, distrito: 1, nombre: "SAN JOAQUIN" },
		{ provincia: 4, canton: 8, distrito: 2, nombre: "BARRANTES" },
		{ provincia: 4, canton: 8, distrito: 2, nombre: "BARRANTES" },
		{ provincia: 4, canton: 8, distrito: 3, nombre: "LLORENTE" },
		{ provincia: 4, canton: 8, distrito: 3, nombre: "LLORENTE" },
		{ provincia: 4, canton: 9, distrito: 1, nombre: "SAN PABLO" },
		{ provincia: 4, canton: 9, distrito: 1, nombre: "SAN PABLO" },
		{ provincia: 4, canton: 9, distrito: 2, nombre: "RINCON DE SABANILLA" },
		{ provincia: 4, canton: 9, distrito: 2, nombre: "RINCON DE SABANILLA" },
		{ provincia: 4, canton: 10, distrito: 1, nombre: "PUERTO VIEJO" },
		{ provincia: 4, canton: 10, distrito: 1, nombre: "PUERTO VIEJO" },
		{ provincia: 4, canton: 10, distrito: 2, nombre: "LA VIRGEN" },
		{ provincia: 4, canton: 10, distrito: 2, nombre: "LA VIRGEN" },
		{ provincia: 4, canton: 10, distrito: 3, nombre: "HORQUETAS" },
		{ provincia: 4, canton: 10, distrito: 3, nombre: "HORQUETAS" },
		{ provincia: 4, canton: 10, distrito: 4, nombre: "LLANURAS DEL GASPAR" },
		{ provincia: 4, canton: 10, distrito: 4, nombre: "LLANURAS DEL GASPAR" },
		{ provincia: 4, canton: 10, distrito: 5, nombre: "CUREÑA" },
		{ provincia: 4, canton: 10, distrito: 5, nombre: "CUREÑA" },
		{ provincia: 5, canton: 1, distrito: 1, nombre: "LIBERIA" },
		{ provincia: 5, canton: 1, distrito: 1, nombre: "LIBERIA" },
		{ provincia: 5, canton: 1, distrito: 2, nombre: "CAÑAS DULCES" },
		{ provincia: 5, canton: 1, distrito: 2, nombre: "CAÑAS DULCES" },
		{ provincia: 5, canton: 1, distrito: 3, nombre: "MAYORGA" },
		{ provincia: 5, canton: 1, distrito: 3, nombre: "MAYORGA" },
		{ provincia: 5, canton: 1, distrito: 4, nombre: "NACASCOLO" },
		{ provincia: 5, canton: 1, distrito: 4, nombre: "NACASCOLO" },
		{ provincia: 5, canton: 1, distrito: 5, nombre: "CURUBANDE" },
		{ provincia: 5, canton: 1, distrito: 5, nombre: "CURUBANDE" },
		{ provincia: 5, canton: 2, distrito: 1, nombre: "NICOYA" },
		{ provincia: 5, canton: 2, distrito: 1, nombre: "NICOYA" },
		{ provincia: 5, canton: 2, distrito: 2, nombre: "MANSION" },
		{ provincia: 5, canton: 2, distrito: 2, nombre: "MANSION" },
		{ provincia: 5, canton: 2, distrito: 3, nombre: "SAN ANTONIO" },
		{ provincia: 5, canton: 2, distrito: 3, nombre: "SAN ANTONIO" },
		{ provincia: 5, canton: 2, distrito: 4, nombre: "QUEBRADA HONDA" },
		{ provincia: 5, canton: 2, distrito: 4, nombre: "QUEBRADA HONDA" },
		{ provincia: 5, canton: 2, distrito: 5, nombre: "SAMARA" },
		{ provincia: 5, canton: 2, distrito: 5, nombre: "SAMARA" },
		{ provincia: 5, canton: 2, distrito: 6, nombre: "NOSARA" },
		{ provincia: 5, canton: 2, distrito: 6, nombre: "NOSARA" },
		{ provincia: 5, canton: 2, distrito: 7, nombre: "BELEN DE NOSARITA" },
		{ provincia: 5, canton: 2, distrito: 7, nombre: "BELEN DE NOSARITA" },
		{ provincia: 5, canton: 3, distrito: 1, nombre: "SANTA CRUZ" },
		{ provincia: 5, canton: 3, distrito: 1, nombre: "SANTA CRUZ" },
		{ provincia: 5, canton: 3, distrito: 2, nombre: "BOLSON" },
		{ provincia: 5, canton: 3, distrito: 2, nombre: "BOLSON" },
		{ provincia: 5, canton: 3, distrito: 3, nombre: "VEINTISIETE DE ABRIL" },
		{ provincia: 5, canton: 3, distrito: 3, nombre: "VEINTISIETE DE ABRIL" },
		{ provincia: 5, canton: 3, distrito: 4, nombre: "TEMPATE" },
		{ provincia: 5, canton: 3, distrito: 4, nombre: "TEMPATE" },
		{ provincia: 5, canton: 3, distrito: 5, nombre: "CARTAGENA" },
		{ provincia: 5, canton: 3, distrito: 5, nombre: "CARTAGENA" },
		{ provincia: 5, canton: 3, distrito: 6, nombre: "CUAJINIQUIL" },
		{ provincia: 5, canton: 3, distrito: 6, nombre: "CUAJINIQUIL" },
		{ provincia: 5, canton: 3, distrito: 7, nombre: "DIRIA" },
		{ provincia: 5, canton: 3, distrito: 7, nombre: "DIRIA" },
		{ provincia: 5, canton: 3, distrito: 8, nombre: "CABO VELAS" },
		{ provincia: 5, canton: 3, distrito: 8, nombre: "CABO VELAS" },
		{ provincia: 5, canton: 3, distrito: 9, nombre: "TAMARINDO" },
		{ provincia: 5, canton: 3, distrito: 9, nombre: "TAMARINDO" },
		{ provincia: 5, canton: 4, distrito: 1, nombre: "BAGACES" },
		{ provincia: 5, canton: 4, distrito: 1, nombre: "BAGACES" },
		{ provincia: 5, canton: 4, distrito: 2, nombre: "FORTUNA" },
		{ provincia: 5, canton: 4, distrito: 2, nombre: "FORTUNA" },
		{ provincia: 5, canton: 4, distrito: 3, nombre: "MOGOTE" },
		{ provincia: 5, canton: 4, distrito: 3, nombre: "MOGOTE" },
		{ provincia: 5, canton: 4, distrito: 4, nombre: "RIO NARANJO" },
		{ provincia: 5, canton: 4, distrito: 4, nombre: "RIO NARANJO" },
		{ provincia: 5, canton: 5, distrito: 1, nombre: "FILADELFIA" },
		{ provincia: 5, canton: 5, distrito: 1, nombre: "FILADELFIA" },
		{ provincia: 5, canton: 5, distrito: 2, nombre: "PALMIRA" },
		{ provincia: 5, canton: 5, distrito: 2, nombre: "PALMIRA" },
		{ provincia: 5, canton: 5, distrito: 3, nombre: "SARDINAL" },
		{ provincia: 5, canton: 5, distrito: 3, nombre: "SARDINAL" },
		{ provincia: 5, canton: 5, distrito: 4, nombre: "BELEN" },
		{ provincia: 5, canton: 5, distrito: 4, nombre: "BELEN" },
		{ provincia: 5, canton: 6, distrito: 1, nombre: "CAÑAS" },
		{ provincia: 5, canton: 6, distrito: 1, nombre: "CAÑAS" },
		{ provincia: 5, canton: 6, distrito: 2, nombre: "PALMIRA" },
		{ provincia: 5, canton: 6, distrito: 2, nombre: "PALMIRA" },
		{ provincia: 5, canton: 6, distrito: 3, nombre: "SAN MIGUEL" },
		{ provincia: 5, canton: 6, distrito: 3, nombre: "SAN MIGUEL" },
		{ provincia: 5, canton: 6, distrito: 4, nombre: "BEBEDERO" },
		{ provincia: 5, canton: 6, distrito: 4, nombre: "BEBEDERO" },
		{ provincia: 5, canton: 6, distrito: 5, nombre: "POROZAL" },
		{ provincia: 5, canton: 6, distrito: 5, nombre: "POROZAL" },
		{ provincia: 5, canton: 7, distrito: 1, nombre: "JUNTAS" },
		{ provincia: 5, canton: 7, distrito: 1, nombre: "JUNTAS" },
		{ provincia: 5, canton: 7, distrito: 2, nombre: "SIERRA" },
		{ provincia: 5, canton: 7, distrito: 2, nombre: "SIERRA" },
		{ provincia: 5, canton: 7, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 5, canton: 7, distrito: 3, nombre: "SAN JUAN" },
		{ provincia: 5, canton: 7, distrito: 4, nombre: "COLORADO" },
		{ provincia: 5, canton: 7, distrito: 4, nombre: "COLORADO" },
		{ provincia: 5, canton: 8, distrito: 1, nombre: "TILARAN" },
		{ provincia: 5, canton: 8, distrito: 1, nombre: "TILARAN" },
		{ provincia: 5, canton: 8, distrito: 2, nombre: "QUEBRADA GRANDE" },
		{ provincia: 5, canton: 8, distrito: 2, nombre: "QUEBRADA GRANDE" },
		{ provincia: 5, canton: 8, distrito: 3, nombre: "TRONADORA" },
		{ provincia: 5, canton: 8, distrito: 3, nombre: "TRONADORA" },
		{ provincia: 5, canton: 8, distrito: 4, nombre: "SANTA ROSA" },
		{ provincia: 5, canton: 8, distrito: 4, nombre: "SANTA ROSA" },
		{ provincia: 5, canton: 8, distrito: 5, nombre: "LIBANO" },
		{ provincia: 5, canton: 8, distrito: 5, nombre: "LIBANO" },
		{ provincia: 5, canton: 8, distrito: 6, nombre: "TIERRAS MORENAS" },
		{ provincia: 5, canton: 8, distrito: 6, nombre: "TIERRAS MORENAS" },
		{ provincia: 5, canton: 8, distrito: 7, nombre: "ARENAL" },
		{ provincia: 5, canton: 8, distrito: 7, nombre: "ARENAL" },
		{ provincia: 5, canton: 9, distrito: 1, nombre: "CARMONA" },
		{ provincia: 5, canton: 9, distrito: 1, nombre: "CARMONA" },
		{ provincia: 5, canton: 9, distrito: 2, nombre: "SANTA RITA" },
		{ provincia: 5, canton: 9, distrito: 2, nombre: "SANTA RITA" },
		{ provincia: 5, canton: 9, distrito: 3, nombre: "ZAPOTAL" },
		{ provincia: 5, canton: 9, distrito: 3, nombre: "ZAPOTAL" },
		{ provincia: 5, canton: 9, distrito: 4, nombre: "SAN PABLO" },
		{ provincia: 5, canton: 9, distrito: 4, nombre: "SAN PABLO" },
		{ provincia: 5, canton: 9, distrito: 5, nombre: "PORVENIR" },
		{ provincia: 5, canton: 9, distrito: 5, nombre: "PORVENIR" },
		{ provincia: 5, canton: 9, distrito: 6, nombre: "BEJUCO" },
		{ provincia: 5, canton: 9, distrito: 6, nombre: "BEJUCO" },
		{ provincia: 5, canton: 10, distrito: 1, nombre: "LA CRUZ" },
		{ provincia: 5, canton: 10, distrito: 1, nombre: "LA CRUZ" },
		{ provincia: 5, canton: 10, distrito: 2, nombre: "SANTA CECILIA" },
		{ provincia: 5, canton: 10, distrito: 2, nombre: "SANTA CECILIA" },
		{ provincia: 5, canton: 10, distrito: 3, nombre: "GARITA" },
		{ provincia: 5, canton: 10, distrito: 3, nombre: "GARITA" },
		{ provincia: 5, canton: 10, distrito: 4, nombre: "SANTA ELENA" },
		{ provincia: 5, canton: 10, distrito: 4, nombre: "SANTA ELENA" },
		{ provincia: 5, canton: 11, distrito: 1, nombre: "HOJANCHA" },
		{ provincia: 5, canton: 11, distrito: 1, nombre: "HOJANCHA" },
		{ provincia: 5, canton: 11, distrito: 2, nombre: "MONTE ROMO" },
		{ provincia: 5, canton: 11, distrito: 2, nombre: "MONTE ROMO" },
		{ provincia: 5, canton: 11, distrito: 3, nombre: "PUERTO CARRILLO" },
		{ provincia: 5, canton: 11, distrito: 3, nombre: "PUERTO CARRILLO" },
		{ provincia: 5, canton: 11, distrito: 4, nombre: "HUACAS" },
		{ provincia: 5, canton: 11, distrito: 4, nombre: "HUACAS" },
		{ provincia: 6, canton: 1, distrito: 1, nombre: "PUNTARENAS" },
		{ provincia: 6, canton: 1, distrito: 1, nombre: "PUNTARENAS" },
		{ provincia: 6, canton: 1, distrito: 2, nombre: "PITAHAYA" },
		{ provincia: 6, canton: 1, distrito: 2, nombre: "PITAHAYA" },
		{ provincia: 6, canton: 1, distrito: 3, nombre: "CHOMES" },
		{ provincia: 6, canton: 1, distrito: 3, nombre: "CHOMES" },
		{ provincia: 6, canton: 1, distrito: 4, nombre: "LEPANTO" },
		{ provincia: 6, canton: 1, distrito: 4, nombre: "LEPANTO" },
		{ provincia: 6, canton: 1, distrito: 5, nombre: "PAQUERA" },
		{ provincia: 6, canton: 1, distrito: 5, nombre: "PAQUERA" },
		{ provincia: 6, canton: 1, distrito: 6, nombre: "MANZANILLO" },
		{ provincia: 6, canton: 1, distrito: 6, nombre: "MANZANILLO" },
		{ provincia: 6, canton: 1, distrito: 7, nombre: "GUACIMAL" },
		{ provincia: 6, canton: 1, distrito: 7, nombre: "GUACIMAL" },
		{ provincia: 6, canton: 1, distrito: 8, nombre: "BARRANCA" },
		{ provincia: 6, canton: 1, distrito: 8, nombre: "BARRANCA" },
		{ provincia: 6, canton: 1, distrito: 9, nombre: "MONTE VERDE" },
		{ provincia: 6, canton: 1, distrito: 9, nombre: "MONTE VERDE" },
		{ provincia: 6, canton: 1, distrito: 10, nombre: "ISLA DEL COCO" },
		{ provincia: 6, canton: 1, distrito: 10, nombre: "ISLA DEL COCO" },
		{ provincia: 6, canton: 1, distrito: 11, nombre: "COBANO" },
		{ provincia: 6, canton: 1, distrito: 11, nombre: "COBANO" },
		{ provincia: 6, canton: 1, distrito: 12, nombre: "CHACARITA" },
		{ provincia: 6, canton: 1, distrito: 12, nombre: "CHACARITA" },
		{ provincia: 6, canton: 1, distrito: 13, nombre: "CHIRA" },
		{ provincia: 6, canton: 1, distrito: 13, nombre: "CHIRA" },
		{ provincia: 6, canton: 1, distrito: 14, nombre: "ACAPULCO" },
		{ provincia: 6, canton: 1, distrito: 14, nombre: "ACAPULCO" },
		{ provincia: 6, canton: 1, distrito: 15, nombre: "EL ROBLE" },
		{ provincia: 6, canton: 1, distrito: 15, nombre: "EL ROBLE" },
		{ provincia: 6, canton: 1, distrito: 16, nombre: "ARANCIBIA" },
		{ provincia: 6, canton: 2, distrito: 1, nombre: "ESPIRITU SANTO" },
		{ provincia: 6, canton: 2, distrito: 1, nombre: "ESPIRITU SANTO" },
		{ provincia: 6, canton: 2, distrito: 2, nombre: "SAN JUAN GRANDE" },
		{ provincia: 6, canton: 2, distrito: 2, nombre: "SAN JUAN GRANDE" },
		{ provincia: 6, canton: 2, distrito: 3, nombre: "MACACONA" },
		{ provincia: 6, canton: 2, distrito: 3, nombre: "MACACONA" },
		{ provincia: 6, canton: 2, distrito: 4, nombre: "SAN RAFAEL" },
		{ provincia: 6, canton: 2, distrito: 4, nombre: "SAN RAFAEL" },
		{ provincia: 6, canton: 2, distrito: 5, nombre: "SAN JERONIMO" },
		{ provincia: 6, canton: 2, distrito: 5, nombre: "SAN JERONIMO" },
		{ provincia: 6, canton: 3, distrito: 1, nombre: "BUENOS AIRES" },
		{ provincia: 6, canton: 3, distrito: 1, nombre: "BUENOS AIRES" },
		{ provincia: 6, canton: 3, distrito: 2, nombre: "VOLCAN" },
		{ provincia: 6, canton: 3, distrito: 2, nombre: "VOLCAN" },
		{ provincia: 6, canton: 3, distrito: 3, nombre: "POTRERO GRANDE" },
		{ provincia: 6, canton: 3, distrito: 3, nombre: "POTRERO GRANDE" },
		{ provincia: 6, canton: 3, distrito: 4, nombre: "BORUCA" },
		{ provincia: 6, canton: 3, distrito: 4, nombre: "BORUCA" },
		{ provincia: 6, canton: 3, distrito: 5, nombre: "PILAS" },
		{ provincia: 6, canton: 3, distrito: 5, nombre: "PILAS" },
		{ provincia: 6, canton: 3, distrito: 6, nombre: "COLINAS" },
		{ provincia: 6, canton: 3, distrito: 6, nombre: "COLINAS" },
		{ provincia: 6, canton: 3, distrito: 7, nombre: "CHANGUENA" },
		{ provincia: 6, canton: 3, distrito: 7, nombre: "CHANGUENA" },
		{ provincia: 6, canton: 3, distrito: 8, nombre: "BIOLLEY" },
		{ provincia: 6, canton: 3, distrito: 8, nombre: "BIOLLEY" },
		{ provincia: 6, canton: 3, distrito: 9, nombre: "BRUNKA" },
		{ provincia: 6, canton: 3, distrito: 9, nombre: "BRUNKA" },
		{ provincia: 6, canton: 4, distrito: 1, nombre: "MIRAMAR" },
		{ provincia: 6, canton: 4, distrito: 1, nombre: "MIRAMAR" },
		{ provincia: 6, canton: 4, distrito: 2, nombre: "UNION" },
		{ provincia: 6, canton: 4, distrito: 2, nombre: "UNION" },
		{ provincia: 6, canton: 4, distrito: 3, nombre: "SAN ISIDRO" },
		{ provincia: 6, canton: 4, distrito: 3, nombre: "SAN ISIDRO" },
		{ provincia: 6, canton: 5, distrito: 1, nombre: "PUERTO CORTES" },
		{ provincia: 6, canton: 5, distrito: 1, nombre: "PUERTO CORTES" },
		{ provincia: 6, canton: 5, distrito: 2, nombre: "PALMAR" },
		{ provincia: 6, canton: 5, distrito: 2, nombre: "PALMAR" },
		{ provincia: 6, canton: 5, distrito: 3, nombre: "SIERPE" },
		{ provincia: 6, canton: 5, distrito: 3, nombre: "SIERPE" },
		{ provincia: 6, canton: 5, distrito: 4, nombre: "BAHIA BALLENA" },
		{ provincia: 6, canton: 5, distrito: 4, nombre: "BAHIA BALLENA" },
		{ provincia: 6, canton: 5, distrito: 5, nombre: "PIEDRAS BLANCAS" },
		{ provincia: 6, canton: 5, distrito: 5, nombre: "PIEDRAS BLANCAS" },
		{ provincia: 6, canton: 5, distrito: 6, nombre: "BAHIA DRAKE" },
		{ provincia: 6, canton: 5, distrito: 6, nombre: "BAHIA DRAKE" },
		{ provincia: 6, canton: 6, distrito: 1, nombre: "QUEPOS" },
		{ provincia: 6, canton: 6, distrito: 1, nombre: "QUEPOS" },
		{ provincia: 6, canton: 6, distrito: 2, nombre: "SAVEGRE" },
		{ provincia: 6, canton: 6, distrito: 2, nombre: "SAVEGRE" },
		{ provincia: 6, canton: 6, distrito: 3, nombre: "NARANJITO" },
		{ provincia: 6, canton: 6, distrito: 3, nombre: "NARANJITO" },
		{ provincia: 6, canton: 7, distrito: 1, nombre: "GOLFITO" },
		{ provincia: 6, canton: 7, distrito: 1, nombre: "GOLFITO" },
		{ provincia: 6, canton: 7, distrito: 2, nombre: "PUERTO JIMENEZ" },
		{ provincia: 6, canton: 7, distrito: 2, nombre: "PUERTO JIMENEZ" },
		{ provincia: 6, canton: 7, distrito: 3, nombre: "GUAYCARA" },
		{ provincia: 6, canton: 7, distrito: 3, nombre: "GUAYCARA" },
		{ provincia: 6, canton: 7, distrito: 4, nombre: "PAVON" },
		{ provincia: 6, canton: 7, distrito: 4, nombre: "PAVON" },
		{ provincia: 6, canton: 8, distrito: 1, nombre: "SAN VITO" },
		{ provincia: 6, canton: 8, distrito: 1, nombre: "SAN VITO" },
		{ provincia: 6, canton: 8, distrito: 2, nombre: "SABALITO" },
		{ provincia: 6, canton: 8, distrito: 2, nombre: "SABALITO" },
		{ provincia: 6, canton: 8, distrito: 3, nombre: "AGUA BUENA" },
		{ provincia: 6, canton: 8, distrito: 3, nombre: "AGUA BUENA" },
		{ provincia: 6, canton: 8, distrito: 4, nombre: "LIMONCITO" },
		{ provincia: 6, canton: 8, distrito: 4, nombre: "LIMONCITO" },
		{ provincia: 6, canton: 8, distrito: 5, nombre: "PITTIER" },
		{ provincia: 6, canton: 8, distrito: 5, nombre: "PITTIER" },
		{ provincia: 6, canton: 8, distrito: 6, nombre: "GUTIERREZ BROWN" },
		{ provincia: 6, canton: 9, distrito: 1, nombre: "PARRITA" },
		{ provincia: 6, canton: 9, distrito: 1, nombre: "PARRITA" },
		{ provincia: 6, canton: 10, distrito: 1, nombre: "CORREDOR" },
		{ provincia: 6, canton: 10, distrito: 1, nombre: "CORREDOR" },
		{ provincia: 6, canton: 10, distrito: 2, nombre: "LA CUESTA" },
		{ provincia: 6, canton: 10, distrito: 2, nombre: "LA CUESTA" },
		{ provincia: 6, canton: 10, distrito: 3, nombre: "CANOAS" },
		{ provincia: 6, canton: 10, distrito: 3, nombre: "CANOAS" },
		{ provincia: 6, canton: 10, distrito: 4, nombre: "LAUREL" },
		{ provincia: 6, canton: 10, distrito: 4, nombre: "LAUREL" },
		{ provincia: 6, canton: 11, distrito: 1, nombre: "JACO" },
		{ provincia: 6, canton: 11, distrito: 1, nombre: "JACO" },
		{ provincia: 6, canton: 11, distrito: 2, nombre: "TARCOLES" },
		{ provincia: 6, canton: 11, distrito: 2, nombre: "TARCOLES" },
		{ provincia: 7, canton: 1, distrito: 1, nombre: "LIMON" },
		{ provincia: 7, canton: 1, distrito: 1, nombre: "LIMON" },
		{ provincia: 7, canton: 1, distrito: 2, nombre: "VALLE LA ESTRELLA" },
		{ provincia: 7, canton: 1, distrito: 2, nombre: "VALLE LA ESTRELLA" },
		{ provincia: 7, canton: 1, distrito: 3, nombre: "RIO BLANCO" },
		{ provincia: 7, canton: 1, distrito: 3, nombre: "RIO BLANCO" },
		{ provincia: 7, canton: 1, distrito: 4, nombre: "MATAMA" },
		{ provincia: 7, canton: 1, distrito: 4, nombre: "MATAMA" },
		{ provincia: 7, canton: 2, distrito: 1, nombre: "GUAPILES" },
		{ provincia: 7, canton: 2, distrito: 1, nombre: "GUAPILES" },
		{ provincia: 7, canton: 2, distrito: 2, nombre: "JIMENEZ" },
		{ provincia: 7, canton: 2, distrito: 2, nombre: "JIMENEZ" },
		{ provincia: 7, canton: 2, distrito: 3, nombre: "RITA" },
		{ provincia: 7, canton: 2, distrito: 3, nombre: "RITA" },
		{ provincia: 7, canton: 2, distrito: 4, nombre: "ROXANA" },
		{ provincia: 7, canton: 2, distrito: 4, nombre: "ROXANA" },
		{ provincia: 7, canton: 2, distrito: 5, nombre: "CARIARI" },
		{ provincia: 7, canton: 2, distrito: 5, nombre: "CARIARI" },
		{ provincia: 7, canton: 2, distrito: 6, nombre: "COLORADO" },
		{ provincia: 7, canton: 2, distrito: 6, nombre: "COLORADO" },
		{ provincia: 7, canton: 2, distrito: 7, nombre: "LA COLONIA" },
		{ provincia: 7, canton: 3, distrito: 1, nombre: "SIQUIRRES" },
		{ provincia: 7, canton: 3, distrito: 1, nombre: "SIQUIRRES" },
		{ provincia: 7, canton: 3, distrito: 2, nombre: "PACUARITO" },
		{ provincia: 7, canton: 3, distrito: 2, nombre: "PACUARITO" },
		{ provincia: 7, canton: 3, distrito: 3, nombre: "FLORIDA" },
		{ provincia: 7, canton: 3, distrito: 3, nombre: "FLORIDA" },
		{ provincia: 7, canton: 3, distrito: 4, nombre: "GERMANIA" },
		{ provincia: 7, canton: 3, distrito: 4, nombre: "GERMANIA" },
		{ provincia: 7, canton: 3, distrito: 5, nombre: "CAIRO" },
		{ provincia: 7, canton: 3, distrito: 5, nombre: "CAIRO" },
		{ provincia: 7, canton: 3, distrito: 6, nombre: "ALEGRIA" },
		{ provincia: 7, canton: 3, distrito: 6, nombre: "ALEGRIA" },
		{ provincia: 7, canton: 4, distrito: 1, nombre: "BRATSI" },
		{ provincia: 7, canton: 4, distrito: 1, nombre: "BRATSI" },
		{ provincia: 7, canton: 4, distrito: 2, nombre: "SIXAOLA" },
		{ provincia: 7, canton: 4, distrito: 2, nombre: "SIXAOLA" },
		{ provincia: 7, canton: 4, distrito: 3, nombre: "CAHUITA" },
		{ provincia: 7, canton: 4, distrito: 3, nombre: "CAHUITA" },
		{ provincia: 7, canton: 4, distrito: 4, nombre: "TELIRE" },
		{ provincia: 7, canton: 5, distrito: 1, nombre: "MATINA" },
		{ provincia: 7, canton: 5, distrito: 1, nombre: "MATINA" },
		{ provincia: 7, canton: 5, distrito: 2, nombre: "BATAN" },
		{ provincia: 7, canton: 5, distrito: 2, nombre: "BATAN" },
		{ provincia: 7, canton: 5, distrito: 3, nombre: "CARRANDI" },
		{ provincia: 7, canton: 5, distrito: 3, nombre: "CARRANDI" },
		{ provincia: 7, canton: 6, distrito: 1, nombre: "GUACIMO" },
		{ provincia: 7, canton: 6, distrito: 1, nombre: "GUACIMO" },
		{ provincia: 7, canton: 6, distrito: 2, nombre: "MERCEDES" },
		{ provincia: 7, canton: 6, distrito: 2, nombre: "MERCEDES" },
		{ provincia: 7, canton: 6, distrito: 3, nombre: "POCORA" },
		{ provincia: 7, canton: 6, distrito: 3, nombre: "POCORA" },
		{ provincia: 7, canton: 6, distrito: 4, nombre: "RIO JIMENEZ" },
		{ provincia: 7, canton: 6, distrito: 4, nombre: "RIO JIMENEZ" },
		{ provincia: 7, canton: 6, distrito: 5, nombre: "DUACARI" },
		{ provincia: 7, canton: 6, distrito: 5, nombre: "DUACARI" }

    ];

};