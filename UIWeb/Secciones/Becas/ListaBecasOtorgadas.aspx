<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="ListaBecasOtorgadas.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Lista de becas otorgadas</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Lista de becas activas en el sistema.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">
    <!-- Tabla de becas -->
    <table class="table table-bordered table-hover table-striped">
	    <thead>
            <tr>
                <th>ID</th>
                <th>Carrera</th>
                <th>Fecha de aprobación</th>
                <th>Usuario</th>
                <th>Tipo de beca</th>
                <th>Estado</th>
                <th>Comentario</th>
                <th style="width:200px;">Acciones</th>
            </tr>
	    </thead>
	    <tbody id="contenidoTabla">
	    </tbody>
    </table>
    <!-- / Tabla de becas -->

    <!-- Ventana para agregar nuevas becas -->
    <div class="modal fade" id="ventanaAgregarBeca">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarBeca">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nueva beca</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->                        
                    <div class="form-group">
                        <label for="txtCarrera_agregar">Carrera:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtCarrera_agregar" placeholder="" />
                    </div>
                    <div class="form-group">
                        <label for="txtFechaAprobacion_agregar">Fecha de aprobación:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtFechaAprobacion_agregar" placeholder="" />
                    </div>
                    <div class="form-group">
                        <label for="txtUsuario_agregar">Usuario:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtUsuario_agregar" placeholder="" />
                    </div>
                    <div class="form-group">
                        <label for="txtTipoBeca_agregar">Tipo de beca:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtTipoBeca_agregar" placeholder="" />
                    </div>
                    <div class="form-group">
                        <label for="txtEstado_agregar">Estado:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtEstado_agregar" placeholder="" />
                    </div>
                    <div class="form-group">
                        <label for="txtComentario_agregar">Comentario:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtComentario_agregar" placeholder="" />
                    </div>
                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarBeca">Agregar beca</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevas becas -->


    <!-- Ventana para actualizar tipos de beca -->
    <div class="modal fade" id="ventanaEditarBeca">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarBeca">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Cambiar estado de beca</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
                    <!-- Cuerpo de la ventana -->                
                    <!-- Espacio oculto para colocar el ID de la beca que se esté editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    <input type="hidden" id="txtIdBeca_editar" />
                    
                    <!-- A las becas no se les edita sus referencias sino solo se le cambia su estado y comentario. -->
                    <!-- Por eso los primeros campos tienen input type="hidden" -->
                    <input type="hidden" class="form-control validate[required,minSize[1]]" id="txtCarrera_editar" />
                    <input type="hidden" class="form-control validate[required,minSize[1]]" id="txtFechaAprobacion_editar" />
                    <input type="hidden" class="form-control validate[required,minSize[1]]" id="txtUsuario_editar" />
                    <input type="hidden" class="form-control validate[required,minSize[1]]" id="txtTipoBeca_editar" />

                    <div class="form-group">
                        <label for="txtEstado_editar">Estado:</label><br />
                        <div class="btn-group" data-toggle="buttons" id="rdgEstado_editar">
                            <label class="btn btn-default">
                                <input type="radio" name="estado" value="true" checked="checked" />
                                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                 Activo 
                            </label>
                            <label class="btn btn-default">
                                <input type="radio" name="estado" value="false" />
                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                 Inactivo 
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtComentario_editar">Comentario:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtComentario_editar" placeholder="" />
                    </div>
                    <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarBeca">Guardar cambios</button>
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

    <script src="../../assets/codigo_secciones/Becas.js"></script>
    
</asp:Content>
