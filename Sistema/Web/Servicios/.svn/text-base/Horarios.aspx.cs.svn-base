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

public partial class Servicios_Horarios : MyPage
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
        if (!AppSecurity.HasAccess("Horarios"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Horarios.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            SetFocus();
            CargarSalas();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        RN.Entidades.Horario horario = new RN.Entidades.Horario();
        if (string.IsNullOrEmpty(HorarioId.Value))
        {
            TextLogs.WriteDebug("Insertando horario: " + Sala.Text + " " + HoraInicio.SelectedValue + ":" + MinutoInicio.SelectedValue);
            TextLogs.WriteInfo("Entrando a crear nuevo horario.");

            horario.HoraInicio = HoraInicio.SelectedValue + ":" + MinutoInicio.SelectedValue;
            horario.HoraFin = HoraFin.SelectedValue + ":" + MinutoFin.SelectedValue;
            horario.SalaId = Convert.ToInt32(Sala.SelectedValue);
            horario.FinDeSemana = FinDeSemana.Checked;
            horario.Estado = true;

            DataTable cruces = RN.Componentes.CHorario.TraerXCriterioCruce(horario.HoraInicio, horario.HoraFin, horario.SalaId, horario.FinDeSemana, horario.Estado);
            if (cruces.Rows.Count > 0)
            {
                TextLogs.WriteWarning("No se pudo registrar el horario.", new Exception("Existen cruces de horarios."));
                SetInformation(Helper.MessageType.Error, "No se pudo registrar el horario. Existen cruces de horarios.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }

            try
            {
                RN.Componentes.CHorario.Insertar(horario);
                TextLogs.WriteInfo("Se creo un nuevo horario.");
            }
            catch (System.Data.SqlClient.SqlException x)
            {
                MensajesError(x);
                return;
            }
            catch (RN.ValidationException x)
            {
                TextLogs.WriteWarning(x.ListarErrores("\n"), x);
                SetInformation(Helper.MessageType.Error, x.Message + "<br/>" + x.ListarErrores("<br/>"));
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }
            catch (Exception x)
            {
                TextLogs.WriteError("No se pudo guardar el horario", x);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
                return;
            }           
            SetViewPanel(true);
            SetFocus();
            Search();
            TextLogs.WriteInfo("El horario ha sido guardado correctamente.");
            SetInformation(Helper.MessageType.Info, "El horario ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else
        {

            TextLogs.WriteDebug("Actualizando horario: " + HorarioId.Value);
            TextLogs.WriteInfo("Entrando a actualizar horario.");
            horario.Id = Convert.ToInt32(HorarioId.Value);

            horario.HoraInicio = HoraInicio.SelectedValue + ":" + MinutoInicio.SelectedValue;
            horario.HoraFin = HoraFin.SelectedValue + ":" + MinutoFin.SelectedValue;
            horario.SalaId = Convert.ToInt32(Sala.SelectedValue);
            horario.FinDeSemana = FinDeSemana.Checked;
            horario.Estado = true;
            try
            {
                RN.Componentes.CHorario.Actualizar(horario);
                TextLogs.WriteInfo("Horario actualizado.");
            }
            catch (System.Data.SqlClient.SqlException x)
            {
                MensajesError(x);
                return;
            }
            catch (Exception x)
            {
                TextLogs.WriteError("No se pudo guardar el horario", x);
                SetInformation(Helper.MessageType.Error, "Error no clasificado");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }            
            SetViewPanel(true);
            SetFocus();
            Search();
            SetInformation(Helper.MessageType.Info, "El horario ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de horario INVISIBLE.");
        SetViewPanel(false);
        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de horario VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Filtrando resultados del listado de horarios.");
        SetFocus();
        Search();
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para el Horario: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos del horario seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }
        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Entrando a eliminar el Horario seleccionado.");
            try
            {
                RN.Componentes.CHorario.Eliminar(Convert.ToInt32(e.CommandArgument.ToString()));
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                MensajesError(err);
                return;
            }
            HorarioId.Value = string.Empty;

            TextLogs.WriteInfo("El horario ha sido eliminado.");
            SetInformation(Helper.MessageType.Info, "El horario ha sido eliminado.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        Search();
    }
    protected void ResultGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        TextLogs.WriteInfo("Cambiando índice de página.");
        TextLogs.WriteDebug("Nuevo índice: " + e.NewPageIndex);
        ResultGrid.PageIndex = e.NewPageIndex;
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
            Page.SetFocus(Sala);
            return;
        }
        Page.SetFocus(SalaSearch);
    }
    private void Search()
    {
        if (Sala.Items.Count <= 0)
        {
            lblInfo.Text = "0";
            TextLogs.WriteWarning("No existen salas ingresadas en el sistema, no se presentarán horarios en el formulario horarios.aspx", new Exception("No hay salas registradas en el sistema"));
            return;
        }

        string inicio = HoraInicioSearch.SelectedValue + ":" + MinutoInicioSearch.SelectedValue;
        string fin = HoraFinSearch.SelectedValue + ":" + MinutoFinSearch.SelectedValue;

        //bool? finDeSemana = null;
        //if (FinDeSemanaSearch.SelectedValue == "1")
        //    finDeSemana = false;
        //if (FinDeSemanaSearch.SelectedValue == "2")
        //    finDeSemana = true;

        DataTable results = RN.Componentes.CHorario.TraerXCriterio(inicio, fin, Convert.ToInt32(SalaSearch.SelectedValue));
        
        ResultGrid.DataSource = results;
        ResultGrid.DataBind();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public string IsWeekend(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "finDeSemana"));
        if (approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string GetSala(object id)
    {
        RN.Entidades.Sala sala = RN.Componentes.CSala.TraerXId(Convert.ToInt32(DataBinder.Eval(id, "salaId")));
        return sala.Nombre;
    }
    private void Limpiar()
    {
        HorarioId.Value = string.Empty;
        HoraInicio.SelectedValue = "06";
        MinutoInicio.SelectedValue = "30";
        HoraFin.SelectedValue = "07";
        MinutoFin.SelectedValue = "30";
        FinDeSemana.Checked = false;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string id)
    {
        TextLogs.WriteInfo("Cargando datos del horario a los controles del formulario.");
        TextLogs.WriteDebug("Cargando horario: " + id);
        RN.Entidades.Horario horario = RN.Componentes.CHorario.TraerXId(Convert.ToInt32(id));
        HorarioId.Value = id;
        Sala.SelectedValue = horario.SalaId.ToString();
        HoraInicio.SelectedValue = horario.HoraInicio.Substring(0, 2);
        MinutoInicio.SelectedValue = horario.HoraInicio.Substring(3, 2);
        HoraFin.SelectedValue = horario.HoraFin.Substring(0, 2);
        MinutoFin.SelectedValue = horario.HoraFin.Substring(3, 2);
        FinDeSemana.Checked = Convert.ToBoolean(horario.FinDeSemana.ToString().ToLower());
        TextLogs.WriteInfo("Datos del horario cargados al formulario correctamente.");
    }
    private void CargarSalas()
    {
        DataTable salas = RN.Componentes.CSala.TraerXEstado("true");
        Sala.DataSource = salas;
        Sala.DataTextField = "nombre";
        Sala.DataValueField = "id";
        Sala.DataBind();

        SalaSearch.DataSource = salas;
        SalaSearch.DataTextField = "nombre";
        SalaSearch.DataValueField = "id";
        SalaSearch.DataBind();

        SalaSearch.Items.Add(new ListItem("Todos", "0"));
        SalaSearch.SelectedValue = "0";
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
        string sError = "No se pudo guardar el horario";
        string sTipo = string.Empty;
        switch (eVariable.Number.ToString())
        {
            case "08001":
                sTipo = "No se pudo conectar con la base de datos";
                break;
            case "547":
                sTipo = "No se puede eliminar el horario debido a que está siendo utilizado.";
                break;
            default:
                sTipo = "Ocurrio un problema al guardar el horario. Por favor comuniquese con el administrador";
                break;
        }
        TextLogs.WriteError(sError, eVariable);
        SetInformation(Helper.MessageType.Error, sTipo);
        lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
    }
}
