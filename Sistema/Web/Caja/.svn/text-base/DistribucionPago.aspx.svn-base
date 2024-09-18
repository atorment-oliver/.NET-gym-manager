<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DistribucionPago.aspx.cs" Inherits="Caja_DistribucionPago" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="../Scripts/jquery.autocomplete.js" type="text/javascript" language="javascript" ></script>
    <link href="../Styles/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />     
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtCliente.ClientID%>").autocomplete('../Handlers/ClienteNoEmpresa.ashx').result(function (event, data, formatted) {
                if (data) {
                    //alert('Value: ' + data[1]);
                    $("#<%= ClienteId.ClientID %>").val(data[1]);
                }
                else {
                    $("#<%= ClienteId.ClientID %>").val('-1');
                }
            });
        });
        $(document).ready(function () {
            $("#<%=txtNombre.ClientID%>").autocomplete('../Handlers/ClienteNoEmpresa.ashx').result(function (event, data, formatted) {
                if (data) {
                    //alert('Value: ' + data[1]);
                    $("#<%= RegistrarClienteId.ClientID %>").val(data[1]);
                    $("#<%= txtCodigoCliente.ClientID %>").val(data[1]);
                    $("#<%= lblEmpresaNombre.ClientID %>").val(data[2]);
                }
                else {
                    $("#<%= RegistrarClienteId.ClientID %>").val('');
                    $("#<%= txtCodigoCliente.ClientID %>").val('-1');
                    $("#<%= lblEmpresaNombre.ClientID %>").val('-');
                }
            });
        });
    </script>
    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
    <asp:HiddenField runat="server" ID="DistribucionPagosId" Value="" />
    <asp:HiddenField runat="server" ID="ClienteId" Value="" />
    <asp:HiddenField runat="server" ID="RegistrarClienteId" Value="" />
    </ContentTemplate>
    </asp:UpdatePanel>
     <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nueva distribuci&oacute;n" onclick="btnNuevo_Click" />
        <br />
    <h2>DISTRIBUCIÓN DE PAGOS</h2> 
    <h2>Filtro de búsqueda</h2>    
        <hr />
        <fieldset class="search">
            <table border="0" cellpadding="2" cellspacing="0">
                <colgroup>
                    <col width="100px" />
                    <col width="300px" />
                    <col width="100px" />
                    <col width="*" />
                </colgroup>
                <tr>
                    <td>
                       Cliente:
                    </td>
                    <td>
                        <asp:TextBox ID="txtCliente" runat="server" Width="250px"></asp:TextBox> 
                    </td>
                    <td>
                        Empresa:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEmpresas" Width="300px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>    
                    <td>
                        Porcentaje inicio:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="lblPorcentajeInicio">
                            <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                            <asp:ListItem Text="70" Value="70"></asp:ListItem>
                            <asp:ListItem Text="80" Value="80"></asp:ListItem>
                            <asp:ListItem Text="90" Value="90"></asp:ListItem>
                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                        </asp:DropDownList>
                    </td>     
                    <td>
                        Porcentaje fin:
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="lblPorcentajeFin">
                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                            <asp:ListItem Text="40" Value="40"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                            <asp:ListItem Text="70" Value="70"></asp:ListItem>
                            <asp:ListItem Text="80" Value="80"></asp:ListItem>
                            <asp:ListItem Text="90" Value="90"></asp:ListItem>
                            <asp:ListItem Text="100" Value="100" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </td>                    
                </tr>
            </table>            
        </fieldset>

        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Promociones encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> 
         distribuciones.<asp:ObjectDataSource 
            ID="ObjectDataSource1" runat="server" SelectMethod="TraerXCriterioD" 
            TypeName="RN.Componentes.CDistribucionPago" 
             OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblPorcentajeInicio" Name="porcentajeInicio" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="lblPorcentajeFin" Name="porcentajeFin" 
                    PropertyName="SelectedValue" Type="Int32" />
                <asp:ControlParameter ControlID="txtCliente" Name="cliente" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="ddlEmpresas" Name="empresaId" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#DDDDDD" 
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
                    <asp:BoundField ItemStyle-Width="150" DataField="nombreEmpresa" SortExpression="nombreEmpresa" HeaderText="Nombre empresa" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="200" DataField="nombreCliente" SortExpression="nombreCliente" HeaderText="Nombre cliente" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    
                       
                    <asp:BoundField ItemStyle-Width="70" DataField="porcentaje" SortExpression="porcentaje" HeaderText="Porcentaje" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
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
            Nueva distribuci&oacute;n
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información del la distribuci&oacute;n</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblEmpresa" runat="server">Nombre del cliente:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtNombre" Width="250" runat="server" CssClass="textEntry" autocomplete="off" Enabled="false"
                             ></asp:TextBox>
                            <asp:TextBox ID="txtCodigoCliente" Width="50" runat="server" 
                                CssClass="textEntry" Enabled="False"></asp:TextBox>
                            <asp:ImageButton ID="IbtBuscarEmpleado" runat="server" 
                                      ImageUrl="~/Images/ver.gif" onclick="IbtBuscarEmpleado_Click" 
                                      CausesValidation="False" ImageAlign="AbsMiddle" />
                            <%--<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                                    CssClass="failureNotification" ErrorMessage="El nombre de la distribuci&oacute;n es obligatorio." Text="El nombre de la distribuci&oacute;n es obligatorio." ToolTip="El nombre de la distribuci&oacute;n es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator CssClass="failureNotification" Display="Dynamic" runat="server" ID="revNombre" ValidationGroup="valGroup" ControlToValidate="txtNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txtCodigoCliente" 
                                    CssClass="failureNotification" ErrorMessage="El nombre del cliente es obligatorio." Text="El nombre del cliente es obligatorio." ToolTip="El nombre del cliente es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal2" runat="server">Empresa:</asp:Literal></td>
                        <td>
                            <asp:TextBox runat="server" ID="lblEmpresaNombre" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal4" runat="server">Porcentaje:</asp:Literal></td>
                        <td>          
                            <asp:TextBox ID="txtMonto" Width="70" runat="server" CssClass="textEntry"></asp:TextBox> %.
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMonto"  Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="El porcentaje es obligatorio." Text="El porcentaje es obligatorio." ToolTip="El porcentaje es obligatorio." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="txtTipoCambioRegular" 
                                    ValidationGroup="valGroup" ControlToValidate="txtMonto" Display="Dynamic"
                                    ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>">
                                    </asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="vdGrossTonnage" runat="server" 
                            ErrorMessage="Porcentaje solo permite de 1 a 100" Text="" Display="Dynamic" CssClass="failureNotification" 
                            ControlToValidate="txtMonto" MinimumValue="1" MaximumValue="100" Type="Integer" />
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="false" ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar Distribuci&oacute;n" ValidationGroup="valGroup"/>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnAtras" runat="server" CausesValidation="false" onclick="btnAtras_Click">Atrás</asp:LinkButton>
            </p>
        </div>
    </asp:Panel>  

    <asp:Panel runat="server" ID="PnlGridEmpleados">
     <asp:HiddenField ID="HdfAux" runat="server" />
                            <asp:Panel runat="server" BackColor="Wheat" ID="PnlListadoEmpleados" style="display:none;" CssClass="modalPopupInventario" Height="350px" 
                    ScrollBars="Vertical" >
                              <div >
                                <asp:ImageButton runat="server" ImageAlign="Right" ID="BtnPnlEmpleadosClose" 
                                      ImageUrl="~/Images/no.png" onclick="BtnPnlEmpleadosClose_Click" 
                                      CausesValidation="False" />
                              </div>
                              <br />
                              <div align="center">
          <center>
      <table border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse"  width="80%" id="AutoNumber3" bgcolor="#C8E6AC">
        <tr>
          <td width="100%">
        <table border="0" cellpadding="3" cellspacing="0" style="border-collapse: collapse" bordercolor="#111111" width="100%" id="AutoNumber2">
          <tr>
            <td width="14%">
            <p align="right"><b>Texto:</b></td>
            <td width="18%">
            <asp:TextBox id="TxtApellidoPaternoBuscar" runat="server" size="40" 
                    class="textoform"></asp:TextBox></td>
            <td width="17%">
           <asp:Button id="BtnBuscarEmpleados"  runat="server" Text="Buscar" 
                    class="textoform" onclick="BtnBuscarEmpleados_Click" 
                    CausesValidation="False"></asp:Button></td>
          </tr>
        </table>
          </td>
        </tr>
      </table> 
      <asp:GridView ID="GrvEmpleados" 
                                      runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
                                      CssClass="mGrid" DataKeyNames="id" GridLines="None" 
                                      onrowcommand="GrvEmpleados_RowCommand" PagerStyle-CssClass="pgr" Width="465px" HorizontalAlign="Left">
                                  <Columns>
                                      <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                      <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                                      <asp:BoundField DataField="EmpresaId" HeaderText="EmpresaId" Visible="false" />
                                      <asp:TemplateField HeaderText="Empresa">
                                        <ItemTemplate>
                                            <asp:Literal runat="server" ID="lblEmpresaNombre" Text ='<%# TraerEmpresa(Container.DataItem) %>' ></asp:Literal>
                                        </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:CommandField ButtonType="Button" HeaderStyle-Width="1px" SelectText="Seleccionar"
                                           ShowSelectButton="true">
                                          <HeaderStyle Width="1px" />
                                      </asp:CommandField>
                                  </Columns>
                                  <PagerStyle CssClass="pgr" />
                                  <AlternatingRowStyle CssClass="alt" />
                                  </asp:GridView>       
          </center>
        
<br />
                             
</div>
<br />
                            
                            </asp:Panel>
                        <asp:ModalPopupExtender ID="PnlListadoEmpleados_ModalPopupExtender" 
             runat="server" DynamicServicePath="" Enabled="True" BackgroundCssClass="modalBackground"
             TargetControlID="HdfAux" PopupControlID="PnlListadoEmpleados">
         </asp:ModalPopupExtender>
                       
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