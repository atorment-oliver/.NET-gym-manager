using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Instrumentacion;
using System.Web.Profile;
using System.Data;

public partial class Servicios_Salas : MyPage
{
    protected override void OnPreRender(EventArgs e)
    {
        base.OnPreRender(e);
        ResultGrid.CssClass = "ui-widget-content";
        if (ResultGrid.Rows.Count > 0)
        {
            ResultGrid.UseAccessibleHeader = true;
            ResultGrid.HeaderRow.TableSection = TableRowSection.TableHeader;
            ResultGrid.HeaderRow.CssClass = "ui-widget-header";
            ResultGrid.FooterRow.TableSection = TableRowSection.TableFooter;

            if (ResultGrid.TopPagerRow != null)
                ResultGrid.TopPagerRow.TableSection = TableRowSection.TableHeader;

            if (ResultGrid.BottomPagerRow != null)
                ResultGrid.BottomPagerRow.TableSection = TableRowSection.TableFooter;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("Salas"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Salas.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            SetFocus();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        RN.Entidades.Sala sala = new RN.Entidades.Sala();
        if (string.IsNullOrEmpty(SalaId.Value))
        {
            TextLogs.WriteDebug("Insertando sala: " + Nombre.Text);
            TextLogs.WriteInfo("Entrando a crear nueva sala.");
            sala.Nombre = Nombre.Text;
            sala.Estado = true;
            try
            {
                RN.Componentes.CSala.Insertar(sala);
                TextLogs.WriteInfo("Se creo una nueva sala.");
            }
            catch (System.Data.SqlClient.SqlException x)
            {
                MensajesError(x);
                return;
            }
            catch (Exception x)
            {
                TextLogs.WriteError("No se pudo guardar la sala", x);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }           
            SetViewPanel(true);
            SetFocus();
            Search();
            TextLogs.WriteInfo("La sala ha sido guardada correctamente.");
            SetInformation(Helper.MessageType.Info, "La sala ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else
        {

            TextLogs.WriteDebug("Actualizando sala: " + SalaId.Value);
            TextLogs.WriteInfo("Entrando a actualizar sala.");
            sala.Id = Convert.ToInt32(SalaId.Value);
            sala.Nombre = Nombre.Text;
            sala.Estado = true;
            try
            {
                RN.Componentes.CSala.Actualizar(sala);
                TextLogs.WriteInfo("Sala actualizada.");
            }
            catch (System.Data.SqlClient.SqlException x)
            {
                MensajesError(x);
                return;
            }
            catch (Exception x)
            {
                TextLogs.WriteError("No se pudo guardar la sala", x);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }            
            SetViewPanel(true);
            SetFocus();
            Search();
            SetInformation(Helper.MessageType.Info, "La sala ha sido guardada correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de sala INVISIBLE.");
        SetViewPanel(false);
        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de salas VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Filtrando resultados del listado de salas.");
        SetFocus();
        Search();
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para la sala: " + e.CommandArgument);
        
        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos de la sala seleccionada.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }
        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Ingresando a eliminar salas.");
            RN.Componentes.CSala.Eliminar(Convert.ToInt32(e.CommandArgument.ToString()));
            TextLogs.WriteInfo("Sala eliminada.");
            Search();

            SetInformation(Helper.MessageType.Info, "La sala ha sido eliminada correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        if (e.CommandName != "Page")
            Search();
    }

    private void SetViewPanel(bool status)
    {
        pnlNuevo.Visible = !status;
        pnlVer.Visible = status;
        SetFocus();
    }
    private void SetFocus()
    {
        if (pnlNuevo.Visible)
        {
            Page.SetFocus(Nombre);
            return;
        }
        Page.SetFocus(NombreSearch);
    }
    private void Search()
    {
        ResultGrid.DataBind();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public bool IsNotUsed(object id)
    {
        List<RN.Entidades.Horario> horarios = RN.Componentes.CHorario.TraerXSala(Convert.ToInt32(DataBinder.Eval(id, "id")));
        if (horarios != null && horarios.Count > 0)
        {
            return false;
        }
        return true;
    }
    private void Limpiar()
    {
        SalaId.Value = string.Empty;
        Nombre.Text = string.Empty;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string id)
    {
        TextLogs.WriteInfo("Cargando datos de la sala a los controles del formulario.");
        TextLogs.WriteDebug("Cargando sala: " + id);
        RN.Entidades.Sala sala = RN.Componentes.CSala.TraerXId(Convert.ToInt32(id));
        SalaId.Value = id;
        Nombre.Text = sala.Nombre;
        TextLogs.WriteInfo("Datos de la sala cargados al formulario correctamente.");
    }
    public void SetInformation(Helper.MessageType type, string message)
    {
        popupMessage.Text = message;
        switch (type)
        {
            case Helper.MessageType.Info:
                popupTitle.Text = "INFORMACION";
                break;
            case Helper.MessageType.Warning:
                popupTitle.Text = "ADVERTENCIA";
                break;
            case Helper.MessageType.Error:
                popupTitle.Text = "ERROR";
                break;
            default:
                break;
        }
    }
    private void MensajesError(System.Data.SqlClient.SqlException eVariable)
    {
        string sError = "No se pudo guardar la sala";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "No se pudo conectar con la base de datos";
                break;
            case "2627":
                sTipo = "El nombre de la sala ya existe";
                break;
            default:
                sTipo = "Ocurrio un problema al guardar la sala. Por favor comuniquese con el administrador";
                break;
        }
        TextLogs.WriteError(sError, eVariable);
        SetInformation(Helper.MessageType.Error, sTipo);
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
    }
    protected void ResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        ResultGrid.PageIndex = e.NewPageIndex;
        Search();
    }
}
