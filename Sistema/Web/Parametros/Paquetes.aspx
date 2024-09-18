<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Paquetes.aspx.cs" Inherits="Parametros_Paquetes" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="PaqueteId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nuevo paquete" 
            onclick="btnNuevo_Click" />
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
                    <td><asp:Literal ID="lblBuscarNombre" runat="server">Nombre:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarNombre" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarNombre" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                        
                    </td>
                    <td><asp:Literal ID="lblBuscarTipo" runat="server">Tipo de paquete:</asp:Literal></td>
                    <td>
                        <asp:DropDownList ID="ddlBuscarTipoPaquete" Width="250" runat="server" CssClass="textEntry"></asp:DropDownList>
                        
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarTipoPaquete" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="ddlBuscarTipoPaquete" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstado">
                            <asp:ListItem Selected="True" Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="Activo" Value="True"></asp:ListItem>
                            <asp:ListItem Text="Inactivo" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Paquetes encontrados</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> paquetes.<asp:ObjectDataSource 
            ID="PaqueteDataSource" runat="server" SelectMethod="TraerXCriterioD" 
            TypeName="RN.Componentes.CPaquete" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarNombre" Name="nombre" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="ddlBuscarTipoPaquete" Name="tipoPaqueteId" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" Name="estado" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="PaqueteDataSource" 
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
                    <asp:BoundField DataField="id" HeaderText="Id" Visible="false" />
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false"  CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="250" DataField="nombre" SortExpression="nombre" HeaderText="Nombre del paquete" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="110" DataField="tiempo" SortExpression="tiempo" HeaderText="Tiempo" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="110" DataField="precio" SortExpression="precio" HeaderText="Precio" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Fecha creación" SortExpression="fechaRegistro" 
                            ItemStyle-Width="110">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="Fecha" runat="server" Text="<%# GetFecha(Container.DataItem) %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Image  runat="server" ID="IsApproved" ImageUrl='<%# IsApproved(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>
                </Columns>
            </asp:GridView>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Nuevo paquete
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información de paquete</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblEmpresa" runat="server">Nombre del paquete:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtNombre" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                                    CssClass="failureNotification" ErrorMessage="El nombre del paquete es obligatorio." Text="El nombre del paquete es obligatorio." ToolTip="El nombre del paquete es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="failureNotification" runat="server" ID="revNombre" ValidationGroup="valGroup" ControlToValidate="txtNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblUnidad" runat="server">Unidad:</asp:Literal></td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlUnidad"></asp:DropDownList>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="rfvUnidad" runat="server" ControlToValidate="ddlUnidad" 
                                    CssClass="failureNotification" ErrorMessage="La unidad es obligatoria." Text="La unidad es obligatoria." ToolTip="La unidad es obligatoria." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblTiempo" runat="server">Tiempo:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtTiempo" Width="80" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTiempo" Display="Dynamic" runat="server" ControlToValidate="txtTiempo" 
                                    CssClass="failureNotification" ErrorMessage="El tiempo es obligatorio." Text="El tiempo es obligatorio." ToolTip="El tiempo es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Display="Dynamic" runat="server" ID="revTiempo" ValidationGroup="valGroup" ControlToValidate="txtTiempo" ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblTipoPaquete" runat="server">Cobertura:</asp:Literal></td>
                        <td>                                        
                            <asp:DropDownList ID="ddlTipoPaquete" Width="150" runat="server" CssClass="textEntry"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTipoPaquete" Display="Dynamic" runat="server" ControlToValidate="ddlTipoPaquete" 
                                    CssClass="failureNotification" ErrorMessage="El tipo de paquete es obligatorio." Text="El tipo de paquete es obligatorio." ToolTip="El tipo de paquete es obligatorio.." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>                            
                        </td>
                    </tr>                    
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblPrecio" runat="server">Precio:</asp:Literal></td>
                        <td> 
                            <asp:TextBox ID="txtPrecio" Width="80" runat="server" CssClass="textEntry"></asp:TextBox>
                            
                            <asp:Literal ID="Literal1" runat="server">Bs.</asp:Literal>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="PrecioRequired" runat="server" ControlToValidate="txtPrecio" 
                                    CssClass="failureNotification" ErrorMessage="El Precio es obligatorio." Text="El Precio es obligatorio." ToolTip="El Precio es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RangeValidator CssClass="failureNotification" ID="rvPrecio" runat="server" Display="Dynamic" ControlToValidate="txtPrecio" ValidationGroup="valGroup" MinimumValue="1" MaximumValue="90000" Type="Double" ErrorMessage="El valor debe ser mayor a 0." ToolTip="El valor debe ser mayor a 0."></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="passwordTR">
                        <td><asp:Literal ID="lblDias" runat="server">Días de validez:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtDias" Width="80" runat="server" CssClass="textEntry" TextMode="SingleLine" ></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Display="Dynamic"  runat="server" ID="revDias" ValidationGroup="valGroup" ControlToValidate="txtDias" ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>"></asp:RegularExpressionValidator>
                            <asp:RangeValidator CssClass="failureNotification" ID="rvDias" runat="server" Display="Dynamic" ControlToValidate="txtDias" MinimumValue="1" ValidationGroup="RegisterUserValidationGroup" MaximumValue="90000" Type="Integer" ErrorMessage="El valor debe ser mayor a 0." ToolTip="El valor debe ser mayor a 0."></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="passwordConfirmTR">
                        <td class="mandatory"><asp:Literal ID="lblEstado" runat="server">Activo:</asp:Literal></td>
                        <td>                                        
                            <asp:CheckBox ID="cbEstado" Text=""  runat="server" />                            
                        </td>
                    </tr>
                    <tr>
                        
                        <td><asp:Literal ID="FechaCreacionLabel" runat="server">Fecha Creación:</asp:Literal></td>
                        <td>
                            <asp:Label runat="server" ID="txtFechaCreacion" Text=""></asp:Label>
                        </td>
                    </tr>
                   
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="false" ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar Paquete" ValidationGroup="valGroup"/>
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