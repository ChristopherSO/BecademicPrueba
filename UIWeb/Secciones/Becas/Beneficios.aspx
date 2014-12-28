<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="Beneficios.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Beneficios de becas</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Gestión de beneficios de becas.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">

    <!-- Contenedor principal -->
    <div class="container">

        <div class="row">
            <div class="col-md-12 validarPermiso" data-permiso="7">
                <p>
                    <button class="btn btn-info" data-toggle="modal" data-target="#ventanaAgregarBeneficio">Agregar nuevo beneficio</button>
                </p>
                <p>
                    Cambio de prueba
                    123
                </p>
                <p>
                    ABC
                </p>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">

                <!-- Tabla de beneficios -->
                <table class="table table-bordered table-hover table-striped">
	                <thead>
                        <tr>
                            <th>ID</th>
                            <th>Tipo de beneficio</th>
                            <th>Nombre</th>
                            <th>Descripción</th>
                            <th>Valor</th>
                            <th style="width:200px;">Acciones</th>
                        </tr>
	                </thead>
	                <tbody id="contenidoTabla">
	                </tbody>
                </table>
                <!-- / Tabla de beneficios -->

            </div>
        </div>
    </div>
    <!-- / Contenedor principal -->
    
    <!-- Ventana para agregar nuevos beneficios -->
    <div class="modal fade" id="ventanaAgregarBeneficio">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarBeneficio">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nuevo beneficio</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->                        
                    <!-- Campo para seleccionar un tipo de beneficio -->
                    <div class="form-group">
                        <label for="cmbTipoBeneficio_agregar">Tipo de beneficio:</label>
                        <select class="form-control" id="cmbTipoBeneficio_agregar">
                        </select>
                    </div>
                    <!-- Campo para escribir el nombre del beneficio -->
                    <div class="form-group">
                        <label for="txtNombreBeneficio_agregar">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreBeneficio_agregar" placeholder="Escriba aquí el nombre..." />
                    </div>
                    <!-- Campo para escribir la descripción del beneficio -->
                    <div class="form-group">
                        <label for="txtDescripcionBeneficio_agregar">Descripción:</label>
                        <textarea class="form-control validate[required,minSize[1]" rows="5" id="txtDescripcionBeneficio_agregar" placeholder="Escriba aquí la descripción..." ></textarea>
                    </div>
                    <!-- Campo para insertar un valor -->
                    <div class="form-group">
                        <label for="txtValorBeneficio_agregar">Valor:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtValorBeneficio_agregar" placeholder="Escriba un valor..." />
                    </div>
                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarBeneficio">Agregar beneficio</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevos beneficios -->

    <!-- Ventana para actualizar tipos de beca -->
    <div class="modal fade" id="ventanaEditarBeneficio">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarBeneficio">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar beneficio</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
                    <!-- Cuerpo de la ventana -->                
                    <!-- Espacio oculto para colocar el ID del beneficio que se esté editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    <input type="hidden" id="txtIdBeneficio_editar" />
                    <!-- Campo para seleccionar un tipo de beneficio -->
                    <div class="form-group">
                        <label for="cmbTipoBeneficio_editar">Tipo de beneficio:</label>
                        <select class="form-control" id="cmbTipoBeneficio_editar">
                        </select>
                    </div>
                    <!-- Campo para escribir el nombre -->
                    <div class="form-group">
                        <label for="txtNombreBeneficio_editar">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreBeneficio_editar" placeholder="Escriba aquí el nombre..." />
                    </div>
                    <!-- Campo para escribir la descripcion -->
                    <div class="form-group">
                        <label for="txtDescripcionBeneficio_editar">Descripcion:</label>
                        <textarea class="form-control validate[required,minSize[2]]" rows="5" id="txtDescripcionBeneficio_editar" placeholder="Escriba aquí la descripción..." ></textarea>
                    </div>
                    <!-- Campo para escribir un valor -->
                    <div class="form-group">
                        <label for="txtValorBeneficio_editar">Valor:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtValorBeneficio_editar" placeholder="Escriba un valor..." />
                    </div>                                  
                    <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarBeneficio">Guardar cambios</button>
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
    <script src="/assets/codigo_secciones/Beneficios.js"></script>
</asp:Content>
