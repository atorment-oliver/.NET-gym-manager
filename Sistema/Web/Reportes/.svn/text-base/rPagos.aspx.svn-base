<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="rPagos.aspx.cs" Inherits="Reportes_rPagos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Reporte de pagos</h2>    
    <hr />
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
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button class="btnStyle" ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" />
        </p>
    <rsweb:ReportViewer ID="rvPagos" runat="server" Width="933px">
    </rsweb:ReportViewer>
</asp:Content>

