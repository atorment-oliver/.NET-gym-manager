<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Users.aspx.cs" Inherits="Account_Users" EnableEventValidation="false" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="UserId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
    <asp:Button ID="btnNuevo" CausesValidation="false" CssClass="btnStyle" runat="server" Text="Registrar nuevo usuario" onclick="btnNuevo_Click" />
        <br />
        <h2>Filtro de búsqueda</h2>    
        <hr />
        <fieldset class="search">
            <table border="0" cellpadding="2" cellspacing="0">
                <colgroup>
                    <col width="150px" />
                    <col width="300px" />
                    <col width="70px" />
                    <col width="*" />
                </colgroup>
                <tr>                    
                    <td>Nombre:</td>
                    <td>
                        <asp:TextBox ID="FirstNameSearch" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                    <td>Apellidos:</td>
                    <td>
                        <asp:TextBox ID="LastNameSearch" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Nombre de usuario:</td>
                    <td>
                        <asp:TextBox ID="UserNameSearch" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                    </td>
                    <td><asp:Literal ID="StatusLabelSearch" runat="server">Aprobados:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="StatusSearch">
                            <asp:ListItem Selected="True" Text="SI" Value="True"></asp:ListItem>
                            <asp:ListItem Text="NO" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Usuarios en l&iacute;nea:</td>
                    <td>
                        <asp:DropDownList runat="server" ID="UsersOnLineSearch">
                            <asp:ListItem Selected="True" Text="Todos" Value="False"></asp:ListItem>
                            <asp:ListItem Text="SI" Value="True"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Usuarios encontrados</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> usuarios.
        <div id='content'>
            <asp:GridView ID="ResultGrid" runat="server" DataSourceID="UsersDataSource" CellPadding="3" 
                AutoGenerateColumns="false" DataKeyNames="UserName" PageSize="10" 
                AllowPaging="True" AllowSorting="true" HeaderStyle-Height="25px" BorderColor="#dddddd" BorderStyle="Solid" BorderWidth="1px" Width="100%" 
                onrowcommand="ResultGrid_RowCommand" 
                onpageindexchanging="ResultGrid_PageIndexChanging">
                <EmptyDataTemplate>
                    No se encontraron resultados para el filtro aplicado.
                </EmptyDataTemplate>
                <RowStyle Height="30px" />
                <HeaderStyle CssClass="ui-widget-header" />
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="Id" Visible="false" />
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false" CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>'  Visible='<%# IsVisible(Container.DataItem) %>'/>
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="110" DataField="UserName" SortExpression="UserName" HeaderText="Nombre de usuario" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="150" DataField="FirstName" SortExpression="FirstName" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="150" DataField="LastName" SortExpression="LastName" HeaderText="Apellidos" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="createDate" SortExpression="createDate" HeaderText="Fecha creación" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField DataField="lastLoginDate" SortExpression="lastLoginDate" HeaderText="Último acceso" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Aprobado">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Approved" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' runat="server" ID="IsApproved" ImageUrl='<%# IsApproved(Container.DataItem) %>'  Visible='<%# IsVisible(Container.DataItem) %>'/>
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Bloqueado">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Locked" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' runat="server" ID="IsLockedOut" ImageUrl='<%# IsLockedOut(Container.DataItem) %>' Enabled='<%# DataBinder.Eval(Container.DataItem,"IsLockedOut") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Cambiar contraseña">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' OnClientClick="javascript:return Change(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false" CommandName="Password" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UserName") %>' runat="server" ID="Password" ImageUrl='<%# Config.GetPath("Images/seguridad.gif") %>'  Visible='<%# IsVisible(Container.DataItem) %>' />
			            </ItemTemplate>
		            </asp:TemplateField>                    
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="UsersDataSource" runat="server" 
                SelectMethod="GetUsersList" TypeName="AppSecurity" 
                OldValuesParameterFormatString="original_{0}">
                <SelectParameters>
                    <asp:ControlParameter ControlID="UserNameSearch" Name="userName" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="FirstNameSearch" Name="firstName" 
                        PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="LastNameSearch" DefaultValue="" 
                        Name="lastName" PropertyName="Text" Type="String" />
                    <asp:ControlParameter ControlID="UsersOnLineSearch" DefaultValue="False" 
                        Name="onLine" PropertyName="SelectedValue" Type="Boolean" />
                    <asp:ControlParameter ControlID="StatusSearch" Name="status" 
                        PropertyName="SelectedValue" Type="Boolean" DefaultValue="False" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Nuevo usuario del sistema
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
            Las contraseñas deben tener una longitud mínima de <%= Membership.MinRequiredPasswordLength %> caracteres.
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información de cuenta</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="UserNameLabel" runat="server">Nombre de usuario:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="UserName" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                    CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El nombre de usuario es obligatorio." Text="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="FirstNameLabel" runat="server">Nombre:</asp:Literal></td>
                        <td>
                            <asp:TextBox ID="FirstName" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="FirstName" 
                                    CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El nombre es obligatorio." Text="El nombre es obligatorio." ToolTip="El nombre es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="LastNameLabel" runat="server">Apellidos:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="LastName" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastName" 
                                    CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El apellido es obligatorio." Text="El apellido es obligatorio." ToolTip="El apellido es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="mandatory"><asp:Literal ID="EmailLabel" runat="server">Correo electrónico:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="Email" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                    CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="El correo electrónico es obligatorio." Text="El correo electrónico es obligatorio." ToolTip="El correo electrónico es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="passwordTR">
                        <td class="mandatory"><asp:Literal ID="PasswordLabel" runat="server">Contraseña:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="Password" Width="100" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                    CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="La contraseña es obligatoria." Text="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="passwordConfirmTR">
                        <td class="mandatory"><asp:Literal ID="ConfirmPasswordLabel" runat="server">Confirmar contraseña:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="ConfirmPassword" Width="100" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                    ErrorMessage="Confirmar contraseña es obligatorio." Text="Confirmar contraseña es obligatorio." ID="ConfirmPasswordRequired" runat="server" 
                                    ToolTip="Confirmar contraseña es obligatorio." SetFocusOnError="true" ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    CssClass="failureNotification" Display="Dynamic" ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." 
                                    Text="Contraseña y Confirmar contraseña deben coincidir." SetFocusOnError="true" 
                                    ValidationGroup="valGroup"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="RolLabel" runat="server">Rol:</asp:Literal></td>
                        <td>                                        
                            <asp:DropDownList ID="Rol" runat="server"></asp:DropDownList>
                        </td>
                    </tr> 
                    <tr>
                        <td><asp:Literal ID="FechaCreacionLabel" runat="server">Fecha Creación:</asp:Literal></td>
                        <td>
                            <asp:Label runat="server" ID="FechaCreacion" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="UltimaActividadLabel" runat="server">última actividad:</asp:Literal></td>
                        <td>
                            <asp:Label runat="server" ID="UltimaActividad" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="UltimoIngresoLabel" runat="server">último ingreso:</asp:Literal></td>
                        <td>
                            <asp:Label runat="server" ID="UltimoIngreso" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="AprobadoLabel" runat="server">Aprobado:</asp:Literal></td>
                        <td>
                            <asp:CheckBox ID="Aprobado"  runat="server" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="false" ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar usuario" ValidationGroup="valGroup"/>
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
            $("#dialog-delete").dialog({
                autoOpen: false
            });
            $("#dialog-password").dialog({
                autoOpen: false
            });
        });
        function deleteItem(uniqueID, itemID) {
            $("#dialog-delete").dialog({
                modal: true,
                buttons: {
                    "Borrar": function () { __doPostBack(uniqueID, ''); $(this).dialog("close"); global.MostrarEsperaAjax(); },
                    "Cancelar": function () { $(this).dialog("close"); }
                }
            });

            $('#dialog-delete').dialog('open');
            return false;
        }
        function Change(uniqueID, itemID) {
            $("#dialog-password").dialog({
                modal: true,
                buttons: {
                    "Guardar": function () {
                        var texto = document.getElementById('txtChngPass');
                        __doPostBack(uniqueID, texto.value);
                        $(this).dialog("close");
                    },
                    "Cancelar": function () { $(this).dialog("close"); }
                }
            });

            $('#dialog-password').dialog('open');
            return false;
        }
        
	</script>
    <div id="dialog-delete" title="Informacion">
	<p>
        ¿Está seguro de borrar el registro seleccionado?
	</p>
    </div>
    <div id="dialog-message" title="Informacion">
	    <p>
            <strong><asp:Literal runat="server" ID="popupTitle"></asp:Literal></strong>
            <br />
            <asp:Literal runat="server" ID="popupMessage"></asp:Literal>
	    </p>
    </div> 
    <div id="dialog-password" title="Cambio de contraseña">
	    <p>
            <strong>Ingrese una nueva contraseña: <input id="txtChngPass" type="text" /> </strong>
            <br />
            <asp:Literal runat="server" ID="Literal2"></asp:Literal>
	    </p>
    </div>
    <asp:Literal runat="server" ID="lblScriptShow"></asp:Literal>
</asp:Content>