<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PagosEmpresa.aspx.cs" Inherits="Clientes_PagosEmpresa" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .btnStyle
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
    <asp:HiddenField runat="server" ID="EmpresaId" Value="" />
    <asp:HiddenField runat="server" ID="EmpresaPagoId" Value="" />
    <asp:HiddenField runat="server" ID="hdnEmpresaId" Value="" />
    </ContentTemplate>
    </asp:UpdatePanel>    
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">    
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nuevo pago" onclick="btnNuevo_Click" />
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
        <h2>Pagos de empresas encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> empresas.
        <asp:ObjectDataSource 
            ID="OBJDataSource" runat="server" SelectMethod="TraerXCriterioData" 
            TypeName="RN.Componentes.CPagoEmpresa">
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
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#DDDDDD" 
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
                    <asp:TemplateField ItemStyle-Width="50"  HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false"  CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id")+"="+ DataBinder.Eval(Container.DataItem,"fechaPago")  %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar" Visible="false">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
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
                    <asp:BoundField ItemStyle-Width="150" DataField="montoTotal" 
                        SortExpression="correo" HeaderText="Monto pago" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="100" DataField="fechaPago2" SortExpression="fechaPago2" 
                        HeaderText="Fecha pago" HeaderStyle-HorizontalAlign="Left" 
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
                    <asp:TemplateField ItemStyle-Width="100" Visible="true" HeaderStyle-HorizontalAlign="Center" HeaderText="Imprimir">            
			                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                    <ItemTemplate>
                                    <asp:ImageButton CommandName="Imprimir" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id")+"="+ DataBinder.Eval(Container.DataItem,"fechaPago")  %>' runat="server" ID="btImpresion" ImageUrl='<%# Config.GetPath("Images/print.gif") %>' />
			                    </ItemTemplate>
		            </asp:TemplateField>
                                  
                </Columns>
            </asp:GridView>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Pago empresa
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
                        <td>
                            <asp:Literal ID="Literal7" runat="server">Fecha de registro:</asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="lblFechaSolicitud" runat="server"></asp:Literal>
                        </td>
                    </tr> 
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal1" runat="server">Empresa:</asp:Literal></td>
                        <td>
                            <asp:TextBox ID="txtSearchCI" runat="server" Width="250px" autocomplete="off" Enabled="false"></asp:TextBox><asp:ImageButton ID="IbtBuscarEmpleado" runat="server" 
                                      ImageUrl="~/Images/ver.gif" onclick="IbtBuscarEmpleado_Click" 
                                      CausesValidation="False" ImageAlign="AbsMiddle" /> Ingrese el nombre de la empresa para que aparezcan sugerencias.
                            
                        </td>
                    </tr>  
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal6" runat="server">Seleccione Periodo:</asp:Literal></td>
                        <td>
                        <asp:DropDownList ID="ddlMes" runat="server">
                            <asp:ListItem Text="Enero" Value="01"></asp:ListItem>
                            <asp:ListItem Text="Febrero" Value="02"></asp:ListItem>
                            <asp:ListItem Text="Marzo" Value="03"></asp:ListItem>
                            <asp:ListItem Text="Abril" Value="04"></asp:ListItem>
                            <asp:ListItem Text="Mayo" Value="05"></asp:ListItem>
                            <asp:ListItem Text="Junio" Value="06"></asp:ListItem>
                            <asp:ListItem Text="Julio" Value="07"></asp:ListItem>
                            <asp:ListItem Text="Agosto" Value="08"></asp:ListItem>
                            <asp:ListItem Text="Septiembre" Value="09"></asp:ListItem>
                            <asp:ListItem Text="Octubre" Value="10"></asp:ListItem>
                            <asp:ListItem Text="Noviembre" Value="11"></asp:ListItem>
                            <asp:ListItem Text="Diciembre" Value="12"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlAno" runat="server">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlAno" 
                                    CssClass="failureNotification" ErrorMessage="El a&ntilde;o es obligatorio." Text="El a&ntilde;o es obligatorio." ToolTip="El a&ntilde;o es obligatorio." 
                                    ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                       
                    <tr>
                        <td class="mandatory" valign="top"><asp:Literal ID="Literal21" runat="server">Paquetes adeudados:</asp:Literal></td>
                        <td>  
                        <asp:Button ID="btnCargarDeudas" runat="server" Text="Recuperar deudas de la empresa" 
                                CausesValidation="false" CssClass="btnStyle" onclick="btnCargarDeudas_Click" />
                        <div style="padding-top:10px;">
                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
                            <ContentTemplate>       
             
                                <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" 
                                SelectMethod="TraerPaquetesAdeudadosEmpresa" 
                                    TypeName="RN.Componentes.CClientePaquete" 
                                    OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnEmpresaId" Name="clienteId" 
                                        PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlMes" Name="Mes" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ddlAno" Name="ano" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:GridView ID="grdPaquetesAdeudados" runat="server" AllowPaging="True" 
                                    AutoGenerateColumns="False" BackColor="White" 
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="0px" CellPadding="3" 
                                DataKeyNames="id" DataSourceID="ObjectDataSource7" ForeColor="Black" 
                                GridLines="Vertical" 
                                PageSize="5000" Width="100%" 
                                onpageindexchanging="grdPaquetesAdeudados_PageIndexChanging">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerSettings PageButtonCount="5000" />
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
                                    <asp:BoundField DataField="nombreCliente" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Empleado" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200" 
                                        SortExpression="nombreCliente">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="nombrePaquete" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Paquete" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100" 
                                        SortExpression="nombrePaquete">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha inicio" 
                                        ItemStyle-Width="100">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblfechaRegistro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"fechaRegistro") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha fin" 
                                        ItemStyle-Width="100">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblfechaFin" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FechaFin") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                  
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Precio" 
                                        ItemStyle-Width="100">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrecioPaquete" runat="server" Text='<%# GetMonto(Container.DataItem,"precioPaquete") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField ItemStyle-Width="80" HeaderText="Seleccionar">
                                    <HeaderTemplate>
                                    <asp:CheckBox ID="cbSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="cbSeleccionarMes_OnCheckedChanged1"  />
                                    </HeaderTemplate>
 	                                <ItemTemplate>
		                                <asp:CheckBox id="cbSeleccionarMes" AutoPostBack="true" OnCheckedChanged="cbSeleccionarMes_OnCheckedChanged" name="cbSeleccionarMes" runat="server" /> 
 	                                </ItemTemplate>
	                                    <ItemStyle Width="80px" />
	                                </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        </td>
                    </tr>  
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal2" runat="server">Concepto:</asp:Literal></td>
                        <td>
  
                            <asp:TextBox ID="txtConcepto" Width="350" runat="server" CssClass="textEntry" 
                                ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConcepto" 
                                    CssClass="failureNotification" ErrorMessage="El Concepto es obligatorio." Text="El Concepto es obligatorio." ToolTip="El Concepto es obligatorio." 
                                    ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator1" ValidationGroup="ruvgLicencia" ControlToValidate="txtConcepto" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>              
                    <tr>
                        <td><asp:Literal ID="Literal4" runat="server">Forma de pago:</asp:Literal></td>
                        <td>                                        
                            <asp:DropDownList runat="server" ID="ddlFormaPago" AutoPostBack="True" 
                                onselectedindexchanged="ddlFormaPago_SelectedIndexChanged">
                                <asp:ListItem Text="Efectivo" Value="ef"></asp:ListItem>
                                <asp:ListItem Text="Tarjeta" Value="ta"></asp:ListItem>
                                <asp:ListItem Text="Cheque" Value="ch"></asp:ListItem>
                                <asp:ListItem Text="Transeferencia" Value="tr"></asp:ListItem>
                                <asp:ListItem Text="Intercambio" Value="in"></asp:ListItem>
                                
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal5" runat="server">N&uacute;mero factura:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNumeroFactura" MaxLength="20"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="revtxtNumeroFactura" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNumeroFactura" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoTarjeta" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal10" runat="server">D&iacute;gitos tarjeta:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtDigitosTarjeta"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator2" 
                            ValidationGroup="valGroup2" ControlToValidate="txtDigitosTarjeta" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDigitosTarjeta" 
                            CssClass="failureNotification" ErrorMessage="D&iacute;gitos obligatorios." Text="D&iacute;gitos obligatorios." 
                            ToolTip="D&iacute;gitos obligatorios." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoTarjeta2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal11" runat="server">N&uacute;mero aprobaci&oacute;n POS:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNumeroAprobacionPOS"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator5" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNumeroAprobacionPOS" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNumeroAprobacionPOS" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de aprobaci&oacute;n obligatorio." Text="N&uacute;mero de aprobaci&oacute;n obligatorio." 
                            ToolTip="N&uacute;mero de aprobaci&oacute;n obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCheque" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal12" runat="server">N&uacute;mero de cheque:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNumeroCheque"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator6" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNumeroCheque" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNumeroCheque" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de cheque obligatorio." Text="N&uacute;mero de cheque obligatorio." 
                            ToolTip="N&uacute;mero de cheque obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCheque2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal13" runat="server">Nombre del banco cheque:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNombreBancoCheque"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator7" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNombreBancoCheque" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNombreBancoCheque" 
                            CssClass="failureNotification" ErrorMessage="Nombre del banco obligatorio." Text="Nombre del banco obligatorio." 
                            ToolTip="Nombre del banco obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCuenta" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal14" runat="server">N&uacute;mero de cuenta de transferencia:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNumeroCuentaTransferencia"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator8" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNumeroCuentaTransferencia" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNumeroCuentaTransferencia" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de cuenta obligatorio." Text="N&uacute;mero de cuenta obligatorio." 
                            ToolTip="N&uacute;mero de cuenta obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCuenta2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal15" runat="server">Nombre del banco de transferencia:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNombreBancoTransferencia"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator9" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNombreBancoTransferencia" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNombreBancoTransferencia" 
                            CssClass="failureNotification" ErrorMessage="Nombre del banco obligatorio." Text="Nombre del banco obligatorio." 
                            ToolTip="Nombre del banco obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoIntercambio" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal16" runat="server">Intercambio:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtIntercambioId"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator10" 
                            ValidationGroup="valGroup2" ControlToValidate="txtIntercambioId" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtIntercambioId" 
                            CssClass="failureNotification" ErrorMessage="C&oacute;digo de intercambio obligatorio." Text="C&oacute;digo de intercambio obligatorio." 
                            ToolTip="C&oacute;digo de intercambio obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoIntercambio2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal17" runat="server">N&uacute;mero de pago:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNroPago"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator11" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNroPago" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtNroPago" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de intercambio obligatorio." Text="N&uacute;mero de intercambio obligatorio." 
                            ToolTip="N&uacute;mero de intercambio obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal3" runat="server">Periodo a pagar:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtPeriodo" Width="80px"></asp:TextBox>
                            <asp:Image ID="ImgFechaNacimento" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                            <asp:CalendarExtender ID="txtFechaNacimento_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtPeriodo" PopupButtonID="ImgFechaNacimento" PopupPosition="BottomLeft" Format="MM/yyyy">
                                    </asp:CalendarExtender>
                        </td>
                    </tr>
                    
                </table>
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
                            <ContentTemplate>       
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr runat="server" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal18" runat="server">Fecha periodo inicio:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtFechaPeriodoInicio"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFechaPeriodoInicio" 
                            CssClass="failureNotification" ErrorMessage="Fecha de inicio obligatoria." Text="Fecha de inicio obligatoria." 
                            ToolTip="Fecha de inicio obligatoria." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal19" runat="server">Fecha periodo fin:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtFechaPeriodoFin"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFechaPeriodoFin" 
                            CssClass="failureNotification" ErrorMessage="Fecha final obligatoria." Text="Fecha final obligatoria." 
                            ToolTip="Fecha final obligatoria." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal20" runat="server">Monto:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtMonto" Width="80px"></asp:TextBox>.Bs
                            <asp:RegularExpressionValidator CssClass="failureNotification" runat="server" ID="RegularExpressionValidator12" 
                            ValidationGroup="valGroup2" ControlToValidate="txtMonto" 
                            ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMonto" 
                                    CssClass="failureNotification" ErrorMessage="El monto es obligatorio." Text="El monto es obligatorio." ToolTip="El monto es obligatorio." 
                                    ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPromocion" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal24" runat="server">Descuento:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtDescuento" Width="80px" Enabled="false"></asp:TextBox>.Bs <asp:Literal ID="lblNombreDescuento" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr runat="server" id="trPromocion2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal25" runat="server">Monto - descuento:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtTotalDescuento" Width="80px" Enabled="false"></asp:TextBox>.Bs
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal9" runat="server">Estado:</asp:Literal></td>
                        <td>                                        
                            <asp:checkbox runat="server" id="cbEstadoPago" />
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </fieldset>
            <p class="submitButton">
                <asp:Button CssClass="btnStyle" CausesValidation="true"  ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" runat="server" CommandName="MoveNext" Text="Guardar" ValidationGroup="valGroup2"/>
                &nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="btnAtras" runat="server" onclick="btnAtras_Click">Atrás</asp:LinkButton>
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
      <table>
        <colgroup>
            <col width="10px" />
            <col width="*" />
        </colgroup>
        <tr>
        <td>&nbsp;</td>
        <td>
      <asp:GridView ID="GrvEmpleados" 
                                      runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" 
                                      CssClass="mGrid" DataKeyNames="id" GridLines="None" 
                                      onrowcommand="GrvEmpleados_RowCommand" PagerStyle-CssClass="pgr" Width="300px" HorizontalAlign="Left">
                                  <Columns>
                                      <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-HorizontalAlign="Left" />
                                      <asp:CommandField ButtonType="Button" HeaderStyle-Width="1px" SelectText="Seleccionar"
                                           ShowSelectButton="true">
                                          <HeaderStyle Width="1px" />
                                      </asp:CommandField>
                                  </Columns>
                                  <PagerStyle CssClass="pgr" />
                                  <AlternatingRowStyle CssClass="alt" />
                                  </asp:GridView>   
           </td>
           </tr>
           </table>    
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

    <asp:Panel runat="server" ID="pnlReporte" Visible="false">
            <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
                    ID="btnImpresionRecibo" runat="server" Text="Atrás"  Enabled="true" 
                    CausesValidation="false" onclick="btnImpresionRecibo_Click" 
                      />
                      <br />
                <rsweb:ReportViewer ID="rpRecibo" runat="server" Width="933px" Height="720px">
                </rsweb:ReportViewer>
                
           
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