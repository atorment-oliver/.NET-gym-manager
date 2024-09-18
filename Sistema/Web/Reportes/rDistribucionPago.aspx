<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="rDistribucionPago.aspx.cs" Inherits="Reportes_rDistribucionPago" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript" language="javascript" ></script>
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtCliente.ClientID%>").autocomplete('../Handlers/ClienteCorporativos.ashx').result(function (event, data, formatted) {
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
    <h2>Reporte de Distribución Pagos Corporativos</h2>    
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
                    <td colspan="3"><div style="font-size:18px;font-weight:bold;padding-bottom:7px;">Filtro de búsqueda:</div></td>                 
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
                <tr>                    
                    <td align="right">Porcentaje inicial: </td>
                    <td>
                        <asp:DropDownList ID="ddlInicial" runat="server">
                            <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="25" Value="25"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="35" Value="35"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="45" Value="45"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="55" Value="55"></asp:ListItem>
                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                            <asp:ListItem Text="65" Value="65"></asp:ListItem>
                            <asp:ListItem Text="70" Value="70"></asp:ListItem>
                            <asp:ListItem Text="75" Value="75"></asp:ListItem>
                            <asp:ListItem Text="80" Value="80"></asp:ListItem>
                            <asp:ListItem Text="85" Value="85"></asp:ListItem>
                            <asp:ListItem Text="90" Value="90"></asp:ListItem>
                            <asp:ListItem Text="95" Value="95"></asp:ListItem>
                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                    </td>  
                    <td>&nbsp;</td>             
                    <td align="right">Porcentaje final: </td>
                    <td>
                        <asp:DropDownList ID="ddlFinal" runat="server">
                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="25" Value="25"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="35" Value="35"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="45" Value="45"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="55" Value="55"></asp:ListItem>
                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                            <asp:ListItem Text="65" Value="65"></asp:ListItem>
                            <asp:ListItem Text="70" Value="70"></asp:ListItem>
                            <asp:ListItem Text="75" Value="75"></asp:ListItem>
                            <asp:ListItem Text="80" Value="80"></asp:ListItem>
                            <asp:ListItem Text="85" Value="85"></asp:ListItem>
                            <asp:ListItem Text="90" Value="90"></asp:ListItem>
                            <asp:ListItem Text="95" Value="95"></asp:ListItem>
                            <asp:ListItem Text="100" Value="100" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
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

