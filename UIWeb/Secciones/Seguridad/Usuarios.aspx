<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="Usuarios.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
		<li class="active">Gestión de usuarios</li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Gestión de usuarios del sistema.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">

    <div class="row">
            <div class="col-md-12 validarPermiso" data-permiso="27">
                <p><button class="btn btn-info" data-toggle="modal" data-target="#ventanaAgregarUsuario">Agregar nuevo usuario</button></p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <!-- Tabla de usuario -->
                <table class="table table-bordered table-hover table-striped">
                    <!-- Encabezado de la tabla -->
                    <thead><tr><th>ID</th><th>Nombre</th><th>Segundo Nombre</th><th>Primer Apellido</th><th>Segundo Apellido</th><th>Correo</th><th>Genero</th><th>Telefono</th><th>Estado</th><th style="width:100px;">Rol</th><th style="width:200px;">Acciones</th></tr></thead>
                    <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                    <tbody id="contenidoTabla"></tbody>

                </table>
                <!-- / Tabla de usuarios -->

            </div>
        </div>

<!-- Ventanas -->
    <!-- Ventana para agregar nuevos usuarios -->
    <div class="modal fade" id="ventanaAgregarUsuario">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioAgregarUsuario">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Agregar nuevo Usuario</h4>
                    <!-- / Encabezado de la ventana -->
                </div>
                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                        
                         <!-- Campo para escribir la cedula del usuario -->
                        <div class="form-group">
                            <label for="txtCedula_agregar">Cedula:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtCedula_agregar" placeholder="Escriba aquí la cedula..." />
                        </div>

                        <!-- Campo para escribir el nombre del usuario -->
                        <div class="form-group">
                            <label for="txtNombreUsuario_agregar">Nombre:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreUsuario_agregar" placeholder="Escriba aquí el nombre..." />
                        </div>

                         <!-- Campo para escribir el nombre_2 del usuario, si aplicase -->
                        <div class="form-group">
                            <label for="txtNombre2_agregar">Segundo Nombre:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtNombre2_agregar" placeholder="Escriba aquí el segundo nombre..." />
                        </div>

                        <!-- Campo para escribir el apellido del usuario -->
                        <div class="form-group">
                            <label for="txtApellidoUsuario_agregar">Apellido:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtApellidoUsuario_agregar" placeholder="Escriba aquí el apellido..." />
                        </div>

                         <!-- Campo para escribir el apellido_2 del usuario, si aplicase -->
                        <div class="form-group">
                            <label for="txtApellido2_agregar">Segundo Apellido:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtApellido2_agregar" placeholder="Escriba aquí el segundo apellido..." />
                        </div>

                        <!-- Campo para escribirel correo del usuario -->
                        <div class="form-group">
                            <label for="txtCorreoUsuario_agregar">Correo:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtCorreoUsuario_agregar" placeholder="Escriba aquí el correo..." />
                        </div>


                        <!-- Campo para insertar un telefono -->
                        <div class="form-group">
                            <label for="txtTelefonoUsuario_agregar">Telefono:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtTelefonoUsuario_agregar" placeholder="Escriba un telefono..." />
                        </div>


                        <!-- Campo para insertar un genero -->
                        <div class="form-group">
                            <label for="txtGeneroUsuario_agregar">Genero:</label>

                            <select id ="txtGeneroUsuario_agregar" class ="form-control">
                                <option value="M" >Masculino</option>
                                <option value="F">Femenino</option>
                            </select>


<%--                            <input type="text" class="form-control validate[required,maxSize[1]]" id="txtGeneroUsuario_agregar" placeholder="Seleccione el genero..." />--%>
                        </div>

                     <!-- Campo para insertar un estado -->
                        <div class="form-group">
                            <label for="txtEstadoUsuario_agregar">Estado:</label>

                            <select id ="txtEstadoUsuario_agregar" class ="form-control">
                                 <option value="1">Activo</option>
                                <option value="2">Inactivo</option>
                                <option value ="3">Postulante</option>
                            </select>
                            
<%--                            <input type="text" class="form-control validate[minSize[1]]" id="txtEstadoUsuario_agregar" placeholder="Seleccione el estado..." />--%>
                        </div>


                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-primary btnAgregarUsuario">Agregar Usuario</button>
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para agregar nuevos usuarios -->


    <!-- Ventana para actualizar tipos de beca -->
    <div class="modal fade" id="ventanaEditarUsuario">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioEditarUsuario">

              <div class="modal-header">
                  <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Editar Usuario</h4>
                  <!-- / Encabezado de la ventana -->
              </div>
              <div class="modal-body">
                  <!-- Cuerpo de la ventana -->
                
                    <!-- Espacio oculto para colocar el ID del usuario que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->
                    
                    <input type="hidden" id="txtIdUsuario_editar" />
                    <!-- / Espacio oculto para colocar el ID del grupo que se este editando, esto con el fin de poder enviarlo de nuevo a WebService -->

                         <!-- Campo para escribir la cedula del usuario -->
                        <div class="form-group">
                            <label for="txtCedula_editar">Cedula:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtCedula_editar" placeholder="Escriba aquí la cedula..." />
                        </div>

                        <!-- Campo para escribir el nombre del usuario -->
                        <div class="form-group">
                            <label for="txtNombreUsuario_editar">Nombre:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtNombreUsuario_editar" placeholder="Escriba aquí el nombre..." />
                        </div>

                         <!-- Campo para escribir el nombre_2 del usuario, si aplicase -->
                        <div class="form-group">
                            <label for="txtNombre2_editar">Segundo Nombre:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtNombre2_editar" placeholder="Escriba aquí el segundo nombre..." />
                        </div>

                        <!-- Campo para escribir el apellido del usuario -->
                        <div class="form-group">
                            <label for="txtApellidoUsuario_editar">Apellido:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtApellidoUsuario_editar" placeholder="Escriba aquí el apellido..." />
                        </div>

                         <!-- Campo para escribir el apellido_2 del usuario, si aplicase -->
                        <div class="form-group">
                            <label for="txtApellido2_editar">Segundo Apellido:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtApellido2_editar" placeholder="Escriba aquí el segundo apellido..." />
                        </div>

                        <!-- Campo para escribir el correo del usuario -->
                        <div class="form-group">
                            <label for="txtCorreoUsuario_editar">Correo:</label>
                            <input type="text" class="form-control validate[required,minSize[2]]" id="txtCorreoUsuario_editar" placeholder="Escriba aquí el correo..." />
                        </div>

                        <!-- Campo para insertar un telefono -->
                        <div class="form-group">
                            <label for="txtTelefonoUsuario_editar">Telefono:</label>
                            <input type="text" class="form-control validate[minSize[2]]" id="txtTelefonoUsuario_editar" placeholder="Escriba un telefono..." />
                        </div>


                        <!-- Campo para insertar un genero -->
                        <div class="form-group">
                            <label for="txtGeneroUsuario_editar">Genero:</label>

                            <select id="txtGeneroUsuario_editar" class = "form-control">
                                <option value="M" >Masculino</option>
                                <option value="F">Femenino</option>
                            </select>

                          <!-- <input type="text" class="form-control validate[required,maxSize[1]]" id="txtGeneroUsuario_editar" placeholder="Seleccione el genero..." /> -->
                        </div>

                     <!-- Campo para insertar un estado -->
                        <div class="form-group">
                            <label for="txtEstadoUsuario_editar">Estado:</label>

                            <select id="txtEstadoUsuario_editar" class = "form-control">
                                <option value="1">Activo</option>
                                <option value="2">Inactivo</option>
                                <option value ="3">Postulante</option>
                            </select>

                            <!-- <input type="text" class="form-control validate[minSize[1]]" id="txtEstadoUsuario_editar" placeholder="Seleccione el estado..." /> -->
                        </div>

                      <!-- boton para moddificar la contrasena -->
                        <div class="form-group">
                            <label for="txtPassUsuario_editar">Contraseña:</label>
                            <button type="button" id = "btnPassUsuario_editar" class="btn btn-success form-control">Modificar</button>
                        </div>
  
                  <!-- / Cuerpo de la ventana -->
              </div>
              <div class="modal-footer">
                  <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                    <button type="submit" class="btn btn-warning btnEditarUsuario">Guardar cambios</button>
                  <!-- / Zona inferior de la ventana -->
              </div>
            
            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para editar usuarios -->

        <!-- Ventana para los roles de un usuarios -->
    <div class="modal fade" id="ventanaRolUsuario">
      <div class="modal-dialog">
        <div class="modal-content">

            <form id="formularioRolUsuario">

                <div class="modal-header">
                    <!-- Encabezado de la ventana -->
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="lblRolUsuario">Roles</h4>
                    <!-- / Encabezado de la ventana -->
                </div>

                <div class="modal-body">
                    <!-- Cuerpo de la ventana -->
                    <div class="row">
                        <div class="col-md-12">
                            <!-- Tabla de usuario -->
                            <table class="table table-bordered table-hover table-striped">
                                <!-- Encabezado de la tabla -->
                                <thead><tr><th>ID</th><th>Nombre</th><th>Descripción</th><th style="width:100px;">Acciones</th></tr></thead>
                                <!-- Cuerpo de la tabla, aqui es donde el javascript escribe en tiempo de ejecucion las filas con la informacion necesaria -->
                                <tbody id="tablaRol"></tbody>
                            </table>
                            <!-- / Tabla de usuarios -->
                        </div>
                    </div> 

                    <!-- Lista de roles para asignar/remover --> 
                     
                    <!-- Campo para insertar un genero -->
                        <div class="form-group">
                            <label for="txtRolUsuario">Roles:</label>

                            <select id ="cmbRolUsuario" class ="form-control">
                                <!-- Aqui van a ir los roles que exista en el sistema en un <option></option> -->

                            </select>

                        </div>    
                    
                    <!-- boton para asignar roles -->
                        <div class="form-group">
                            <button type="submit" class="btn btn-success form-control btnAsignar" id="btnAsignarRol"><span class="" ></span> Asignar</button>
                        </div>    

                    <!-- / Cuerpo de la ventana -->
                </div>
                <div class="modal-footer">
                    <!-- Zona inferior de la ventana -->
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
<!--                     <button type="submit" class="btn btn-primary btnAgregarUsuario">Agregar Usuario</button> -->
                    <!-- / Zona inferior de la ventana -->
                </div>

            </form>

        </div><!-- /.modal-content -->
      </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->
    <!-- / Ventana para roles de usuario -->

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
    <script src="../../assets/codigo_secciones/usuario.js"></script>
</asp:Content>