<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Cliente.master" CodeFile="ClienteConsulta.aspx.cs" Inherits="Clientes_ClienteConsulta" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/RegistrarCliente.ascx" tagname="Cliente" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />     
    <style type="text/css">
        .textEntry
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">    
    <script type="text/javascript">
        $(document).ready(function () {
            

            //Consulta
            $('#dialogConsulta').dialog({
                autoOpen: false,
                draggable: true,
                modal: true,
                title: "Datos de la consulta",
                closeOnEscape: false,
                width: 850,
                height: 700,
                draggable: true,
                open: function (type, data) {
                    $(".ui-dialog-titlebar-close").hide();
                    $(this).parent().appendTo("form");
                }
            });
            
           
        });

        function showDialog(id) {
            $('#' + id).dialog("open");
        }

        function closeDialog(id) {
            $('#' + id).dialog("close");
        }
        function LimpiarBusqueda() {
            $("#<%=txtSearchCI.ClientID%>").val('');
            $("#<%= hdnAutoCompleteClienteId.ClientID %>").val('');
        }
        function CargarBusqueda(id, nombre, ci) {
            $("#<%=txtSearchCI.ClientID%>").val(nombre + ' - ' + ci);
            $("#<%= hdnAutoCompleteClienteId.ClientID %>").val(id);
        }
        $(document).ready(function () {
            $("#<%=txtSearchCI.ClientID%>").autocomplete('../Handlers/ClienteCi.ashx').result(function (event, data, formatted) {
                if (data) {
                    //alert('Value: ' + data[1]);
                    $("#<%= hdnAutoCompleteClienteId.ClientID %>").val(data[1]);
                    //__doPostBack('<%=btnBuscar.ClientID%>', 'btnBuscar_Click');
                }
                else {
                    $("#<%= hdnAutoCompleteClienteId.ClientID %>").val('-1');
                }
            });
        });
        function Mensaje() {
            $.msgBox('"+ El M +"');
        }
        $.fn.msgBox.defaults =
	    {
	        height: 190,
	        width: 300,
	        title: "Informaciones",
	        modal: true,
	        resizable: false,
	        closeOnEscape: true
	    };
       
	    
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnAutoCompleteClienteId" runat="server" Value="" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <colgroup>
            <col width="70%" />
            <col width="30%" />
        </colgroup>
        <tr>
            <td>
                <fieldset class="register" style="width:620px">
                    <legend>Buscador de clientes</legend>
                    <table border="0" cellpadding="2" cellspacing="0">
                        <colgroup>
                            <col width="200px" />
                            <col width="*" />
                            <col width="*" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Literal runat="server" ID="lblBuscadorCi" Text="Nombre o C.I. del cliente:"></asp:Literal>
                            </td>
                            <td>                    
                                <asp:TextBox ID="txtSearchCI" runat="server" Width="350px"></asp:TextBox>                    
                            </td>
                            <td>
                                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="btnBuscar" runat="server" Text="Recuperar" 
                                    onclick="btnBuscar_Click" Visible="true" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
           
        </tr>
    </table>
    <hr />
    <asp:UpdatePanel ID="upCliente" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
    <ContentTemplate>
    <table cellpadding="2" cellspacing="0" border="0">
        <tr>
            <td>
                        <fieldset class="register" style="width:350px">
                        <legend>Informaci&oacute;n del cliente</legend>
                        <table border="0" cellpadding="2" cellspacing="0">
                            <colgroup>
                                <col width="150px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblNumCliente" Text="C&oacute;digo de cliente:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblNumeroCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblNombre" Text="Nombre completo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblNombreCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblFecha" Text="Fecha de ingreso:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaIngreso"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblEdad" Text="Edad:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEdadCliente"></asp:Label>
                                </td>
                            </tr>                                                        
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefono" Text="Tel&eacute;fono:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefonoCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDireccion" Text="Direcci&oacute;n:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblDireccionCliente"></asp:Label>
                                </td>
                            </tr>  
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblCi" Text="C.I:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCiCliente"></asp:Label>
                                </td>
                            </tr>                          
                        </table>
                    </fieldset>
                        
        </td>
        <td style="vertical-align:top">
           
                    <fieldset class="register" style="width:430px">
                        <legend>Informaci&oacute;n del Paquete</legend>
                        <table border="0" cellpadding="2" cellspacing="0">
                            <colgroup>
                                <col width="170px" />
                                <col width="*" />
                            </colgroup>
                           
                             <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPrecio" Text="Precio:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPrecioPaquete"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color:#f1f1f1;color:#54ac24;font-size:12px;">
                                <td>
                                    <asp:Label runat="server" ID="lblEstadoPaqueteLabel" Text="Estado pago:"></asp:Label>
                                </td>
                                <td style="font-size:14px;font-weight:bolder;">
                                    <asp:Label runat="server" ID="lblEstadoPagoPaquete"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label7" Text="Estado paquete:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEstadoPaquete"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaInicioLabel" Text="Fecha inicio:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaInicio"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDiasLic" Text="D&iacute;as de licencia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblDiasLicencia"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblTiempo" Text="Fecha expira el paquete:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTiempoPaquete"></asp:Label>
                                </td>
                            </tr>
                            
                           
                        </table>  
                    </fieldset>
                                  
        </td>
        <td style="vertical-align:top" rowspan="2">
            <br />
                <table>
                    <tr>
                        <td>
                            <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
                                runat="server" ID="btnConsultaMedica" style="width:120px; height:80px; top: 0px; left: 0px;"
                                Text="Datos consulta" onclick="btnConsultaMedica_Click" />
                        </td>
                    </tr>                
                </table>
              
        </td>
    </tr>
    <tr>
        <td style="vertical-align:top">
       
                    <asp:Panel runat="server" ID="pnlEmpresa">
                    <fieldset class="register" style="width:350px">
                        <legend>Empresa</legend>
                        <table border="0" cellpadding="2" cellspacing="0">
                            <colgroup>
                                <col width="150px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblEmpresa" Text="Nombre:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEmpresaCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefonoEmp" Text="Tel&eacute;fono:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefonoEmpresa"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPersona" Text="Persona de contacto:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPersonaEmpresa"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label8" Text="% cobertura empresa:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCoberturaEmpresa"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label9" Text="Cobertura empresa Bs:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCoberturaEmpresaMonto"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    </asp:Panel>
                       
        </td>
        
            </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
    <div id='dialogConsulta'>
    <table border="0" cellpadding="2" cellspacing="0">
            <colgroup>
                <col width="100px" style="vertical-align:top;border:0;"/>
                <col width="150px" style="vertical-align:top;border:0;"/>
                <col width="100px" style="vertical-align:top;border:0;"/>
                <col width="150px" style="vertical-align:top;border:0;"/>
            </colgroup>            
            <tr>
            <td class="mandatory"><asp:Literal ID="Literal1" runat="server">Fecha de evaluaci&oacute;n:</asp:Literal></td>
                <td>
                    
                    <asp:TextBox ID="txtFechaIngreso"  Width="90" runat="server" 
                        CssClass="textEntry" AutoPostBack="True" 
                        ontextchanged="txtFechaIngreso_TextChanged" TabIndex="1"></asp:TextBox>
                    <asp:Image ID="imgFechaIngreso" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" TargetControlID="txtFechaIngreso" PopupButtonID="imgFechaIngreso" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic" ControlToValidate="txtFechaIngreso" 
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="La fecha de ingreso es obligatoria." Text="La fecha de ingreso es obligatoria." ToolTip="La fecha de ingreso es obligatoria." 
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator runat="server" ID="revFechaIngreso" Display="Dynamic" CssClass="failureNotification" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtFechaIngreso" 
                    ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>
                    
                </td>
                <td class="mandatory"><asp:Literal ID="Literal20" runat="server">Peso:</asp:Literal></td>
                <td>                                        
                    <asp:TextBox runat="server" ID="txtPeso" Width="80px"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator12" 
                    ValidationGroup="valGroup2" ControlToValidate="txtPeso" 
                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                    ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Font-Size="11px" runat="server" ControlToValidate="txtPeso" 
                            CssClass="failureNotification" ErrorMessage="El peso es obligatorio." Text="El peso es obligatorio." ToolTip="El peso es obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="mandatory"><asp:Literal ID="Literal2" runat="server">Talla:</asp:Literal></td>
                <td>                                        
                    <asp:TextBox runat="server" ID="txtTalla" Width="80px"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator1" 
                    ValidationGroup="valGroup2" ControlToValidate="txtTalla" 
                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                    ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="11px" runat="server" ControlToValidate="txtTalla" 
                            CssClass="failureNotification" ErrorMessage="La talla es obligatoria." Text="La talla es obligatoria." ToolTip="La talla es obligatoria." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td class="mandatory"><asp:Literal ID="Literal3" runat="server">IMC:</asp:Literal></td>
                <td>                                        
                    <asp:TextBox runat="server" ID="txtIMC" Width="80px"></asp:TextBox> <br />
                    <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator2" 
                    ValidationGroup="valGroup2" ControlToValidate="txtIMC" 
                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                    ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Font-Size="11px" runat="server" ControlToValidate="txtIMC" 
                            CssClass="failureNotification" ErrorMessage="El índice de masa corporal(IMC) es obligatorio." Text="El índice de masa corporal(IMC) es obligatorio." ToolTip="El índice de masa corporal(IMC) es obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                <fieldset class="register" style="width:430px">
                        <legend>Signos Vitales</legend>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <colgroup>
                            <col width="100px" />
                            <col width="150px" />
                            <col width="100px" />
                            <col width="150px" />
                        </colgroup>   
                        <tr>
                            <td class="mandatory"><asp:Literal ID="Literal4" runat="server">PA:</asp:Literal></td>
                            <td>                                        
                                <asp:TextBox runat="server" ID="txtPA" Width="80px"></asp:TextBox> <br />
                                <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator3" 
                                ValidationGroup="valGroup2" ControlToValidate="txtPA" 
                                ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                                ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Font-Size="11px" runat="server" ControlToValidate="txtPA" 
                                        CssClass="failureNotification" ErrorMessage="El PA es obligatorio." Text="El PA es obligatorio." ToolTip="El PA es obligatorio." 
                                        ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>

                            <td class="mandatory"><asp:Literal ID="Literal5" runat="server">FR:</asp:Literal></td>
                            <td>                                        
                                <asp:TextBox runat="server" ID="txtFR" Width="80px"></asp:TextBox> <br />
                                <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator4" 
                                ValidationGroup="valGroup2" ControlToValidate="txtFR" 
                                ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                                ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Font-Size="11px" runat="server" ControlToValidate="txtFR" 
                                        CssClass="failureNotification" ErrorMessage="El FR es obligatorio." Text="El FR es obligatorio." ToolTip="El FR es obligatorio." 
                                        ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="mandatory"><asp:Literal ID="Literal6" runat="server">FR:</asp:Literal></td>
                            <td>                                        
                                <asp:TextBox runat="server" ID="TextBox1" Width="80px"></asp:TextBox> <br />
                                <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator5" 
                                ValidationGroup="valGroup2" ControlToValidate="txtFR" 
                                ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                                ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Font-Size="11px" runat="server" ControlToValidate="txtFR" 
                                        CssClass="failureNotification" ErrorMessage="El FR es obligatorio." Text="El FR es obligatorio." ToolTip="El FR es obligatorio." 
                                        ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>

                            <td class="mandatory"><asp:Literal ID="Literal7" runat="server">FC:</asp:Literal></td>
                            <td>                                        
                                <asp:TextBox runat="server" ID="txtFC" Width="80px"></asp:TextBox> <br />
                                <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator6" 
                                ValidationGroup="valGroup2" ControlToValidate="txtFC" 
                                ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                                ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Font-Size="11px" runat="server" ControlToValidate="txtFC" 
                                        CssClass="failureNotification" ErrorMessage="El FC es obligatorio." Text="El FC es obligatorio." ToolTip="El FC es obligatorio." 
                                        ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Literal ID="Literal8" runat="server">Pulso:</asp:Literal></td>
                            <td>                                        
                                <asp:TextBox runat="server" ID="txtPulso" Width="80px"></asp:TextBox> <br />
                                <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator7" 
                                ValidationGroup="valGroup2" ControlToValidate="txtPulso" 
                                ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                                ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Font-Size="11px" runat="server" ControlToValidate="txtPulso" 
                                        CssClass="failureNotification" ErrorMessage="El pulso es obligatorio." Text="El pulso es obligatorio." ToolTip="El pulso es obligatorio." 
                                        ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                <fieldset class="register" style="width:430px">
                        <legend>Examen F&iacute;sico</legend>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <colgroup>
                                <col  style="vertical-align:top;" />
                                <col  style="vertical-align:top;"/>
                                <col  style="vertical-align:top;"/>
                                <col  style="vertical-align:top;"/>
                            </colgroup>
                            <tr>
                                <td class="mandatory"><asp:Literal ID="Literal9" runat="server">Cabeza:</asp:Literal></td>
                                <td>
                                        
                                    <asp:TextBox ID="txtCabeza" Width="250px" runat="server" CssClass="textEntry" 
                                        Height="63px" TextMode="MultiLine" MaxLength="250"
                                        ></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCabeza" 
                                            CssClass="failureNotification" Font-Size="11px" ErrorMessage="La cabeza es obligatoria." Text="La cabeza es obligatoria." 
                                            ToolTip="La cabeza es obligatoria es obligatorio." 
                                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtCabeza" Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator8" ValidationGroup="ruvgLicencia"  ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                                </td>
                                <td class="mandatory"><asp:Literal ID="Literal10" runat="server">Cardiopulmonar:</asp:Literal></td>
                                <td>
                                        
                                    <asp:TextBox ID="txtCardioPulmonar" Width="250px" runat="server" 
                                        CssClass="textEntry" Height="63px" TextMode="MultiLine" MaxLength="250"
                                        ></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCardioPulmonar" 
                                            CssClass="failureNotification" Font-Size="11px" ErrorMessage="El cardio es obligatorio." Text="El cardio es obligatorio." 
                                            ToolTip="El cardio es obligatorio." 
                                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtCardioPulmonar" Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator9" ValidationGroup="ruvgLicencia"  ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="mandatory"><asp:Literal ID="Literal11" runat="server">Abdomen:</asp:Literal></td>
                                <td>
                                        
                                    <asp:TextBox ID="txtAbdomen" Width="250px" runat="server" CssClass="textEntry" 
                                        Height="63px" TextMode="MultiLine" MaxLength="250"
                                        ></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtAbdomen" 
                                            CssClass="failureNotification" Font-Size="11px" ErrorMessage="El abdomen es obligatoria." Text="El abdomen es obligatoria." 
                                            ToolTip="El abdomen es obligatoria es obligatorio." 
                                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtAbdomen" Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator10" ValidationGroup="ruvgLicencia"  ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                                </td>
                                <td class="mandatory"><asp:Literal ID="Literal12" runat="server">G&eacute;nito urinario:</asp:Literal></td>
                                <td>
                                        
                                    <asp:TextBox ID="txtGenitoUrinario" Width="250px" runat="server" 
                                        CssClass="textEntry" Height="63px" TextMode="MultiLine" MaxLength="250"
                                        ></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtGenitoUrinario" 
                                            CssClass="failureNotification" Font-Size="11px" ErrorMessage="El g&eacute;nito urinario es obligatorio." Text="El g&eacute;nito urinario es obligatorio." 
                                            ToolTip="El g&eacute;nito urinario es obligatorio." 
                                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtGenitoUrinario" Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator11" ValidationGroup="ruvgLicencia"  ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="mandatory"><asp:Literal ID="Literal13" runat="server">Extremidades:</asp:Literal></td>
                                <td>
                                        
                                    <asp:TextBox ID="txtExtremidades" Width="250px" runat="server" 
                                        CssClass="textEntry" Height="63px" TextMode="MultiLine" MaxLength="250"
                                        ></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtExtremidades" 
                                            CssClass="failureNotification" Font-Size="11px" ErrorMessage="Las extremidades son obligatorias." Text="Las extremidades son obligatorias." 
                                            ToolTip="Las extremidades son obligatorias." 
                                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ControlToValidate="txtExtremidades" Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator13" ValidationGroup="ruvgLicencia"  ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                                </td>
                                </tr>
                        </table>
                </fieldset>
                </td>
            </tr>
            <tr>
                <td class="mandatory"><asp:Literal ID="Literal14" runat="server">Antecedentes patol&oacute;gicos:</asp:Literal></td>
                <td>
                                        
                    <asp:TextBox ID="txtAntecedentesPatologicos" Width="250px" runat="server" 
                        CssClass="textEntry" Height="63px" TextMode="MultiLine" MaxLength="250"
                        ></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAntecedentesPatologicos" 
                            CssClass="failureNotification" Font-Size="11px" ErrorMessage="Los antecedentes son obligatorios." Text="Los antecedentes son obligatorios." 
                            ToolTip="Los antecedentes son obligatorios." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtAntecedentesPatologicos" Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator14" ValidationGroup="ruvgLicencia"  ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="mandatory"><asp:Literal ID="Literal15" runat="server">Enfermedades actuales:</asp:Literal></td>
                <td>
                                        
                    <asp:TextBox ID="txtEnfermedadesActuales" Width="250px" runat="server" 
                        CssClass="textEntry" Height="63px" TextMode="MultiLine" MaxLength="250"
                        ></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtEnfermedadesActuales" 
                            CssClass="failureNotification" Font-Size="11px" ErrorMessage="Las enfermedades son obligatorias." Text="Las enfermedades son obligatorias." 
                            ToolTip="Las enfermedades son obligatorias." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ControlToValidate="txtEnfermedadesActuales" Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator15" ValidationGroup="ruvgLicencia"  ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <fieldset class="register" style="width:430px">
                        <legend>H&aacute;bitos</legend>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="mandatory"><asp:Literal ID="Literal16" runat="server">Tabaco:</asp:Literal></td>
                                <td>
                                    <asp:RadioButtonList ID="rblTabaco" runat="server" TextAlign="Right" 
                                        RepeatDirection="Horizontal" RepeatColumns="2" TabIndex="16">
                                        <asp:ListItem Selected="True" Text="Si" Value="True"></asp:ListItem>
                                        <asp:ListItem  Text="No" Value="False"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td class="mandatory"><asp:Literal ID="Literal17" runat="server">Alcohol:</asp:Literal></td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" TextAlign="Right" 
                                        RepeatDirection="Horizontal" RepeatColumns="4" TabIndex="16">
                                        <asp:ListItem Selected="True" Text="Si" Value="s"></asp:ListItem>
                                        <asp:ListItem  Text="A veces" Value="a"></asp:ListItem>
                                        <asp:ListItem  Text="Socialmente" Value="s"></asp:ListItem>
                                        <asp:ListItem  Text="Nunca" Value="n"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="Button2" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="Button2_Click"/>
                </td>
            </tr>
            </table>
            
        <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>  
                
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
     

       

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



