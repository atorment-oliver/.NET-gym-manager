<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Parametro.aspx.cs" Inherits="Parametros_Parametro" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField ID="CajaId" runat="server" Value="" />
    <asp:HiddenField ID="CajaNumero" runat="server" Value="" />
    <asp:Panel ID="pnlVer" runat="server" DefaultButton="Seach" Visible="false">
        <asp:Button ID="btnNuevo" runat="server" CausesValidation="false" CssClass="btnStyle"
            OnClick="btnNuevo_Click" Text="Registrar Parámetros" />
        <br />
        <h2>
            Filtro de búsqueda</h2>
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
                    <td>
                        <asp:Literal ID="lblBuscarNumero" runat="server">Numero:</asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBuscarNumero" runat="server" CssClass="textEntry" Width="50"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revBuscarNumero" runat="server" ControlToValidate="txtBuscarNumero"
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ValidationGroup="RegisterUserValidationGroup"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Literal ID="lblBuscarCajero" runat="server">Cajero:</asp:Literal>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCajero" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem Selected="True" Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="Activa" Value="True"></asp:ListItem>
                            <asp:ListItem Text="Inactiva" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </fieldset>
        <p class="findButton">
            <asp:Button ID="Seach" runat="server" CssClass="btnStyle" OnClick="Seach_Click" Text="Buscar" />
        </p>
        <h2>
            Par&aacute;metros encontrados</h2>
        <hr />
        Se encontraron
        <asp:Literal ID="lblInfo" runat="server"></asp:Literal>
        Cajas.<asp:ObjectDataSource ID="CajaDataSource" runat="server" SelectMethod="TraerXCriterioD"
            TypeName="RN.Componentes.CCaja">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarnumero" Name="numero" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="ddlCajero" Name="cajeroId" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" Name="estado" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="ResultGrid" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BorderColor="#dddddd" BorderStyle="Solid" BorderWidth="1px"
            DataKeyNames="id" DataSourceID="CajaDataSource" HeaderStyle-Height="25px" OnPageIndexChanging="ResultGrid_PageIndexChanging"
            OnRowCommand="ResultGrid_RowCommand" Width="100%">
            <EmptyDataTemplate>
                No se encontraron resultados para el filtro aplicado.
            </EmptyDataTemplate>
            <RowStyle Height="30px" />
            <HeaderStyle CssClass="ui-widget-header" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar" ItemStyle-Width="50">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="Delete" runat="server" AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>'
                            CausesValidation="false" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'
                            CommandName="Eliminar" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>'
                            OnClientClick="javascript:return deleteItem(this.name, this.alt);" UseSubmitBehavior="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Editar" ItemStyle-Width="50">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'
                            CommandName="Editar" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="numero" HeaderStyle-HorizontalAlign="Left" HeaderText="Numero de caja"
                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50" SortExpression="numero" />
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Cajero" ItemStyle-Width="350">
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <asp:Label ID="lblCajero" runat="server" Text='<%# CargarNombre(Container.DataItem) %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estado" ItemStyle-Width="50">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:Image ID="IsApproved" runat="server" ImageUrl='<%# IsApproved(Container.DataItem) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnlNueva" runat="server" Visible="true">
        <h2>
            Par&aacute;metros
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información </legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory">
                            <asp:Literal ID="lblNumero" runat="server">Tipo de cambio:</asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTipoCambio" runat="server" Enabled="true" Width="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtMontoBsRequired" runat="server" ControlToValidate="txtTipoCambio" 
                                    CssClass="failureNotification" ErrorMessage="El monto de apertura en Bolivianos es obligatorio." 
                                    Text="El monto de apertura en Bolivianos es obligatorio." ToolTip="El monto de apertura en Bolivianos es obligatorio." 
                                    ValidationGroup="valGroup" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="txtMontoBsRegular" 
                                    ValidationGroup="valGroup" ControlToValidate="txtTipoCambio" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                        </tr>
                        <tr>
                        <td>
                            <asp:Literal ID="Literal1" runat="server">Usar Tipo de cambio BNB:</asp:Literal>
                        </td>
                        <td>
                            
                            <asp:CheckBox ID="cbTipoCambio" runat="server" />
                            
                        </td>
                    </tr>
                    
                    
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="CreateUserButton" runat="server" CausesValidation="false" CommandName="MoveNext"
                    CssClass="btnStyle" OnClick="RegisterUser_CreatedUser" Text="Guardar " ValidationGroup="RegisterUserValidationGroup" />
                &nbsp;&nbsp;&nbsp;
            </p>
        </div>
    </asp:Panel>
    <script language="javascript" type="text/javascript">
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
            <strong>
                <asp:Literal ID="popupTitle" runat="server"></asp:Literal></strong>
            <br />
            <asp:Literal ID="popupMessage" runat="server"></asp:Literal>
        </p>
    </div>
    <asp:Literal ID="lblScriptShow" runat="server"></asp:Literal>
</asp:Content>
