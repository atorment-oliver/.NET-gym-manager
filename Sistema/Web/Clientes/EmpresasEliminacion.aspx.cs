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

public partial class Clientes_EmpresasEliminacion : MyPage
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
        if (!AppSecurity.HasAccess("EmpresasEliminacion"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder a la página EmpresasEliminacion.aspx");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!IsPostBack)
        {
            SetFocus();
            Search();
        }
        lblScriptShow.Text = string.Empty;
    }
    protected void Seach_Click(object sender, EventArgs e)
    {
        if (revBuscarNombre.IsValid & revBuscarPersona.IsValid & revBuscarCorreo.IsValid)
        {
            TextLogs.WriteInfo("Filtrando resultados del listado de empresas.");
            SetFocus();
            Search();
        }
    }
    protected void ResultGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextLogs.WriteDebug("Realizando acción: " + e.CommandName + " para la empresa: " + e.CommandArgument);
        if (e.CommandName == "Eliminar")
        {
            TextLogs.WriteInfo("Entrando a eliminar la empresa seleccionado.");
            RN.Componentes.CEmpresa.EliminarEmpresa(Convert.ToInt32(e.CommandArgument.ToString()));
            TextLogs.WriteInfo("La empresa ha sido eliminada.");
            SetInformation(Helper.MessageType.Info, "La empresa ha sido eliminada.");
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

    private void SetFocus()
    {
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
    public bool EsVisible(object id)
    {
        int approved = Convert.ToInt32(DataBinder.Eval(id, "id"));
        List<RN.Entidades.PagoEmpresa> lstPagoEmpresa = RN.Componentes.CPagoEmpresa.TraerXIdEmpresa(approved);
        if (lstPagoEmpresa.Count != 0)
            return false;
        else
            return true;
    }
    public string IsLockedOut(object id)
    {
        bool locked = Convert.ToBoolean(DataBinder.Eval(id, "estado"));
        if (locked)
            return Config.GetPath("Images/yes.png");

        return Config.GetPath("Images/no.png");
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
