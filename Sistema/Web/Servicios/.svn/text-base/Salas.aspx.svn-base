<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Salas.aspx.cs" Inherits="Servicios_Salas" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">   
    <asp:HiddenField runat="server" ID="SalaId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar sala" 
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
                    <td><asp:Literal ID="NombreSearchLabel" runat="server">Nombre:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="NombreSearch" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:RegularExpressionValidator runat="server" ID="NombreSearchRequired" ValidationGroup="SearchValidationGroup" ControlToValidate="NombreSearch" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ></asp:RegularExpressionValidator>
                        
                    </td>
                </tr>                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" ValidationGroup="SearchValidationGroup" />
        </p>
        <h2>Salas encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> salas.
        <div id='content'>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="SalasDataSource" 
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
                    <asp:BoundField DataField="UserId" HeaderText="Id" Visible="false" />
                    <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false" CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="deleteOpen" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' Visible='<%# IsNotUsed(Container.DataItem) %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField  DataField="nombre" SortExpression="nombre" HeaderText="Nombre de la sala" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="SalasDataSource" runat="server" 
                SelectMethod="TraerXCriterio" TypeName="RN.Componentes.CSala">
                <SelectParameters>
                    <asp:ControlParameter ControlID="NombreSearch" Name="nombre" 
                        PropertyName="Text" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Nueva sala
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información de la sala</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblEmpresa" runat="server">Nombre de la sala:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="Nombre" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="NombreRequired" runat="server" ControlToValidate="Nombre" 
                                    CssClass="failureNotification" ErrorMessage="El nombre de la sala es obligatorio." Text="El nombre de la sala es obligatorio." ToolTip="El nombre de la sala es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="NombreRegular" ValidationGroup="valGroup" ControlToValidate="Nombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="false" ID="RegisterButton" runat="server" Text="Guardar" 
                    ValidationGroup="valGroup" onclick="RegisterButton_Click"/>
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