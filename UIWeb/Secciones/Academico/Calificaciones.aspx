<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="Calificaciones.aspx.vb"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Calificaciones</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Consulta y gestión de calificaciones.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">
    <input type="hidden" id="txtIdCarrera_Filtrar" />
    <input type="hidden" id="txtIdEstudiante_Filtrar" />
    <input type="hidden" id="txtIdEstudiante_Agregar" />

    <p><button class="btn btn-info" data-toggle="modal" data-target="#ventanaFiltrarEstudiantes">Filtrar calificaciones por estudiante</button></p>
   
    <div class="row">
            <div class="col-md-12">
                <!-- Tabla de tipo de becas -->
                <table class="table table-bordered table-hover table-striped">
                    <!-- Encabezado de la tabla -->
                    <thead><tr><th>ID</th><th>Usuario</th><th>Curso</th><th>Nota</th><th>Periodo</th><th>Año</th><th>Comentarios</th><th style="width:200px;">Acciones</th></tr></thead>
                    <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                    <tbody id="contenidoTabla"></tbody>

                </table>
                <!-- / Tabla de carreras -->
        </div>
    </div>
    <!-- / Contenedor principal -->

    <div class="modal fade" id="ventanaFiltrarEstudiantes">
      <div class="modal-dialog">
        <div class="modal-content">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Filtrar calificaciones por estudiante:</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                        
                        <!-- Campo para cargar las carreras -->
                        <div class="form-group">
                            
                        <label for="cmbCarreras_listar">Carreras:</label>
                        <select class="form-control" id="cmbCarreras_listar">
                            <option value="0" style="display:none;" selected="selected" >--Seleccione una carrera--</option>
                        </select>
                        </div>

                    <!-- / Cuerpo de la ventana -->
                </div>

            <form id="formularioFiltrarEstudiantes">
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnListarEstudiante" id="btnListarEstudiante">Listar estudiantes</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

            <div>
                <table class="table table-bordered table-hover table-striped">
                <!-- Encabezado de la tabla -->
                    <thead><tr><th>ID</th><th>Nombre</th><th style="width:200px;">Acciones</th></tr></thead>
                    <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                    <tbody id="contenidoTablaEstudiantesCarreraCalificacion"></tbody>

                </table>
            </div>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para filtrar -->   

      <!-- Ventana para agregar nuevas carreras -->
    <div class="modal fade" id="ventanaAgregarCalificacion">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarCalificacion">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nueva calificación</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->

                        <!-- Campo para escribir el nombre del calificaciona -->
                        <div class="form-group">
                            
                        <label for="cmbCursos_listar">Cursos:</label>
                        <select class="form-control" id="cmbCursos_listar">
                            <option value="0" style="display:none;" selected="selected" >--Seleccione un curso--</option>
                        </select>
                        </div>
                        
                        <!-- Campo para escribir el Nota de la calificacion -->
                        <div class="form-group">
                            <label for="txtNombreCarrera_agregar">Nota:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNota_agregar" placeholder="Ingrese la nota..." />
                        </div>
                        <!-- / Campo para escribir el Nota de la calificacion -->
                        <!-- Campo para escribir la Periodo de la calificacion -->
                        <div class="form-group">
                            <label for="txtDescripcionCarrera_agregar">Periodo:</label>
                            <textarea class="form-control validate[required,minSize[1]" rows="5" id="txtPeriodo_agregar" placeholder="Ingrese un periodo..."></textarea>
                        </div>
                        <!-- / Campo para escribir la Periodo de la calificacion -->
                        <!-- Campo para insertar un Año -->
                        <div class="form-group">
                            <label for="txtIconoCarrera_agregar">Año:</label>
                            <input type="text" class="form-control" id="txtAnnio_agregar" placeholder="Seleccione año..." />
                        </div>
                        <!-- / Campo para insertar un Año -->
                        <!-- Campo para insertar un Comentarios -->
                        <div class="form-group">
                            <label for="txtColorCarrera_agregar">Comentarios:</label>
                            <input type="text" class="form-control " id="txtComentarios_agregar" placeholder="Ingrese un comentario..." />
                        </div>
                        <!-- / Campo para insertar un Comentarios -->

                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary" id="btnAgregarCalificacion">Agregar calificación</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevas calificaciones -->

     <!-- Ventana para agregar nuevas carreras -->
    <div class="modal fade" id="ventanaEditarCalificacion">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarCalificacion">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar calificación</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->

                        <!-- Campo para escribir el nombre del calificaciona -->
                        <div class="form-group">

                        <input type="hidden" id="txtIdCalificacion_editar" />
                            
                        <label for="cmbCursos_Editar">Cursos:</label>
                        <select class="form-control" id="cmbCursos_Editar">
                            <option value="0" style="display:none;" selected="selected" >--Seleccione un curso--</option>
                        </select>
                        </div>
                        
                        <!-- Campo para escribir el Nota de la calificacion -->
                        <div class="form-group">
                            <label for="txtNombreCarrera_agregar">Nota:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNota_editar" placeholder="Ingrese la nota..." />
                        </div>
                        <!-- / Campo para escribir el Nota de la calificacion -->
                        <!-- Campo para escribir la Periodo de la calificacion -->
                        <div class="form-group">
                            <label for="txtDescripcionCarrera_agregar">Periodo:</label>
                            <textarea class="form-control validate[required,minSize[1]" rows="5" id="txtPeriodo_editar" placeholder="Ingrese un periodo..."></textarea>
                        </div>
                        <!-- / Campo para escribir la Periodo de la calificacion -->
                        <!-- Campo para insertar un Año -->
                        <div class="form-group">
                            <label for="txtIconoCarrera_agregar">Año:</label>
                            <input type="text" class="form-control" id="txtAnnio_editar" placeholder="Seleccione año..." />
                        </div>
                        <!-- / Campo para insertar un Año -->
                        <!-- Campo para insertar un Comentarios -->
                        <div class="form-group">
                            <label for="txtColorCarrera_agregar">Comentarios:</label>
                            <input type="text" class="form-control " id="txtComentarios_editar" placeholder="Ingrese un comentario..." />
                        </div>
                        <!-- / Campo para insertar un Comentarios -->

                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary" id="btnEditarCalificacion">Editar calificación</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevas calificaciones -->
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
    <script src="../../assets/codigo_secciones/calificacion.js"></script>
</asp:Content>
