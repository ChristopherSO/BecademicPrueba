<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="Requisitos.aspx.vb"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Requisitos de becas</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Gestión de requisitos de becas.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">
    <!-- Contenedor principal -->
    <div class="container">
        <div class="row">
            <div class="col-md-12 validarPermiso" data-permiso="11">
                <p>
                    <button class="btn btn-info" data-toggle="modal" data-target="#ventanaAgregarRequisito">Agregar nuevo requisito</button>
                </p>
                <p>
                    Cambio de prueba
                </p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
    
    <!-- Tabla de requisito -->
                    <table class="table table-bordered table-hover table-striped">
	                    <thead>
                            <tr>
                                <th>ID</th>
                                <th>Tipo Requisito</th>
                                <th>Nombre</th>
                                <th>Descripci&oacute;n</th>
                                <th style="width:200px;">Acciones</th>
                            </tr>
	                    </thead>
	                    <tbody id="contenidoTabla">
	                    </tbody>
                    </table>
                </div>
            </div>
        </div>
    <!-- / Tabla de requisito -->
    <!-- Ventana para agregar nuevo requisito -->
    <div class="modal fade" id="ventanaAgregarRequisito">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarRequisito">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nuevo Requisito</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                    <!-- Campo para seleccionar un tipo de requisito -->
                    <div class="form-group">
                        <label for="lblTipoRequisito_agregar">Tipo de requisito:</label>
                        <select class="form-control" id="cmbTipoRequisito_agregar">
                        </select>
                    </div>                        
                    <!-- Campo para escribir el nombre de un Requisito -->
                    <div class="form-group">
                        <label for="lblNombreRequisito_agregar">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreRequisito_agregar" placeholder="Escriba aquí el nombre..." />
                    </div>
                    <!-- Campo para escribir la descripcion -->
                    <div class="form-group">
                        <label for="lblDescripcionRequisito_agregar">Descripci&oacute;n:</label>
                        <input type="text" class="form-control validate[required,minSize[2]" id="txtDescripcionRequisito_agregar" placeholder="Escriba aquí la descripcion..." />
                    </div>
                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarRequisito">Agregar Requisito</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevos beneficios -->


    <!-- Ventana para actualizar Requisito-->
    <div class="modal fade" id="ventanaEditarRequisito">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarRequisito">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar Requisito</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
                    <!-- Cuerpo de la ventana -->                
                    <!-- Espacio oculto para colocar el ID del Requisito que se esté editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    <input type="hidden" id="txtIdRequisito_editar" />
                  <!-- Campo para seleccionar un tipo de requisito -->
                    <div class="form-group">
                        <label for="lblTipoRequisito_editar">Tipo de requisito:</label>
                        <select class="form-control" id="cmbTipoRequisito_editar">
                        </select>
                    </div>
                    <!-- Campo para escribir el nombre de un Requisito -->
                    <div class="form-group">
                        <label for="txtNombreRequisito_editar">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreRequisito_editar" placeholder="Escriba aquí el nombre..." />
                    </div>
                  <!-- Campo para escribir la descripcion -->
                    <div class="form-group">
                        <label for="lblDescripcionRequisito_editar">Descripci&oacute;n:</label>
                        <input type="text" class="form-control validate[required,minSize[2]" id="txtDescripcionRequisito_editar" placeholder="Escriba aquí la descripcion..." />
                    </div>
                    <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default btnCerrarEditarRequisito" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarRequisito">Guardar cambios</button>
                  <!-- / Zona inferior de la ventana -->
              </div>
            
            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para editar beneficios -->

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
    <script src="../../assets/codigo_secciones/Requisitos.js"></script>
</asp:Content>
