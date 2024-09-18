<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.master"  AutoEventWireup="true" CodeFile="rClientesDatos.aspx.cs" Inherits="Reportes_rClientesDatos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<%--<script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>        
    <script src="../Scripts/jquery.simplemodal.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.msgBox.v1.js" type="text/javascript"></script> 
    <script src="../Scripts/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>--%>
<link href="../Styles/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtSearchCI.ClientID%>").autocomplete('../Handlers/ClienteCi.ashx').result(function (event, data, formatted) {
            if (data) {
                $("#<%= hdnAutoCompleteClienteId.ClientID %>").val(data[1]);
            }
            else {
                $("#<%= hdnAutoCompleteClienteId.ClientID %>").val('');
            }
        });
    });
    </script>
    <h2>Reporte de clientes</h2>    
    <hr />
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
    <asp:HiddenField ID="hdnAutoCompleteClienteId" runat="server" Value="" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <fieldset class="search">
            <table border="0" cellpadding="2" cellspacing="0">
                <colgroup>
                    <col width="80px" />
                    <col width="150px" />
                    <col width="10px" />
                    <col width="80px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td colspan="2"><div style="font-size:18px;font-weight:bold;padding-bottom:7px;">Filtro de búsqueda:</div></td>
                </tr>
                <tr>
                    <td align="right">Cliente: </td>
                    <td>
                        <asp:TextBox ID="txtSearchCI" runat="server" Width="350px"></asp:TextBox>  
                    </td>
                    <td>&nbsp;</td>
                    <td align="right">Estado del cliente: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstadoPago">
                            <asp:ListItem Value="d">Vigentes al día</asp:ListItem>
                            <asp:ListItem Value="s">Vigentes con deuda</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>                    
                    <td align="right">Fecha Inicio: </td>
                    <td>
                        <asp:TextBox ID="txtFechaInicio"  Width="90" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:Image ID="imgFechaInicio" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="calendarFechaInicio" runat="server" 
                            Enabled="True" TargetControlID="txtFechaInicio" PopupButtonID="imgFechaInicio" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="reqFechaInicio" runat="server" Display="Dynamic" ControlToValidate="txtFechaInicio" 
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="La fecha de inicio es obligatoria." Text="La fecha de inicio es obligatoria." ToolTip="La fecha de inicio es obligatoria."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="revFechaInicio" Display="Dynamic" CssClass="failureNotification" ControlToValidate="txtFechaInicio" 
                            ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>  
                    </td>
                    <td>&nbsp;</td>
                    <td align="right">Fecha Fin: </td>
                    <td>
                        <asp:TextBox ID="txtFechaFin"  Width="90" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:Image ID="imgFechaFin" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="calendarFechaFin" runat="server" 
                            Enabled="True" TargetControlID="txtFechaFin" PopupButtonID="imgFechaFin" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="reqFechaFin" runat="server" Display="Dynamic" ControlToValidate="txtFechaFin" 
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="La fecha de finalizacion es obligatoria." Text="La fecha de finalizacion es obligatoria." ToolTip="La fecha de finalizacion es obligatoria."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="revFechaFin" Display="Dynamic" CssClass="failureNotification" ControlToValidate="txtFechaFin" 
                            ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>                    
                    <td align="right">Grupo: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlGrupo" AppendDataBoundItems="true">
                            <asp:ListItem Value="">&#60;TODOS&#62;</asp:ListItem>
                        </asp:DropDownList>
                          
                    </td>
                    <td>&nbsp;</td>
                    <td align="right">Empresa: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEmpresa" AppendDataBoundItems="true">
                            <asp:ListItem Value="">&#60;TODOS&#62;</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>                    
                    <td align="right">Disciplina: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlDisciplina" AppendDataBoundItems="true">
                            <asp:ListItem Value="">&#60;TODOS&#62;</asp:ListItem>
                        </asp:DropDownList>
                          
                    </td>
                    <td>&nbsp;</td>
                    <td align="right">Promoci&oacute;n: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPromociones" AppendDataBoundItems="true">
                            <asp:ListItem Value="">&#60;TODOS&#62;</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>                    
                    <%--<td align="right">Forma Pago: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlFormaPago">
                            <asp:ListItem Text="<< TODOS >>" Value=""></asp:ListItem>
                            <asp:ListItem Text="Efectivo" Value="ef"></asp:ListItem>
                                <asp:ListItem Text="Tarjeta" Value="ta"></asp:ListItem>
                                <asp:ListItem Text="Cheque" Value="ch"></asp:ListItem>
                                <asp:ListItem Text="Transeferencia" Value="tr"></asp:ListItem>
                                <asp:ListItem Text="Intercambio" Value="in"></asp:ListItem>
                        </asp:DropDownList>
                          
                    </td>
                    <td>&nbsp;</td>--%>
                     <td align="right">Paquete: </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPaquete" AppendDataBoundItems="true">
                            <asp:ListItem Value="">&#60;TODOS&#62;</asp:ListItem>
                        </asp:DropDownList>
                          
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        Nuevo, Reingreso, Renovaci&oacute;n:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstadoNRI">
                            <asp:ListItem Value="" Selected="True">&#60;TODOS&#62;</asp:ListItem>
                            <asp:ListItem Value="N">NUEVO</asp:ListItem>
                            <asp:ListItem Value="R">RENOVACION</asp:ListItem>
                            <asp:ListItem Value="I">REINGRESO</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" />
        </p>
    <rsweb:ReportViewer ID="rvClientes" runat="server" Width="933px">
    </rsweb:ReportViewer>
</asp:Content>

