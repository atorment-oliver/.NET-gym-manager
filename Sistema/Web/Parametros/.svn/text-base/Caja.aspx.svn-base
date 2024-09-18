<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Caja.aspx.cs" Inherits="Parametros_Caja" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="CajaId" Value="" />
    <asp:HiddenField runat="server" ID="CajaNumero" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nueva caja" onclick="btnNuevo_Click" />
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
                    <td><asp:Literal ID="lblBuscarNumero" runat="server">Numero:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarNumero" Width="50" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarNumero" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarNumero" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                    </td>
                    <td><asp:Literal ID="lblBuscarCajero" runat="server">Cajero:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlCajero">                           
                        </asp:DropDownList>                        
                    </td>
               </tr>
               <tr>                    
                    <td><asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstado">
                            <asp:ListItem Selected="True" Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="Activa" Value="True"></asp:ListItem>
                            <asp:ListItem Text="Inactiva" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Cajas encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> Cajas.<asp:ObjectDataSource 
            ID="CajaDataSource" runat="server" SelectMethod="TraerXCriterioD" 
            TypeName="RN.Componentes.CCaja">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarnumero" Name="numero" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="ddlCajero" Name="cajeroId" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" Name="estado" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="CajaDataSource" 
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
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:TemplateField ItemStyle-Width="50"  HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false"  CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="50" DataField="numero" SortExpression="numero" HeaderText="Numero de caja" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    
                    <asp:TemplateField ItemStyle-Width="350"  HeaderStyle-HorizontalAlign="Center" HeaderText="Cajero">            
			            <ItemStyle HorizontalAlign="Left"></ItemStyle>
			            <ItemTemplate>
                            <asp:Label  runat="server" ID="lblCajero" Text='<%# CargarNombre(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>
                    
                    <asp:TemplateField ItemStyle-Width="50"  HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Image  runat="server" ID="IsApproved" ImageUrl='<%# IsApproved(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNueva" Visible="false">
        <h2>
            Nuevo caja
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información de la caja</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblNumero" runat="server">N&uacute;mero de caja:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtnumero" Width="50" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblCajero" runat="server">Cajero:</asp:Literal></td>
                        <td>
                                        
                            <asp:DropDownList ID="ddlCajeros" Width="250" runat="server" CssClass="textEntry"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvCajero" runat="server" ControlToValidate="ddlCajeros" 
                                    CssClass="failureNotification" ErrorMessage="El cajero es obligatorio." Text="El cajero es obligatorio." ToolTip="El cajero es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>                                    
                        </td>
                    </tr>
                    <tr runat="server">
                        <td class="mandatory"><asp:Literal ID="lblEstado" runat="server">Caja activa:</asp:Literal></td>
                        <td>                                        
                            <asp:checkbox runat="server" id="cbEstado" />                            
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="false" ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar caja" ValidationGroup="RegisterUserValidationGroup"/>
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
                    "Borrar": function () { __doPostBack(uniqueID, ''); $(this).dialog("close"); global.MostrarEsperaAjax(); },
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
