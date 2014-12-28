<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">
    <ul class="breadcrumb">
		<li>
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="../index.aspx">Home</a>
		</li>
        <li class="active">
            Módulos de reportes
        </li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="titulo_contenido_principal" runat="server">
    Módulo de reportes
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contenido_principal" runat="server">

    <table class="table table-bordered table-hover table-striped">
        <thead>
            <tr>
                <td>Nombre</td>
                <td style="width:150px;">Acciones</td>
            </tr>
        </thead>

        <tbody>
            <tr>
                <td>Reporte 1</td>
                <td><a class="btn btn-primary" href="Reporte1.aspx">Generar reporte</a></td>
            </tr>
            <tr>
                <td>Reporte 2</td>
                <td><a class="btn btn-primary" href="Reporte1.aspx">Generar reporte</a></td>
            </tr>
            <tr>
                <td>Reporte 3</td>
                <td><a class="btn btn-primary" href="Reporte1.aspx">Generar reporte</a></td>
            </tr>
        </tbody>
    </table>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
