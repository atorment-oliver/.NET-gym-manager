<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RegistrarCliente.ascx.cs" Inherits="Controles_RegistrarCliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<div class="accountInfo">
    <asp:HiddenField runat="server" ID="ClienteIdH" Value="" />  
    <script language="javascript" type="text/javascript">
        function SiguienteObjeto() {
            if (event.keyCode == 13) event.keyCode = 9;
        }
    </script>  
    <fieldset class="register">
    <br />
        <table border="0" cellpadding="2" cellspacing="0">
            <colgroup>
                <col width="160px" />
                <col width="*" />
            </colgroup>            
            <tr>
                
                <td class="mandatory"><asp:Literal ID="lblNumeroCliente" runat="server">C&oacute;digo de cliente:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtNumeroCliente" Width="80" runat="server" CssClass="textEntry"></asp:TextBox>
                <%--    <asp:RequiredFieldValidator ID="rfvNumeroCliente" runat="server" Display="Dynamic" ControlToValidate="txtNumeroCliente" 
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El n&uacute;mero de cliente es obligatorio." Text="El n&uacute;mero de cliente es obligatorio." ToolTip="El n&uacute;mero de cliente es obligatorio." 
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ID="revNumeroCliente" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtNumeroCliente" 
                    ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" ></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="mandatory"><asp:Literal ID="lblFechaIngreso" runat="server">Fecha de ingreso:</asp:Literal></td>
                <td>
                    
                    <asp:TextBox ID="txtFechaIngreso"  Width="90" runat="server" 
                        CssClass="textEntry" AutoPostBack="True" 
                        ontextchanged="txtFechaIngreso_TextChanged" TabIndex="1"></asp:TextBox>
                    <asp:Image ID="imgFechaIngreso" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" TargetControlID="txtFechaIngreso" PopupButtonID="imgFechaIngreso" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic" ControlToValidate="txtFechaIngreso" 
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="La fecha de ingreso es obligatoria." Text="La fecha de ingreso es obligatoria." ToolTip="La fecha de ingreso es obligatoria." 
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator runat="server" ID="revFechaIngreso" Display="Dynamic" CssClass="failureNotification" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtFechaIngreso" 
                    ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>
                    
                </td>
            </tr>            
            <tr>
                <td class="mandatory"><asp:Literal ID="lblNombre" runat="server">Nombre:</asp:Literal></td>
                <td>
                                        
                    <asp:TextBox ID="txtNombre" Width="180" runat="server" CssClass="textEntry" 
                        TabIndex="1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NombreRequired" runat="server" ControlToValidate="txtNombre" Display="Dynamic" 
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El nombre es obligatorio." Text="El nombre es obligatorio." ToolTip="El nombre es obligatorio." 
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ID="revNombre" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtNombre" 
                    ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="mandatory"><asp:Literal ID="lblApellidos" runat="server">Apellidos:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtApellidos" Width="180" runat="server" CssClass="textEntry" 
                        TabIndex="3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ApellidosRequired" runat="server" ControlToValidate="txtApellidos" Display="Dynamic"
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El apellido es obligatorio." Text="El apellido es obligatorio." ToolTip="El apellido es obligatorio." 
                            ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ID="revApellidos" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtApellidos" 
                    ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblFechaNacimiento" runat="server">Fecha de nacimiento:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtFechaNacimento"  Width="90" runat="server" 
                        CssClass="textEntry" AutoPostBack="True" 
                        ontextchanged="txtFechaNacimento_TextChanged" TabIndex="4"></asp:TextBox>
                    <asp:Image ID="ImgFechaNacimento" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                    <asp:CalendarExtender ID="txtFechaNacimento_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtFechaNacimento" PopupButtonID="ImgFechaNacimento" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                    <asp:RegularExpressionValidator runat="server" ID="revFechaNacimento" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtFechaNacimento" 
                    ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblTelefono" runat="server">Tel&eacute;fono:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtTelefono" Width="100" runat="server" CssClass="textEntry" 
                        TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="revTelefono" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtTelefono" 
                    ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblDireccion" runat="server">Direcci&oacute;n:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtDireccion" Width="350" Height="40px" TextMode="MultiLine" 
                        runat="server" CssClass="textEntry" TabIndex="6"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="revDireccion" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtDireccion" 
                    ValidationExpression="<%$ Resources: Regex, SoloDireccion %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="register"><asp:Literal ID="lblCelular" runat="server">Celular:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtCelular" Width="100" runat="server" CssClass="textEntry" 
                        TabIndex="7"></asp:TextBox>                   
                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtCelular" 
                    ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="register"><asp:Literal ID="Literal1" runat="server">Celular 2:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtCelular2" Width="100" runat="server" CssClass="textEntry" 
                        TabIndex="8"></asp:TextBox>                   
                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtCelular2" 
                    ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblCi" runat="server">CI:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtCi" Width="100" runat="server" CssClass="textEntry" 
                        TabIndex="9"></asp:TextBox>
                    <asp:DropDownList runat="server" ID="ddlCi" TabIndex="10" >
                        <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                        <asp:ListItem Text="LP" Value="LP"></asp:ListItem>
                        <asp:ListItem Text="OR" Value="OR"></asp:ListItem>
                        <asp:ListItem Text="PO" Value="PO"></asp:ListItem>
                        <asp:ListItem Text="CBB" Value="CBB"></asp:ListItem>
                        <asp:ListItem Text="SU" Value="SU"></asp:ListItem>
                        <asp:ListItem Text="TA" Value="TA"></asp:ListItem>
                        <asp:ListItem Text="BE" Value="BE"></asp:ListItem>
                        <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                        <asp:ListItem Text="CE" Value="CE"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtCi" 
                    ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblCorreo" runat="server">Correo:</asp:Literal></td>
                <td style="margin-left: 40px">
                    <asp:TextBox ID="txtCorreo" Width="200" runat="server" CssClass="textEntry" 
                        TabIndex="11"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="revCorreo" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtCorreo" 
                    ValidationExpression="<%$ Resources: Regex, Correo %>" ErrorMessage="<%$ Resources: Mensajes, Correo %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblOcupacion" runat="server">Ocupaci&oacute;n:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtOcupacion" Width="250" runat="server" CssClass="textEntry" 
                        TabIndex="12"></asp:TextBox>
                    <asp:RegularExpressionValidator runat="server" ID="revOcupacion" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtOcupacion" 
                    ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="register"><asp:Literal ID="lblLugar" runat="server">Lugar de trabajo:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtLugarTrabajo" Width="250" runat="server" 
                        CssClass="textEntry" TabIndex="13"></asp:TextBox>
                    
                    <asp:RegularExpressionValidator runat="server" ID="revLugarTrabajo" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtLugarTrabajo" 
                    ValidationExpression="<%$ Resources: Regex, SoloDireccion %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="register"><asp:Literal ID="lblTelefonoTrabajo" runat="server">Tel&eacute;fono del trabajo:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtTelefonoTrabajo" Width="100" runat="server" 
                        CssClass="textEntry" TabIndex="14"></asp:TextBox>
                   
                    <asp:RegularExpressionValidator runat="server" ID="revTelefonoTrabajo" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtTelefonoTrabajo" 
                    ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="register"><asp:Literal ID="lblCorreoTrabajo" runat="server">Correo del trabajo:</asp:Literal></td>
                <td>
                    <asp:TextBox ID="txtCorreoTrabajo" Width="200" runat="server" 
                        CssClass="textEntry" TabIndex="15"></asp:TextBox>
                    
                    <asp:RegularExpressionValidator runat="server" ID="revCorreoTrabajo" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtCorreoTrabajo" 
                    ValidationExpression="<%$ Resources: Regex, Correo %>"  ErrorMessage="<%$ Resources: Mensajes, Correo %>" ></asp:RegularExpressionValidator>
                </td>
            </tr>            
            <tr>
                <td><asp:Literal ID="lblGenero" runat="server">G&eacute;nero:</asp:Literal></td>
                <td>
                    <asp:RadioButtonList ID="rblGenero" runat="server" TextAlign="Right" 
                        RepeatDirection="Horizontal" RepeatColumns="2" TabIndex="16">
                        <asp:ListItem Selected="True" Text="Masculino" Value="M"></asp:ListItem>
                        <asp:ListItem  Text="Femenino" Value="F"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblEstadoCivil" runat="server">Estado civil:</asp:Literal></td>
                <td>
                    <asp:RadioButtonList ID="rblEstado" runat="server" 
                        CssClass="textEntry" TextAlign="Right" RepeatDirection="Horizontal" 
                        RepeatLayout="Table" TabIndex="17">
                        <asp:ListItem Selected="True" Text="Soltero(a)" Value="s"></asp:ListItem>
                        <asp:ListItem  Text="Casado(a)" Value="c"></asp:ListItem>
                        <asp:ListItem  Text="Viudo(a)" Value="v"></asp:ListItem>
                        <asp:ListItem  Text="Divorciado(a)" Value="d"></asp:ListItem>
                    </asp:RadioButtonList>
                    
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="lblTieneHijos" runat="server">Tiene hijos:</asp:Literal></td>
                <td>
                    <%--<asp:RadioButtonList ID="rblHijos" runat="server" 
                        CssClass="textEntry" RepeatDirection="Horizontal" RepeatLayout="Table">
                        <asp:ListItem Selected="True" Text="Si" Value="true"></asp:ListItem>
                        <asp:ListItem  Text="No" Value="false"></asp:ListItem>
                    </asp:RadioButtonList>--%>
                    <asp:CheckBox runat="server" ID="rblHijos" 
                        oncheckedchanged="rblHijos_CheckedChanged" AutoPostBack="True" 
                        TabIndex="18" />
                        
                </td>
            </tr>
            <tr runat="server" id="trHijos" visible="false">
                <td>
                
                    
                            <asp:Literal ID="lblNumeroHijos" runat="server" >N&uacute;mero de hijos:</asp:Literal>
                            </td>
                            <td>
                            <asp:TextBox ID="txtNumeroHijos" Width="50" runat="server" CssClass="textEntry" 
                                    TabIndex="19"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNumeroHijos" runat="server" Display="Dynamic" ControlToValidate="txtNumeroHijos" 
                                    CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El n&uacute;mero de hijos es obligatorio." Text="El n&uacute;mero de hijos es obligatorio." ToolTip="El n&uacute;mero de hijos es obligatorio." 
                                    ValidationGroup="RegisterUserValidationGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="revNumeroHijos" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtNumeroHijos" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" ></asp:RegularExpressionValidator>
                            
                       
                </td>
            </tr>            
            <tr runat="server" id="trEmpresa">
                <td><asp:Literal ID="lblEmpresa" runat="server">Empresa:</asp:Literal></td>
                <td>
                    <asp:DropDownList ID="ddlEmpresa" Width="150" runat="server" 
                        CssClass="textEntry" AppendDataBoundItems="true" TabIndex="20" >
                        <asp:ListItem Text="Sin empresa" Value="0" >
                            
                        </asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
            </tr>            
            <tr>
                <td><asp:Literal ID="lblNotificaciones" runat="server">Recibir notificaciones:</asp:Literal></td>
                <td>
                    <asp:CheckBox ID="cbNotificaciones" Width="80" runat="server" 
                        CssClass="textEntry" TabIndex="21"></asp:CheckBox>                    
                </td>
            </tr>
           <tr>
                <td><asp:Literal ID="lblEstado" runat="server">Activo:</asp:Literal></td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlEstado" Enabled="false">
                        <asp:ListItem Selected="True" Text="Activo" Value="a"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="i"></asp:ListItem>
                        <asp:ListItem Text="Vencida" Value="v"></asp:ListItem>
                        <asp:ListItem Text="Licencia" Value="l"></asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
            </tr>
        </table>
    </fieldset>
    <p class="submitButton">
        <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
            ID="RegistrarButton" runat="server" Text="Guardar" 
            ValidationGroup="RegisterUserValidationGroup" 
            onclick="RegistrarButton_Click" TabIndex="22"/>
        &nbsp;&nbsp;&nbsp;
        <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
            ID="btnCerrar" runat="server" Text="Cerrar" CausesValidation="false" 
            onclick="btnCerrar_Click" TabIndex="23" 
            />
        <asp:LinkButton Visible="false" ID="btnAtras" runat="server" 
            onclick="btnAtras_Click" TabIndex="24">Atrás</asp:LinkButton>
    </p>
</div>