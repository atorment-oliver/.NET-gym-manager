<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="rDistribucionesPendientes.aspx.cs" Inherits="Reportes_rDistribucionesPendientes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript" language="javascript" ></script>
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtCliente.ClientID%>").autocomplete('../Handlers/ClienteNoEmpresa.ashx').result(function (event, data, formatted) {
                if (data) {
                    $("#<%= ClienteId.ClientID %>").val(data[1]);
                }
                else {
                    $("#<%= ClienteId.ClientID %>").val('-1');
                }
            });
        });
    </script>
    <asp:HiddenField runat="server" ID="ClienteId" Value="" />
    <h2>Reporte de Distribuciones Pendientes</h2>    
    <hr />
    <fieldset class="search">
            <table border="0" cellpadding="2" cellspacing="0">
                <colgroup>
                    <col width="100px" />
                    <col width="200px" />
                    <col width="10px" />
                    <col width="100px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td colspan="2"><div style="font-size:18px;font-weight:bold;padding-bottom:7px;">Filtro de búsqueda:</div></td>
                </tr>
                <tr>                    
                    <td align="right">Empresa: </td>
                    <td>
                        <asp:DropDownList ID="ddlEmpresa" runat="server" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td align="right">Cliente: </td>
                    <td>
                        <asp:TextBox ID="txtCliente" runat="server" Width="250px"></asp:TextBox>
                    </td>
                </tr>
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button class="btnStyle" ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click"/>
        </p>
    <rsweb:ReportViewer ID="rvDistribucionPagos" runat="server" Width="933px">
    </rsweb:ReportViewer>
</asp:Content>

