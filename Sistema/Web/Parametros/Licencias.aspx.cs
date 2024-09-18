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

public partial class Parametros_Licencias : System.Web.UI.Page
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
        if (!AppSecurity.HasAccess("Licencia"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Licencias.aspx");
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
        RN.Entidades.Licencia objLicencia = new RN.Entidades.Licencia();
        if (string.IsNullOrEmpty(LicenciaId.Value))
        {
            MembershipUser user = Membership.GetUser();
            TextLogs.WriteDebug("Insertando Licencia: " + txtMotivoLicencia.Text + " " + ClientePaqueteId.Value + " " + cbEstadoLicencia.Checked);
            TextLogs.WriteInfo("Entrando a crear nuevo Licencia.");
            objLicencia.Descripcion = txtMotivoLicencia.Text;
            objLicencia.ClientePaqueteId = Convert.ToInt32(ClientePaqueteId.Value);
            objLicencia.FechaInicioLicencia = Convert.ToDateTime(txtFechaInicioLicencia.Text);
            objLicencia.FechaFinLicencia = Convert.ToDateTime(txtFechaFinalLicencia.Text);
            objLicencia.Fecha = DateTime.Now;
            objLicencia.FechaSolicitud = DateTime.Now;
            objLicencia.UsuarioId = user.ProviderUserKey.ToString();
            RN.Componentes.CLicencia.Insertar(objLicencia);
            TextLogs.WriteInfo("Se creo una nuevo Licencia.");
            SetViewPanel(true);
            SetFocus();
            Search();
            TextLogs.WriteInfo("La Licencia ha sido guardado correctamente.");
            SetInformation(Helper.MessageType.Info, "La Licencia ha sido guardado correctamente.");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", "<script language=JavaScript> $(window).load(function () { $('.osx').click(); }); </script>");
        }
        else
        {
            TextLogs.WriteDebug("Actualizando Licencia: " + LicenciaId.Value);
            TextLogs.WriteInfo("Entrando a actualizar Licencia.");
            MembershipUser user = Membership.GetUser();
            objLicencia.Id = Convert.ToInt32(LicenciaId.Value);
            objLicencia.Descripcion = txtMotivoLicencia.Text;
            objLicencia.ClientePaqueteId = Convert.ToInt32(ClientePaqueteId.Value);
            objLicencia.FechaInicioLicencia = Convert.ToDateTime(txtFechaInicioLicencia.Text);
            objLicencia.FechaFinLicencia = Convert.ToDateTime(txtFechaFinalLicencia.Text);
            objLicencia.Fecha = DateTime.Now;
            objLicencia.FechaSolicitud = DateTime.Now;
            objLicencia.UsuarioId = user.ProviderUserKey.ToString();
            RN.Componentes.CLicencia.Actualizar(objLicencia);
            TextLogs.WriteInfo("Licencia actualizada.");
            SetViewPanel(true);
            SetFocus();
            Search();
            SetInformation(Helper.MessageType.Info, "La Licencia ha sido guardado correctamente.");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "popup", "<script language=JavaScript> $(window).load(function () { $('.osx').click(); }); </script>");

        }

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        cbEstadoLicencia.Checked = true;
        TextLogs.WriteInfo("Panel de busqueda de Licencia INVISIBLE.");
        SetViewPanel(false);

        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Licencia VISIBLE.");
        SetViewPanel(true);
    }
    

    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid & RegularExpressionValidator1.IsValid & RegularExpressionValidator2.IsValid & revBuscarNombre.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de Licencia.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para La Licencia: " + e.CommandArgument);
        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos dLa Licencia seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }
        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Ingresando a eliminar Licencia.");
            LicenciaId.Value = e.CommandArgument.ToString();
            LicenciaNombre.Value = RN.Componentes.CLicencia.TraerXId(Convert.ToInt32(e.CommandArgument.ToString()))[0].Descripcion.ToString();
            TextLogs.WriteInfo("Entrando a eliminar La Licencia seleccionado.");
            RN.Workflows.WLicencia.Eliminar(Convert.ToInt32(LicenciaId.Value));
            LicenciaId.Value = string.Empty;
            SetInformation(Helper.MessageType.Info, "La licencia ha sido eliminada correctamente.");
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
            Page.SetFocus(txtSearchCI);
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
    //public bool IsVisible(object id)
    //{
    //    return DataBinder.Eval(id, "UserName").ToString() != "admin";
    //}
    private void Limpiar()
    {
        LicenciaId.Value = string.Empty;
        txtMotivoLicencia.Text = string.Empty;
        txtFechaFinalLicencia.Text = string.Empty;
        txtFechaInicioLicencia.Text = string.Empty;
        lblLicenciaFechaSolicitud.Text = string.Empty;
        cbEstadoLicencia.Checked = true;
        passwordConfirmTR.Visible = true;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos dLa Licencia a los controles del formulario.");
        TextLogs.WriteDebug("Cargando Licencia: " + userName);
        //MembershipUser user = Membership.GetUser(userName);
        //ProfileCommon profile = Profile.GetProfile(user.UserName);
        List<RN.Entidades.Licencia> lEmpresa = RN.Componentes.CLicencia.TraerXId(Convert.ToInt32(userName));
        LicenciaId.Value = userName;
        txtMotivoLicencia.Text = lEmpresa[0].Descripcion;
        txtFechaInicioLicencia.Text = lEmpresa[0].FechaInicioLicencia.ToShortDateString();
        txtFechaFinalLicencia.Text = lEmpresa[0].FechaFinLicencia.ToShortDateString();
        lblLicenciaFechaSolicitud.Text = DateTime.Now.ToShortDateString();
        cbEstadoLicencia.Checked = Convert.ToBoolean(lEmpresa[0].Estado.ToString().ToLower());

        TextLogs.WriteInfo("Datos dLa Licencia cargados al formulario correctamente.");
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
    protected void ResultGrid_Load(object sender, EventArgs e)
    {

    }
    private void CargarEmpresas()
    {

        ResultGrid.DataBind();
    }
    protected void txtNombre_TextChanged(object sender, EventArgs e)
    {

    }
}
