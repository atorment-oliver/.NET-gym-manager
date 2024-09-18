<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Revision.aspx.cs" Inherits="Caja_Revision" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script language="javascript" type="text/javascript">
    

    function EvaluateCierre() {
        var UsuarioBob = document.getElementById('<%= txtCuadre.ClientID%>');
        var SistemaBob = document.getElementById('<%= lblSistemaBs.ClientID%>');
        var UsuarioSus = document.getElementById('<%= txtCuadreSus.ClientID%>');
        var TipoCambio = document.getElementById('<%= lblTipoCambio.ClientID%>');
        var Pendiente = document.getElementById('<%= lblDiferenciaBob.ClientID%>');
        var CierreBs = document.getElementById('<%= txtCierreBs.ClientID%>');
        var CierreSus = document.getElementById('<%= txtCierreSus.ClientID%>');
        var texto = TipoCambio.innerHTML.toString();
        texto = texto.replace(",", ".");

        var montoUsuarioBob = UsuarioBob.value.toString();
        montoUsuarioBob = montoUsuarioBob.replace(",", ".");

        var montoUsuarioSus = UsuarioSus.value.toString();
        montoUsuarioSus = montoUsuarioSus.replace(",", ".");

        var montoSistema = SistemaBob.innerHTML.toString();
        montoSistema = montoSistema.replace(",", ".");

        var montoCierreBs = CierreBs.value.toString();
        montoCierreBs = montoCierreBs.replace(",", ".");

        var montoCierreSus = CierreSus.value.toString();
        montoCierreSus = montoCierreSus.replace(",", ".");

        var total = Number(montoUsuarioBob) + Number(montoUsuarioSus) * Number(texto);

        var totalCierre = Number(montoCierreBs) + Number(montoCierreSus) * Number(texto);
        var montoPendiente = Number(Number(Number(montoSistema) - Number(total)).toFixed(2) - totalCierre).toFixed(2);

        Pendiente.innerHTML = montoPendiente;

        var btnOK = document.getElementById('<%= btnSave.ClientID%>');
        if (montoPendiente != 0.00) {
            btnOK.disabled = true;
        }
        else {
            btnOK.disabled = false;
        }
    }
    </script>
    <asp:HiddenField runat="server" ID="MovimientoId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">
        <h2>Filtro de búsqueda</h2>    
        <hr />
        <fieldset class="search">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <colgroup>
                    <col width="100px" />
                    <col width="300px" />
                    <col width="100px" />
                    <col width="*" />
                </colgroup>
                <tr>                    
                    <td><asp:Literal ID="lblCajeroBuscar" runat="server">Cajero:</asp:Literal></td>
                    <td>
                        <asp:DropDownList ID="ddlCajeroBuscar" runat="server"></asp:DropDownList>
                    </td>
                    <td><asp:Literal ID="lblFechaDesdeBuscar" runat="server">Desde:</asp:Literal></td>
                    <td>     
                        <asp:TextBox ID="txtFechaDesdeBuscar"  Width="90" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="revFechaIngreso" Display="Dynamic" CssClass="failureNotification" ValidationGroup="RegisterUserValidationGroup1" ControlToValidate="txtFechaDesdeBuscar" 
                    ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>
                        <asp:Image ID="imgFechaDesde" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                            Enabled="True" TargetControlID="txtFechaDesdeBuscar" PopupButtonID="imgFechaDesde" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>                  
                    </td>
                </tr>                
                <tr>
                    <td><asp:Literal ID="lblObservadoBuscar" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:RadioButtonList ID="rbtObservadoBuscar" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="Todos" Selected="True" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Correctos" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Observados" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>   
                    </td>
                    <td><asp:Literal ID="lblFechaHastaBuscar" runat="server">Hasta:</asp:Literal></td>
                    <td>     
                        <asp:TextBox ID="txtFechaHastaBuscar"  Width="90" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" Display="Dynamic" CssClass="failureNotification" ValidationGroup="RegisterUserValidationGroup1" ControlToValidate="txtFechaHastaBuscar" 
                    ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>
                        <asp:Image ID="imgFechaHasta" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                            Enabled="True" TargetControlID="txtFechaHastaBuscar" PopupButtonID="imgFechaHasta" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                        </asp:CalendarExtender>                  
                    </td>
                </tr>
                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" ValidationGroup="RegisterUserValidationGroup1" CausesValidation="true" />
        </p>
        <h2>Movimientos encontrados</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> movimientos.
        <asp:ObjectDataSource 
            ID="RevisionDataSource" runat="server" SelectMethod="TraerXObservacion" 
            TypeName="RN.Componentes.CMovimientoCaja" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtFechaDesdeBuscar" Name="fechaDesdeCierre" 
                    PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="txtFechaHastaBuscar" Name="fechaHastaCierre" 
                    PropertyName="Text" Type="DateTime" />
                <asp:ControlParameter ControlID="ddlCajeroBuscar" Name="cajeroId" 
                    PropertyName="SelectedValue" DbType="Guid" />
                <asp:ControlParameter ControlID="rbtObservadoBuscar" Name="tipo" 
                    PropertyName="SelectedValue" Type="Char" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="RevisionDataSource" 
                 Width="100%" 
                AutoGenerateColumns="False" DataKeyNames="id" 
                AllowPaging="True" AllowSorting="True" 
                onrowcommand="ResultGrid_RowCommand" 
                onpageindexchanging="ResultGrid_PageIndexChanging">      
                <EmptyDataTemplate>
                    No se encontraron resultados para el filtro aplicado.
                </EmptyDataTemplate>
                <RowStyle Height="30px" />
                <HeaderStyle CssClass="ui-widget-header" />
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="Id" Visible="false" />
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Ver/Editar">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Cajero">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Label ID="lblGridCajero" runat="server" Text='<%# GetCajero(Container.DataItem) %>'></asp:Label>                            
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="250" DataField="fechaHoraApertura" 
                        SortExpression="fechaHoraApertura" HeaderText="Fecha Apertura" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150" DataField="fechaHoraCierre" 
                        SortExpression="fechaHoraCierre" HeaderText="Fecha Cierre" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>                    
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Literal  runat="server" ID="IsApproved" Text='<%# IsClosed(Container.DataItem) %>' ></asp:Literal>
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Observado">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Image  runat="server" ID="IsObserved" ImageUrl='<%# IsObserved(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Movimientos
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información de movimiento de caja</legend>
                <table border="0" cellpadding="4" cellspacing="0" width="100%">
                    <colgroup>
                        <col width="400px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>Caja:</td>
                        <td><asp:Literal runat="server" ID="lblCaja"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>Fecha apertura:</td>
                        <td><asp:Literal runat="server" ID="lblFechaApertura"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>Fecha cierre:</td>
                        <td><asp:Literal runat="server" ID="lblFechaCierre"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>Estado:</td>
                        <td><asp:Literal runat="server" ID="lblEstado"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td colspan="2"><hr /></td>
                    </tr>                    
                    <tr>
                        <td>Monto apertura Bs:</td>
                        <td><asp:Literal runat="server" ID="lblAperturaBs"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>Monto apertura $us:</td>
                        <td><asp:Literal runat="server" ID="lblAperturaSus"></asp:Literal></td>
                    </tr>
                    <tr>
                        <td>Tipo de cambio:</td>
                        <td><asp:Label runat="server" ID="lblTipoCambio"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><hr /></td>
                    </tr>  
                    <tr>
                        <td class="register">Pagos recibidos en efectivo (Bolivianos):</td>
                        <td>                                        
                            <asp:Label ID="lblPagosEfectivo" runat="server"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Pagos recibidos en cheque (Bolivianos):</td>
                        <td>                                        
                            <asp:Label ID="lblPagosCheque" runat="server"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Pagos recibidos en tarjeta (Bolivianos):</td>
                        <td>                                        
                            <asp:Label ID="lblPagosTarjeta" runat="server"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Pagos recibidos en intercambio (Bolivianos):</td>
                        <td>                                        
                            <asp:Label ID="lblPagosIntercambio" runat="server"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Pagos recibidos en transferencia (Bolivianos):</td>
                        <td>                                        
                            <asp:Label ID="lblPagosTransferencia" runat="server"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Total de ingresos de la caja (Bolivianos):</strong></td>
                        <td><strong><asp:Literal runat="server" ID="lblPagos"></asp:Literal></strong></td>
                    </tr>
                    <tr>
                        <td colspan="2"><hr /></td>
                    </tr>
                    <tr>
                        <td>Total de efetivo en caja Bs:</td>
                        <td><asp:Label runat="server" ID="lblSistemaBs">0</asp:Label> Bs.</td>
                    </tr>
                    <tr>
                        <td>Monto de cierre en efectivo Bs:</td>
                        <td><asp:TextBox runat="server" ID="txtCierreBs" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqrCierreBsRequired" runat="server" ControlToValidate="txtCierreBs" 
                                    CssClass="failureNotification" ErrorMessage="El monto en Bolivianos es obligatorio." ValidationGroup="valGroup"
                                    Text="El monto en Bolivianos es obligatorio." ToolTip="El monto en Bolivianos es obligatorio." 
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="rqrCierreBsRegular" 
                                    ControlToValidate="txtCierreBs" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimalPosNeg %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Monto de cierre en efectivo $us:</td>
                        <td><asp:TextBox runat="server" ID="txtCierreSus" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqrCierreSusRequired" runat="server" ControlToValidate="txtCierreSus" 
                                    CssClass="failureNotification" ErrorMessage="El monto en Dólares es obligatorio." ValidationGroup="valGroup"
                                    Text="El monto en Dólares es obligatorio." ToolTip="El monto en Dólares es obligatorio." 
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="rqrCierreSusRegular" 
                                    ControlToValidate="txtCierreSus" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimalPosNeg %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Efectivo entregado a administración Bs:</td>
                        <td><asp:TextBox runat="server" ID="txtAdministracionBs" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqrAdministracionBsRequired" runat="server" ControlToValidate="txtAdministracionBs" 
                                    CssClass="failureNotification" ErrorMessage="El monto entregado a administración en Bolivianos es obligatorio." ValidationGroup="valGroup" 
                                    Text="El monto entregado a administración en Bolivianos es obligatorio." ToolTip="El monto entregado a administración en Bolivianos es obligatorio." 
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="rqrAdministracionBsRegular" 
                                    ControlToValidate="txtAdministracionBs" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator1" Type="Double" Display="Dynamic" CssClass="failureNotification" ValidationGroup="valGroup" runat="server" ErrorMessage="El monto no puede ser mayor al de cierre" ControlToValidate="txtAdministracionBs" ControlToCompare="txtCierreBs" Operator="LessThanEqual" ></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Efectivo entregado a administración Sus:</td>
                        <td><asp:TextBox runat="server" ID="txtAdministracionSus" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rqrAdministracionSusRequired" runat="server" ControlToValidate="txtAdministracionSus" 
                                    CssClass="failureNotification" ErrorMessage="El monto entregado a administración en Dólares es obligatorio." ValidationGroup="valGroup" 
                                    Text="El monto entregado a administración en Dólares es obligatorio." ToolTip="El monto entregado a administración en Dólares es obligatorio." 
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="rqrAdministracionSusRegular" 
                                    ControlToValidate="txtAdministracionSus" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cbMonto" Type="Double" Display="Dynamic" CssClass="failureNotification" ValidationGroup="valGroup" runat="server" ErrorMessage="El monto no puede ser mayor al de cierre" ControlToValidate="txtAdministracionSus" ControlToCompare="txtCierreSus" Operator="LessThanEqual" ></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">Observaci&oacute;n cajero:</td>
                        <td><asp:TextBox runat="server" ID="txtObservacion" Width="500px" Height="90px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr> 
                    <tr>
                        <td>Pendiente de registrar (Bolivianos):</td>
                        <td>
                          <asp:Label runat="server" ID="lblDiferenciaBob"></asp:Label> Bs.
                        </td>
                    </tr>                   
                    <tr>
                        <td>Monto cuadre Bs:</td>
                        <td><asp:TextBox runat="server" ID="txtCuadre" onchange="javascript: EvaluateCierre( );" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCuadreBob" runat="server" ControlToValidate="txtCuadre" 
                                    CssClass="failureNotification" ErrorMessage="El monto de caudre es obligatorio." Text="El monto de caudre es obligatorio." 
                                    ToolTip="El monto de caudre es obligatorio." Display="Dynamic" 
                                    ValidationGroup="Save"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator1" 
                                    ControlToValidate="txtCuadre" ValidationGroup="Save" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Monto cuadre Sus:</td>
                        <td><asp:TextBox runat="server" ID="txtCuadreSus" onchange="javascript: EvaluateCierre( );" Width="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCuadreSus" runat="server" ControlToValidate="txtCuadreSus" 
                                    CssClass="failureNotification" ErrorMessage="El monto de caudre es obligatorio." Text="El monto de caudre es obligatorio." 
                                    ToolTip="El monto de caudre es obligatorio." Display="Dynamic" 
                                    ValidationGroup="Save"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator2" 
                                    ControlToValidate="txtCuadreSus" ValidationGroup="Save" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">Observaci&oacute;n administrador:</td>
                        <td><asp:TextBox runat="server" ID="txtObservacionAdm" Width="500px" Height="90px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">Observado:</td>
                        <td><strong><asp:Literal runat="server" ID="lblObservado"></asp:Literal></strong>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2"><h3>REPORTE DE RECAUDACIONES</h3></td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="2">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                            
                        <rsweb:ReportViewer ID="rvPagos" runat="server" Width="905px">
                        </rsweb:ReportViewer>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle"  CausesValidation="true" ID="btnSave" OnClick="btnSave_Click" ValidationGroup="Save" runat="server" Text="Quitar observación"/>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnAtras" runat="server" onclick="btnAtras_Click">Atrás</asp:LinkButton>
            </p>
            
        </div>
    </asp:Panel>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#dialog-message").dialog({
                autoOpen: false,
                modal: true,
                show: "blind",
                hide: "explode",
                buttons: {
                    "Ok": function () { $(this).dialog("close"); }
                }
            });
        });
	</script>
    <div id="dialog-message" title="Informacion">
	    <p>
            <strong><asp:Literal runat="server" ID="popupTitle"></asp:Literal></strong>
            <br />
            <asp:Literal runat="server" ID="popupMessage"></asp:Literal>
	    </p>
    </div>     
    <asp:Literal runat="server" ID="lblScriptShow"></asp:Literal>
</asp:Content>

