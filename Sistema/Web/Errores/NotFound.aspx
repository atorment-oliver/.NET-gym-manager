<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NotFound.aspx.cs" Inherits="Errores_NotFound" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        P&aacute;gina NO existente
    </h2>
    <hr />
    <p>
        La p&aacute;gina seleccionada no existe en el sistema.
        <br />
        Por favor haga click <a href="../Default.aspx">aqu&iacute;</a> para volver a la p&aacute;gina inicial o presione <a href="../Soporte.aspx">aqu&iacute;</a> para enviar un correo de consulta a 
        soporte t&eacute;cnico.
    </p>
</asp:Content>

