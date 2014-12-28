<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="Carreras.aspx.vb"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Carreras</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Lista de carreras registradas en el sistema.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">
            <p><button class="btn btn-info" data-toggle="modal" data-target="#ventanaAgregarCarrera">Agregar nueva carrera</button></p>
        <div class="row">
            <div class="col-md-12">
                <!-- Tabla de carrereras -->
                <table class="table table-bordered table-hover table-striped">
                    <!-- Encabezado de la tabla -->
                    <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th>Icono</th><th>Color</th><th style="width:200px;">Acciones</th></tr></thead>
                    <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                    <tbody id="contenidoTabla"></tbody>

                </table>
                <!-- / Tabla de carreras -->
        </div>
    </div>
    <!-- / Contenedor principal -->

    <!-- Ventana para agregar nuevas carreras -->
    <div class="modal fade" id="ventanaAgregarCarrera">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarCarrera">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nueva carrera</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                        
                        <!-- Campo para escribir el nombre de la carrera -->
                        <div class="form-group">
                            <label for="txtNombreCarrera_agregar">Nombre:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreCarrera_agregar" placeholder="Escriba aquí el nombre..." />
                        </div>
                        <!-- / Campo para escribir el nombre de la carrera -->
                        <!-- Campo para escribir la descripcion de la carrera -->
                        <div class="form-group">
                            <label for="txtDescripcionCarrera_agregar">Descripcion:</label>
                            <textarea class="form-control validate[required,minSize[1]" rows="5" id="txtDescripcionCarrera_agregar"></textarea>
                        </div>
                        <!-- / Campo para escribir la descripcion de la carrera -->
                        <!-- Campo para insertar un icono -->
                        <div class="form-group">
                            <label for="txtIconoCarrera_agregar">Icono:</label>
                            <input type="text" class="form-control" id="txtIconoCarrera_agregar" placeholder="Seleccione un icono..." />
                        </div>
                        <!-- / Campo para insertar un icono -->
                        <!-- Campo para insertar un color -->
                        <div class="form-group">
                            <label for="txtColorCarrera_agregar">Color:</label>
                            <input type="text" class="form-control " id="txtColorCarrera_agregar" placeholder="Seleccione un color..." />
                        </div>
                        <!-- / Campo para insertar un color -->

                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarCarrera" id="btnAgregarCarrera">Agregar carrera</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevas carreras -->

    <!-- Ventana para actualizar carreras -->
    <div class="modal fade" id="ventanaEditarCarrera">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarCarrera">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar carrera</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
                  <!-- Cuerpo de la ventana -->
                
                    <!-- Espacio oculto para colocar el ID del grupo que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    <input type="hidden" id="txtIdCarrera_editar" />
                    <!-- / Espacio oculto para colocar el ID del grupo que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->

                    <!-- Campo para escribir el nombre del grupo musical -->
                    <div class="form-group">
                        <label for="txtNombre">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreCarrera_editar" placeholder="Escriba aquí el nombre..." />
                    </div>
                    <!-- / Campo para escribir el nombre del grupo musical -->
                  <!-- Campo para escribir la descripcion del tipo de beca -->
                        <div class="form-group">
                            <label for="txtDescripcion">Descripcion:</label>
                            <textarea class="form-control validate[required,minSize[2]]" rows="5" id="txtDescripcionCarrera_editar"></textarea>
                        </div>
                        <!-- / Campo para escribir la descripcion del tipo de beca -->
                        <!-- Campo para insertar un icono -->
                        <div class="form-group">
                            <label for="txtIcono">Icono:</label>
                            <input type="text" class="form-control" id="txtIconoCarrera_editar" placeholder="Seleccione un icono..." />
                        </div>
                        <!-- / Campo para insertar un icono -->
                        <!-- Campo para insertar un color -->
                        <div class="form-group">
                            <label for="txtColor">Color:</label>
                            <input type="text" class="form-control" id="txtColorCarrera_editar" placeholder="Seleccione un color..." />
                        </div>
                        <!-- / Campo para insertar un color -->
                
                  <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarCarrera">Guardar cambios</button>
                  <!-- / Zona inferior de la ventana -->
              </div>
            
            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para editar tipos de becas -->

    <!-- Ventana de las carreras de una beca -->
    <div class="modal fade" id="ventanaCursosCarrera">
        <div class="modal-dialog">
            <div class="modal-content">

            <!--Ventana de administración de cursos de carrera.-->

                    <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Administrar cursos de la carrera</h4>
                    <!-- / Encabezado de la ventana -->
                    </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                        <div class="col-md-6">
                        <!-- Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->
                        <input type="hidden" id="txtIdCursoCarrera" />
                        <!-- / Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->
                         <!-- Espacio oculto para el id del curso que sea marcado se guarde  -->
                        <input type="hidden" id="txtIdCursoMarcado" />
                        <!-- Espacio oculto para el id del curso que sea marcado se guarde -->

                        <!-- Tabla de carreras de beca -->
                        <table class="table table-bordered table-hover table-striped">
                        <!-- Encabezado de la tabla -->
                            <thead ><tr><th>ID</th><th>Nombre</th><th style="width:200px;">Acciones</th></tr></thead>
                            <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                            <tbody id="contenidoTablaCursosCarrera"></tbody>

                        </table>

                    </div>

                    <div class="col-md-6">

                        <table class="table table-bordered table-hover table-striped">
                        <!-- Encabezado de la tabla -->
                            <thead><tr><th>ID</th><th>Nombre</th><th style="width:200px;">Acciones</th></tr></thead>
                            <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                            <tbody id="contenidoTablaCursos"></tbody>
                       
                        </table>
                    </div>
                    </div>

                <form id="formularioCursosCarrera">
                <div class="modal-footer">
                
                        <div class="form-group">
                            <label for="txtPeriodo_asignar">Periodo:</label>
                            <textarea class="form-control validate[required,minSize[]]" rows="5" id="txtPeriodo_asignar"></textarea>
                        </div>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="submit" class="btn btn-default btnAsignarCursoCarrera">Asignar curso</button>

                    <!-- / Zona inferior de la ventana -->
     
                    </div>

                </form>

            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para administración de cursos de carrera -->

    <!-- Ventana de las carreras de una beca -->
    <div class="modal fade" id="ventanaDirectoresCarrera">
        <div class="modal-dialog">
            <div class="modal-content">

            <!--Ventana de administración de directores de carrera.-->

                    <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Administrar directores académicos de la carrera</h4>
                    <!-- / Encabezado de la ventana -->
                    </div>
                    <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                
                        <!-- Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->
                        <input type="hidden" id="txtIdDirectorCarrera" />
                        <!-- / Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->

                        <!-- Tabla de carreras de beca -->
                        <table class="table table-bordered table-hover table-striped">
                        <!-- Encabezado de la tabla -->
                            <thead><tr><th>ID</th><th>Nombre</th><th style="width:200px;">Acciones</th></tr></thead>
                            <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                            <tbody id="contenidoTablaDirectoresCarrera"></tbody>

                        </table>

                        <label for="cmbDirector_asignar">Directores académicos:</label>
                        <select class="form-control" id="cmbDirector_asignar">
                            <option value="0" style="display:none;" selected="selected" >--Seleccione un director académico--</option>
                        </select>
                        <!-- / Tabla de carreras de beca -->
                
                    <!-- / Cuerpo de la ventana -->
                    </div>

                <form id="formularioDirectoresCarrera">
                    <div class="modal-footer">

                 
                    <!-- Zona inferior de la ventana -->
                    <!-- Campo para seleccionar una carrera -->
                        
                    
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="submit" class="btn btn-default btnAsignarDirectorCarrera">Asignar director académico</button>
                    <!-- / Zona inferior de la ventana -->

                    </div>

                </form>

            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
       </div><!-- /.modal -->
    <!-- / Ventana para administración de cursos de una carrera -->

    <!-- Ventana de las carreras de una beca -->
    <div class="modal fade" id="ventanaEstudiantesCarrera">
        <div class="modal-dialog">
            <div class="modal-content">

            <!--Ventana de administración de directores de carrera.-->

                    <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Administrar estudiantes de la carrera</h4>
                    <!-- / Encabezado de la ventana -->
                    </div>
                    <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                
                        <!-- Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->
                        <input type="hidden" id="txtIdEstudianteCarrera" />
                        <!-- / Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->

                         <!-- Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->
                        <input type="hidden" id="txtIdEstudianteMarcado" />
                        <!-- / Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->

                        <!-- Tabla de carreras de beca -->
                        <table class="table table-bordered table-hover table-striped">
                        <!-- Encabezado de la tabla -->
                            <thead><tr><th>ID</th><th>Nombre</th><th style="width:200px;">Acciones</th></tr></thead>
                            <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                            <tbody id="contenidoTablaEstudiantesCarrera"></tbody>

                        </table>

                        <table class="table table-bordered table-hover table-striped">
                        <!-- Encabezado de la tabla -->
                        <thead><tr><th>ID</th><th>Nombre</th><th style="width:200px;">Acciones</th></tr></thead>
                        <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                        <tbody id="contenidoTablaEstudiantes"></tbody>
                       
                        </table>

                        
                        <!-- / Tabla de carreras de beca -->

                    </div>

                <form id="formularioEstudiantesCarrera">
                    <div class="modal-footer">
                    <!-- / Cuerpo de la ventana -->
                    
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="submit" class="btn btn-default btnAsignarEstudianteCarrera">Asignar estudiante</button>
                    <!-- / Zona inferior de la ventana -->
                    
                    </div>
                </form>

            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para administración de cursos de una carrera -->

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
    <script src="../../assets/codigo_secciones/carrera.js"></script>
</asp:Content>
