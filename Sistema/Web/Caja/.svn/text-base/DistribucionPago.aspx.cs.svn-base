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

public partial class Caja_DistribucionPago : System.Web.UI.Page
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
        if (!AppSecurity.HasAccess("DistribucionPago"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página DistribucionPago.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            GetListadoEmpresas();
            SetFocus();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        RN.Entidades.DistribucionPago objPromocion = new RN.Entidades.DistribucionPago();
        if (string.IsNullOrEmpty(DistribucionPagosId.Value))
        {
            MembershipUser user = Membership.GetUser();
            TextLogs.WriteDebug("Insertando distribucion: " + txtNombre.Text + " " + txtMonto.Text + " " + true);
            TextLogs.WriteInfo("Entrando a crear nuevo Promocion.");
            objPromocion.ClienteId = Convert.ToInt32(RegistrarClienteId.Value);
            objPromocion.Porcentaje = Convert.ToInt32(txtMonto.Text);
            objPromocion.Fecha = DateTime.Now;
            objPromocion.Estado = true;
            objPromocion.UsuarioId = user.ProviderUserKey.ToString();
            RN.Componentes.CDistribucionPago.Insertar(objPromocion);
            TextLogs.WriteInfo("Se creo una nueva distribucion.");
            SetViewPanel(true);
            SetFocus();
            Search();
            TextLogs.WriteInfo("La distribucion ha sido guardado correctamente.");
            SetInformation(Helper.MessageType.Info, "La distribucion ha sido guardada correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else
        {
            TextLogs.WriteDebug("Actualizando distribucion: " + DistribucionPagosId.Value);
            TextLogs.WriteInfo("Entrando a actualizar distribucion.");
            MembershipUser user = Membership.GetUser();
            objPromocion.Id = Convert.ToInt32(DistribucionPagosId.Value);
            objPromocion.ClienteId = Convert.ToInt32(RegistrarClienteId.Value);
            objPromocion.Porcentaje = Convert.ToInt32(txtMonto.Text);
            objPromocion.Fecha = DateTime.Now;
            objPromocion.Estado = true;
            objPromocion.UsuarioId = user.ProviderUserKey.ToString();
            RN.Componentes.CDistribucionPago.Actualizar(objPromocion);
            TextLogs.WriteInfo("distribucion actualizada.");
            SetViewPanel(true);
            SetFocus();
            Search();
            SetInformation(Helper.MessageType.Info, "La distribucion ha sido guardada correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
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
        TextLogs.WriteInfo("Filtrando resultados del listado de distribucion.");
        SetFocus();
        Search();
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para La distribucion: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos de La distribucion seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }

        else if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Entrando a eliminar La promocion seleccionada.");
            RN.Componentes.CDistribucionPago.EliminarDistribucionPago(Convert.ToInt32(e.CommandArgument.ToString()));
            DistribucionPagosId.Value = string.Empty;

            TextLogs.WriteInfo("La promocion ha sido eliminada.");
            SetInformation(Helper.MessageType.Info, "La distribucion ha sido eliminada.");
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
        Page.SetFocus(txtCliente);
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
        DistribucionPagosId.Value = string.Empty;
        txtNombre.Text = string.Empty;
        txtCodigoCliente.Text = string.Empty;
        txtMonto.Text = string.Empty;
        lblEmpresaNombre.Text = string.Empty;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos de La distribucion a los controles del formulario.");
        TextLogs.WriteDebug("Cargando distribucion: " + userName);
        List<RN.Entidades.DistribucionPago> lEmpresa = RN.Componentes.CDistribucionPago.TraerXId(Convert.ToInt32(userName));
        DistribucionPagosId.Value = userName;
        List <RN.Entidades.Cliente> lstClie = RN.Componentes.CCliente.TraerXId(lEmpresa[0].ClienteId);
        List<RN.Entidades.Empresa> lstEmpre = new List<RN.Entidades.Empresa>();
        if (lstClie.Count != 0)
        {
            txtNombre.Text = lstClie[0].Nombre + " " + lstClie[0].Apellidos;
            lstEmpre = RN.Componentes.CEmpresa.TraerXId(lstClie[0].EmpresaId);
        }
        txtCodigoCliente.Text = lEmpresa[0].ClienteId.ToString();
        if (lstEmpre.Count != 0)
        {
            lblEmpresaNombre.Text = lstEmpre[0].Nombre;
        }
        RegistrarClienteId.Value = lEmpresa[0].ClienteId.ToString();
        txtMonto.Text = lEmpresa[0].Porcentaje.ToString();

        TextLogs.WriteInfo("Datos de La distribucion cargados al formulario correctamente.");
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
    protected void txtNombre_TextChanged(object sender, EventArgs e)
    {
        List<RN.Entidades.Cliente> lstClie = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(RegistrarClienteId.Value));
        List<RN.Entidades.Empresa> lstEmpre = new List<RN.Entidades.Empresa>();
        if (lstClie.Count != 0)
        {
            lstEmpre = RN.Componentes.CEmpresa.TraerXId(lstClie[0].EmpresaId);
        }
        if (lstEmpre.Count != 0)
        {
            lblEmpresaNombre.Text = lstEmpre[0].Nombre;
        }
    }
    private void GetListadoEmpresas()
    {
        List<RN.Entidades.Empresa> empresas = RN.Componentes.CEmpresa.TraerXCriterio(string.Empty, string.Empty, string.Empty, "true");
        ddlEmpresas.DataSource = empresas;
        ddlEmpresas.DataTextField = "nombre";
        ddlEmpresas.DataValueField = "id";
        ddlEmpresas.DataBind();

        ddlEmpresas.Items.Insert(0, new ListItem("TODAS",""));
    }
    protected void IbtBuscarEmpleado_Click(object sender, ImageClickEventArgs e)
    {
        PnlListadoEmpleados_ModalPopupExtender.Show();
        LoadGridEmpleados("");

    }
    protected void LoadGridEmpleados(string ApellidoPaterno)
    {

        GrvEmpleados.DataSource = RN.Componentes.CCliente.TraerXCriterioSinEmpresa(ApellidoPaterno, string.Empty, string.Empty, "a");
        GrvEmpleados.DataBind();
        GrvEmpleados.Visible = true;
    }
    protected void GrvEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandArgument.ToString() != string.Empty)
        {
            int Index;
            Index = Convert.ToInt32(e.CommandArgument);
            GrvEmpleados.SelectedIndex = Index;
            List<RN.Entidades.Cliente> DatosEmpleado = RN.Componentes.CCliente.TraerXId(Convert.ToInt32(GrvEmpleados.SelectedDataKey["id"].ToString()));

            txtNombre.Text = DatosEmpleado[0].Nombre + " " + DatosEmpleado[0].Apellidos;
            txtCodigoCliente.Text = DatosEmpleado[0].NumeroCliente.ToString();
            RegistrarClienteId.Value = DatosEmpleado[0].Id.ToString();
            lblEmpresaNombre.Text = RN.Componentes.CEmpresa.TraerXId(Convert.ToInt32(DatosEmpleado[0].EmpresaId))[0].Nombre;
            //TxtCargoJefe.Text = Empleado.Cargo;

            PnlListadoEmpleados_ModalPopupExtender.Hide();
            //PnlListadoEmpleados_ModalPopupExtender.Dispose();
            RequiredFieldValidator2.Validate();

        }
    }
    protected void BtnBuscarEmpleados_Click(object sender, EventArgs e)
    {


        string Criterio = TxtApellidoPaternoBuscar.Text.Replace(',', ' ');
        TxtApellidoPaternoBuscar.Text = Criterio.Trim();



        LoadGridEmpleados(TxtApellidoPaternoBuscar.Text);
        PnlListadoEmpleados_ModalPopupExtender.Show();
    }
    protected void BtnPnlEmpleadosClose_Click(object sender, ImageClickEventArgs e)
    {
        PnlListadoEmpleados_ModalPopupExtender.Hide();
    }
    public string TraerEmpresa(object id)
    {
        string approved = Convert.ToString(DataBinder.Eval(id, "empresaId"));
        if (!String.IsNullOrEmpty(approved))

            return RN.Componentes.CEmpresa.TraerXId(Convert.ToInt32(approved))[0].Nombre;
        else
            return string.Empty;
    }
}
