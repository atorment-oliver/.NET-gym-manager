<%@ Page Title="" Language="C#" MasterPageFile="~/Cliente.master" AutoEventWireup="true" CodeFile="ClienteExterno.aspx.cs" Inherits="Clientes_Clientes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="../Controles/RegistrarCliente.ascx" tagname="Cliente" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/jquery-ui-1.7.2.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />     
    <style type="text/css">
        .textEntry
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">    
    <script type="text/javascript">
    $(document).ready(function () {
        //Cliente
        $('#dialogCliente').dialog({
            autoOpen: false,
            draggable: true,
            modal: true,
            width: 700,
            closeOnEscape: false,
            draggable: true,
            title: "Datos del cliente",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });

        //Paquetes
        $('#dialogPaquetes').dialog({
            autoOpen: false,
            draggable: true,
            modal: true,
            title: "Selección del paquete a contratar",
            closeOnEscape: false,
            width: 760,
            height: 500,
            draggable: true,
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        //Historial
        $('#dialogHistorial').dialog({
            autoOpen: false,
            draggable: true,
            modal: true,
            title: "Historial de paquetes contratados",
            width: 750,
            closeOnEscape: false,
            draggable: true,
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogExtensiones').dialog({
            autoOpen: false,
            draggable: true,
            modal: true,
            title: "Selección de paquete adicional",
            width: 550,
            closeOnEscape: false,
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogExtender').dialog({
            autoOpen: false,
            draggable: true,
            width: 730,
            closeOnEscape: false,
            modal: true,
            title: "Extender el paquete actual",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogLicencia').dialog({
            autoOpen: false,
            draggable: true,
            width: 730,
            closeOnEscape: false,
            modal: true,
            title: "Solicitud de licencia",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogLicencia').dialog({
            autoOpen: false,
            draggable: true,
            width: 530, 
            closeOnEscape: false,
            modal: true,
            title: "Licencias",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogHistorialLicencias').dialog({
            autoOpen: false,
            draggable: true,
            width: 730,
            closeOnEscape: false,
            modal: true,
            title: "Licencias solicitadas",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogRecibos').dialog({
            autoOpen: false,
            draggable: true,
            width: 730,
            closeOnEscape: false,
            modal: true,
            title: "Pagos registrados",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogPagos').dialog({
            autoOpen: false,
            draggable: true,
            width: 730,
            closeOnEscape: false,
            modal: true,
            title: "Pagos registrados",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogPromocion').dialog({
            autoOpen: false,
            draggable: true,
            width: 730,
            closeOnEscape: false,
            modal: true,
            title: "Registrar promoción cliente",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogImpresionLicencia').dialog({
            autoOpen: false,
            draggable: true,
            width: 900,
            height: 820,
            closeOnEscape: false,
            modal: true,
            title: "Licencia Impresión",
            open: function (type, data) {
                $(".ui-dialog-titlebar-close").hide();
                $(this).parent().appendTo("form");
            }
        });
        $('#dialogImpresionRecibo').dialog({
            autoOpen: false,
            draggable: true,
            width: 900,
            height: 620,
            closeOnEscape: false,
            modal: true,
            title: "Recibo Impresión",
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
    function LimpiarBusqueda() {
        $("#<%=txtSearchCI.ClientID%>").val('');
        $("#<%= hdnAutoCompleteClienteId.ClientID %>").val('');
    }
    function CargarBusqueda(id, nombreCargarBusqueda, ci) {
        $("#<%=txtSearchCI.ClientID%>").val(nombreCargarBusqueda + ' - ' + ci);
        $("#<%= hdnAutoCompleteClienteId.ClientID %>").val(id);
    }
    $(document).ready(function () {
        $("#<%=txtSearchCI.ClientID%>").autocomplete('../Handlers/ClienteCi.ashx').result(function (event, data, formatted) {
            if (data) {
                //alert('Value: ' + data[1]);
                $("#<%= hdnAutoCompleteClienteId.ClientID %>").val(data[1]);
                $("#<%= NuevoCliente.ClientID %>").val('');
                //__doPostBack('<%=btnBuscar.ClientID%>', 'btnBuscar_Click');
            }
            else {
                $("#<%= hdnAutoCompleteClienteId.ClientID %>").val('-1');
            }
        });
    });
    function Mensaje() {
        $.msgBox('"+ El M +"');
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
	    function TestCheckBox() {
	        var frm = document.forms[0];
	        for (i = 0; i < frm.elements.length; i++) {
	            if (frm.elements[i].type == "checkbox" && frm.elements[i].id.indexOf("<%= grdPaquetesAdeudados.ClientID %>") == 0) {

	                frm.elements[i].checked = true;

	            }
	        }
	    }
	    
    </script>
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hdnAutoCompleteClienteId" runat="server" Value="" />
            <asp:HiddenField ID="ClientePaqueteId" runat="server" Value="" />
            <asp:HiddenField ID="hdnServicioId" runat="server" Value="" />
            <asp:HiddenField ID="Adicionar" runat="server" Value="" />
            <asp:HiddenField ID="NuevoCliente" runat="server" Value="" />
            <asp:HiddenField ID="HabilitarCombo" runat="server" Value="" />
            <asp:HiddenField ID="Datos" runat="server" Value="" />
            <asp:HiddenField ID="Combo" runat="server" Value="" />
            <asp:HiddenField ID="PromocionClienteId" runat="server" Value="" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <colgroup>
            <col width="70%" />
            <col width="30%" />
        </colgroup>
        <tr>
            <td>
                <fieldset class="register" style="width:620px">
                    <legend>Buscador de clientes</legend>
                    <table border="0" cellpadding="2" cellspacing="0">
                        <colgroup>
                            <col width="200px" />
                            <col width="*" />
                            <col width="*" />
                        </colgroup>
                        <tr>
                            <td>
                                <asp:Literal runat="server" ID="lblBuscadorCi" Text="Nombre o C.I. del cliente:"></asp:Literal>
                            </td>
                            <td>                    
                                <asp:TextBox ID="txtSearchCI" runat="server" Width="350px" autocomplete="off"></asp:TextBox>                    
                            </td>
                            <td>
                                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="btnBuscar" runat="server" Text="Recuperar" 
                                    onclick="btnBuscar_Click" Visible="true" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
            <td style="text-align:center;padding-top:15px;">
                <asp:UpdatePanel ID="upNewUpdatePanel" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
                    <ContentTemplate>
                        <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="btnNuevo" runat="server" Text="Registrar Nuevo Cliente" onclick="btnNuevo_Click"/>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <hr />
    <asp:UpdatePanel ID="upCliente" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
    <ContentTemplate>
    <table cellpadding="2" cellspacing="0" border="0">
        <tr>
            <td>
                        <fieldset class="register" style="width:350px">
                        <legend>Informaci&oacute;n del cliente</legend>
                        <table border="0" cellpadding="2" cellspacing="0">
                            <colgroup>
                                <col width="150px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblNumCliente" Text="C&oacute;digo de cliente:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblNumeroCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblNombre" Text="Nombre completo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblNombreCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblFecha" Text="Fecha de ingreso:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaIngreso"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblEdad" Text="Edad:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEdadCliente"></asp:Label>
                                </td>
                            </tr>                                                        
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefono" Text="Tel&eacute;fono:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefonoCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDireccion" Text="Direcci&oacute;n:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblDireccionCliente"></asp:Label>
                                </td>
                            </tr>  
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblCi" Text="C.I:"></asp:Label>
                                </td>
                                <td> 
                                    <asp:Label runat="server" ID="lblCiCliente"></asp:Label>
                                </td>
                            </tr>                          
                        </table>
                    </fieldset>
                        
        </td>
        <td style="vertical-align:top">
           
                    <fieldset class="register" style="width:430px">
                        <legend>Informaci&oacute;n del Paquete</legend>
                        <table border="0" cellpadding="2" cellspacing="0">
                            <colgroup>
                                <col width="170px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPaquete" Text="Paquete:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaqueteCliente" runat="server" Width="200px" 
                                        Enabled="false" 
                                        onselectedindexchanged="ddlPaqueteCliente_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:LinkButton ID="lbEliminar" runat="server" onclick="lbEliminar_Click">Eliminar</asp:LinkButton>
                                </td>
                            </tr>
                             <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPrecio" Text="Precio:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPrecioPaquete"></asp:Label>
                                </td>
                            </tr>
                            <tr style="background-color:#f1f1f1;color:#54ac24;font-size:12px;">
                                <td>
                                    <asp:Label runat="server" ID="lblEstadoPaqueteLabel" Text="Estado pago:"></asp:Label>
                                </td>
                                <td style="font-size:14px;font-weight:bolder;">
                                    <asp:Label runat="server" ID="lblEstadoPagoPaquete"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label7" Text="Estado paquete:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEstadoPaquete"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaInicioLabel" Text="Fecha inicio:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaInicio"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblDiasLic" Text="D&iacute;as de licencia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblDiasLicencia"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblTiempo" Text="Fecha expira el paquete:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTiempoPaquete"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblHistorial" Text="Historial de paquetes:"></asp:Label>
                                </td>
                                <td>
                                    <a id="Button1" style="width:250px" href="javascript:showDialog('dialogHistorial');">Historial</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label3" Text="Licencias:"></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" ID="lbLicencias" onclick="lbLicencias_Click" 
                                        Enabled="False">Licencias</asp:LinkButton>
                                </td>
                            </tr>
                        </table>  
                    </fieldset>
                                  
        </td>
        <td style="vertical-align:top" rowspan="2">
            <br />
               
                <table>
                    <tr>
                        <td>
                            <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" runat="server" ID="btnCliente" style="width:100px;white-space:normal" type="button" 
                                Text="Actualizar Datos" onclick="btnCliente_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" runat="server" ID="btndPaquetes" style="width:100px" Text="Paquetes" onclick="btndPaquetes_Click" />
                        </td>
                    </tr>
                    
                   
                </table>
              
        </td>
    </tr>
    <tr>
        <td style="vertical-align:top">
       
                    <asp:Panel runat="server" ID="pnlEmpresa">
                    <fieldset class="register" style="width:350px">
                        <legend>Empresa</legend>
                        <table border="0" cellpadding="2" cellspacing="0">
                            <colgroup>
                                <col width="150px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblEmpresa" Text="Nombre:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblEmpresaCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefonoEmp" Text="Tel&eacute;fono:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblTelefonoEmpresa"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblPersona" Text="Persona de contacto:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPersonaEmpresa"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label8" Text="% cobertura empresa:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCoberturaEmpresa"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label9" Text="Cobertura empresa Bs:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCoberturaEmpresaMonto"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    </asp:Panel>
                       <asp:Panel runat="server" ID="pnlPromocion">
                    <fieldset class="register" style="width:350px">
                        <legend>Promoci&oacute;n</legend>
                        <table border="0" cellpadding="2" cellspacing="0">
                            <colgroup>
                                <col width="150px" />
                                <col width="*" />
                            </colgroup>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label4" Text="Nombre:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblPromocionCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label6" Text="Costo:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblCostoPromocionCliente"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="Label5" Text="Fecha de asignaci&oacute;n:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="lblFechaAsignacionPromocion">-</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:LinkButton ID="lbEliminarPromocion" runat="server" 
                                        onclick="lbEliminarPromocion_Click" Visible="false">Eliminar promoci&oacute;n</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    </asp:Panel>
        </td>
        <td style="vertical-align:top">
      
                    <fieldset class="register" style="width:430px">
                        <legend>Informaci&oacute;n de disciplinas</legend>
                        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="Grupo_TraerXServicioHorarioCliente" TypeName="RN.Componentes.CGrupo">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ClientePaqueteId" Name="codigo" PropertyName="Value" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:GridView ID="grdServicios" runat="server" AllowPaging="True" DataKeyNames="id" 
                            AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                            BorderColor="#999999" BorderStyle="Solid" BorderWidth="0px" CellPadding="3" 
                             ForeColor="Black" 
                            GridLines="Vertical" onpageindexchanging="grdServicios_PageIndexChanging" OnRowCommand="ResultGrid_RowCommand" 
                            Width="100%" onrowdatabound="grdServicios_RowDataBound" 
                            DataSourceID="ObjectDataSource3" PageSize="5" >
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                            <EmptyDataTemplate>
                                No se encontraron servicios.
                                    <asp:LinkButton ID="lbRegistrar" runat="server" CommandArgument="Registrar" CommandName="Registrar">Registrar</asp:LinkButton>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="Id" Visible="false" />

                                <asp:BoundField DataField="nombreServicio" HeaderStyle-HorizontalAlign="Left" 
                                    HeaderText="Disciplina" ItemStyle-HorizontalAlign="Left" 
                                    ItemStyle-Width="150" SortExpression="nombreServicio">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" Width="110px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="hora" HeaderStyle-HorizontalAlign="Left" 
                                    HeaderText="Horario" ItemStyle-HorizontalAlign="Left" 
                                    ItemStyle-Width="150" SortExpression="hora">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField ItemStyle-Width="180" HeaderStyle-HorizontalAlign="Center" SortExpression="finDeSemana" HeaderText="D&iacute;as">            
			                        <HeaderStyle HorizontalAlign="Center" />
			                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                        <ItemTemplate>
                                        <asp:Label  runat="server" ID="FinSemana" Text='<%# ListarDias(Container.DataItem) %>'  ></asp:Label>
			                        </ItemTemplate>
		                        </asp:TemplateField> 
                                <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Modificar" Visible="false">            
			                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                    <ItemTemplate>
                                    <asp:ImageButton CommandName="Modificar" Visible='<%# HabilitarModificar() %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Modificar" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			                    </ItemTemplate>
		                        </asp:TemplateField>  
                                <asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                    <ItemTemplate>
                                    <asp:ImageButton CommandName="Eliminar" Visible='<%# HabilitarEliminar() %>'  CommandArgument='<%# IdNombre(Container.DataItem) %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			                    </ItemTemplate>
		                        </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:LinkButton ForeColor="White" ID="lbAdicionar" runat="server" CommandArgument="Adicionar" CommandName="Adicionar">Adicionar</asp:LinkButton>
                                    </HeaderTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </fieldset>
                   
                </td>
            </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
        <div id='dialogCliente'>
        <asp:UpdatePanel ID="upControl" runat="server">
            <ContentTemplate>
                <uc1:Cliente runat="server" ID="ClienteControl" Visible="true" EmpresaVisible="true" />
            </ContentTemplate>            
        </asp:UpdatePanel>      
    </div>
    <div id='dialogPaquetes'>
            <asp:UpdatePanel ID="upPaqueteSeleccion" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>   
                <table border="0" cellpadding="0" cellspacing="0" class="nonBorder">                    
                    <tr>
                        <td>
                            <h3><asp:Literal runat="server" ID="lblSeleccione" Text="Por favor selecciones un paquete:"></asp:Literal> </h3>
                        </td>
                        <td valign="bottom">&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlPaquete" runat="server" Width="200px" AutoPostBack="true"
                                onselectedindexchanged="ddlPaquete_SelectedIndexChanged" ValidationGroup="RegisterUserValidationGroup1">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="rfvPaquete" runat="server" ControlToValidate="ddlPaquete" 
                            CssClass="failureNotification" ErrorMessage="Debe seleccionar un paquete." Text="Debe seleccionar un paquete." 
                            ToolTip="Debe seleccionar un paquete." 
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <hr />
                <table runat="server" id="tbFechaPrecio" border="0" cellpadding="0" cellspacing="0" width="100%" class="nonBorder" style="background-color:#e2e2e2; border:solid 1px #bebebe;padding:5px;">
                    <%--<colgroup>
                        <col width="120px" />
                        <col width="200px" />
                        <col width="100px" />
                        <col width="*" />
                    </colgroup>--%>
                    <tr>
                        <td style="width:120px">
                            <strong><asp:Label runat="server" ID="Label1">Fecha inicio:</asp:Label></strong>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtFechaInicioPaquete"  Width="90" runat="server" 
                                CssClass="textEntry" ontextchanged="txtFechaInicioPaquete_TextChanged"></asp:TextBox>
                    <asp:Image ID="ImgFechaNacimento" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                    <asp:CalendarExtender ID="txtFechaNacimento_CalendarExtender" runat="server" 
                                        Enabled="True" TargetControlID="txtFechaInicioPaquete" PopupButtonID="ImgFechaNacimento" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic" ControlToValidate="txtFechaInicioPaquete" 
                            CssClass="failureNotification" SetFocusOnError="true" ErrorMessage="La fecha de inicio es obligatoria." Text="La fecha de inicio es obligatoria." ToolTip="La fecha de inicio es obligatoria." 
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ID="revFechaNacimento" CssClass="failureNotification" Display="Dynamic" ValidationGroup="RegisterUserValidationGroup1" ControlToValidate="txtFechaInicioPaquete" 
                    ValidationExpression="<%$ Resources: Regex, Fecha %>" ErrorMessage="<%$ Resources: Mensajes, Fecha %>" ></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:120px">
                            <strong><asp:Label runat="server" ID="lblPrecioPaq">Precio:</asp:Label></strong>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblPanelPrecioPaquete"></asp:Label>
                        </td>
                        <td style="width:100px">
                            <strong><asp:Label runat="server" ID="lblTiempoPaq">Tiempo:</asp:Label> </strong>
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblPanelTiempoPaquete"></asp:Label>
                        </td>
                    </tr>                    
                </table>
                <br />                
                <asp:Panel runat="server" ID="pnlServicio" Enabled="true">
                <div style="background-color:#e2e2e2; border:solid 1px #bebebe;padding:5px;">
                <table border="0" cellpadding="0" cellspacing="0"class="nonBorder">
                    <tr>
                        <td>
                            <strong><asp:Label runat="server" ID="lblServicio">Seleccione la disciplina  a contratar:</asp:Label>&nbsp;&nbsp;</strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlGrupo" runat="server" Width="200px"  Enabled="true"
                                AutoPostBack="true" onselectedindexchanged="ddlGrupo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:RequiredFieldValidator  Display="Dynamic" ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGrupo" 
                            CssClass="failureNotification" ErrorMessage="Debe seleccionar un servicio." Text="Debe seleccionar un servicio." 
                            ToolTip="Debe seleccionar un servicio." 
                            ValidationGroup="RegisterUserValidationGroup1"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    </table>
                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" 
                                SelectMethod="Grupo_TraerHorario" TypeName="RN.Componentes.CGrupo" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlGrupo" Name="codigo" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ClientePaqueteId" Name="clientepaqueteid" 
                                        PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="txtFechaInicioPaquete" Name="fecha" 
                                        PropertyName="Text" Type="DateTime" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:GridView ID="grdHorario" runat="server" AllowPaging="True" 
                                AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                                BorderColor="#999999" BorderStyle="Solid" DataSourceID="ObjectDataSource2" 
                                BorderWidth="1px" CellPadding="3" 
                                DataKeyNames="id" ForeColor="Black" 
                                GridLines="Vertical" Width="100%" onrowcommand="grdHorario_RowCommand" 
                                onpageindexchanging="grdHorario_PageIndexChanging">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                                <EmptyDataTemplate>
                                    No se encontraron horarios.
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                    <asp:TemplateField ItemStyle-Width="50" HeaderText="Seleccione el servicio" Visible="false" >
 	                                <ItemTemplate>
		                                <asp:CheckBox id="cbSeleccion" Enabled="true" name="cbSeleccion" runat="server" /> 
 	                                </ItemTemplate>
	                                </asp:TemplateField>
                                    <asp:BoundField DataField="nombreServicio" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Servicio" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200" 
                                        SortExpression="nombreServicio">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Hora" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Horario" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100" 
                                        SortExpression="Hora">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cupo" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Cupos" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50" 
                                        SortExpression="nombreSala">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Lun" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblLunes" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoLunes")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblMartes" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoMartes")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mier" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblMiercoles" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoMiercoles")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jue" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblJueves" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoJueves")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vie" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblViernes" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoViernes")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sab" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblSabado" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoSabado")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dom" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblDomingo" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoDomingo")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estado" 
                                        ItemStyle-Width="80">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Seleccionar" runat="server" CommandName="Seleccionar" Text="Seleccionar" 
                                                 CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" 
                                SelectMethod="Grupo_TraerHorarioIn" TypeName="RN.Componentes.CGrupo" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlGrupo" Name="codigo" 
                                        PropertyName="SelectedValue" Type="Int32" />
                                    <asp:ControlParameter ControlID="ClientePaqueteId" Name="clientepaqueteid" 
                                        PropertyName="Value" Type="Int32" />
                                    <asp:ControlParameter ControlID="txtFechaInicioPaquete" Name="fecha" 
                                        PropertyName="Text" Type="DateTime" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                            <asp:GridView ID="grdHorarioIn" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" BackColor="White" 
                                BorderColor="#999999" BorderStyle="Solid" DataSourceID="ObjectDataSource5" 
                                BorderWidth="1px" CellPadding="3" 
                                DataKeyNames="id" ForeColor="Black" 
                                GridLines="Vertical" Width="100%" onrowcommand="grdHorarioIn_RowCommand" 
                                onpageindexchanging="grdHorarioIn_PageIndexChanging" >
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                                <EmptyDataTemplate>
                                    No se encontraron horarios.
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                    <asp:TemplateField ItemStyle-Width="50" HeaderText="Seleccione el servicio" Visible="false" >
 	                                <ItemTemplate>
		                                <asp:CheckBox id="cbSeleccion" Enabled="true" name="cbSeleccion" runat="server" /> 
 	                                </ItemTemplate>
	                                </asp:TemplateField>
                                    <asp:BoundField DataField="nombreServicio" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Servicio" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Hora" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Horario" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cupo" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Cupos" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Lun" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblLunes" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoLunes")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblMartes" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoMartes")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mié" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblMiercoles" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoMiercoles")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jue" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblJueves" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoJueves")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vie" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblViernes" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoViernes")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sáb" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblSabado" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoSabado")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dom" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblDomingo" runat="server" Enabled="false"
                                                Checked='<%# Convert.ToBoolean(Eval("grupoDomingo")) %>' 
                                                ></asp:CheckBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estado" ItemStyle-Width="80">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Seleccionar" runat="server" CommandName="Seleccionar" Text="Seleccionar" 
                                                 CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                </div>
                <br />
                <strong><asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Servicios a ser adquiridos:"></asp:Label></strong>
                <br />
                    <asp:GridView ID="grdHorariosSeleccionados" runat="server" AllowPaging="True" 
                                AutoGenerateColumns="False" BackColor="White" 
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                                DataKeyNames="id" ForeColor="Black" 
                                GridLines="Vertical" Width="100%" 
                                onrowcommand="grdHorariosSeleccionados_RowCommand">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                                <EmptyDataTemplate>
                                    No se agregó ningún servicio.
                                </EmptyDataTemplate>
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                                    <asp:BoundField DataField="nombreServicio" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Servicio" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Hora" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Horario" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="100">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cupo" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Cupos" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="50">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Lun" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblLunes0" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("grupoLunes")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mar" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblMartes0" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("grupoMartes")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mié" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblMiercoles0" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("grupoMiercoles")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Jue" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblJueves0" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("grupoJueves")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Vie" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblViernes0" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("grupoViernes")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sáb" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblSabado0" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("grupoSabado")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dom" ItemStyle-Width="50">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="lblDomingo0" runat="server" 
                                                Checked='<%# Convert.ToBoolean(Eval("grupoDomingo")) %>' Enabled="false" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estado" 
                                        ItemStyle-Width="80">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lEliminar" runat="server" CommandName="Eliminar" Text="Eliminar" 
                                                 CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'  />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                <br />
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="btnGuardarServicios" runat="server" Text="Guardar" onclick="btnGuardarServicios_Click"  
                 ValidationGroup="RegisterUserValidationGroup1" />
                <asp:LinkButton ID="btnCerrar" runat="server" Text="Cancelar"  Enabled="true" CausesValidation="false"
                     onclick="btnCerrar_Click" />
                </asp:Panel>
            </ContentTemplate>
            </asp:UpdatePanel>            
        </div>

        <div id='dialogHistorial'>        
        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>     
                <br />
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    SelectMethod="TraerHistorial" TypeName="RN.Componentes.CClientePaquete">                    
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdnAutoCompleteClienteId" Name="clienteId" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>                    
                </asp:ObjectDataSource>                
                <asp:GridView  HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server" DataSourceID="ObjectDataSource1" 
                 Width="100%" 
                AutoGenerateColumns="False" DataKeyNames="Id" 
                AllowPaging="True" 
                onpageindexchanging="ResultGrid_PageIndexChanging" onrowcommand="ResultGrid_RowCommand1" 
                    onrowdatabound="ResultGrid_RowDataBound">      
                <EmptyDataTemplate>
                    El cliente no ha contratado ningun paquete.
                </EmptyDataTemplate>
                <RowStyle Height="30px" />
                <HeaderStyle CssClass="ui-widget-header" />
                    <Columns>                        
                        <asp:BoundField DataField="id" HeaderText="Id" Visible="true" ItemStyle-Width="50"/>  
                        <asp:BoundField DataField="adicionalCodigo" HeaderText="Adicional" Visible="true" ItemStyle-Width="50"/>                       
                        <asp:BoundField DataField="nombre" HeaderStyle-HorizontalAlign="Center" 
                            HeaderText="Paquete" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="150" SortExpression="nombre">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                       <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha inicio" 
                            ItemStyle-Width="150">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="FechaInicioHistorial" runat="server" Text="<%# GetFechaInicio(Container.DataItem) %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha finalización" 
                            ItemStyle-Width="150">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="FechaFinHistorial" runat="server" Text="<%# GetFechaFinalizacion(Container.DataItem) %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Precio" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="80" DataFormatString="{0:n}">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estado" 
                            ItemStyle-Width="80">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Image ID="IsApproved" runat="server" 
                                    ImageUrl="<%# IsApproved(Container.DataItem) %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Adicional" 
                            ItemStyle-Width="80">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Image ID="EsAdicional" runat="server" 
                                    ImageUrl='<%# Adicional(Container.DataItem) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estado" 
                            ItemStyle-Width="80">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton ID="LBSelecc" runat="server" CommandName="Selecc" Text="Seleccionar" Enabled='<%# BotonSeleccionar(Container.DataItem) %>'
                                     CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>'  />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="Button2" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="Button2_Click"/>
                    <asp:Literal runat="server" ID="btnSelect"></asp:Literal>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>        
        <div id='dialogExtensiones'>
        <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>                
                <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" 
                    SelectMethod="TraerHistorialAdicional" 
                    TypeName="RN.Componentes.CClientePaquete" 
                    OldValuesParameterFormatString="original_{0}">                    
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ClientePaqueteId" Name="clienteId" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>                    
                </asp:ObjectDataSource>                
                <asp:GridView ID="grdAdicionales" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="id" DataSourceID="ObjectDataSource4" ForeColor="Black" 
                    GridLines="Vertical" 
                     Width="100%" onpageindexchanging="grdAdicionales_PageIndexChanging"  >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <EmptyDataTemplate>
                        No se encontraron paquetes.
                    </EmptyDataTemplate>
                    <Columns>
                        
                        <asp:BoundField DataField="UserId" HeaderText="Id" Visible="false" />
                       
                        <asp:BoundField DataField="nombre" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Nombre del paquete" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="150">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                       
                        
                        <asp:BoundField DataField="fechaRegistro" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Fecha registro" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="150">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Precio" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Precio" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="80">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Estado" 
                            ItemStyle-Width="20">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Image ID="IsApproved" runat="server" 
                                    ImageUrl="<%# IsApproved(Container.DataItem) %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="Button3" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="Button3_Click"
                      />
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>    
        <div id='dialogLicencia'>
        <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>  
                <fieldset class="register">
                <table border="0" cellpadding="5" cellspacing="0" class="nonBorder">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>
                            <asp:Literal ID="Literal6" runat="server">Fecha de solicitud:</asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="lblLicenciaFechaSolicitud" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td ><asp:Literal ID="Literal1" runat="server">Motivo de la licencia:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtMotivoLicencia" Width="400" runat="server" CssClass="textEntry" 
                                ></asp:TextBox><br />
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtMotivoLicencia" 
                                    CssClass="failureNotification" Font-Size="11px" ErrorMessage="El motivo de la licencia es obligatorio." Text="El motivo de la licencia es obligatorio." ToolTip="El motivo de la licencia es obligatorio." 
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
                            <asp:RegularExpressionValidator Font-Size="11px" runat="server" ID="RegularExpressionValidator3" Display="Dynamic" ValidationGroup="ruvgLicencia" ControlToValidate="txtFechaInicioLicencia" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator Font-Size="11px" ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaInicioLicencia" Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="La fecha inicial es obligatoria." Text="La fecha inicial es obligatoria." ToolTip="La fecha inicial es obligatoria." 
                                    ValidationGroup="ruvgLicencia"></asp:RequiredFieldValidator>
                        </td>
                    </tr>  
                    <tr>
                        <td class="register"><asp:Literal ID="Literal3" runat="server">Fecha de final:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox ID="txtFechaFinalLicencia" Width="70" runat="server" CssClass="textEntry"></asp:TextBox>
                            <asp:Image ID="imgtxtFechaFinal" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/img/basic/Calendar_button.jpg" />
                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" 
                                            Enabled="True" TargetControlID="txtFechaFinalLicencia" PopupButtonID="imgtxtFechaFinal" PopupPosition="BottomLeft" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                            <asp:RegularExpressionValidator Font-Size="11px" runat="server" Display="Dynamic" ID="RegularExpressionValidator4" ValidationGroup="ruvgLicencia" ControlToValidate="txtFechaFinalLicencia" ValidationExpression="<%$ Resources: Regex, Fecha %>" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator Font-Size="11px" ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaFinalLicencia" Display="Dynamic"
                                    CssClass="failureNotification" ErrorMessage="La fecha final es obligatoria." Text="La fecha final es obligatoria." ToolTip="La fecha final es obligatoria." 
                                    ValidationGroup="ruvgLicencia"></asp:RequiredFieldValidator>
                            <asp:CompareValidator runat="server" ID="cvFecha" Display="Dynamic" Type="Date" Operator="GreaterThanEqual" ValidationGroup="ruvgLicencia" ControlToCompare="txtFechaInicioLicencia" ControlToValidate="txtFechaFinalLicencia" ErrorMessage="La fecha debe ser mayor o igual a la inicial" ></asp:CompareValidator>
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
                <br />
                <asp:Button ID="btnGuardarLicencia" class="ui-button ui-widget ui-state-default ui-corner-all" runat="server" Text="Guardar"  Enabled="true" 
                     onclick="btnGuardarLicencia_Click"
                      />
                <asp:LinkButton ID="btnCerrarLicencia" runat="server" Text="Cancelar"  Enabled="true" 
                    CausesValidation="false" onclick="btnCerrarLicencia_Click" />
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>  
        <div id='dialogHistorialLicencias'>
        <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>                
                <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" 
                    SelectMethod="TraerXClientePaqueteId" 
                    TypeName="RN.Componentes.CLicencia" 
                    OldValuesParameterFormatString="original_{0}">                    
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ClientePaqueteId" Name="codigo" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>                    
                </asp:ObjectDataSource>                
                <asp:GridView ID="grdHistorialLicencias" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="id" DataSourceID="ObjectDataSource6" ForeColor="Black" 
                    GridLines="Vertical" 
                     Width="100%" 
                    onpageindexchanging="grdHistorialLicencias_PageIndexChanging" 
                    onrowcommand="grdHistorialLicencias_RowCommand" 
                    onrowdatabound="grdHistorialLicencias_RowDataBound" >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <EmptyDataTemplate>
                        No se encontraron paquetes.
                    </EmptyDataTemplate>
                    <Columns>
                        
                        <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                       <asp:BoundField DataField="descripcion" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Motivo" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="300">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechaSolicitud" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Solicitud" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="100">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechaInicioLicencia" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Fecha inicio" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="100">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechaFinLicencia" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Fecha fin" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="100">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="" 
                            ItemStyle-Width="20">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                              <a id="aImprimir" target="_blank" href='Impresion.aspx?param=<%# DataBinder.Eval(Container.DataItem,"id") %> '>Imprimir</a>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField ItemStyle-Width="100" Visible="true" HeaderStyle-HorizontalAlign="Center" HeaderText="Imprimir">            
			                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                    <ItemTemplate>
                                    <asp:ImageButton CommandName="Imprimir" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/print.gif") %>' />
			                    </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="100" Visible="true" HeaderStyle-HorizontalAlign="Center" HeaderText="Notificar por correo">            
			                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                    <ItemTemplate>
                                    <asp:ImageButton CommandName="Notificar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="NotificarLicencia" ImageUrl='<%# Config.GetPath("Images/mail.gif") %>' />
			                    </ItemTemplate>
		            </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
                    ID="Button4" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="Button4_Click" 
                      />
            </ContentTemplate>
            </asp:UpdatePanel>
        </div> 
        <div id='dialogRecibos' >
        <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>                
                <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" 
                    SelectMethod="TraerRecibos" 
                    TypeName="RN.Componentes.CPagoCliente" 
                    OldValuesParameterFormatString="original_{0}">                    
                    <SelectParameters>
                        <asp:ControlParameter ControlID="hdnAutoCompleteClienteId" Name="codigo" 
                            PropertyName="Value" Type="Int32" />
                    </SelectParameters>                    
                </asp:ObjectDataSource>                
                <asp:GridView ID="grdPagosRegistrados" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                    DataKeyNames="id" DataSourceID="ObjectDataSource8" ForeColor="Black" 
                    GridLines="Vertical" 
                     Width="100%" onpageindexchanging="grdPagosRegistrados_PageIndexChanging" 
                    onrowcommand="grdPagosRegistrados_RowCommand" onrowdatabound="grdPagosRegistrados_RowDataBound" 
                     >
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                    <EmptyDataTemplate>
                        No se encontraron paquetes.
                    </EmptyDataTemplate>
                    <Columns> 
                       <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                        
                       <asp:BoundField DataField="nroRecibo" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="N&uacute;mero de recibo" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="80">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       <asp:BoundField DataField="concepto" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Concepto" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="150">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       <asp:BoundField DataField="monto" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Monto" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="300">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechaPagoSinHora" HeaderStyle-HorizontalAlign="Left" 
                            HeaderText="Fecha de pago" ItemStyle-HorizontalAlign="Left" 
                            ItemStyle-Width="100">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="100" Visible="true" HeaderStyle-HorizontalAlign="Center" HeaderText="Imprimir">            
			                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
			                    <ItemTemplate>
                                    <asp:ImageButton CommandName="Imprimir" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/print.gif") %>' />
			                    </ItemTemplate>
		            </asp:TemplateField>
                        
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
                    ID="btnCerrarRecibos" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="btnCerrarRecibos_Click"  />
            </ContentTemplate>
            </asp:UpdatePanel>
        </div> 
        <div id='dialogPagos'>
        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>  
                <fieldset class="register">
                <table border="0" cellpadding="2" cellspacing="0" class="nonBorder">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory" valign="top"><asp:Literal ID="Literal21" runat="server">Paquetes adeudados:</asp:Literal></td>
                        <td>                                        
                            <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" 
                                SelectMethod="TraerPaquetesAdeudados" TypeName="RN.Componentes.CClientePaquete">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="hdnAutoCompleteClienteId" Name="clienteId" 
                                        PropertyName="Value" Type="Int32" />
                                </SelectParameters> 
                            </asp:ObjectDataSource>
                            <asp:GridView ID="grdPaquetesAdeudados" runat="server" AllowPaging="True" 
                                AllowSorting="false" AutoGenerateColumns="False" BackColor="White" 
                                BorderColor="#999999" BorderStyle="Solid" BorderWidth="0px" CellPadding="3" 
                                DataKeyNames="id" DataSourceID="ObjectDataSource7" ForeColor="Black" 
                                GridLines="Vertical" 
                                PageSize="5" Width="100%" 
                                onpageindexchanging="grdPaquetesAdeudados_PageIndexChanging">
                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
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
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Concepto" 
                                        ItemStyle-Width="150" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblConcepto" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Concepto") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="nombrePaquete" HeaderStyle-HorizontalAlign="Left" 
                                        HeaderText="Paquete" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="200" 
                                        SortExpression="nombrePaquete">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha registro" 
                                        ItemStyle-Width="150">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblfechaRegistro" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"fechaRegistro") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fecha fin" 
                                        ItemStyle-Width="150">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblfechaFin" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"FechaFin") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                  
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Precio" 
                                        ItemStyle-Width="80">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrecioPaquete" runat="server" Text='<%# GetPrecioPaquete(Container.DataItem) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Descuento" 
                                        ItemStyle-Width="80">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrecioDescuento" runat="server" Text='<%# GetPrecioDescuento(Container.DataItem) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Total" 
                                        ItemStyle-Width="80">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrecioTotal" runat="server" Text='<%# GetPrecioTotal(Container.DataItem) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="80" HeaderText="Seleccionar">
 	                                <ItemTemplate>
		                                <asp:CheckBox id="cbSeleccionarMes" AutoPostBack="true" OnCheckedChanged="cbSeleccionarMes_OnCheckedChanged" name="cbSeleccionarMes" runat="server" /> 
 	                                </ItemTemplate>
	                                </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="Literal7" runat="server">Fecha de solicitud:</asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="lblFechaSolicitud" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td ><asp:Literal ID="Literal2" runat="server">Concepto:</asp:Literal></td>
                        <td>
                                        
                            <asp:TextBox ID="txtConcepto" Width="300px" runat="server" CssClass="textEntry" 
                                Enabled="false" Height="63px" TextMode="MultiLine"
                                ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConcepto" 
                                    CssClass="failureNotification" Font-Size="11px" ErrorMessage="El Concepto es obligatorio." Text="El Concepto es obligatorio." ToolTip="El Concepto es obligatorio." 
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
                            <asp:TextBox runat="server" ID="txtNumeroFactura" Width="150" CssClass="textEntry" MaxLength="20"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="revtxtNumeroFactura" 
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
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator2" 
                            ValidationGroup="valGroup2" ControlToValidate="txtDigitosTarjeta" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Font-Size="11px" runat="server" ControlToValidate="txtDigitosTarjeta" 
                            CssClass="failureNotification" ErrorMessage="D&iacute;gitos obligatorios." Text="D&iacute;gitos obligatorios." 
                            ToolTip="D&iacute;gitos obligatorios." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoTarjeta2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal11" runat="server">N&uacute;mero aprobaci&oacute;n POS:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNumeroAprobacionPOS"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator5" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNumeroAprobacionPOS" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Font-Size="11px" runat="server" ControlToValidate="txtNumeroAprobacionPOS" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de aprobaci&oacute;n obligatorio." Text="N&uacute;mero de aprobaci&oacute;n obligatorio." 
                            ToolTip="N&uacute;mero de aprobaci&oacute;n obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCheque" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal12" runat="server">N&uacute;mero de cheque:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNumeroCheque"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator6" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNumeroCheque" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Font-Size="11px" runat="server" ControlToValidate="txtNumeroCheque" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de cheque obligatorio." Text="N&uacute;mero de cheque obligatorio." 
                            ToolTip="N&uacute;mero de cheque obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCheque2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal13" runat="server">Nombre del banco cheque:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNombreBancoCheque"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator7" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNombreBancoCheque" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Font-Size="11px" runat="server" ControlToValidate="txtNombreBancoCheque" 
                            CssClass="failureNotification" ErrorMessage="Nombre del banco obligatorio." Text="Nombre del banco obligatorio." 
                            ToolTip="Nombre del banco obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCuenta" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal14" runat="server">N&uacute;mero de cuenta de transferencia:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNumeroCuentaTransferencia"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator8" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNumeroCuentaTransferencia" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Font-Size="11px" runat="server" ControlToValidate="txtNumeroCuentaTransferencia" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de cuenta obligatorio." Text="N&uacute;mero de cuenta obligatorio." 
                            ToolTip="N&uacute;mero de cuenta obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoCuenta2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal15" runat="server">Nombre del banco de transferencia:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNombreBancoTransferencia"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator9" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNombreBancoTransferencia" 
                            ValidationExpression="<%$ Resources: Regex, SoloTexto %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloTexto %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" Font-Size="11px" runat="server" ControlToValidate="txtNombreBancoTransferencia" 
                            CssClass="failureNotification" ErrorMessage="Nombre del banco obligatorio." Text="Nombre del banco obligatorio." 
                            ToolTip="Nombre del banco obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoIntercambio" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal16" runat="server">Intercambio:</asp:Literal></td>
                        <td>  
                            <asp:DropDownList runat="server" ID="txtIntercambioId"></asp:DropDownList>                                      
                            <%--<asp:TextBox runat="server" ID="txtIntercambioId"></asp:TextBox>--%>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator10" 
                            ValidationGroup="valGroup2" ControlToValidate="txtIntercambioId" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" Font-Size="11px" runat="server" ControlToValidate="txtIntercambioId" 
                            CssClass="failureNotification" ErrorMessage="C&oacute;digo de intercambio obligatorio." Text="C&oacute;digo de intercambio obligatorio." 
                            ToolTip="C&oacute;digo de intercambio obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPagoIntercambio2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal17" runat="server">N&uacute;mero de pago:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtNroPago"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator11" 
                            ValidationGroup="valGroup2" ControlToValidate="txtNroPago" 
                            ValidationExpression="<%$ Resources: Regex, SoloNumeros %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloNumeros %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" Font-Size="11px" runat="server" ControlToValidate="txtNroPago" 
                            CssClass="failureNotification" ErrorMessage="N&uacute;mero de intercambio obligatorio." Text="N&uacute;mero de intercambio obligatorio." 
                            ToolTip="N&uacute;mero de intercambio obligatorio." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    
                    <tr>
                        <td><asp:Literal ID="Literal18" runat="server">Fecha periodo inicio:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtFechaPeriodoInicio"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" Font-Size="11px" runat="server" ControlToValidate="txtFechaPeriodoInicio" 
                            CssClass="failureNotification" ErrorMessage="Fecha de inicio obligatoria." Text="Fecha de inicio obligatoria." 
                            ToolTip="Fecha de inicio obligatoria." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="Literal19" runat="server">Fecha periodo fin:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtFechaPeriodoFin"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" Font-Size="11px" runat="server" ControlToValidate="txtFechaPeriodoFin" 
                            CssClass="failureNotification" ErrorMessage="Fecha final obligatoria." Text="Fecha final obligatoria." 
                            ToolTip="Fecha final obligatoria." 
                            ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal ID="Literal20" runat="server">Monto:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtMonto" Width="80px"></asp:TextBox> Bs.
                            <asp:RegularExpressionValidator CssClass="failureNotification" Font-Size="11px" runat="server" ID="RegularExpressionValidator12" 
                            ValidationGroup="valGroup2" ControlToValidate="txtMonto" 
                            ValidationExpression="<%$ Resources: Regex, SoloDecimal %>" 
                            ErrorMessage="<%$ Resources: Mensajes, SoloDecimal %>" Display="Dynamic">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Font-Size="11px" runat="server" ControlToValidate="txtMonto" 
                                    CssClass="failureNotification" ErrorMessage="El monto es obligatorio." Text="El monto es obligatorio." ToolTip="El monto es obligatorio." 
                                    ValidationGroup="valGroup2" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPromocion" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal24" runat="server">Descuento:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtDescuento" Width="80px" Enabled="false"></asp:TextBox> Bs. <asp:Literal ID="lblNombreDescuento" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr runat="server" id="trPromocion2" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal25" runat="server">Monto - descuento:</asp:Literal></td>
                        <td>                                        
                            <asp:TextBox runat="server" ID="txtTotalDescuento" Width="80px" Enabled="false"></asp:TextBox> Bs.
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td class="mandatory"><asp:Literal ID="Literal9" runat="server">Estado:</asp:Literal></td>
                        <td>                                        
                            <asp:checkbox runat="server" id="cbEstadoPago" />
                        </td>
                    </tr>
                </table>
                </fieldset>
                <br />
                <asp:Button ID="btnGuardarPago" class="ui-button ui-widget ui-state-default ui-corner-all" runat="server" Text="Guardar"  Enabled="true" 
                    CausesValidation="true" ValidationGroup="valGroup2" onclick="btnGuardarPago_Click" 
                      />
                <asp:LinkButton ID="btnCerrarPago" runat="server" Text="Cancelar"  Enabled="true" 
                    CausesValidation="false" onclick="btnCerrarPago_Click" 
                      />
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>  
        <div id='dialogPromocion'>
        <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>  
                <fieldset>
                <table border="0" cellpadding="10" cellspacing="0" class="nonBorder">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td>
                            <asp:Literal ID="Literal22" runat="server">Promoción:</asp:Literal>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPromocion" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlPromocion_SelectedIndexChanged" Width="350px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" 
                                ControlToValidate="ddlPromocion" CssClass="failureNotification" 
                                Display="Dynamic" ErrorMessage="Debe seleccionar una promoci&oacute;n." 
                                Text="Debe seleccionar una promoci&oacute;n." ToolTip="Debe seleccionar una promoci&oacute;n." 
                                ValidationGroup="valGroup3"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="Literal23" runat="server">Monto Descuento:</asp:Literal>
                        </td>
                        <td>
                            <asp:Literal ID="lblMontoDescuento" runat="server">0</asp:Literal> Bs.
                        </td>
                    </tr>
                </table>
                </fieldset>
                <br />
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" ID="btnGuardarPromocion" runat="server" Text="Guardar"  Enabled="true" 
                    CausesValidation="true" ValidationGroup="valGroup3" onclick="btnGuardarPromocion_Click" 
                      />
                <asp:LinkButton ID="btnCerrarPromocion" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="btnCerrarPromocion_Click" 
                      />
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div id='dialogImpresionLicencia' style="border:0;border-style:none;">
        <asp:UpdatePanel ID="UpdatePanel8" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>  
                <rsweb:ReportViewer ID="rvLicencias" runat="server" Width="870px" Height="720px">
                </rsweb:ReportViewer>
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
                    ID="btnCerrarImpresion" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="btnCerrarImpresion_Click" 
                      />
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
        <div id='dialogImpresionRecibo' class="nonBorder">
        <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Always" ChildrenAsTriggers="true" runat="server">
            <ContentTemplate>  
                <rsweb:ReportViewer ID="rpRecibo" runat="server" Width="870px" Height="520px">
                </rsweb:ReportViewer>
                <asp:Button class="ui-button ui-widget ui-state-default ui-corner-all" 
                    ID="btnImpresionRecibo" runat="server" Text="Cerrar"  Enabled="true" 
                    CausesValidation="false" onclick="btnImpresionRecibo_Click" 
                      />
            </ContentTemplate>
        </asp:UpdatePanel>
        </div>
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



