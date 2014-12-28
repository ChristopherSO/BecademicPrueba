<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="Cursos.aspx.vb"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Cursos</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Lista de cursos registrados en el sistema.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">
    <!-- Tabla de cursos -->
    <table class="table table-bordered table-hover table-striped">
	    <thead>
            <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>C&oacute;digo</th>
                <th>Precio</th>
                <th>Cantidad cr&eacute;dito</th>
                <th style="width:200px;">Acciones</th>
            </tr>
	    </thead>
	    <tbody id="contenidoTabla">
	    </tbody>
    </table>
    <!-- / Tabla de cursos -->
    <!-- Ventana para agregar nuevos cursos -->
    <div class="modal fade" id="ventanaAgregarCurso">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarCurso">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nuevo curso</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->                        
                    <!-- Campo para escribir el nombre de un curso -->
                    <div class="form-group">
                        <label for="lblNombreCurso_agregar">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreCurso_agregar" placeholder="Escriba aquí el nombre..." />
                    </div>
                    <!-- Campo para escribir el Codigo  -->
                    <div class="form-group">
                        <label for="lblCodigoCurso_agregar">Codigo:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtCodigoCurso_agregar" placeholder="Escriba aquí el codigo..." />
                    </div>
                    <!-- Campo para escribir el precio del curso -->
                    <div class="form-group">
                        <label for="lblPrecioCurso_agregar">Precio:</label>
                        <input type="text" class="form-control validate[required,minSize[2]" id="txtPrecioCurso_agregar" placeholder="Escriba aquí el precio..." />
                    </div>
                    <!-- Campo para insertar la cantidad de credito. -->
                    <div class="form-group">
                        <label for="lblCantidadCreditoCurso_agregar">Cantidad cr&eacute;ditos:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtCantidadCreditoCurso_agregar" placeholder="Escriba un valor..." />
                    </div>
                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarCurso">Agregar curso</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevos beneficios -->


    <!-- Ventana para actualizar curso-->
    <div class="modal fade" id="ventanaEditarCurso">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarCurso">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar curso</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
                    <!-- Cuerpo de la ventana -->                
                    <!-- Espacio oculto para colocar el ID del curso que se esté editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    <input type="hidden" id="txtIdCurso_editar" />
                    <!-- Campo para escribir el nombre de un curso -->
                    <div class="form-group">
                        <label for="txtNombreCurso_editar">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreCurso_editar" placeholder="Escriba aquí el nombre..." />
                    </div>
                    <!-- Campo para escribir el Codigo  -->
                    <div class="form-group">
                        <label for="txtCodigoCurso_editar">Codigo:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtCodigoCurso_editar" placeholder="Escriba aquí el codigo..." />
                    </div>
                    <!-- Campo para escribir el precio del curso -->
                    <div class="form-group">
                        <label for="txtPrecioCurso_editar">Precio:</label>
                        <input type="text" class="form-control validate[required,minSize[2]" id="txtPrecioCurso_editar" placeholder="Escriba aquí el precio..." ></input>
                    </div>
                    <!-- Campo para insertar la cantidad de credito. -->
                    <div class="form-group">
                        <label for="txtCantidadCredito_editar">Cantidad cr&eacute;ditos:</label>
                        <input type="text" class="form-control validate[required,minSize[1]]" id="txtCantidadCreditoCurso_editar" placeholder="Escriba un valor..." />
                    </div>                                  
                    <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default btnCerrarEditarCurso" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarCurso">Guardar cambios</button>
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
    <script src="../../assets/codigo_secciones/Cursos.js"></script>
</asp:Content>
