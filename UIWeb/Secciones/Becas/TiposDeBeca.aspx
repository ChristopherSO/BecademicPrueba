<%@ Page Title="Becademic | Inicio" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="TiposDeBeca.aspx.vb"  %>

<%-- 
    Head
    Contenidos que se agregaran antes de finalizar la etiqueta <head>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<%-- 
    Ubicación
    Contenidos que se agregaran a la barra indicadora de la ruta de la seccion 
--%>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Tipos de becas</li>
	</ul>
</asp:Content>

<%-- 
    Sección
    Contenidos que se agregaran como contenido primordial a la seccion activa 
--%>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido_principal" runat="server">
    
    <!-- Contenedor principal -->
    <div class="container">
        <div class="row">
            <div class="col-md-12 validarPermiso" data-permiso="3">
                <p><button class="btn btn-info" data-toggle="modal" data-target="#ventanaAgregarTipoBeca">Agregar nuevo tipo de beca</button>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Tabla de tipo de becas -->
                <table class="table table-bordered table-hover table-striped">
                    <!-- Encabezado de la tabla -->
                    <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th>Icono</th><th>Color</th><th style="width:200px;">Acciones</th></tr></thead>
                    <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                    <tbody id="contenidoTabla"></tbody>

                </table>
                <!-- / Tabla de tipo de becas -->

            </div>
        </div>
    </div>
    <!-- / Contenedor principal -->

    <!-- Ventana para agregar nuevos tipos de becas -->
    <div class="modal fade" id="ventanaAgregarTipoBeca">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarTipoBeca">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nuevo tipo de beca</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                        
                        <!-- Campo para escribir el nombre del tipo de beca -->
                        <div class="form-group">
                            <label for="txtNombreTipoBeca_agregar">Nombre:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreTipoBeca_agregar" placeholder="Escriba aquí el nombre..." />
                        </div>
                        <!-- / Campo para escribir el nombre del tipo de beca -->
                        <!-- Campo para escribir la descripcion del tipo de beca -->
                        <div class="form-group">
                            <label for="txtDescripcionTipoBeca_agregar">Descripcion:</label>
                            <textarea class="form-control validate[required,minSize[1]" rows="5" id="txtDescripcionTipoBeca_agregar"></textarea>
                        </div>
                        <!-- / Campo para escribir la descripcion del tipo de beca -->
                        <!-- Campo para insertar un icono -->
                        <div class="form-group">
                            <label for="txtIconoTipoBeca_agregar">Icono:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtIconoTipoBeca_agregar" placeholder="Seleccione un icono..." />
                        </div>
                        <!-- / Campo para insertar un icono -->
                        <!-- Campo para insertar un color -->
                        <div class="form-group">
                            <label for="txtColorTipoBeca_agregar">Color:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtColorTipoBeca_agregar" placeholder="Seleccione un color..." />
                        </div>
                        <!-- / Campo para insertar un color -->
                    <!-- Campo para insertar una cantidad -->
                        <div class="form-group">
                            <label for="txtCantidadTipoBeca_agregar">Cantidad:</label>
                            <input type="text" class="form-control validate[required,minSize[1]]" id="txtCantidadTipoBeca_agregar" placeholder="Escriba aquí una cantidad..." />
                        </div>
                        <!-- / Campo para insertar una cantidad -->
                    <!-- Campo para seleccionar si el tipo de beca es socioeconomico -->
                    <div class="checkbox" id="ckbSocioeconomicoAgregar">
                        <label>
                            <input type="checkbox" id="ckbSocioeconomico_agregar" />Socioeconómica
                        </label>
                     </div>
                    <!-- / Campo para seleccionar si el tipo de beca es socioeconomico -->
                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarTipoBeca">Agregar tipo de beca</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevos tipos de becas -->

    <!-- Ventana para actualizar tipos de beca -->
    <div class="modal fade" id="ventanaEditarTipoBeca">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarTipoBeca">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar tipo de beca</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
               <!-- Cuerpo de la ventana -->
                
                    <!-- Espacio oculto para colocar el ID del tipo de beca que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    <input type="hidden" id="txtIdTipoBeca_editar" />
                    <!-- / Espacio oculto para colocar el ID del tipo de beca que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->

                    <!-- Campo para escribir el nombre del grupo musical -->
                    <div class="form-group">
                        <label for="txtNombre">Nombre:</label>
                        <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreTipoBeca_editar" placeholder="Escriba aquí el nombre..." />
                    </div>
                    <!-- / Campo para escribir el nombre del grupo musical -->
                    <!-- Campo para escribir la descripcion del tipo de beca -->
                        <div class="form-group">
                            <label for="txtDescripcion">Descripcion:</label>
                            <textarea class="form-control validate[required,minSize[2]]" rows="5" id="txtDescripcionTipoBeca_editar"></textarea>
                        </div>
                        <!-- / Campo para escribir la descripcion del tipo de beca -->
                        <!-- Campo para insertar un icono -->
                        <div class="form-group">
                            <label for="txtIcono">Icono:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtIcono_editar" placeholder="Seleccione un icono..." />
                        </div>
                        <!-- / Campo para insertar un icono -->
                        <!-- Campo para insertar un color -->
                        <div class="form-group">
                            <label for="txtColor">Color:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtColor_editar" placeholder="Seleccione un color..." />
                        </div>
                        <!-- / Campo para insertar un color -->
                        <!-- Campo para seleccionar si el tipo de beca es socioeconomico -->
                        <div class="checkbox" id="ckbSocioeconomico">
                            <label>
                                <input type="checkbox" id="ckbSocioeconomico_editar" />Socioeconómica
                            </label>
                        </div>
                        <!-- / Campo para seleccionar si el tipo de beca es socioeconomico -->
                  <!-- Campo para insertar una cantidad -->
                        <div class="form-group">
                            <label for="txtCantidadTipoBeca_editar">Cantidad:</label>
                            <input type="text" class="form-control validate[required,minSize[1]]" id="txtCantidadTipoBeca_editar" placeholder="Escriba aquí una cantidad..." />
                        </div>
                        <!-- / Campo para insertar una cantidad -->
                  <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarTipoBeca">Guardar cambios</button>
                  <!-- / Zona inferior de la ventana -->
              </div>
            
            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para editar tipos de becas -->

    <!-- Ventana de los beneficios de una beca -->
    <div class="modal fade" id="ventanaBeneficiosBeca">
        <div class="modal-dialog">
            <div class="modal-content">

            <!--Ventana de administración de beneficios de una beca.-->
            <div class="modal-header">
            <!-- Encabezado de la ventana -->
                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                <h4 class="modal-title">Administrar beneficios de la beca</h4>
            <!-- / Encabezado de la ventana -->
            </div>
            <div class="modal-body">
            <!-- Cuerpo de la ventana -->
                
            <!-- Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->
            <input type="hidden" id="txtIdTipoBecaBeneficio" />
            <!-- / Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->

            <!-- Tabla de beneficios de beca -->
            <table class="table table-bordered table-hover table-striped">
                <!-- Encabezado de la tabla -->
                <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th style="width:200px;">Acciones</th></tr></thead>
                <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                <tbody id="contenidoTablaBeneficiosBeca"></tbody>

            </table>
            <!-- / Tabla de beneficios de beca -->     
            <!-- / Cuerpo de la ventana -->
            </div>

            <form id="formularioBeneficiosBeca">
                <div class="modal-footer">
                <!-- Zona inferior de la ventana -->
                <!-- Campo para seleccionar un beneficio -->

                    <div class="form-group">
                        <label for="cmbBeneficio_asignar">Beneficios:</label>
                        <select class="form-control" id="cmbBeneficio_asignar">
                            <option value="0" style="display:none;" selected="selected" >--Seleccione un beneficio--</option>
                        </select>
                    </div>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="submit" class="btn btn-default btnAsignarBeneficioBeca">Asignar beneficio</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para administración de requisitos de una beca -->

    <!-- Ventana de los requisitos de una beca -->
    <div class="modal fade" id="ventanaRequisitosBeca">
        <div class="modal-dialog">
            <div class="modal-content">

            <!--Ventana de administración de requisitos de una beca.-->

                <form id="formularioRequisitosBeca">

                    <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Administrar requisitos de la beca</h4>
                    <!-- / Encabezado de la ventana -->
                    </div>
                    <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                
                        <!-- Espacio oculto para colocar el ID del tipo de beca que se este asignando el requisito, esto con el fin de poder enviarlo de nuevo a WebService -->
                        <input type="hidden" id="txtIdTipoBecaRequisito" />
                        <!-- / Espacio oculto para colocar el ID del tipo de beca que se este asignando el requisito, esto con el fin de poder enviarlo de nuevo a WebService -->

                        <!-- Tabla de requisitos de beca -->
                        <table class="table table-bordered table-hover table-striped">
                        <!-- Encabezado de la tabla -->
                            <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th style="width:200px;">Acciones</th></tr></thead>
                            <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                            <tbody id="contenidoTablaRequisitosBeca"></tbody>

                        </table>
                        <!-- / Tabla de requisitos de beca -->
                
                    <!-- / Cuerpo de la ventana -->
                    </div>
                    <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <!-- Campo para seleccionar un requisito -->
                    <div class="form-group">
                        <label for="cmbRequisito_asignar">Requisitos:</label>
                        <select class="form-control" id="cmbRequisito_asignar">
                            <option value="0" style="display:none;" selected="selected" >--Seleccione un requisito--</option>
                        </select>
                    </div>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="submit" class="btn btn-default btnAsignarBeneficioBeca">Asignar requisito</button>
                    <!-- / Zona inferior de la ventana -->
                    </div>

                </form>

            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para administración de requisitos de una beca -->

    <!-- Ventana de las carreras de una beca -->
    <div class="modal fade" id="ventanaCarrerasBeca">
        <div class="modal-dialog">
            <div class="modal-content">

            <!--Ventana de administración de carreras de una beca.-->

                <form id="formularioCarrerasBeca">

                    <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Administrar carreras de la beca</h4>
                    <!-- / Encabezado de la ventana -->
                    </div>
                    <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                
                        <!-- Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->
                        <input type="hidden" id="txtIdTipoBecaCarrera" />
                        <!-- / Espacio oculto para colocar el ID del tipo de beca que se este asignando el beneficio, esto con el fin de poder enviarlo de nuevo a WebService -->

                        <!-- Tabla de carreras de beca -->
                        <table class="table table-bordered table-hover table-striped">
                        <!-- Encabezado de la tabla -->
                            <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th style="width:200px;">Acciones</th></tr></thead>
                            <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                            <tbody id="contenidoTablaCarrerasBeca"></tbody>

                        </table>
                        <!-- / Tabla de carreras de beca -->
                
                    <!-- / Cuerpo de la ventana -->
                    </div>
                    <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <!-- Campo para seleccionar una carrera -->
                    <div class="form-group">
                        <label for="cmbCarrera_asignar">Carreras:</label>
                        <select class="form-control" id="cmbCarrera_asignar">
                            <option value="0" style="display:none;" selected="selected" >--Seleccione una carrera--</option>
                        </select>
                    </div>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                        <button type="submit" class="btn btn-default btnAsignarBeneficioBeca">Asignar carrera</button>
                    <!-- / Zona inferior de la ventana -->
                    </div>

                </form>

            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para administración de carreras de una beca -->

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

<%-- 
    Scripts
    Contenidos que se agregarán justo antes de finalizar la etiqueta </body> 
--%>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">

    <script src="../../assets/codigo_secciones/tipoBeca.js"></script>

</asp:Content>
