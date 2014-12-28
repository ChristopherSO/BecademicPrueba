<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="index.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
        <li class="active">
            Notificaciones
        </li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Notificaciones de eventos del sistema.
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">

<div class="timeline-container">
	<div class="timeline-label">
		<span class="label label-primary arrowed-in-right label-lg">
			<b>Hoy</b>
		</span>
	</div>

	<div class="timeline-items">
													
		<div class="timeline-item clearfix">
			<div class="timeline-info">
				<i class="timeline-indicator icon-legal btn btn-warning no-hover"></i>
			</div>

			<div class="widget-box transparent">
				<div class="widget-header widget-header-small hidden"></div>

				<div class="widget-body">
					<div class="widget-main">
						Guadalberto Jurado Barrios ha dado su veredicto para la beca: <span class="badge badge-info">#215 </span>
						<div class="pull-right">
							<i class="icon-time bigger-110"></i>
							08:30 am
						</div>
					</div>
				</div>
			</div>
		</div>

	</div><!-- /.timeline-items -->
</div><!-- /.timeline-container -->

<div class="timeline-container">
	<div class="timeline-label">
		<span class="label label-success arrowed-in-right label-lg">
			<b>Ayer</b>
		</span>
	</div>

	<div class="timeline-items">
													
		<div class="timeline-item clearfix">
			<div class="timeline-info">
				<i class="timeline-indicator icon-archive btn btn-primary no-hover"></i>
			</div>

			<div class="widget-box transparent">
				<div class="widget-header widget-header-small hidden"></div>

				<div class="widget-body">
					<div class="widget-main">
						Rayen Badillo Martínez ha actualizado las notas de los estudiantes de la carrera: <span class="badge badge-info">BISOFT</span>
						<div class="pull-right">
							<i class="icon-time bigger-110"></i>
							11:02 am
						</div>
					</div>
				</div>
			</div>
		</div>

		<div class="timeline-item clearfix">
			<div class="timeline-info">
				<i class="timeline-indicator icon-comment btn btn-pink no-hover"></i>
			</div>

			<div class="widget-box transparent">
				<div class="widget-header widget-header-small hidden"></div>

				<div class="widget-body">
					<div class="widget-main">
						Departamento de registro ha sumado 15 nuevas solicitudes que debe revisar
						<div class="pull-right">
							<i class="icon-time bigger-110"></i>
							01:48 pm
						</div>
					</div>
				</div>
			</div>
		</div>

	</div><!-- /.timeline-items -->
</div><!-- /.timeline-container -->

<div class="timeline-container">
	<div class="timeline-label">
		<span class="label label-grey arrowed-in-right label-lg">
			<b>14 de Octubre del 2014</b>
		</span>
	</div>

	<div class="timeline-items">
													
		<div class="timeline-item clearfix">
			<div class="timeline-info">
				<i class="timeline-indicator icon-thumbs-up btn btn-success no-hover"></i>
			</div>

			<div class="widget-box transparent">
				<div class="widget-header widget-header-small hidden"></div>

				<div class="widget-body">
					<div class="widget-main">
						La beca para el usuario: Anelisa Hernández Santacruz ha sido aprobada.
						<div class="pull-right">
							<i class="icon-time bigger-110"></i>
							04:30 pm
						</div>
					</div>
				</div>
			</div>
		</div>

	</div><!-- /.timeline-items -->
</div><!-- /.timeline-container -->

    <div>
        <label>Id usuario:</label>
        <input type="text" id="txtIdUsuario"/>
        <br />

        <label>Id carrera:</label>
        <input type="text" id="txtIdCarrera"/>
        <br />

        <button id="btnValidarBeca">Validar beca</button>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
    <script src="/assets/codigo_secciones/PruebasNotificaciones.js"></script>
</asp:Content>
