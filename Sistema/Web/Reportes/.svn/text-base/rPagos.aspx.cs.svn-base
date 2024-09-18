using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Instrumentacion;

public partial class Reportes_rPagos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("ReportePagos"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder al reporte de Pagos");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            txtFechaInicio.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }
    }
    private void CargarReporte()
    {
        DataTable datos = RN.Componentes.CPagoCliente.TraerXFechaPago(Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text));
        rvPagos.Visible = true;

        rvPagos.LocalReport.DataSources.Clear();
        rvPagos.LocalReport.ReportPath = Server.MapPath("~/Reportes/rPagos.rdlc");
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaInicio", txtFechaInicio.Text, true));
        rvPagos.LocalReport.SetParameters(new ReportParameter("FechaFin", txtFechaFin.Text, true));
        rvPagos.LocalReport.DataSources.Add(new ReportDataSource("Pagos", datos));
        rvPagos.LocalReport.Refresh();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}