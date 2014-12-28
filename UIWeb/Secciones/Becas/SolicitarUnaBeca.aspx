<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="SolicitarUnaBeca.aspx.vb" %>

<%-- Contenido que ira finalizando el </head> --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<%-- / Contenido que ira finalizando el </head> --%>

<%-- Contenido que marcará la ruta de acceso a este documento --%>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb" runat="server">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="/Secciones/index.aspx">Home</a>
		</li>
		<li class="active">
			Solicitar una beca
		</li>
	</ul>
</asp:Content>
<%-- / Contenido que marcará la ruta de acceso a este documento --%>

<%-- Proceso de solicitud de una beca --%>
<asp:Content ID="Content5" ContentPlaceHolderID="titulo_contenido_principal" runat="server">Proceso de solicitud de becas</asp:Content>
<%-- / Proceso de solicitud de una beca --%>

<%-- Contenido que ira dentro de la pagina --%>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido_principal" runat="server">

			
           <!-- #section:plugins/fuelux.wizard -->
			<div id="fuelux-wizard" data-target="#step-container">
				<!-- #section:plugins/fuelux.wizard.steps -->
				<ul class="wizard-steps">
					<li data-target="#step1" class="active">
						<span class="step">1</span>
						<span class="title">Información del interesado</span>
					</li>

					<li data-target="#step2">
						<span class="step">2</span>
						<span class="title">Carrera</span>
					</li>

					<li data-target="#step3">
						<span class="step">3</span>
						<span class="title">Tipo de beca</span>
					</li>

					<li data-target="#step4">
						<span class="step">4</span>
						<span class="title">Beneficios</span>
					</li>

                    <li data-target="#step5">
						<span class="step">5</span>
						<span class="title">Requisitos</span>
					</li>

                    <li data-target="#step6">
						<span class="step">6</span>
						<span class="title">Formalizar la solicitud</span>
					</li>
				</ul>

				<!-- /section:plugins/fuelux.wizard.steps -->
			</div>

			<hr />

			<!-- #section:plugins/fuelux.wizard.container -->
			<div class="step-content pos-rel" id="step-container">
				<div class="step-pane active" id="step1">
					<h3 class="lighter block green">Información personal</h3>
                    <p>Indique en el siguiente campo para quién será la beca a solicitar.</p>
					<form class="form-horizontal" id="sample-form">
                        <p>Cédula:</p>
						<p><input type="text" id="id_usuario_txt" value="" /><button type="button" id="buscarUsuarioBtn" class="btn btn-primary">Buscar</button></p>
                        <div id="infoUsuario"></div>
					</form>
				</div>

                <!-- Segundo paso -->
				<div class="step-pane" id="step2">
					<div>
						<h3>Carrera</h3>
                        <p>Elija una carrera para la cual desea solicitar una beca.</p>
					</div>
                    <div id="seleccionarCarrera"></div>
				</div>
                <!-- / Segundo paso -->

                <!-- Tercer paso -->
				<div class="step-pane" id="step3">
					<div>
						<h3 class="blue lighter">Tipo de beca</h3>
                        <p>Por favor, seleccione el tipo de beca que desea solicitar.</p>
					</div>
                    <div id="seleccionarTipo"></div>
				</div>
                <!-- / Tercer paso -->

                <!-- Cuarto paso -->
				<div class="step-pane" id="step4">
					<div>
						<h3 class="green">Beneficios</h3>
						<p>Usted podrá disfrutar de los siguientes beneficios relacionados al tipo de beca que esta solicitando.</p>
					</div>
                    <div id="listaBeneficios"></div>
				</div>
                <!-- / Cuarto paso -->

                <!-- Quinto paso -->
				<div class="step-pane" id="step5">
					<div>
						<h3 class="green">Requistos</h3>
						<p>Los siguientes requisitos son necesarios para el proceso de proceso de aprobación de esta solicitud.</p>
					</div>
                    <div id="listaRequisitos"></div>
				</div>
                <!-- / Quinto paso -->

                <!-- Sexto paso -->
				<div class="step-pane" id="step6">
					<div class="center">
						<h3 class="green">Paso final de la solicitud</h3>
						<p>Para registrar formalmente su solicitud en el sistema presione el boton de finalizar.<br />
                        tome en cuenta que una vez formalizada la solicitud no podrá cambiar ningun datos de la misma durante el proceso de aprobación.</p>
					</div>
				</div>
                <!-- / Sexto paso -->

			</div>

			<!-- /section:plugins/fuelux.wizard.container -->
			<hr />
			<div class="wizard-actions">
				<!-- #section:plugins/fuelux.wizard.buttons -->
				<button class="btn btn-prev">
					<i class="ace-icon fa fa-arrow-left"></i>
					Paso anterior.
				</button>

				<button class="btn btn-success btn-next" data-last="Finish">
					Siguiente paso.
					<i class="ace-icon fa fa-arrow-right icon-on-right"></i>
				</button>

				<!-- /section:plugins/fuelux.wizard.buttons -->
			</div>


	

</asp:Content>
<%-- Contenido que ira dentro de la pagina --%>

<%-- Contenido que ira finalizando el </body> --%>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">
    <script src="../../assets/js/bootbox.min.js"></script>
    <script src="../../assets/js/fuelux/fuelux.wizard.min.js"></script>
    <!-- inline scripts related to this page -->
	<script type="text/javascript" src="../../assets/codigo_secciones/procesoDeSolicitudDeBecas.js"></script>
</asp:Content>
<%-- Contenido que ira finalizando el </body> --%>
