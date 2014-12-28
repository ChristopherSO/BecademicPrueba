<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="ListaDeSolicitudes.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb" runat="server">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="/Secciones/index.aspx">Home</a>
		</li>
		<li class="active">
			Lista de solicitudes
		</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Lista de solicitudes en proceso de aprobación
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">

    <!-- Contenedor principal -->
    <div class="container">

        <div class="row">
            <div class="alert alert-info">
                <span id="txtNombreIntervencion"></span>
            </div>
            <div class="col-md-12">

                <!-- Tabla de becas -->
                <table class="table table-bordered table-hover table-striped">
	                <thead>
                        <tr>
                            <th>Solicitud</th>
                            <th>Usuario</th>
                            <th>Carrera</th>
                            <th>Tipo de beca</th>
                            <th>Estudio</th>
                            <th>Fecha</th>
                            <th>Emitir veredicto</th>
                        </tr>
	                </thead>
	                <tbody id="contenidoTabla">
	                </tbody>
                </table>
                <!-- / Tabla de becas -->
            </div>
        </div>
    </div>
    <!-- / Contenedor principal -->

    <!-- Ventana para actualizar tipos de beca -->
    <div class="modal fade" id="ventanaEmitirVeredicto">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEmitirVeredicto">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Emitir veredicto</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
              <!-- Cuerpo de la ventana -->   
                  
                  <!-- Espacio oculto para colocar el ID del Requisito que se esté editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                  <input type="hidden" id="txtIdSolicitud_emitir" />
                  <input type="hidden" id="txtIdUsuarioEstudiante_emitir" />
                  <input type="hidden" id="txtIdCarrera_emitir" />
                  <input type="hidden" id="txtIdTipoBeca_emitir" />

                    <div class="form-group">
                        <label for="txtComentario_agregar">Comentario:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtComentario_agregar" placeholder="" />
                    </div>

                  <div class="form-group" id="rdgAprobar">
                        <label for="txtEstado_editar">Aprueba:</label><br />
                        <div class="radio" id="rdgEstado_editar">
                            <label>
                                <input type="radio" name="aprueba" value="si" checked="checked" />
                                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                 Si 
                            </label>
                        </div>
                        <div class="radio">
                            <label>
                                <input type="radio" name="aprueba" value="no" />
                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                 No 
                            </label>
                        </div>
                   </div>

              <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="submit" class="btn btn-succcess btnEmitirVeredicto" id="btnAceptarVeredicto">Enviar</button>
                  <!-- / Zona inferior de la ventana -->
              </div>
            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para editar becas -->

    <!-- Ventana Loading.... -->
    <div class="modal fade" id="ventanaLoader">
      <div class="modal-dialog" style="width:126px;">
            <div class="modal-content">
                 <img src="../../assets/img/ajax-loader.gif" class="ïmg-responsive" />
            </div>
        </div>
    </div>
    <!-- Ventana Loading.... -->

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">

    <script src="../../assets/codigo_secciones/solicitudesBeca.js"></script>

</asp:Content>