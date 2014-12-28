<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="Roles.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Gestión de roles</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Gestión de roles de usuarios del sistema.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">
       
    <!-- Contenedor principal -->
    <div class="container">
        <div class="row">
            <div class="col-md-12 validarPermiso" data-permiso="31">
                <p><button class="btn btn-info" data-toggle="modal" data-target="#ventanaAgregarRol">Agregar nuevo rol</button></p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Tabla de rol -->
                <table class="table table-bordered table-hover table-striped">
                    <!-- Encabezado de la tabla -->
                    <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th style="width:100px;">Permisos</th><th style="width:200px;">Acciones</th></tr></thead>
                    <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                    <tbody id="contenidoTabla"></tbody>

                </table>
                <!-- / Tabla de rols -->

            </div>
        </div>
    </div>
    <!-- / Contenedor principal -->

    <!-- Ventana para agregar nuevos rols -->
    <div class="modal fade" id="ventanaAgregarRol">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarRol">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nuevo Rol</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                        
                        <!-- Campo para escribir el nombre del rol -->
                        <div class="form-group">
                            <label for="txtNombreRol_agregar">Nombre:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreRol_agregar" placeholder="Escriba aquí el nombre..." />
                        </div>

                         <!-- Campo para escribir la descripcion, si aplicase -->
                        <div class="form-group">
                            <label for="txtDescripcionRol_agregar">Descripción:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtDescripcionRol_agregar" placeholder="Escriba aquí el una breve descripción..." />
                        </div>

                     <!-- Campo para insertar un estado -->
                        <div class="form-group">
                            <label for="txtFaseRol_agregar">Intervención:</label>
                       
                            <select id ="cmbFaseRol_agregar" class ="form-control">
                                <option value="1">Primera fase</option>
                                <option value="2">Segunda fase</option>
                                <option value ="3">Tercera fase</option>
                                <option value ="5">Cuarta fase</option>
                                <option value ="4">No tiene</option>
                            </select>
                            
                        </div>


                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarRol">Agregar Rol</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevos rols -->


    <!-- Ventana para actualizar tipos de beca -->
    <div class="modal fade" id="ventanaEditarRol">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarRol">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar Rol</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
                  <!-- Cuerpo de la ventana -->
                
                    <!-- Espacio oculto para colocar el ID del rol que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    
                    <input type="hidden" id="txtIdRol_editar" />
                    <!-- / Espacio oculto para colocar el ID del grupo que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->

                        <!-- Campo para escribir el nombre del rol -->
                        <div class="form-group">
                            <label for="txtNombreRol_editar">Nombre:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreRol_editar" placeholder="Escriba aquí el nombre..." />
                        </div>

                         <!-- Campo para escribir la descripcion, si aplicase -->
                        <div class="form-group">
                            <label for="txtDescripcionRol_editar">Descripción:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtDescripcionRol_editar" placeholder="Escriba aquí el una breve descripción..." />
                        </div>

                     <!-- Campo para insertar un estado -->
                        <div class="form-group">
                            <label for="txtEstadoRol_editar">Intervención:</label>

                            <select id ="cmbFaseRol_editar" class ="form-control">
                                <option value="1">Primera fase</option>
                                <option value="2">Segunda fase</option>
                                <option value ="3">Tercera fase</option>
                                <option value ="5">Cuarta fase</option>
                                <option value ="4">No tiene</option>
                            </select>
                            
                        </div>
  
                  <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarRol">Guardar cambios</button>
                  <!-- / Zona inferior de la ventana -->
              </div>
            
            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para editar rols -->


        <!-- Ventana para los permisos de un rols -->
    <div class="modal fade" id="ventanaPermisoRol">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioPermisoRol">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="lblPermisoRol">Permisos del Rol</h4>
                    <!-- / Encabezado de la ventana -->
                </div>

                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                    <div class="row">
                        <div class="col-md-12">
                            <!-- Tabla de rol -->
                            <table class="table table-bordered table-hover table-striped">
                                <!-- Encabezado de la tabla -->
                                <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th>Categoria</th><th style="width:100px;">Acciones</th></tr></thead>
                                <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                                <tbody id="tablaPermisoRol"></tbody>
                            </table>
                            <!-- / Tabla de rols -->
                        </div>
                    </div> 

                    <!-- Lista de roles para asignar/remover --> 
                     
                    <!-- Campo para insertar un genero -->
                        <div class="form-group">
                            <label for="txtPermisoRol">Permisos:</label>

                            <select id ="cmbPermisoRol" class ="form-control">
                                <!-- Aqui van a ir los permisos que exista en el sistema en un <option></option> -->

                            </select>

                        </div>    
                    
                    <!-- boton para asignar roles -->
                        <div class="form-group">
                            <button type="submit" class="btn btn-success form-control btnAsignar" id="btnAsignarPermiso"><span class="" ></span> Asignar</button>
                        </div>    

                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
<!--                     <button type="submit" class="btn btn-primary btnAgregarRol">Agregar Rol</button> -->
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para roles de rol -->

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

       <script src="../../assets/codigo_secciones/rol.js"></script>

</asp:Content>
