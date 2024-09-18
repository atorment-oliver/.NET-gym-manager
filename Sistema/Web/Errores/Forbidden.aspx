<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Forbidden.aspx.cs" Inherits="Errores_Forbidden" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Acceso a la p&aacute;gina NO permitido
    </h2>
    <hr />
    <p>
        La p&aacute;gina seleccionada se encuentra con acceso restringido.
        <br />
        Por favor haga click <a href="../Default.aspx">aqu&iacute;</a> para volver a la p&aacute;gina inicial o presione <a href="../Soporte.aspx">aqu&iacute;</a> para enviar un correo de consulta a 
        soporte t&eacute;cnico.
    </p>
</asp:Content>

