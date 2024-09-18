<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="rLicencia.aspx.cs" Inherits="Reportes_rLicencia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register src="../Controles/RegistrarCliente.ascx" tagname="Cliente" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript" language="javascript" ></script> 
    <link href="../Styles/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" /> 
     
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtSearchCI.ClientID%>").autocomplete('../Handlers/ClienteServicios.ashx').result(function (event, data, formatted) {
                if (data) {
                    //alert('Value: ' + data[1]);
                    $("#<%= ClientePaqueteId.ClientID %>").val(data[1]);
                }
                else {
                    $("#<%= ClientePaqueteId.ClientID %>").val('-1');
                }
            });
        });
    </script>
    <asp:HiddenField runat="server" ID="ClientePaqueteId" Value="" />
    <h2>Reporte de licencias</h2> 
    <h2>Filtro de búsqueda</h2>    
        <hr />
        <fieldset class="search">
            <table border="0" cellpadding="2" cellspacing="0">
                <colgroup>
                    <col width="150px" />
                    <col width="300px" />
                    <col width="70px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td>
                        <asp:Literal ID="Literal5" runat="server">Cliente/Servicio:</asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchCI" runat="server" Width="250px"></asp:TextBox> 
                    </td>
                </tr>
                <tr>                    
                    <td><asp:Literal ID="lblBuscarNombre" runat="server">Nombre:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarNombre" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarNombre" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                        
                    </td>
                    <td><asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstado">
                            <asp:ListItem Selected="True" Text="TODOS" Value=""></asp:ListItem>
                            <asp:ListItem Text="ACTIVO" Value="True"></asp:ListItem>
                            <asp:ListItem Text="INACTIVO" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>                    
                    <td><asp:Literal ID="Literal1" runat="server">Fecha inicio:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarFechaInicio" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:Image ID="imgFechaIngreso" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" TargetControlID="txtBuscarFechaInicio" PopupButtonID="imgFechaIngreso" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                         </asp:CalendarExtender>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarFechaInicio" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                        
                    </td>
                    <td><asp:Literal ID="Literal2" runat="server">Fecha final:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarFechaFinal" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                         <asp:Image ID="imgButton2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                        Enabled="True" TargetControlID="txtBuscarFechaFinal" PopupButtonID="imgButton2" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarFechaFinal" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p class="findButton">
                            <asp:Button CssClass="btnStyle" CausesValidation="false" ID="Seach" runat="server" Text="Buscar" 
                                onclick="Seach_Click"  />
                        </p>                       
                    </td>
                </tr>
            </table>            
        </fieldset>
    <rsweb:ReportViewer ID="rvHorario" ZoomPercent="80" runat="server" Width="100%" Height="600px">
    </rsweb:ReportViewer>
</asp:Content>
