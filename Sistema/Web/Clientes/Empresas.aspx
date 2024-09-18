<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Empresas.aspx.cs" Inherits="Clientes_Empresas"  %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="EmpresaId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nueva empresa" onclick="btnNuevo_Click" />
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
                    <td><asp:Literal ID="lblBuscarPersona" runat="server">Persona de contacto:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarPersona" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarPersona" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarPersona" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Literal ID="lblBuscarCorreo" runat="server">Correo:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarCorreo" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                        
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarCorreo" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarCorreo" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                    </td>
                    <td><asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstado">
                            <asp:ListItem Selected="True" Text="TODOS" Value=""></asp:ListItem>
                            <asp:ListItem Text="ACTIVO" Value="True"></asp:ListItem>
                            <asp:ListItem Text="INACTIVO" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Empresas encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> empresas.
        <asp:ObjectDataSource 
            ID="OBJDataSource" runat="server" SelectMethod="TraerXCriterioData" 
            TypeName="RN.Componentes.CEmpresa">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarNombre" Name="nombre" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtBuscarPersona" Name="nombrePersonaContacto" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtBuscarCorreo" Name="correo" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" Name="estado" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="OBJDataSource" 
                 Width="100%" 
                AutoGenerateColumns="False" DataKeyNames="Id" 
                AllowPaging="True" AllowSorting="True" 
                onrowcommand="ResultGrid_RowCommand" 
                onpageindexchanging="ResultGrid_PageIndexChanging" > 
                <EmptyDataTemplate>
                    No se encontraron resultados para el filtro aplicado.
                </EmptyDataTemplate>
                <RowStyle Height="30px" />
                <HeaderStyle CssClass="ui-widget-header" />
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="Id" Visible="false" />
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="50" DataField="id" 
                        SortExpression="id" HeaderText="C&oacute;digo" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="250" DataField="nombre" 
                        SortExpression="nombre" HeaderText="Nombre de la empresa" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150" DataField="nombrePersonaContacto" 
                        SortExpression="nombrePersonaContacto" HeaderText="Persona de contacto" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150" DataField="correo" 
                        SortExpression="correo" HeaderText="Correo" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="100" DataField="fechaRegistro" SortExpression="fechaRegistro" 
                        HeaderText="Fecha creación" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
			            <HeaderStyle HorizontalAlign="Center" />
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
            Nueva empresa
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información de empresa</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        
                        <td><asp:Literal ID="FechaCreacionLabel" runat="server">Fecha Creación:</asp:Literal></td>
                        <td>
                            <asp:Label runat="server" ID="txtFechaCreacion" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblEmpresa" runat="server">Nombre de la empresa:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtNombre" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                                    CssClass="failureNotification" ErrorMessage="El nombre de la empresa es obligatorio." Text="El nombre de la empresa es obligatorio." ToolTip="El nombre de la empresa es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="failureNotification" runat="server" ID="revNombre" ValidationGroup="valGroup" ControlToValidate="txtNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="register"><asp:Literal ID="lblDescripcion" runat="server">Descripción:</asp:Literal></td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" Width="350" TextMode="MultiLine" 
                                runat="server" CssClass="textEntry" Height="40px"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revDescripcion" ValidationGroup="valGroup" ControlToValidate="txtDescripcion" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblPersona" runat="server">Persona de contacto:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtPersonaContacto" Width="150px" runat="server" 
                                CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPersonaContacto" Display="Dynamic" runat="server" ControlToValidate="txtPersonaContacto" 
                                    CssClass="failureNotification" ErrorMessage="La persona de contacto es obligatorio." Text="La persona de contacto es obligatorio." ToolTip="La persona de contacto es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Display="Dynamic" runat="server" ID="revPersonaContacto" ValidationGroup="valGroup" ControlToValidate="txtPersonaContacto" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="register"><asp:Literal ID="lblTelefono" runat="server">Teléfono:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtTelefono" Width="100px" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revTelefono" ValidationGroup="valGroup" ControlToValidate="txtTelefono" ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>"></asp:RegularExpressionValidator>
                            
                        </td>
                    </tr>                    
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblCorreo" runat="server">Correo electrónico:</asp:Literal></td>
                        <td>                                        <asp:TextBox ID="txtCorreo" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="rfvCorreo" Display="Dynamic" runat="server" ControlToValidate="txtCorreo" 
                                    CssClass="failureNotification" ErrorMessage="El correo electrónico es obligatorio." Text="El correo electrónico es obligatorio." ToolTip="El correo electrónico es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Display="Dynamic" runat="server" ID="revCorreo" ValidationGroup="valGroup" ControlToValidate="txtCorreo" ValidationExpression="<%$ Resources: Regex, Correo %>" ErrorMessage="<%$ Resources: Mensajes, Correo %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="passwordTR">
                        <td class="mandatory"><asp:Literal ID="lblDireccion" runat="server">Dirección:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtDireccion" Width="350" runat="server" CssClass="textEntry" 
                                TextMode="MultiLine" Height="40px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDireccion" Display="Dynamic" runat="server" ControlToValidate="txtDireccion" 
                                    CssClass="failureNotification" ErrorMessage="La dirección es obligatoria." Text="La dirección es obligatoria." ToolTip="La dirección es obligatoria." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Display="Dynamic"  runat="server" ID="revDireccion" ValidationGroup="valGroup" ControlToValidate="txtDireccion" ValidationExpression="<%$ Resources: Regex, SoloDireccion %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="passwordConfirmTR">
                        <td class="mandatory"><asp:Literal ID="lblEstado" runat="server" Text="Activo:"></asp:Literal></td>
                        <td>                                        
                            <asp:CheckBox ID="cbEstado"  runat="server" />                            
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal1" runat="server" Text="Precios de paquetes:"></asp:Literal></td>
                        <td>
                            

                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                SelectMethod="TraerXEmpresaId" TypeName="RN.Componentes.CEmpresaPaquete" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="EmpresaId" Name="id" 
                                        PropertyName="Value" Type="String" DefaultValue="0" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            
                            <asp:GridView ID="grdPaquetes" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" BackColor="White" 
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="0px" CellPadding="3" 
                                DataKeyNames="id" DataSourceID="ObjectDataSource2" ForeColor="Black" 
                                GridLines="Vertical" 
                                Width="100%" onpageindexchanging="grdPaquetes_PageIndexChanging" 
                                PageSize="10000">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerSettings PageButtonCount="100000" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                                <EmptyDataTemplate>
                                    No se encontraron deudas.
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" Visible="false" />
                                    <asp:BoundField DataField="nombre" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Paquete" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200" 
                                        SortExpression="nombre">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" 
                                        HeaderText="Precio paquete" ItemStyle-Width="80">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPrecioPaquete" runat="server" 
                                                Text='<%# DataBinder.Eval(Container.DataItem,"costo") %>' Width="100px" ValidationGroup="valGroup" />
                                            <asp:RangeValidator CssClass="failureNotification" ID="rvPrecio" runat="server" Display="Dynamic" 
                                            ControlToValidate="txtPrecioPaquete" ValidationGroup="valGroup" MinimumValue="0" MaximumValue="900000" Type="Double" 
                                            ErrorMessage="Solo valor decimal." ToolTip="Solo valor decimal."></asp:RangeValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="false"  ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar empresa" ValidationGroup="valGroup"/>
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