<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Licencias.aspx.cs" Inherits="Parametros_Licencias" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
      
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <link href="../Styles/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />   
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtSearchCI.ClientID%>").autocomplete('../Handlers/ClienteServicios.ashx').result(function (event, data, formatted) {
                if (data) {
                    //alert('Value: ' + data[1]);
                    $("#<%= ClientePaqueteId.ClientID %>").val(data[1]);
                }
                else {
                    $("#<%= ClientePaqueteId.ClientID %>").val('-1');
                }
            });
        });
    </script>
    <asp:HiddenField runat="server" ID="LicenciaId" Value="" />
    <asp:HiddenField runat="server" ID="LicenciaNombre" Value="" />
    <asp:HiddenField runat="server" ID="ClientePaqueteId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button ID="btnNuevo" CausesValidation="false" CssClass="btnStyle" runat="server" Text="Registrar nueva licencia" Visible="false"
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
                    <td>
                        <asp:Literal ID="Literal5" runat="server">Cliente/Servicio:</asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearchCI" runat="server" Width="250px"></asp:TextBox> 
                    </td>
                </tr>
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
            <asp:Button ID="Seach" CausesValidation="false" CssClass="btnStyle" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Licenciaes encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> Licenciaes.
        &nbsp;<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="TraerXCriterioD" TypeName="RN.Componentes.CLicencia" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarNombre" 
                    ConvertEmptyStringToNull="False" Name="descripcion" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="ClientePaqueteId" Name="clientePaqueteId" 
                    PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="txtFechaInicioLicencia" 
                    ConvertEmptyStringToNull="False" Name="fechaInicio" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="txtFechaFinalLicencia" 
                    ConvertEmptyStringToNull="False" Name="fechaFin" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" ConvertEmptyStringToNull="False" 
                    Name="estado" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
&nbsp;<div id='content'>
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
                    <asp:TemplateField ItemStyle-Width="100"  HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false" CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar" Visible="false">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CausesValidation="false" CssClass="btnStyle" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="100" DataField="descripcion" SortExpression="descripcion" HeaderText="Motivo" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="100" DataField="fechaInicioLicencia" SortExpression="fechaInicioLicencia" HeaderText="Fecha inicio" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="100" DataField="fechaFinLicencia" SortExpression="fechaFinLicencia" HeaderText="Fecha final" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="100" DataField="fechaSolicitud" SortExpression="fechaSolicitud" HeaderText="Fecha de solicitud" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:TemplateField ItemStyle-Width="100"  HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Image  runat="server" ID="IsApproved" ImageUrl='<%# IsApproved(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>
                </Columns>
            </asp:GridView>
         
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Nueva Licencia
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información de la Licencia</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td ><asp:Literal ID="Literal3" runat="server">Motivo de la licencia:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtMotivoLicencia" Width="250" runat="server" CssClass="textEntry" 
                                ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtMotivoLicencia" 
                                    CssClass="failureNotification" ErrorMessage="El motivo de la licencia es obligatorio." Text="El motivo de la licencia es obligatorio." ToolTip="El motivo de la licencia es obligatorio." 
                                    ValidationGroup="ruvgLicencia" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="failureNotification" runat="server" ID="revNombre" ValidationGroup="ruvgLicencia" ControlToValidate="txtMotivoLicencia" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="register"><asp:Literal ID="lblLimite" runat="server">Fecha de inicio:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtFechaInicioLicencia" Width="70" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:Image ID="imgtxtFechaInicio" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" 
                                            Enabled="True" TargetControlID="txtFechaInicioLicencia" PopupButtonID="imgtxtFechaInicio" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                            <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator3" Display="Dynamic" ValidationGroup="ruvgLicencia" ControlToValidate="txtFechaInicioLicencia" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaInicioLicencia" Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="La fecha inicial es obligatoria." Text="La fecha inicial es obligatoria." ToolTip="La fecha inicial es obligatoria." 
                                    ValidationGroup="ruvgLicencia"></asp:RequiredFieldValidator>
                        </td>
                    </tr>  
                    <tr>
                        <td class="register"><asp:Literal ID="Literal4" runat="server">Fecha de final:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtFechaFinalLicencia" Width="70" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:Image ID="imgtxtFechaFinal" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                            Enabled="True" TargetControlID="txtFechaFinalLicencia" PopupButtonID="imgtxtFechaFinal" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ID="RegularExpressionValidator4" ValidationGroup="ruvgLicencia" ControlToValidate="txtFechaFinalLicencia" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaFinalLicencia" Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="La fecha final es obligatoria." Text="La fecha final es obligatoria." ToolTip="La fecha final es obligatoria." 
                                    ValidationGroup="ruvgLicencia"></asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="cvFecha" Display="Dynamic" Type="Date" Operator="GreaterThanEqual" ValidationGroup="ruvgLicencia" ControlToCompare="txtFechaInicioLicencia" ControlToValidate="txtFechaFinalLicencia" ErrorMessage="La fecha debe ser mayor o igual a la inicial" ></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="Literal6" runat="server">Fecha de solicitud:</asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="lblLicenciaFechaSolicitud" runat="server"></asp:Literal>
                        </td>
                    </tr> 
                    <tr runat="server" id="passwordConfirmTR" visible="false">
                        <td class="mandatory"><asp:Literal ID="lblEstado" runat="server">Estado:</asp:Literal></td>
                        <td>                                        
                            <asp:checkbox runat="server" id="cbEstadoLicencia" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="CreateUserButton" CausesValidation="false" CssClass="btnStyle" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar licencia" ValidationGroup="RegisterUserValidationGroup"/>
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