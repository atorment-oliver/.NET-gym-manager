<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Horarios.aspx.cs" Inherits="Servicios_Horarios" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:HiddenField runat="server" ID="HorarioId" Value="" />
    <asp:Panel runat="server" ID="pnlVer" Visible="true" DefaultButton="Seach">        
        <asp:Button CausesValidation="false" CssClass="btnStyle" ID="btnNuevo" runat="server" Text="Registrar horario" 
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
                    <td><asp:Literal ID="SalaSearchLabel" runat="server">Sala:</asp:Literal></td>
                    <td>
                        <asp:DropDownList ID="SalaSearch" runat="server" Width="200px">
                        </asp:DropDownList>                    
                    </td>
                </tr> 
                <tr>                    
                    <td>Hora inicio:</td>
                    <td>
                        <asp:DropDownList ID="HoraInicioSearch" runat="server">
                            <asp:ListItem Value="05" Text="05" Selected="true"></asp:ListItem>
                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                            <asp:ListItem Value="13" Text="13"></asp:ListItem>
                            <asp:ListItem Value="14" Text="14"></asp:ListItem>
                            <asp:ListItem Value="15" Text="15"></asp:ListItem>
                            <asp:ListItem Value="16" Text="16"></asp:ListItem>
                            <asp:ListItem Value="17" Text="17"></asp:ListItem>
                            <asp:ListItem Value="18" Text="18"></asp:ListItem>
                            <asp:ListItem Value="19" Text="19"></asp:ListItem>
                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                            <asp:ListItem Value="21" Text="21"></asp:ListItem>
                            <asp:ListItem Value="22" Text="22"></asp:ListItem>
                            <asp:ListItem Value="23" Text="23"></asp:ListItem>
                        </asp:DropDownList>
                        :
                        <asp:DropDownList ID="MinutoInicioSearch" runat="server">
                            <asp:ListItem Value="00" Text="00" Selected="true"></asp:ListItem>
                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                            <asp:ListItem Value="15" Text="15"></asp:ListItem>
                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                            <asp:ListItem Value="25" Text="25"></asp:ListItem>
                            <asp:ListItem Value="30" Text="30"></asp:ListItem>
                            <asp:ListItem Value="35" Text="35"></asp:ListItem>
                            <asp:ListItem Value="40" Text="40"></asp:ListItem>
                            <asp:ListItem Value="45" Text="45"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50"></asp:ListItem>
                            <asp:ListItem Value="55" Text="55"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>Hora fin:</td>
                    <td>
                        <asp:DropDownList ID="HoraFinSearch" runat="server">
                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                            <asp:ListItem Value="06" Text="06"></asp:ListItem>
                            <asp:ListItem Value="07" Text="07"></asp:ListItem>
                            <asp:ListItem Value="08" Text="08"></asp:ListItem>
                            <asp:ListItem Value="09" Text="09"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                            <asp:ListItem Value="11" Text="11"></asp:ListItem>
                            <asp:ListItem Value="12" Text="12"></asp:ListItem>
                            <asp:ListItem Value="13" Text="13"></asp:ListItem>
                            <asp:ListItem Value="14" Text="14"></asp:ListItem>
                            <asp:ListItem Value="15" Text="15"></asp:ListItem>
                            <asp:ListItem Value="16" Text="16"></asp:ListItem>
                            <asp:ListItem Value="17" Text="17"></asp:ListItem>
                            <asp:ListItem Value="18" Text="18"></asp:ListItem>
                            <asp:ListItem Value="19" Text="19"></asp:ListItem>
                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                            <asp:ListItem Value="21" Text="21"></asp:ListItem>
                            <asp:ListItem Value="22" Text="22"></asp:ListItem>
                            <asp:ListItem Value="23" Text="23" Selected="true"></asp:ListItem>
                        </asp:DropDownList>
                        :
                        <asp:DropDownList ID="MinutoFinSearch" runat="server">
                            <asp:ListItem Value="00" Text="00"></asp:ListItem>
                            <asp:ListItem Value="05" Text="05"></asp:ListItem>
                            <asp:ListItem Value="10" Text="10"></asp:ListItem>
                            <asp:ListItem Value="15" Text="15"></asp:ListItem>
                            <asp:ListItem Value="20" Text="20"></asp:ListItem>
                            <asp:ListItem Value="25" Text="25"></asp:ListItem>
                            <asp:ListItem Value="30" Text="30"></asp:ListItem>
                            <asp:ListItem Value="35" Text="35"></asp:ListItem>
                            <asp:ListItem Value="40" Text="40"></asp:ListItem>
                            <asp:ListItem Value="45" Text="45"></asp:ListItem>
                            <asp:ListItem Value="50" Text="50"></asp:ListItem>
                            <asp:ListItem Value="55" Text="55" Selected="true"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>   
                <%--<tr>                    
                    <td><asp:Literal ID="FinDeSemanaSearchLabel" runat="server">Fin de Semana:</asp:Literal></td>
                    <td>
                        <asp:RadioButtonList ID="FinDeSemanaSearch" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="Todos" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Día de semana" Value="1"></asp:ListItem>                            
                            <asp:ListItem Text="Fin de semana" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>--%>              
            </table>            
        </fieldset>
        <p class="findButton">
            <asp:Button CssClass="btnStyle" ID="Seach" runat="server" Text="Buscar" onclick="Seach_Click" ValidationGroup="SearchValidationGroup" />
        </p>
        <h2>Horarios encontrados</h2>
        <hr />
        Se encontraron <asp:Literal runat="server" ID="lblInfo"></asp:Literal> horarios.
            <asp:GridView HeaderStyle-Height="25px" BorderColor="#dddddd" 
                BorderStyle="Solid" BorderWidth="1px" ID="ResultGrid" runat="server"  
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
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Eliminar">            
			            <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton AlternateText='<%# DataBinder.Eval(Container.DataItem,"id") %>' OnClientClick="javascript:return deleteItem(this.name, this.alt);" CausesValidation="false" UseSubmitBehavior="false"  CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Delete" ImageUrl='<%# Config.GetPath("Images/delete.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Editar">            
			            <ItemStyle Width="60px" HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id") %>' runat="server" ID="Edit" ImageUrl='<%# Config.GetPath("Images/editar.gif") %>' />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sala">            
			            <ItemStyle Width="300px" HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Literal runat="server" ID="Sala" Text='<%# GetSala(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>
                    <asp:BoundField ItemStyle-Width="300" DataField="horaInicio" HeaderText="Hora Inicio" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <asp:BoundField ItemStyle-Width="300" DataField="horaFin" HeaderText="Hora Fin" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" />
                    <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Fin de Semana">            
			            <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
			            <ItemTemplate>
                            <asp:Image  runat="server" ID="IsWeekend" ImageUrl='<%# IsWeekend(Container.DataItem) %>'  />
			            </ItemTemplate>
		            </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlNuevo" Visible="false">
        <h2>
            Nuevo horario
        </h2>
        <hr />
        <p>
            Los campos <span class="mandatory">en rojo</span> son obligatorios.
            <br />
        </p>
        <div class="accountInfo">
            <fieldset class="register">
                <legend>Información del horario</legend>
                <table border="0" cellpadding="2" cellspacing="0">
                    <colgroup>
                        <col width="150px" />
                        <col width="*" />
                    </colgroup>
                    <tr>
                        <td class="mandatory"><asp:Literal ID="SalaLabel" runat="server">Sala:</asp:Literal></td>
                        <td>                                        
                            <asp:DropDownList ID="Sala" runat="server" Width="200px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="SalaRequired" runat="server" ControlToValidate="Sala" 
                                    CssClass="failureNotification" ErrorMessage="La sala es obligatoria." Text="La sala es obligatoria." ToolTip="La sala es obligatoria." 
                                    ValidationGroup="valGroup"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="mandatory"><asp:Literal ID="InicioLabel" runat="server">Hora Inicio:</asp:Literal></td>
                        <td>                                        
                            <asp:DropDownList ID="HoraInicio" runat="server">
                                <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                <asp:ListItem Value="06" Text="06" Selected="true"></asp:ListItem>
                                <asp:ListItem Value="07" Text="07"></asp:ListItem>
                                <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                <asp:ListItem Value="13" Text="13"></asp:ListItem>
                                <asp:ListItem Value="14" Text="14"></asp:ListItem>
                                <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                <asp:ListItem Value="16" Text="16"></asp:ListItem>
                                <asp:ListItem Value="17" Text="17"></asp:ListItem>
                                <asp:ListItem Value="18" Text="18"></asp:ListItem>
                                <asp:ListItem Value="19" Text="19"></asp:ListItem>
                                <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                <asp:ListItem Value="21" Text="21"></asp:ListItem>
                                <asp:ListItem Value="22" Text="22"></asp:ListItem>
                                <asp:ListItem Value="23" Text="23"></asp:ListItem>
                            </asp:DropDownList>
                            :
                            <asp:DropDownList ID="MinutoInicio" runat="server">
                                <asp:ListItem Value="00" Text="00"></asp:ListItem>
                                <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                <asp:ListItem Value="30" Text="30" Selected="true"></asp:ListItem>
                                <asp:ListItem Value="35" Text="35"></asp:ListItem>
                                <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                <asp:ListItem Value="50" Text="50"></asp:ListItem>
                                <asp:ListItem Value="55" Text="55"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td class="mandatory"><asp:Literal ID="FinLabel" runat="server">Hora Finalización:</asp:Literal></td>
                        <td>                                        
                            <asp:DropDownList ID="HoraFin" runat="server">
                                <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                <asp:ListItem Value="06" Text="06"></asp:ListItem>
                                <asp:ListItem Value="07" Text="07" Selected="true"></asp:ListItem>
                                <asp:ListItem Value="08" Text="08"></asp:ListItem>
                                <asp:ListItem Value="09" Text="09"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="11" Text="11"></asp:ListItem>
                                <asp:ListItem Value="12" Text="12"></asp:ListItem>
                                <asp:ListItem Value="13" Text="13"></asp:ListItem>
                                <asp:ListItem Value="14" Text="14"></asp:ListItem>
                                <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                <asp:ListItem Value="16" Text="16"></asp:ListItem>
                                <asp:ListItem Value="17" Text="17"></asp:ListItem>
                                <asp:ListItem Value="18" Text="18"></asp:ListItem>
                                <asp:ListItem Value="19" Text="19"></asp:ListItem>
                                <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                <asp:ListItem Value="21" Text="21"></asp:ListItem>
                                <asp:ListItem Value="22" Text="22"></asp:ListItem>
                                <asp:ListItem Value="23" Text="23"></asp:ListItem>
                            </asp:DropDownList>
                            :
                            <asp:DropDownList ID="MinutoFin" runat="server">
                                <asp:ListItem Value="00" Text="00"></asp:ListItem>
                                <asp:ListItem Value="05" Text="05"></asp:ListItem>
                                <asp:ListItem Value="10" Text="10"></asp:ListItem>
                                <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                <asp:ListItem Value="20" Text="20"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                <asp:ListItem Value="30" Text="30" Selected="true"></asp:ListItem>
                                <asp:ListItem Value="35" Text="35"></asp:ListItem>
                                <asp:ListItem Value="40" Text="40"></asp:ListItem>
                                <asp:ListItem Value="45" Text="45"></asp:ListItem>
                                <asp:ListItem Value="50" Text="50"></asp:ListItem>
                                <asp:ListItem Value="55" Text="55"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td class="mandatory"><asp:Literal ID="FinDeSemanaLabel" runat="server">Fin de semana:</asp:Literal></td>
                        <td>                                        
                            <asp:checkbox runat="server" id="FinDeSemana" />
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