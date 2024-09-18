<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Impresion.aspx.cs" Inherits="Clientes_Impresion" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    <rsweb:ReportViewer ID="rvLicencias"  runat="server" Width="700px" Height="600px">
    </rsweb:ReportViewer>
</asp:Content>