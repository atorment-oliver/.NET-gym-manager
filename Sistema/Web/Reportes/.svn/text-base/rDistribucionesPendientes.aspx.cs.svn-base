using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Instrumentacion;

public partial class Reportes_rDistribucionesPendientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("ReporteDistribucionesPendientes"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder al reporte de Distribuciones de pagos pendientes");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }

        if (!this.IsPostBack)
            GetEmpresas();
    }
    private void GetEmpresas()
    {
        List<RN.Entidades.Empresa> empresas = RN.Componentes.CEmpresa.TraerXCriterio(string.Empty, string.Empty, string.Empty, "true");
        ddlEmpresa.DataSource = empresas;
        ddlEmpresa.DataTextField = "nombre";
        ddlEmpresa.DataValueField = "id";
        ddlEmpresa.DataBind();

        ddlEmpresa.Items.Insert(0, new ListItem("TODOS", ""));
    }
    private void CargarReporte()
    {
        DataTable datos = RN.Componentes.CDistribucionPago.TraerXPendientes(ClienteId.Value, ddlEmpresa.SelectedValue);
        rvDistribucionPagos.Visible = true;

        Helper.Member usuario = AppSecurity.GetUser(User.Identity.Name);

        string cliente = string.IsNullOrEmpty(txtCliente.Text) ? "TODOS" : txtCliente.Text;

        rvDistribucionPagos.LocalReport.DataSources.Clear();
        rvDistribucionPagos.LocalReport.ReportPath = Server.MapPath("~/Reportes/rDistribucionPendiente.rdlc");
        rvDistribucionPagos.LocalReport.SetParameters(new ReportParameter("Empresa", ddlEmpresa.SelectedItem.Text, true));
        rvDistribucionPagos.LocalReport.SetParameters(new ReportParameter("Cliente", cliente, true));
        rvDistribucionPagos.LocalReport.SetParameters(new ReportParameter("FechaActual", DateTime.Now.ToShortDateString(), true));
        rvDistribucionPagos.LocalReport.SetParameters(new ReportParameter("UsuarioActual", usuario.FirstName + " " + usuario.LastName, true));
        rvDistribucionPagos.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datos));
        rvDistribucionPagos.LocalReport.Refresh();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}