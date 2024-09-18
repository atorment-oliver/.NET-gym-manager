<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Promocion.aspx.cs" Inherits="Parametros_Promocion" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="PromocionId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nueva promoci&oacute;n" onclick="btnNuevo_Click" />
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
                    <td><asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstado">
                            <asp:ListItem Selected="True" Text="TODOS" Value=""></asp:ListItem>
                            <asp:ListItem Text="ACTIVO" Value="True"></asp:ListItem>
                            <asp:ListItem Text="INACTIVO" Value="False"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>                    
                    <td><asp:Literal ID="Literal1" runat="server">Fecha inicio:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarFechaInicio" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                        <asp:Image ID="imgFechaIngreso" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" TargetControlID="txtBuscarFechaInicio" PopupButtonID="imgFechaIngreso" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarFechaInicio" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                        
                    </td>
                    <td><asp:Literal ID="Literal2" runat="server">Fecha final:</asp:Literal></td>
                    <td>
                        <asp:TextBox ID="txtBuscarFechaFinal" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                         <asp:Image ID="imgButton2" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                        Enabled="True" TargetControlID="txtBuscarFechaFinal" PopupButtonID="imgButton2" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ValidationGroup="RegisterUserValidationGroup" ControlToValidate="txtBuscarFechaFinal" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Promociones encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> promociones.<asp:ObjectDataSource 
            ID="ObjectDataSource1" runat="server" SelectMethod="TraerXCriterioD" 
            TypeName="RN.Componentes.CPromocion">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarFechaInicio" Name="fechaInicio" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtBuscarFechaFinal" Name="fechaFin" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtBuscarNombre" Name="usuarioId" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" Name="estado" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="ObjectDataSource1" 
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
                    <asp:BoundField ItemStyle-Width="200" DataField="nombre" SortExpression="nombre" HeaderText="Nombre" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha inicio" 
                            ItemStyle-Width="100">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="fechaInicio" runat="server" Text="<%# GetFechaInicio(Container.DataItem) %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha finalización" 
                            ItemStyle-Width="100">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="fechaFin" runat="server" Text="<%# GetFechaFin(Container.DataItem) %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="100" DataField="montoDescuento" SortExpression="montoDescuento" HeaderText="Monto descuento" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField ItemStyle-Width="60"  HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
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
            Nueva promoci&oacute;n
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información del la promoci&oacute;n</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblEmpresa" runat="server">Nombre de la promoci&oacute;n:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtNombre" Width="250" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                                    CssClass="failureNotification" ErrorMessage="El nombre de la promoci&oacute;n es obligatorio." Text="El nombre de la promoci&oacute;n es obligatorio." ToolTip="El nombre de la promoci&oacute;n es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revNombre" ValidationGroup="valGroup" ControlToValidate="txtNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="register"><asp:Literal ID="lblLimite" runat="server">Fecha de inicio:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtFechaInicio" Width="70" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:Image ID="imgtxtFechaInicio" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                            Enabled="True" TargetControlID="txtFechaInicio" PopupButtonID="imgtxtFechaInicio" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" Display="Dynamic" ValidationGroup="valGroup" ControlToValidate="txtFechaInicio" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonto" Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="La fecha inicial es obligatoria." Text="La fecha inicial es obligatoria." ToolTip="La fecha inicial es obligatoria." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>  
                    <tr>
                        <td class="register"><asp:Literal ID="Literal3" runat="server">Fecha de final:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtFechaFinal" Width="70" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:Image ID="imgtxtFechaFinal" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                            Enabled="True" TargetControlID="txtFechaFinal" PopupButtonID="imgtxtFechaFinal" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ValidationGroup="valGroup" ControlToValidate="txtFechaFinal" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMonto" Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="La fecha final es obligatoria." Text="La fecha final es obligatoria." ToolTip="La fecha final es obligatoria." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="cvFecha" Display="Dynamic" Type="Date" Operator="GreaterThan" ValidationGroup="RegisterUserValidationGroup" ControlToCompare="txtFechaInicio" ControlToValidate="txtFechaFinal" ErrorMessage="La fecha debe ser mayor a la inicial" ></asp:CompareValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal4" runat="server">Monto descuento:</asp:Literal></td>
                        <td>          
                            <asp:TextBox ID="txtMonto" Width="70" runat="server" CssClass="textEntry"></asp:TextBox> Bs.
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMonto"  Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="El monto es obligatorio." Text="El monto es obligatorio." ToolTip="El monto es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="txtTipoCambioRegular" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMonto" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>">
                                    </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="passwordConfirmTR">
                        <td class="mandatory"><asp:Literal ID="lblEstado" runat="server">Estado:</asp:Literal></td>
                        <td>                                        
                            <asp:checkbox runat="server" id="cbEstado" />
                            
                        </td>
                    </tr>
                    <tr runat="server" id="Tr1">
                        <td class="mandatory"><asp:Literal ID="Literal5" runat="server">Mensual(Si no es mensual es ilimitada):</asp:Literal></td>
                        <td>                                        
                            <asp:checkbox runat="server" id="cbMensual" />
                            
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="false" ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar Promoci&oacute;n" ValidationGroup="valGroup"/>
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