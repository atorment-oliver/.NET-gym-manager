<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClientesExcel.aspx.cs" Inherits="Clientes_ClientesExcel" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src='<%=this.ResolveUrl("~/Scripts/jquery-1.4.1.min.js") %>' type="text/javascript"></script>        
<script src='<%=this.ResolveUrl("~/Scripts/jquery.simplemodal.js") %>' type="text/javascript"></script>
<script src='<%=this.ResolveUrl("~/Scripts/jquery.msgBox.v1.js") %>' type="text/javascript"></script> 
<script src='<%=this.ResolveUrl("~/Scripts/jquery-ui-1.7.2.custom.min.js") %>' type="text/javascript"></script>

<script type="text/javascript">
    $(document).ready(function () {
function showDialog(id) {
        $('#' + id).dialog("open");
    }
    );
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <br />
        <h2>Carga Masiva de Clientes con Excel</h2>    
        <hr />
        <h3>Para realizar el cargado favor tome como referencia el siguiente <asp:HyperLink
                ID="hlEjemplo" runat="server" >EJEMPLO</asp:HyperLink> y seguir las instrucciones.
        </h3>
        <hr />
        Por favor seleccione el excel y luego presione el botón Subir Excel
        <br />
        Una vez se cargo el excel correctamente se mostrar&aacute;n los datos seguido debe presionar el boton Iniciar Importaci&oacute;n para cargar los datos en la base de datos.
        <br />
    <asp:FileUpLoad id="FileUpLoad1" Width="300px" runat="server" />
        <br />
        <br />
        <asp:Button id="UploadBtn" CausesValidation="false" CssClass="btnStyle" Text="Subir Excel" OnClick="UploadBtn_Click" runat="server" Width="105px" />
        <asp:Button id="btnImportar" CausesValidation="false" CssClass="btnStyle" 
        Text="Iniciar Importacion de clientes" runat="server" 
        onclick="btnImportar_Click" Enabled="False" /> 
        <br />
        <div runat="server" id="dMensaje" visible="false">
        Se cargaron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> clientes.
        </div>
    <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" 
        runat="server" 
                 Width="100%" 
                AutoGenerateColumns="False"  
                AllowPaging="false" AllowSorting="false" PageSize="1000" 
                
               > 
                <EmptyDataTemplate>
                    No se encontraron datos.
                </EmptyDataTemplate>
                <PagerSettings PageButtonCount="1000" />
                <RowStyle Height="30px" />
                <HeaderStyle CssClass="ui-widget-header" />
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Id" Visible="false" />
                    <%--<asp:TemplateField ItemStyle-Width="100" HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <HeaderStyle HorizontalAlign="Center" />
			            <ItemStyle HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>--%>
                    <asp:BoundField ItemStyle-Width="150" DataField="nombre" 
                        SortExpression="nombre" HeaderText="Nombre" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="200" DataField="apellidos" 
                        SortExpression="apellidos" HeaderText="Apellidos" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    <%--<asp:BoundField ItemStyle-Width="200" DataField="direccion" 
                        SortExpression="direccion" HeaderText="Direccion" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="80" DataField="telefono" 
                        SortExpression="telefono" HeaderText="Tel&eacute;fono" 
                        HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="110px" />
                    </asp:BoundField>
                    --%>
                    <asp:BoundField ItemStyle-Width="150" DataField="Correo" 
                        SortExpression="correo" HeaderText="Correo" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="80" DataField="CiCompleto" 
                        SortExpression="CiCompleto" HeaderText="Ci" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="100" DataField="fechaIngreso" SortExpression="fechaIngreso" 
                        HeaderText="Fecha ingreso" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" DataFormatString="{0:d}"  >
                    
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField ItemStyle-Width="100" DataField="fechaInicio" SortExpression="fechaInicio" 
                        HeaderText="Fecha inicio" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" DataFormatString="{0:d}" >
                    
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:BoundField ItemStyle-Width="100" DataField="distribucion" SortExpression="distribucion" 
                        HeaderText="Distrubuci&oacute;n" HeaderStyle-HorizontalAlign="Left" 
                        ItemStyle-HorizontalAlign="Left" >
                    
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                  
                    
                                  
                </Columns>
            </asp:GridView>
</asp:Content>