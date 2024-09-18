<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PasswordRecovery.aspx.cs" Inherits="Account_PasswordRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>
        Recuperaci&oacute;n de Contraseña
    </h2>
    <hr />
        <asp:Literal runat="server" ID="lblInfo">Ingrese su nombre de usuario del sistema y le enviaremos una nueva contraseña a su correo electrónico asociado al sistema.</asp:Literal>
        <asp:Panel runat="server" ID="panel" DefaultButton="PasswordRecovery">
         <br /><br /><br />
            <center>
            <div id="fields" class="pswRecovery">   
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <colgroup>
                    <col width="150px" />
                    <col width="250px" />
                </colgroup>
                <tr>
                    <td><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label></td>
                    <td>
                        <asp:TextBox ID="UserName" runat="server" Width="100" CssClass="textEntry"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator Display="Dynamic" ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                            CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." Text="El nombre de usuario es obligatorio." 
                            ValidationGroup="PasswordRecoveryValidationGroup"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>   
            <br />
            <div class="btnAlign">
            <asp:Button CssClass="btnStyle" ID="PasswordRecovery" runat="server" Text="Recuperar contraseña" 
                    ValidationGroup="PasswordRecoveryValidationGroup" 
                onclick="PasswordRecovery_Click"/>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="Cancel" runat="server" CausesValidation="False" 
                Text="Cancelar" onclick="Cancel_Click">Cancelar</asp:LinkButton>
        </div>
        </center>
        <script type="text/javascript" language="javascript">
            $('#fields').addClass("ui-corner-all");

            $(function () {
                $("#dialog-message").dialog({
                    autoOpen: false,
                    modal: true,
                    show: "blind",
                    hide: "explode",
                    buttons: {
                        "Ok": function () { $(this).dialog("close"); document.getElementById('MainContent_UserName').focus(); }
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
    </asp:Panel>
</asp:Content>

