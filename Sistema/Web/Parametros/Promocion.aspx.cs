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

public partial class Parametros_Promocion : System.Web.UI.Page
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
        if (!AppSecurity.HasAccess("Promociones"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Coberturas.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            SetFocus();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        RN.Entidades.Promocion objPromocion = new RN.Entidades.Promocion();
        if (string.IsNullOrEmpty(PromocionId.Value))
        {
            MembershipUser user = Membership.GetUser();
            TextLogs.WriteDebug("Insertando Promocion: " + txtNombre.Text + " " + txtMonto.Text + " " + cbEstado.Checked);
            TextLogs.WriteInfo("Entrando a crear nuevo Promocion.");
            objPromocion.Nombre = txtNombre.Text;
            objPromocion.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            objPromocion.FechaFin = Convert.ToDateTime(txtFechaFinal.Text);
            objPromocion.Fecha = DateTime.Now;
            objPromocion.MontoDescuento = Convert.ToDecimal(txtMonto.Text);
            objPromocion.UsuarioId = user.ProviderUserKey.ToString();
            objPromocion.Mensual = cbMensual.Checked;
            RN.Componentes.CPromocion.Insertar(objPromocion);
            TextLogs.WriteInfo("Se creo una nuevo Promocion.");
            SetViewPanel(true);
            SetFocus();
            Search();
            TextLogs.WriteInfo("La promocion ha sido guardado correctamente.");
            SetInformation(Helper.MessageType.Info, "La promocion ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else
        {
            TextLogs.WriteDebug("Actualizando Promocion: " + PromocionId.Value);
            TextLogs.WriteInfo("Entrando a actualizar Promocion.");
            MembershipUser user = Membership.GetUser();
            objPromocion.Id = Convert.ToInt32(PromocionId.Value);
            objPromocion.Nombre = txtNombre.Text;
            objPromocion.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            objPromocion.FechaFin = Convert.ToDateTime(txtFechaFinal.Text);
            objPromocion.Fecha = DateTime.Now;
            objPromocion.MontoDescuento = Convert.ToDecimal(txtMonto.Text);
            objPromocion.UsuarioId = user.ProviderUserKey.ToString();
            objPromocion.Mensual = cbMensual.Checked;
            RN.Componentes.CPromocion.Actualizar(objPromocion);
            TextLogs.WriteInfo("Promocion actualizada.");
            SetViewPanel(true);
            SetFocus();
            Search();
            SetInformation(Helper.MessageType.Info, "La promocion ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        cbEstado.Checked = true;
        cbMensual.Checked = true;
        TextLogs.WriteInfo("Panel de busqueda de Promocion INVISIBLE.");
        SetViewPanel(false);

        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Promocion VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid & RegularExpressionValidator1.IsValid & RegularExpressionValidator2.IsValid & revBuscarNombre.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de Promocion.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para La promocion: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos dLa promocion seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }

        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Entrando a eliminar La promocion seleccionado.");
            RN.Componentes.CPromocion.EliminarPromocion(Convert.ToInt32(e.CommandArgument.ToString()));
            PromocionId.Value = string.Empty;

            TextLogs.WriteInfo("La promocion ha sido eliminada.");
            SetInformation(Helper.MessageType.Info, "La promocion ha sido eliminada.");
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
            Page.SetFocus(txtNombre);
            return;
        }
        Page.SetFocus(txtBuscarNombre);
    }
    private void Search()
    {
        CargarEmpresas();
        lblInfo.Text = ResultGrid.Rows.Count.ToString();
        TextLogs.WriteDebug("Resultados encontrados en el grid: " + lblInfo.Text);
    }
    public string IsApproved(object id)
    {
        bool approved = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (approved)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string IsLockedOut(object id)
    {
        bool locked = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (locked)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
    }
    public string GetFechaInicio(object id)
    {
        return Convert.ToDateTime(DataBinder.Eval(id, "fechaInicio")).ToShortDateString();
    }
    public string GetFechaFin(object id)
    {
        return Convert.ToDateTime(DataBinder.Eval(id, "fechaFin")).ToShortDateString();
    }
    private void Limpiar()
    {
        PromocionId.Value = string.Empty;
        txtNombre.Text = string.Empty;
        txtFechaFinal.Text = string.Empty;
        txtFechaInicio.Text = string.Empty;
        txtMonto.Text = string.Empty;
        cbEstado.Checked = true;

        passwordConfirmTR.Visible = true;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos dLa promocion a los controles del formulario.");
        TextLogs.WriteDebug("Cargando Promocion: " + userName);
        List<RN.Entidades.Promocion> lEmpresa = RN.Componentes.CPromocion.TraerXId(Convert.ToInt32(userName));
        PromocionId.Value = userName;
        txtNombre.Text = lEmpresa[0].Nombre;
        txtFechaInicio.Text = lEmpresa[0].FechaInicio.ToShortDateString();
        txtFechaFinal.Text = lEmpresa[0].FechaFin.ToShortDateString();
        txtMonto.Text = lEmpresa[0].MontoDescuento.ToString();
        cbEstado.Checked = Convert.ToBoolean(lEmpresa[0].Estado.ToString().ToLower());
        cbMensual.Checked = Convert.ToBoolean(lEmpresa[0].Mensual.ToString().ToLower());
        TextLogs.WriteInfo("Datos dLa promocion cargados al formulario correctamente.");
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
    private void CargarEmpresas()
    {
        ResultGrid.DataBind();
    }
}
