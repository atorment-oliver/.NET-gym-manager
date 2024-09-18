<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ABMCliente.aspx.cs" Inherits="Clientes_ABMCliente" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/RegistrarCliente.ascx" tagname="Cliente" tagprefix="uc1" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<script src="../Scripts/jquery.msgBox.v1.js" type="text/javascript"></script>
    <asp:HiddenField runat="server" ID="PaqueteId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nuevo cliente" onclick="btnNuevo_Click" />
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
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarNombre" ValidationGroup="RegisterUserValidationGroup1" ControlToValidate="txtBuscarNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                        
                    </td>
                    <td><asp:Literal ID="lblBuscarCorreo" runat="server">Correo:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarCorreo" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarCorreo" ValidationGroup="RegisterUserValidationGroup1" ControlToValidate="txtBuscarCorreo" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td><asp:Literal ID="lblBuscarci" runat="server">C.I.:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarCi" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="revBuscarCi" ValidationGroup="RegisterUserValidationGroup1" ControlToValidate="txtBuscarCi" ValidationExpression="<%$ Resources: Regex, Correo %>" ></asp:RegularExpressionValidator>
                    </td>
                    <td><asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstado">
                            <asp:ListItem Selected="True" Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="Activo" Value="a"></asp:ListItem>
                            <asp:ListItem Text="Inactivo" Value="i"></asp:ListItem>
                            <asp:ListItem Text="Vencido" Value="v"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Clientes encontrados</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> clientes.
        <asp:ObjectDataSource ID="ClientesDataSource" runat="server" SelectMethod="TraerXOrCriterioEmpresa" 
            TypeName="RN.Componentes.CCliente" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarNombre" Name="nombre" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtBuscarCorreo" Name="correo" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtBuscarCi" Name="ci" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" Name="estado" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="ClientesDataSource" 
                 Width="100%" 
                AutoGenerateColumns="False" DataKeyNames="Id" 
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
                    <asp:TemplateField ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false" CommandName="Eliminar" Visible="<%# EliminarVisible(Container.DataItem) %>" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="150" DataField="nombreCompleto" SortExpression="nombreCompleto" HeaderText="Nombre del cliente" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="110" DataField="ci" SortExpression="ci" HeaderText="C.I." HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="250" DataField="direccion" SortExpression="direccion" HeaderText="Direcci&oacute;n" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="110" DataField="correo" SortExpression="correo" HeaderText="Correo" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="110" DataField="empresa" SortExpression="empresa" HeaderText="Empresa" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField ItemStyle-Width="50" HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
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
            Cliente
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
                <legend>Informaci&oacute;n del cliente</legend>
                <uc1:Cliente runat="server" ID="ClienteControl" Visible="true" />
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