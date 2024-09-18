<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Account_Login" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:Literal runat="server" ID="Literal1"></asp:Literal> 
    <h2>
        <asp:Literal runat="server" ID="lblTitulo" meta:resourcekey="lblTitulo"></asp:Literal>
    </h2>
    <hr />
        <asp:Literal runat="server" ID="lblTexto1" meta:resourcekey="lblTexto1"></asp:Literal>      
    <asp:Login ID="LoginUser" runat="server" EnableViewState="false" 
        RenderOuterTable="false" onloginerror="LoginUser_LoginError">        
        <LayoutTemplate>
            <br /><br /><br />
            <center>
            <div id="fields" class="pswRecovery">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                        <colgroup>
                            <col width="150px" />
                            <col width="*" />
                        </colgroup>
                        <tr>
                            <td><asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName"><asp:Literal runat="server" ID="lblUsuario" meta:resourcekey="lblUsuario"></asp:Literal></asp:Label></td>
                            <td>
                                <asp:TextBox ID="UserName" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                    CssClass="failureNotification" meta:resourcekey="UserNameRequired" ValidationGroup="valGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password"><asp:Literal runat="server" ID="lblPassword" meta:resourcekey="lblPassword"></asp:Literal></asp:Label></td>
                            <td>
                                <asp:TextBox ID="Password" Width="200" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator Display="Dynamic" ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                    CssClass="failureNotification" meta:resourcekey="PasswordRequired" ValidationGroup="valGroup">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:CheckBox ID="RememberMe" runat="server"/>
                                <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline"><asp:Literal runat="server" ID="lblKeepConnected" meta:resourcekey="lblKeepConnected"></asp:Literal></asp:Label>
                            </td>
                        </tr>
                    </table>
            </div>   
            <br />
            <div class="btnAlign">
                    <asp:Button ID="LoginButton" CssClass="btnStyle" CausesValidation="false" runat="server" meta:resourcekey="LoginButton" CommandName="Login" ValidationGroup="valGroup"/>
            </div>
            </center>
        </LayoutTemplate>
    </asp:Login>
    <script type="text/javascript" language="javascript">
        $('#fields').addClass("ui-corner-all");

        $(function () {
            $("#dialog-message").dialog({
                autoOpen: false,
                modal: true,
                show: "blind",
                hide: "explode",
                buttons: {
                    "Ok": function () { $(this).dialog("close"); document.getElementById('MainContent_LoginUser_UserName').focus(); }
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