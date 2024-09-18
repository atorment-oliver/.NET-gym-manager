<%@ Page Language="C#"  MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeFile="Caja.aspx.cs" Inherits="Caja_Caja" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script language="javascript" type="text/javascript">
        function EvaluateCierre() {
            var UsuarioBob = document.getElementById('<%= txtMontoCierreBob.ClientID%>');
            var SistemaBob = document.getElementById('<%= lblCalculoSistemaBob.ClientID%>');
            var UsuarioSus = document.getElementById('<%= txtMontoCierreSus.ClientID%>');
            var TipoCambio = document.getElementById('<%= lblTipoCambio.ClientID%>');
            var Pendiente = document.getElementById('<%= lblDiferenciaBob.ClientID%>');
            var texto = TipoCambio.innerHTML.toString();
            texto = texto.replace(",", ".");
           
            var montoUsuarioBob = UsuarioBob.value.toString();
            montoUsuarioBob = montoUsuarioBob.replace(",", ".");

            var montoUsuarioSus = UsuarioSus.value.toString();
            montoUsuarioSus = montoUsuarioSus.replace(",", ".");

            var montoSistema = SistemaBob.innerHTML.toString();
            montoSistema = montoSistema.replace(",", ".");

            var obs = document.getElementById('trObservacion');
            var total = Number(montoUsuarioBob) + Number(montoUsuarioSus) * Number(texto);

            Pendiente.innerHTML = Number(Number(montoSistema) - Number(total)).toFixed(2);
            //total = Math.round(total * 100) / 100;
            //montoSistema = Math.round(montoSistema * 100) / 100;
            
            if (Number(total).toFixed(2) != Number(montoSistema).toFixed(2)) {
            //if (total != montoSistema) {
                obs.value = '';
                obs.style.visibility = 'visible';
                obs.style.position = "relative";
                var btnOK = document.getElementById('<%= btnOK.ClientID%>');
                btnOK.disabled = true;
            }
            else {
                obs.value = '-';
                obs.style.visibility = 'hidden';
                obs.style.position = "absolute";
                var btnOK = document.getElementById('<%= btnOK.ClientID%>');
                btnOK.disabled = false;
            }
        }
        function Info() {
            var obs = document.getElementById('trObservacion');
            if (obs.value != '-') {
                var btnOK = document.getElementById('<%= btnOK.ClientID%>');
                return deleteItem(btnOK.name);
            }
            return true;
        }
        function EvaluateObservacion() {
            var obs = document.getElementById('<%= txtObservacion.ClientID%>');
            var btnOK = document.getElementById('<%= btnOK.ClientID%>');
            if (obs.value == '') {
                btnOK.disabled = true;
            }
            else {
                btnOK.disabled = false;
            }
        }
        function showDialog(id) {
            $('#' + id).dialog("open");
        }

        function closeDialog(id) {
            $('#' + id).dialog("close");
        }

        $(document).ready(function() {
            $('#dialogRecibos').dialog({
                autoOpen: false,
                draggable: true,
                width: 730,
                closeOnEscape: false,
                modal: true,
                title: "Pagos registrados",
                open: function(type, data) {
                    $(".ui-dialog-titlebar-close").hide();
                    $(this).parent().appendTo("form");
                }
            });
        });
    </script>
    <asp:HiddenField runat="server" ID="CajaId" Value="" />
    <asp:HiddenField runat="server" ID="CajeroId" Value="" />
    <asp:HiddenField runat="server" ID="MovimientoId" Value="" />
    <asp:Panel runat="server" ID="pnlNuevo" Visible="true">
        <h2>
            <asp:Literal runat="server" ID="lblCaja" Text="Apertura Caja"></asp:Literal>
        </h2>
        <hr />
            <asp:Literal ID="lblSaludo" runat="server"></asp:Literal>
            <br />
            <br />
        <div class="accountInfo">
            <fieldset class="register" runat="server" id="fsAperturaCaja">
                <legend>Información de la caja</legend>
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <colgroup>
                        <col width="250px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>Caja:</td>
                        <td>
                            <asp:Label ID="lblNroCaja" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Fecha apertura:</td>
                        <td>                                        
                            <asp:Label ID="lblFechaApertura" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Cajero:</td>
                        <td>                                        
                            <asp:Label ID="lblCajero" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><hr /></td>
                    </tr>
                    <tr>
                        <td>Fecha &uacute;ltimo cierre:</td>
                        <td>                                        
                            <asp:Label ID="lblFechaUltimoCierre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Monto &uacute;ltimo cierre (Bolivianos):</td>
                        <td>         
                            <asp:Label ID="lblUltimoMontoCierreBob" runat="server"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td>Monto &uacute;ltimo cierre (Dólares):</td>
                        <td>         
                            <asp:Label ID="lblUltimoMontoCierreSus" runat="server"></asp:Label> Sus.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><hr /></td>
                    </tr>
                    <tr>
                        <td class="mandatory">Monto de apertura (Bolivianos):</td>
                        <td>
                                        
                            <asp:TextBox ID="txtMontoBs" Width="80" runat="server" CssClass="textEntry"></asp:TextBox> Bs.
                            <asp:RequiredFieldValidator ID="txtMontoBsRequired" runat="server" ControlToValidate="txtMontoBs" 
                                    CssClass="failureNotification" ErrorMessage="El monto de apertura en Bolivianos es obligatorio." 
                                    Text="El monto de apertura en Bolivianos es obligatorio." ToolTip="El monto de apertura en Bolivianos es obligatorio." 
                                    ValidationGroup="valGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="txtMontoBsRegular" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMontoBs" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory">Monto de apertura (Dólares):</td>
                        <td>
                                        
                            <asp:TextBox ID="txtMontoSus" Width="80" runat="server" CssClass="textEntry"></asp:TextBox> Sus.
                            <asp:RequiredFieldValidator ID="txtMontoSusRequired" runat="server" ControlToValidate="txtMontoSus" 
                                    CssClass="failureNotification" ErrorMessage="El monto de apertura en Dólares es obligatorio." 
                                    Text="El monto de apertura en Dólares es obligatorio." ToolTip="El monto de apertura en Dólares es obligatorio." 
                                    ValidationGroup="valGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="txtMontoSusRegular" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMontoSus" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory">Tipo de cambio:</td>
                        <td>
                                        
                            <asp:TextBox ID="txtTipoCambio" Width="80" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtTipoCambioRequired" runat="server" ControlToValidate="txtTipoCambio" 
                                    CssClass="failureNotification" ErrorMessage="El tipo de cambio es obligatorio." 
                                    Text="El tipo de cambio es obligatorio." ToolTip="El tipo de cambio es obligatorio." 
                                    ValidationGroup="valGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="txtTipoCambioRegular" 
                                    ValidationGroup="valGroup" ControlToValidate="txtTipoCambio" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>
            <fieldset runat="server" id="fsCierreCaja" visible="false" class="register">
                <legend>Información de la caja</legend>
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <colgroup>
                        <col width="250px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>Caja:</td>
                        <td>                                        
                            <asp:Label ID="lblNroCajaCierre" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Cajero:</td>
                        <td>                                        
                            <asp:Label ID="lblCajeroCierre" runat="server"></asp:Label>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="register">Fecha de apertura:</td>
                        <td>
                                        
                            <asp:Label ID="lblHoraAperturar" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Monto de apertura (Bolivianos):</td>
                        <td>                                        
                            <asp:Label ID="lblMontoAperturaBob" runat="server"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Monto de apertura (Dólares):</td>
                        <td>                                        
                            <asp:Label ID="lblMontoAperturaSus" runat="server"></asp:Label> Sus.
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Tipo de cambio:</td>
                        <td>                                        
                            <asp:Label ID="lblTipoCambio" runat="server"></asp:Label>.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
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
                        <td class="register"><strong>Total de ingresos de la caja (Bolivianos):</strong></td>
                        <td>                                        
                            <strong><asp:Label ID="lblPagosBob" runat="server"></asp:Label> Bs.</strong>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>
                    <tr>
                        <td>Total de efetivo en caja (Bolivianos):</td>
                        <td>
                          <asp:Label runat="server" ID="lblCalculoSistemaBob"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td>Pendiente de registrar (Bolivianos):</td>
                        <td>
                          <asp:Label runat="server" ID="lblDiferenciaBob"></asp:Label> Bs.
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory">Monto de cierre (Bolivianos):</td>
                        <td>
                          <asp:TextBox ID="txtMontoCierreBob" Width="80" runat="server" 
                                CssClass="textEntry" onchange="javascript: EvaluateCierre( );"></asp:TextBox> Bs.
                            <asp:RequiredFieldValidator ID="rfvMontoCierreBob" runat="server" ControlToValidate="txtMontoCierreBob" 
                                    CssClass="failureNotification" ErrorMessage="El monto de cierre es obligatorio." Text="El monto de cierre es obligatorio." 
                                    ToolTip="El monto de cierre es obligatorio." Display="Dynamic" 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revMontoCierreBob" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMontoCierreBob" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory">Monto de cierre (Dólares):</td>
                        <td>
                          <asp:TextBox ID="txtMontoCierreSus" Width="80" runat="server" 
                                CssClass="textEntry" onchange="javascript: EvaluateCierre( );"></asp:TextBox> Sus.
                            <asp:RequiredFieldValidator ID="rfvMontoCierreSus" runat="server" ControlToValidate="txtMontoCierreSus" 
                                    CssClass="failureNotification" ErrorMessage="El monto de cierre es obligatorio." Text="El monto de cierre es obligatorio." 
                                    ToolTip="El monto de cierre es obligatorio." Display="Dynamic" 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revMontoCierreSus" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMontoCierreSus" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>     
                    <tr>
                        <td colspan="2">
                            <hr />
                        </td>
                    </tr>           
                    <tr>
                        <td class="mandatory">Monto entrega a administraci&oacute;n (Bolivianos):</td>
                        <td>
                          <asp:TextBox ID="txtMontoCierreAdministracionBob" Width="80" runat="server" CssClass="textEntry"></asp:TextBox> Bs.
                            <asp:RequiredFieldValidator ID="rfvMontoCierreAdministracionBob" runat="server" ControlToValidate="txtMontoCierreAdministracionBob" 
                                    CssClass="failureNotification" ErrorMessage="El monto es obligatorio." Text="El monto es obligatorio." 
                                    ToolTip="El monto es obligatorio." Display="Dynamic"
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revMontoCierreAdministracionBob" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMontoCierreAdministracionBob" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="cbMonto" Type="Double" Display="Dynamic" CssClass="failureNotification" ValidationGroup="valGroup" runat="server" ErrorMessage="El monto no puede ser mayor al de cierre" ControlToValidate="txtMontoCierreAdministracionBob" ControlToCompare="txtMontoCierreBob" Operator="LessThanEqual" ></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory">Monto entrega a administraci&oacute;n (Dólares):</td>
                        <td>
                          <asp:TextBox ID="txtMontoCierreAdministracionSus" Width="80" runat="server" CssClass="textEntry"></asp:TextBox> Sus.
                            <asp:RequiredFieldValidator ID="frvMontoCierreAdministracionSus" runat="server" ControlToValidate="txtMontoCierreAdministracionSus" 
                                    CssClass="failureNotification" ErrorMessage="El monto es obligatorio." Text="El monto es obligatorio." 
                                    ToolTip="El monto es obligatorio." Display="Dynamic"
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revMontoCierreAdministracionSus" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMontoCierreAdministracionSus" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                            </asp:RegularExpressionValidator>
                            <asp:CompareValidator ID="CompareValidator1" Type="Double" Display="Dynamic" CssClass="failureNotification" ValidationGroup="valGroup" runat="server" ErrorMessage="El monto no puede ser mayor al de cierre" ControlToValidate="txtMontoCierreAdministracionSus" ControlToCompare="txtMontoCierreSus" Operator="LessThanEqual" ></asp:CompareValidator>
                        </td>
                    </tr>  
                    <tr id="trObservacion">
                        <td valign="top" class="mandatory">Observación:</td>
                        <td>
                            <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Height="40" Width="300"></asp:TextBox>
                            <br />La observación es obligatoria
                        </td>
                    </tr>
                   
                </table>
            </fieldset>
            </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel runat="server" ID="upReporte" Visible="false">
                <ContentTemplate>
                    <legend>DETALLE DE RECAUDACIONES</legend>
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <tr>
                        <td class="mandatory" colspan="2"><hr />
                        </td>
                    </tr>  
                    <tr>
                        <td class="mandatory" colspan="2">
                            <rsweb:ReportViewer ID="rvPagos" runat="server" Width="905px">
    </rsweb:ReportViewer>
                        </td>
                    </tr>  
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Button CssClass="btnStyle" CausesValidation="false" ID="btnImprimir" Visible="false" 
                runat="server" CommandName="MoveNext" Text="Imprimir pagos" 
                ValidationGroup="valGroup" onclick="btnImprimir_Click"/>                
            <asp:Button CssClass="btnStyle" CausesValidation="false" ID="btnOK" OnClick="btnOK_Click" runat="server" CommandName="MoveNext" Text="Abrir Caja" ValidationGroup="valGroup"/>                
            <asp:Button CssClass="btnStyle" Visible="false" CausesValidation="false" ID="btnAceptar" 
                runat="server" Text="Aceptar" onclick="btnAceptar_Click" />
        </div>   
        <div id='dialogRecibos'>
        <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>                
                <%--<asp:ObjectDataSource ID="ObjectDataSource8" runat="server" 
                    SelectMethod="TraerRecibosCaja" 
                    TypeName="RN.Componentes.CPagoCliente" 
                    OldValuesParameterFormatString="original_{0}">                    
                  
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CajeroId" Name="codigo" PropertyName="Value" 
                            Type="String" />
                    </SelectParameters>
                  
                </asp:ObjectDataSource>        --%>    
                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" 
                    >
                </asp:ObjectDataSource>            
                <asp:GridView ID="grdPagosRegistrados" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="id" DataSourceID="" ForeColor="Black" 
                    GridLines="Vertical" 
                     Width="100%" onpageindexchanging="grdPagosRegistrados_PageIndexChanging" 
                    onrowcommand="grdPagosRegistrados_RowCommand" onrowdatabound="grdPagosRegistrados_RowDataBound" 
                     >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <EmptyDataTemplate>
                        No se encontraron paquetes.
                    </EmptyDataTemplate>
                    <Columns> 
                       <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                        
                       <asp:BoundField DataField="nroRecibo" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="N&uacute;mero de recibo" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="80">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       <asp:BoundField DataField="concepto" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Concepto" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="150">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       <asp:BoundField DataField="monto" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Monto" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="300">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechaPagoSinHora" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Fecha de pago" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="100">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="100" Visible="true" HeaderStyle-HorizontalAlign="Center" HeaderText="Imprimir">            
			                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                    <ItemTemplate>
                                    <asp:ImageButton CommandName="Imprimir" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/print.gif") %>' />
			                    </ItemTemplate>
		            </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
                    ID="btnCerrarRecibos" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="btnCerrarRecibos_Click"  />
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>     
    </asp:Panel> 
    
    <script type="text/javascript">
        var obs = document.getElementById('trObservacion');
        if (obs != null) {
            obs.value = "-";
            obs.style.visibility = 'hidden';
            obs.style.position = "absolute";
        }
        </script>
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
                $("#dialog-delete").dialog({
                    autoOpen: false
                });
            });
            
            function deleteItem(uniqueID) {
                $("#dialog-delete").dialog({
                    modal: true,
                    buttons: {
                        "Guardar": function () { __doPostBack(uniqueID, ''); $(this).dialog("close");  },
                        "Cancelar": function () { $(this).dialog("close"); global.OcultarEsperaAjax(); }
                    }
                });
            }
	</script>
    <div id="dialog-delete" title="Informacion">
	<p>
        La caja no cuadra. ¿Está seguro que desea cerrarla?
	</p>
    </div>
    <div id="Div1" title="Informacion">
	    <p>
            <strong><asp:Literal runat="server" ID="Literal1"></asp:Literal></strong>
            <br />
            <asp:Literal runat="server" ID="Literal2"></asp:Literal>
	    </p>
    </div> 
    <div id="dialog-message" title="Informacion">
	    <p>
            <strong><asp:Literal runat="server" ID="popupTitle"></asp:Literal></strong>
            <br />
            <asp:Literal runat="server" ID="popupMessage"></asp:Literal>
	    </p>
    </div>     
    <asp:Literal runat="server" ID="lblScriptShow"></asp:Literal>
</asp:Content>