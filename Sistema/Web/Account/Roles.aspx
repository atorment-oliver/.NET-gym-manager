<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Account_Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script language="javascript" type="text/javascript">
        function SelectAllCheckboxes(spanChk) 
        {
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
            spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
                  elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
    </script>
    <asp:HiddenField runat="server" ID="Id" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nuevo Rol" onclick="btnNuevo_Click" />
        <br />
        <h2>Roles encontrados</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> usuarios.
        <div id='content'>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" BorderStyle="Solid" BorderWidth="1px" Width="100%" 
             ID="ResultGrid" runat="server" DataSourceID="RolesDataSource" CellPadding="3" 
                AutoGenerateColumns="False" DataKeyNames="RolName" 
                AllowPaging="True" AllowSorting="True" 
                onrowcommand="ResultGrid_RowCommand" 
                onpageindexchanging="ResultGrid_PageIndexChanging">
                <EmptyDataTemplate>
                    No se encontraron resultados.
                </EmptyDataTemplate>
                <RowStyle Height="30px" />
                <HeaderStyle CssClass="ui-widget-header" />
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle HorizontalAlign="Center" Width="70"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"RolName") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false"  CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"RolName") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>'  Visible='<%# IsVisible(Container.DataItem) %>'/>
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <ItemStyle HorizontalAlign="Center" Width="70"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"RolName") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField DataField="RolName" SortExpression="Rol" HeaderText="Nombre de rol" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="50" DataField="NroPrivilegios" SortExpression="NroPrivilegios" HeaderText="# Privilegios" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField ItemStyle-Width="50" DataField="NroUsuarios" SortExpression="NroUsuarios" HeaderText="# Usuarios" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="RolesDataSource" runat="server" SelectMethod="GetRolesList" TypeName="AppSecurity"></asp:ObjectDataSource>            
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Nuevo rol del sistema
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información</legend>
                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="RolLabel" runat="server">Nombre de rol:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="Rol" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RolRequired" runat="server" ControlToValidate="Rol" SetFocusOnError="true"  
                                    CssClass="failureNotification" ErrorMessage="El nombre del rol es obligatorio." Text="El nombre del rol es obligatorio." ToolTip="El nombre de usuario es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory" valign="top"><asp:Literal ID="PrivilegiosLabel" runat="server">Privilegios:</asp:Literal></td>
                        <td>
                            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" BorderStyle="Solid" BorderWidth="1px" Width="100%"
                                ID="Privilegios" runat="server" DataSourceID="PrivilegiosDataSource" CellPadding="3" 
                                GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Id">
                                <EmptyDataTemplate>
                                    No se encontraron resultados.
                                </EmptyDataTemplate>
                                <RowStyle Height="30px" />
                                <HeaderStyle CssClass="ui-widget-header" />
                                <Columns>
                                    <asp:BoundField ItemStyle-Width="50" DataField="Id" HeaderText="Id" />
                                    <asp:BoundField ItemStyle-Width="110" DataField="Nombre" SortExpression="Nombre" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                    <asp:BoundField ItemStyle-Width="250" DataField="Descripcion" SortExpression="Descripcion" HeaderText="Descripcion" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Seleccionar">            
			                            <ItemStyle HorizontalAlign="Center" Width="50"></ItemStyle>
                                        <HeaderTemplate>
                                            <input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server" type="checkbox" />
                                        </HeaderTemplate>
			                            <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkSelect" Checked='<%# IsAssigned(Container.DataItem) %>'/>
			                            </ItemTemplate>
		                            </asp:TemplateField> 
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="PrivilegiosDataSource" runat="server" 
                                SelectMethod="GetPrivilegesList" TypeName="AppSecurity"></asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="CreateRolButton" CausesValidation="false" CssClass="btnStyle" OnClick="CreateRolButton_Click" runat="server" Text="Guardar Rol" ValidationGroup="valGroup"/>
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
        });
        function deleteItem(uniqueID, itemID) {
            $("#dialog-delete").dialog({
                modal: true,
                buttons: {
                    "Borrar": function () { __doPostBack(uniqueID, ''); $(this).dialog("close"); },
                    "Cancelar": function () { $(this).dialog("close"); }
                }
            });

            $('#dialog-delete').dialog('open');
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
    <asp:Literal runat="server" ID="lblScriptShow"></asp:Literal>
</asp:Content>

