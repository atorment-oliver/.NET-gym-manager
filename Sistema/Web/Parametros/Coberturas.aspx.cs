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

public partial class Parametros_Coberturas : MyPage
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
        if (!AppSecurity.HasAccess("Coberturas"))
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
        RN.Entidades.TipoPaquete objTipoPaquete = new RN.Entidades.TipoPaquete();
        if (string.IsNullOrEmpty(TipoPaqueteId.Value))
        {
            MembershipUser user = Membership.GetUser();
            TextLogs.WriteDebug("Insertando tipo de paquete: " + txtNombre.Text + " " + txtLimite.Text + " " + cbEstado.Checked);
            TextLogs.WriteInfo("Entrando a crear nuevo tipo de paquete.");
            objTipoPaquete.Nombre = txtNombre.Text;
            objTipoPaquete.LimiteServicios = txtLimite.Text;
            objTipoPaquete.Estado = cbEstado.Checked;
            RN.Componentes.CTipoPaquete.Insertar(objTipoPaquete);
            TextLogs.WriteInfo("Se creo una nuevo tipo de paquete.");
            SetViewPanel(true);
            SetFocus();
            Search();
            TextLogs.WriteInfo("El tipo de paquete ha sido guardado correctamente.");
            SetInformation(Helper.MessageType.Info, "El tipo de paquete ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
        }
        else
        {

            TextLogs.WriteDebug("Actualizando tipo de paquete: " + TipoPaqueteId.Value);
            TextLogs.WriteInfo("Entrando a actualizar tipo de paquete.");
            MembershipUser user = Membership.GetUser();
            objTipoPaquete.Id = Convert.ToInt32(TipoPaqueteId.Value);
            objTipoPaquete.Nombre = txtNombre.Text;
            objTipoPaquete.LimiteServicios = txtLimite.Text;
            objTipoPaquete.Estado = cbEstado.Checked;
            RN.Componentes.CTipoPaquete.Actualizar(objTipoPaquete);
            TextLogs.WriteInfo("Tipo de paquete actualizada.");
            SetViewPanel(true);
            SetFocus();
            Search();
            SetInformation(Helper.MessageType.Info, "El tipo de paquete ha sido guardado correctamente.");
            lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";

        }

    }
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        cbEstado.Checked = true;
        TextLogs.WriteInfo("Panel de busqueda de tipo de paquete INVISIBLE.");
        SetViewPanel(false);

        Limpiar();
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        TextLogs.WriteInfo("Panel de busqueda de tipo de paquete VISIBLE.");
        SetViewPanel(true);
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid & revBuscarLimite.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de tipo de paquete.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para el tipo de paquete: " + e.CommandArgument);

        if (e.CommandName == "Editar")
        {
            TextLogs.WriteInfo("Recuperando datos del tipo de paquete seleccionado.");
            SetViewPanel(false);
            LoadData(e.CommandArgument.ToString());
            return;
        }

        else if (e.CommandName == "Eliminar")
        {
            if (!RN.Componentes.CTipoPaquete.EstaAsignado(Convert.ToInt32(e.CommandArgument.ToString())))
            {
                TextLogs.WriteInfo("Entrando a eliminar el tipo de paquete seleccionado.");
                RN.Componentes.CTipoPaquete.EliminarTipoPaquete(Convert.ToInt32(e.CommandArgument.ToString()));
                TipoPaqueteId.Value = string.Empty;

                TextLogs.WriteInfo("El tipo de paquete ha sido eliminada.");
                SetInformation(Helper.MessageType.Info, "El tipo de paquete ha sido eliminada.");
                lblScriptShow.Text = "<script language=JavaScript> $(document).ready(function() { $('#dialog-message').dialog('open'); }); </script>";
            }
            else
            {
                TextLogs.WriteInfo("El tipo de paquete no se pudo eliminar, se encuentra asignado a un paquete");
                SetInformation(Helper.MessageType.Info, "El tipo de paquete no se pudo eliminar, esta asignado a un paquete.");
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
    private void Limpiar()
    {
        TipoPaqueteId.Value = string.Empty;
        txtNombre.Text = string.Empty;
        txtLimite.Text = string.Empty;
        cbEstado.Checked = true;

        passwordConfirmTR.Visible = true;
        TextLogs.WriteInfo("Valores del formulario limpiados.");
    }
    private void LoadData(string userName)
    {
        TextLogs.WriteInfo("Cargando datos del tipo de paquete a los controles del formulario.");
        TextLogs.WriteDebug("Cargando tipo de paquete: " + userName);
        //MembershipUser user = Membership.GetUser(userName);
        //ProfileCommon profile = Profile.GetProfile(user.UserName);
        List<RN.Entidades.TipoPaquete> lEmpresa = RN.Componentes.CTipoPaquete.TraerXId(Convert.ToInt32(userName));
        TipoPaqueteId.Value = userName;
        txtNombre.Text = lEmpresa[0].Nombre;
        txtLimite.Text = lEmpresa[0].LimiteServicios.ToString();
        cbEstado.Checked = Convert.ToBoolean(lEmpresa[0].Estado.ToString().ToLower());

        TextLogs.WriteInfo("Datos del tipo de paquete cargados al formulario correctamente.");
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
