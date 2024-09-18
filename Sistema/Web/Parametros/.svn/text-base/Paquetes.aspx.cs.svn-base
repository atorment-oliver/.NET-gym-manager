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


public partial class Parametros_Paquetes : MyPage    
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
        if (!AppSecurity.HasAccess("Paquetes"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página Paquetes.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            SetFocus();
            Search();
            CargarTipoPaquete();
            CargarTipoPaqueteBuscar();
            CargarUnidad();
        }
        lblScriptShow.Text = string.Empty;
    }
    private void CargarTipoPaquete()
    {
        ddlTipoPaquete.DataSource = RN.Componentes.CTipoPaquete.Traer();
        ddlTipoPaquete.DataTextField = "nombre";
        ddlTipoPaquete.DataValueField = "id";
        ddlTipoPaquete.DataBind();
    }
    private void CargarTipoPaqueteBuscar()
    {
        ddlBuscarTipoPaquete.DataSource = RN.Componentes.CTipoPaquete.Traer();
        ddlBuscarTipoPaquete.DataTextField = "nombre";
        ddlBuscarTipoPaquete.DataValueField = "id";
        ddlBuscarTipoPaquete.DataBind();
        ddlBuscarTipoPaquete.Items.Add(new ListItem("Todos", ""));
        ddlBuscarTipoPaquete.Items.FindByText("Todos").Selected = true;
    }
    private void CargarUnidad()
    {
        ddlUnidad.DataSource = RN.Componentes.CUnidad.Traer();
        ddlUnidad.DataTextField = "nombre";
        ddlUnidad.DataValueField = "id";
        ddlUnidad.DataBind();
    }
    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
        RN.Entidades.Paquete objPaquete = new RN.Entidades.Paquete();
        if (string.IsNullOrEmpty(PaqueteId.Value))
        {
            try
            {
                MembershipUser user = Membership.GetUser();
                TextLogs.WriteDebug("Insertando Paquete: " + txtNombre.Text + " " + ddlUnidad.SelectedValue.ToString() + " " + cbEstado.Checked.ToString());
                TextLogs.WriteInfo("Entrando a crear nueva Paquete.");
                objPaquete.Nombre = txtNombre.Text;
                objPaquete.UnidadId = Convert.ToInt32(ddlUnidad.SelectedValue.ToString());
                objPaquete.Tiempo = Convert.ToInt32(txtTiempo.Text);
                objPaquete.TipoPaqueteId = Convert.ToInt32(ddlTipoPaquete.SelectedValue.ToString());
                objPaquete.Precio = Convert.ToDouble(txtPrecio.Text);
                objPaquete.DiasValidez = txtDias.Text;
                objPaquete.FechaRegistro = Convert.ToDateTime(txtFechaCreacion.Text);
                objPaquete.Estado = cbEstado.Checked;
                objPaquete.UsuarioId = user.ProviderUserKey.ToString();
                objPaquete.Fecha = DateTime.Now;
                objPaquete.Estado = cbEstado.Checked;
                objPaquete.UsuarioId = user.ProviderUserKey.ToString();
                objPaquete.Fecha = DateTime.Now;
                RN.Componentes.CPaquete.Insertar(objPaquete);
                TextLogs.WriteInfo("Se creo una nueva Paquete.");
                SetViewPanel(true);
                SetFocus();
                Search();
                TextLogs.WriteInfo("El Paquete ha sido guardado correctamente.");
                SetInformation(Helper.MessageType.Info, "El Paquete ha sido guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar el paquete", err);
                SetInformation(Helper.MessageType.Error, "Error guardar, El nombre del paquete ya existe.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
        else
        {
            try
            {
                TextLogs.WriteDebug("Actualizando Paquete: " + PaqueteId.Value);
                TextLogs.WriteInfo("Entrando a actualizar emrpesa.");
                MembershipUser user = Membership.GetUser();
                objPaquete.Id = Convert.ToInt32(PaqueteId.Value);
                objPaquete.Nombre = txtNombre.Text;
                objPaquete.UnidadId = Convert.ToInt32(ddlUnidad.SelectedValue.ToString());
                objPaquete.Tiempo = Convert.ToInt32(txtTiempo.Text);
                objPaquete.TipoPaqueteId = Convert.ToInt32(ddlTipoPaquete.SelectedValue.ToString());
                objPaquete.Precio = Convert.ToDouble(txtPrecio.Text);
                objPaquete.DiasValidez = txtDias.Text;
                objPaquete.FechaRegistro = Convert.ToDateTime(txtFechaCreacion.Text);
                objPaquete.Estado = cbEstado.Checked;
                objPaquete.UsuarioId = user.ProviderUserKey.ToString();
                objPaquete.Fecha = DateTime.Now;
                RN.Componentes.CPaquete.Actualizar(objPaquete);
                TextLogs.WriteInfo("Paquete actualizada.");
                SetViewPanel(true);
                SetFocus();
                Search();
                SetInformation(Helper.MessageType.Info, "El Paquete ha sido guardado correctamente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            catch (Exception err)
            {
                TextLogs.WriteError("No se pudo guardar el paquete", err);
                SetInformation(Helper.MessageType.Error, "Error guardar, Nombre paquete repetido.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
        }
    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Estableciendo la fecha de creación de la Paquete.");
        txtFechaCreacion.Text = DateTime.Now.ToShortDateString();
        cbEstado.Checked = true;
        TextLogs.WriteInfo("Panel de busqueda de Empresas INVISIBLE.");
        SetViewPanel(false);
        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de Empresas VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid & revBuscarTipoPaquete.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de paquetes.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para la Paquete: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos de la Paquete seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }

        else if (e.CommandName == "Eliminar")
        {
            if (!RN.Componentes.CPaquete.EstaAsignado(Convert.ToInt32(e.CommandArgument.ToString())))
            {
                TextLogs.WriteInfo("Entrando a eliminar el paquete seleccionado.");
                RN.Componentes.CPaquete.EliminarPaquete(Convert.ToInt32(e.CommandArgument.ToString()));
                TextLogs.WriteInfo("La Paquete ha sido eliminado.");
                SetInformation(Helper.MessageType.Info, "La Paquete ha sido eliminado.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            else
            {
                TextLogs.WriteInfo("No se puede eliminar, el paquete se encuentra asignado a clientes.");
                SetInformation(Helper.MessageType.Info, "La Paquete no se puede eliminar, está asignado a un cliente.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
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
    public string GetFecha(object id)
    {
        return Convert.ToDateTime(DataBinder.Eval(id, "fechaRegistro")).ToShortDateString();
    }
    private void Limpiar()
    {
        PaqueteId.Value = string.Empty;
        txtNombre.Text = string.Empty;
        ddlUnidad.SelectedIndex = 0;
        txtTiempo.Text = string.Empty;
        ddlTipoPaquete.SelectedIndex = 0;
        txtPrecio.Text = string.Empty;
        txtDias.Text = string.Empty;
        txtFechaCreacion.Text = DateTime.Now.ToShortDateString();
        cbEstado.Checked = true;
        passwordTR.Visible = true;
        passwordConfirmTR.Visible = true;

        ddlUnidad.Enabled = true;
        txtTiempo.Enabled = true;
        ddlTipoPaquete.Enabled = true;
        txtPrecio.Enabled = true;
        txtDias.Enabled = true;
        txtFechaCreacion.Enabled = true;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos de la Paquete a los controles del formulario.");
        TextLogs.WriteDebug("Cargando Paquete: " + userName);
        List<RN.Entidades.Paquete> lEmpresa = RN.Componentes.CPaquete.TraerXId(Convert.ToInt32(userName));
        PaqueteId.Value = userName;
        txtNombre.Text = lEmpresa[0].Nombre;
        ddlUnidad.SelectedValue = lEmpresa[0].UnidadId.ToString();
        txtTiempo.Text = lEmpresa[0].Tiempo.ToString();
        ddlTipoPaquete.SelectedValue = lEmpresa[0].TipoPaqueteId.ToString();
        txtPrecio.Text = lEmpresa[0].Precio.ToString();
        txtDias.Text = lEmpresa[0].DiasValidez.ToString();
        txtFechaCreacion.Text = lEmpresa[0].FechaRegistro.ToShortDateString();
        cbEstado.Checked = Convert.ToBoolean(lEmpresa[0].Estado.ToString());

        ddlUnidad.Enabled = false;
        txtTiempo.Enabled = false;
        ddlTipoPaquete.Enabled = false;
        txtPrecio.Enabled = false;
        txtDias.Enabled = false;
        txtFechaCreacion.Enabled = false;
        
        TextLogs.WriteInfo("Datos de paquetes cargados al formulario correctamente.");
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
