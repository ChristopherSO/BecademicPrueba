<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Becademic.Master" CodeBehind="index.aspx.vb"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="breadcrumbs" runat="server">

    <ul class="breadcrumb">
		<li class="active">
			<i class="ace-icon fa fa-home home-icon"></i>
			<a href="index.aspx">Home</a>
		</li>
	</ul>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="titulo_contenido_principal" runat="server">Becademic</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contenido_principal" runat="server">

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footer" runat="server">

    <script type="text/javascript">
        console.log(usuarioActual.Nombre + " " + usuarioActual.PrimerApellido);
    </script>

</asp:Content>
