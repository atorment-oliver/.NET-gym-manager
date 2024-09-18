<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Grupos.aspx.cs" Inherits="Servicios_Grupo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">  
        <script src="../Scripts/jquery.autocomplete.js" type="text/javascript"></script>
        <script src="../Scripts/jquery.msgBox.v1.js" type="text/javascript"></script> 
    <script type="text/javascript">
        $(document).ready(function () {
            //Cliente
            $('#dialogServicios').dialog({
                autoOpen: false,
                draggable: true,
                modal: true,
                width: 700,
                closeOnEscape: false,
                draggable: true,
                title: "Datos del servicio",
                open: function (type, data) {
                    $(".ui-dialog-titlebar-close").hide();
                    $(this).parent().appendTo("form");
                }
            });

            
            
        });

        function showDialog(id) {
            $('#' + id).dialog("open");
        }

        function closeDialog(id) {
            $('#' + id).dialog("close");
        }
        
       
        $.fn.msgBox.defaults =
	    {
	        height: 190,
	        width: 300,
	        title: "Informaciones",
	        modal: true,
	        resizable: false,
	        closeOnEscape: true
	    };
        
	    
    </script>
    
    
    <asp:HiddenField runat="server" ID="GrupoId" Value="" />
    <asp:HiddenField runat="server" ID="ServicioId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar nueva disciplina" 
            onclick="btnNuevo_Click" />
            
        <br />
        <h2>Filtro de b&uacute;squeda</h2>    
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
                    <td><asp:Literal ID="lblBuscarServicio" runat="server">Servicio:</asp:Literal></td>
                    <td>
                        <asp:DropDownList ID="ddlBuscarServicio" Width="300" runat="server" CssClass="textEntry"></asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td><asp:Literal ID="lblBuscarEstado" runat="server">Estado:</asp:Literal></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstado">
                            <asp:ListItem Selected="True" Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" />
        </p>
        <h2>Disciplinas encontradas</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> disciplinas.
        <asp:ObjectDataSource 
            ID="GruposDataSource" runat="server" SelectMethod="TraerXCriterioD" 
            TypeName="RN.Componentes.CGrupo">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtBuscarNombre" Name="nombre" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="ddlBuscarServicio" Name="servicioId" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="ddlEstado" Name="estado" 
                    PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="GruposDataSource" 
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
                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar" ItemStyle-Width="100">
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false" CommandName="Eliminar" Visible="<%# EliminarVisible(Container.DataItem) %>" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="250" DataField="nombre" Visible="false"
                        SortExpression="nombre" HeaderText="Nombre del grupo" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="120" DataField="sala" 
                        SortExpression="sala" HeaderText="Sala" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150" DataField="horario" 
                        SortExpression="horario" HeaderText="Horario" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="150" DataField="nombreServicio" 
                        SortExpression="nombreServicio" HeaderText="Servicio" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="100" DataField="fecha" SortExpression="fecha" 
                        HeaderText="Fecha creación" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" SortExpression="finDeSemana" HeaderText="Lunes a Viernes">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Image  runat="server" ID="FinSemana" ImageUrl='<%# FinSemana(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>     
                    <%--<asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Estado">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Image  runat="server" ID="IsApproved" ImageUrl='<%# IsApproved(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Nuevo grupo
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Informaci&oacute;n de la disciplina</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="Literal1" runat="server">Activo:</asp:Literal></td>
                        <td>                                        
                            <asp:CheckBox ID="cbEstado" Text=""  runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="register"><asp:Label ID="lblServicio" runat="server" class="mandatory">Servicio:</asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtServicio" Width="250"
                                runat="server" CssClass="textEntry" autocomplete="off" Visible="false"></asp:TextBox>
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                            <asp:DropDownList ID="ddlServicio" runat="server" Width="250px" 
                                AutoPostBack="true" onselectedindexchanged="ddlServicio_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:LinkButton ID="lbNuevo" runat="server" onclick="lbNuevo_Click">Nuevo Servicio</asp:LinkButton>
                            </ContentTemplate>
        </asp:UpdatePanel>
                                        <br />
                            <%--<asp:RegularExpressionValidator  Display="Dynamic" CssClass="failureNotification" runat="server" ID="revDescripcion" 
                            ValidationGroup="valGroup" ControlToValidate="txtServicio" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtServicio" 
                            CssClass="failureNotification" ErrorMessage="El nombre del servicio es obligatorio." Text="El nombre del servicio es obligatorio." 
                            ToolTip="El nombre del servicio es obligatorio." ValidationGroup="valGroup"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="register">Cupo:</td>
                        <td>
                            <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                            
                            <asp:TextBox ID="txtCupo" Width="150"
                                runat="server" CssClass="textEntry" ></asp:TextBox>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:RegularExpressionValidator  Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator1" 
                            ValidationGroup="valGroup" ControlToValidate="txtCupo" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>"></asp:RegularExpressionValidator>
                            
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td class="mandatory"><asp:Literal ID="lblEmpresa" runat="server">Nombre del grupo:</asp:Literal></td>
                        <td>        
                            <asp:TextBox ID="txtNombre" Width="150" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="rfvNombre" runat="server" ControlToValidate="txtNombre" 
                            CssClass="failureNotification" ErrorMessage="El nombre de la disciplina es obligatoria." Text="El nombre de la disciplina es obligatoria." 
                            ToolTip="El nombre de la disciplina es obligatoria." 
                            ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" CssClass="failureNotification" 
                            runat="server" ID="revNombre" ValidationGroup="valGroup" 
                            ControlToValidate="txtNombre" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="mandatory"><asp:Literal ID="lblSala" runat="server">Sala:</asp:Literal></td>
                        <td> 
                            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
                                <ContentTemplate>                                       
                                <asp:DropDownList runat="server" AutoPostBack="true" Width="250px" ID="ddlSala" 
                                onselectedindexchanged="ddlSala_SelectedIndexChanged"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    
                    <tr runat="server" id="passwordConfirmTR">
                        <td class="mandatory" colspan="2">
                        <asp:UpdatePanel ID="upNewUpdatePanel" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
                        <ContentTemplate>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                SelectMethod="Grupo_TraerHorarioValidando" 
                                TypeName="RN.Componentes.CGrupo" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlSala" Name="salaId" 
                                        PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>

                            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="grdHorario" runat="server" DataSourceID="ObjectDataSource2" 
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
                                <asp:BoundField DataField="id" HeaderText="id" Visible="false" />

                                <asp:TemplateField ItemStyle-Width="50" >
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbSeleccion" Enabled="false" name="cbSeleccion" runat="server" /> 
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                
                                
                                <asp:BoundField ItemStyle-Width="150" DataField="Hora" 
                                    SortExpression="Hora" HeaderText="Horario" 
                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="150" DataField="nombreSala" 
                                    SortExpression="nombreSala" HeaderText="Sala" HeaderStyle-HorizontalAlign="Left" 
                                    ItemStyle-HorizontalAlign="Left" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                
                                <asp:TemplateField ItemStyle-Width="150" HeaderText="Lunes">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbLunes" AutoPostBack="true" OnCheckedChanged="cbLunes_OnCheckedChanged"  Visible='<%# !Convert.ToBoolean(Eval("Lunes")) %>' name="cbLunes" runat="server" /> 
                                    <asp:Literal ID="lblLunes" runat="server" Visible='<%# Convert.ToBoolean(Eval("Lunes")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoLunes") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Martes">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbMartes" AutoPostBack="true" OnCheckedChanged="cbMartes_OnCheckedChanged"  Visible='<%# !Convert.ToBoolean(Eval("Martes")) %>' name="cbMartes" runat="server" /> 
                                    <asp:Literal ID="lblMartes" runat="server" Visible='<%# Convert.ToBoolean(Eval("Martes")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoMartes") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Miercoles">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbMiercoles" AutoPostBack="true" OnCheckedChanged="cbMiercoles_OnCheckedChanged"  Visible='<%# !Convert.ToBoolean(Eval("Miercoles")) %>' name="cbMiercoles" runat="server" /> 
                                    <asp:Literal ID="lblMiercoles" runat="server" Visible='<%# Convert.ToBoolean(Eval("Miercoles")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoMiercoles") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Jueves">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbJueves" AutoPostBack="true" OnCheckedChanged="cbJueves_OnCheckedChanged"  Visible='<%# !Convert.ToBoolean(Eval("Jueves")) %>' name="cbJueves" runat="server" /> 
                                    <asp:Literal ID="lblJueves" runat="server" Visible='<%# Convert.ToBoolean(Eval("Jueves")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoJueves") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Viernes">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbViernes" AutoPostBack="true" OnCheckedChanged="cbViernes_OnCheckedChanged"  Visible='<%# !Convert.ToBoolean(Eval("Viernes")) %>' name="cbViernes" runat="server" /> 
                                    <asp:Literal ID="lblViernes" runat="server" Visible='<%# Convert.ToBoolean(Eval("Viernes")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoViernes") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150" HeaderText="Sabado">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbSabado" AutoPostBack="true" OnCheckedChanged="cbSabado_OnCheckedChanged"  Visible='<%# !Convert.ToBoolean(Eval("Sabado")) %>' ToolTip='<%# Convert.ToBoolean(Eval("finDeSemana")) %>' name="cbSabado" runat="server" /> 
                                    <asp:Literal ID="lblSabado" runat="server" Visible='<%# Convert.ToBoolean(Eval("Sabado")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoSabado") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150" HeaderText="Domingo">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbDomingo" AutoPostBack="true" OnCheckedChanged="cbDomingo_OnCheckedChanged"  Visible='<%# !Convert.ToBoolean(Eval("Domingo")) %>' ToolTip='<%# Convert.ToBoolean(Eval("finDeSemana")) %>' name="cbDomingo" runat="server" /> 
                                    <asp:Literal ID="lblDomingo" runat="server" Visible='<%# Convert.ToBoolean(Eval("Domingo")) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoDomingo") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" 
                                SelectMethod="Grupo_TraerHorarioValidando" 
                                TypeName="RN.Componentes.CGrupo" 
                                OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlSala" Name="salaId" 
                                        PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>

                            <asp:GridView  HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="grdHorarioHor" runat="server" DataSourceID="ObjectDataSource3" 
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
                                <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                <asp:TemplateField ItemStyle-Width="50" >
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbSeleccion" Enabled="false" name="cbSeleccion" runat="server" /> 
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                <asp:BoundField ItemStyle-Width="150" DataField="Hora" 
                                    SortExpression="Hora" HeaderText="Horario" 
                                    HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="150" DataField="nombreSala" 
                                    SortExpression="nombreSala" HeaderText="Sala" HeaderStyle-HorizontalAlign="Left" 
                                    ItemStyle-HorizontalAlign="Left" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="150px" />
                                </asp:BoundField>
                                
                                <asp:TemplateField ItemStyle-Width="150" HeaderText="Lunes">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbLunes" AutoPostBack="true" OnCheckedChanged="cbLunes_OnCheckedChanged2" Checked='<%# lblVisibleLunes2(Container.DataItem) %>' Enabled='<%# !lblVisibleLunes1(Container.DataItem) %>' Visible='<%# !lblVisibleLunes1(Container.DataItem) %>' name="cbLunes" runat="server" /> 
                                    <asp:Literal ID="lblLunes" runat="server" Visible='<%# lblVisibleLunes1(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoLunes") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Martes">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbMartes" AutoPostBack="true" OnCheckedChanged="cbMartes_OnCheckedChanged2" Checked='<%# lblVisibleMartes2(Container.DataItem) %>' Enabled='<%# !lblVisibleMartes1(Container.DataItem) %>' Visible='<%# !lblVisibleMartes1(Container.DataItem) %>' name="cbMartes" runat="server" /> 
                                    <asp:Literal ID="lblMartes" runat="server" Visible='<%# lblVisibleMartes1(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoMartes") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Miercoles">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbMiercoles" AutoPostBack="true" OnCheckedChanged="cbMiercoles_OnCheckedChanged2" Checked='<%# lblVisibleMiercoles2(Container.DataItem) %>' Enabled='<%# !lblVisibleMiercoles1(Container.DataItem) %>' Visible='<%# !lblVisibleMiercoles1(Container.DataItem) %>' name="cbMiercoles" runat="server" /> 
                                    <asp:Literal ID="lblMiercoles" runat="server" Visible='<%# lblVisibleMiercoles1(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoMiercoles") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Jueves">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbJueves" AutoPostBack="true" OnCheckedChanged="cbJueves_OnCheckedChanged2" Checked='<%# lblVisibleJueves2(Container.DataItem) %>' Enabled='<%# !lblVisibleJueves1(Container.DataItem) %>' Visible='<%# !lblVisibleJueves1(Container.DataItem) %>' name="cbJueves" runat="server" /> 
                                    <asp:Literal ID="lblJueves" runat="server" Visible='<%# lblVisibleJueves1(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoJueves") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                 <asp:TemplateField ItemStyle-Width="150" HeaderText="Viernes">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbViernes" AutoPostBack="true" OnCheckedChanged="cbViernes_OnCheckedChanged2" Checked='<%# lblVisibleViernes2(Container.DataItem) %>' Enabled='<%# !lblVisibleViernes1(Container.DataItem) %>' Visible='<%# !lblVisibleViernes1(Container.DataItem) %>' name="cbViernes" runat="server" /> 
                                    <asp:Literal ID="lblViernes" runat="server" Visible='<%# lblVisibleViernes1(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoViernes") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150" HeaderText="Sabado">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbSabado" AutoPostBack="true" OnCheckedChanged="cbSabado_OnCheckedChanged2" Checked='<%# lblVisibleSabado2(Container.DataItem) %>' Enabled='<%# !lblVisibleSabado1(Container.DataItem) %>' Visible='<%# !lblVisibleSabado1(Container.DataItem) %>' ToolTip='<%# Convert.ToBoolean(Eval("finDeSemana")) %>' name="cbSabado" runat="server" /> 
                                    <asp:Literal ID="lblSabado" runat="server" Visible='<%# lblVisibleSabado1(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoSabado") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                                <asp:TemplateField ItemStyle-Width="150" HeaderText="Domingo">
 	                            <ItemTemplate>
		                            <asp:CheckBox id="cbDomingo" AutoPostBack="true" OnCheckedChanged="cbDomingo_OnCheckedChanged2" Checked='<%# lblVisibleDomingo2(Container.DataItem) %>' Enabled='<%# !lblVisibleSabado1(Container.DataItem) %>' Visible='<%# !lblVisibleDomingo1(Container.DataItem) %>' ToolTip='<%# Convert.ToBoolean(Eval("finDeSemana")) %>' name="cbDomingo" runat="server" /> 
                                    <asp:Literal ID="lblDomingo" runat="server" Visible='<%# lblVisibleDomingo1(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"grupoDomingo") %>'></asp:Literal>
 	                            </ItemTemplate>
	                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        
                         </ContentTemplate>
                         </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p class="submitButton">
                                <asp:Button CssClass="btnStyle" CausesValidation="false" ID="CreateUserButton" OnClick="RegisterUser_CreatedUser" 
                                    runat="server" CommandName="MoveNext" Text="Guardar" 
                                    ValidationGroup="valGroup"/>
                                &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="btnAtras" runat="server" onclick="btnAtras_Click">Atrás</asp:LinkButton>
                            </p>
                        </td>
                    </tr>
                   
                </table>
            </fieldset>

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
    <div id='dialogServicios'>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
            
    
                        <table cellpadding="0" cellspacing="0" border="0" class="nonBorder">
                            <tr>
                                <td>Nombre:</td>
                                <td>
                                    <asp:TextBox ID="txtNombreServicio" runat="server" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator  Display="Dynamic" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreServicio" 
                            CssClass="failureNotification" ErrorMessage="El nombre de la disciplina es obligatoria." Text="El nombre de la disciplina es obligatorio." 
                            ToolTip="El nombre de la disciplina es obligatoria." 
                            ValidationGroup="valGroup2"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" CssClass="failureNotification" 
                            runat="server" ID="RegularExpressionValidator2" ValidationGroup="valGroup2" 
                            ControlToValidate="txtNombreServicio" ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                Cupos:
                                </td>
                                <td>
                                 <asp:TextBox ID="txtCupoServicio" Width="150"
                                runat="server" CssClass="textEntry" ></asp:TextBox>
                            <asp:RegularExpressionValidator  Display="Dynamic" CssClass="failureNotification" runat="server" ID="RegularExpressionValidator3" 
                            ValidationGroup="valGroup2" ControlToValidate="txtCupoServicio" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>"></asp:RegularExpressionValidator>
                            
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                <br />
                                <asp:Button ID="btnGuardarServicios" class="ui-button ui-widget ui-state-default ui-corner-all" CausesValidation="false" 
                                        ValidationGroup="valGroup2" runat="server" Text="Guardar" 
                                        onclick="btnGuardarServicios_Click" />
                                <asp:LinkButton ID="btnCerrarServicios" CssClass="btnStyle"  CausesValidation="false" 
                                        runat="server" Text="Cerrar" onclick="btnCerrarServicios_Click" />
                                </td>
                            </tr>
                            
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
        </div>
</asp:Content>