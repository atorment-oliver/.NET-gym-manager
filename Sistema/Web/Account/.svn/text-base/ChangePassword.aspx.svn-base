<%@ Page Title="Cambiar contraseña" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="Account_ChangePassword" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Cambio de contraseña
    </h2>
    <hr />      
    <asp:ChangePassword ID="ChangeUserPassword" runat="server" 
        CancelDestinationPageUrl="~/" EnableViewState="false" RenderOuterTable="false"  
        onchangepassworderror="ChangeUserPassword_ChangePasswordError" 
        onchangedpassword="ChangeUserPassword_ChangedPassword">
        <ChangePasswordTemplate>
            Ingrese su contraseña anterior seguida de la nueva contraseña que desea utilizar en el sistema.
            <br /><br /><br />
            <center>
            <div id="fields" class="pswRecovery">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <colgroup>
                            <col width="150px" />
                            <col width="*" />
                        </colgroup>
                        <tr>
                            <td><asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Contraseña anterior:</asp:Label></td>
                            <td><asp:TextBox ID="CurrentPassword" runat="server" Width="100" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" Display="Dynamic" runat="server" ControlToValidate="CurrentPassword" 
                                    CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña anterior es obligatoria." Text="La contraseña anterior es obligatoria." 
                                    ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva contraseña:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="NewPassword" runat="server" Width="100" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" Display="Dynamic" runat="server" ControlToValidate="NewPassword" 
                             CssClass="failureNotification" ErrorMessage="La nueva contraseña es obligatoria." ToolTip="La nueva contraseña es obligatoria." Text="La nueva contraseña es obligatoria." 
                             ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirmar contraseña:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" Width="100" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="Debe confirmar la nueva contraseña."
                                     ToolTip="Debe confirmar la nueva contraseña." ValidationGroup="ChangeUserPasswordValidationGroup"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="Las contraseñas no coinciden." Text="Las contraseñas no coinciden."
                                     ValidationGroup="ChangeUserPasswordValidationGroup"></asp:CompareValidator>
                            </td>
                        </tr>
                    </table>                
            </div>   
            <br />
            <div class="btnAlign">
                    <asp:Button CssClass="btnStyle" ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Cambiar contraseña" 
                         ValidationGroup="ChangeUserPasswordValidationGroup"/>
                    &nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar">Cancelar</asp:LinkButton>
           </div>
            </center>            
        </ChangePasswordTemplate>
        <SuccessTemplate>
            La contraseeña fue cambiada exitosamente.
            <br />
            Para volver a la página de inicio del sistema presione el siguiente vínculo: <a href="../Default.aspx">Inicio</a>
        </SuccessTemplate>
    </asp:ChangePassword>
    <script type="text/javascript" language="javascript">
        $('#fields').addClass("ui-corner-all");

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