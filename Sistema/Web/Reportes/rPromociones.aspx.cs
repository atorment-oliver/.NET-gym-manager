using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using Instrumentacion;

public partial class Reportes_rPromociones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!AppSecurity.HasAccess("ReportePromociones"))
        {
            TextLogs.WriteDebug("El usuario " + User.Identity.Name + " intentó acceder al reporte de Promociones");
            Response.Redirect(Config.GetPath("Default.aspx"));
        }
        if (!IsPostBack)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            CargarReporte();
        }
    }
    private void CargarReporte()
    {
        DataTable datos = RN.Componentes.CPromocion.TraerDatosTodos(Convert.ToDateTime(txtFecha.Text));
        rvPromociones.Visible = true;

        Helper.Member usuario = AppSecurity.GetUser(User.Identity.Name);

        rvPromociones.LocalReport.DataSources.Clear();
        rvPromociones.LocalReport.ReportPath = Server.MapPath("~/Reportes/rPromociones.rdlc");
        rvPromociones.LocalReport.SetParameters(new ReportParameter("FechaActual", DateTime.Now.ToShortDateString(), true));
        rvPromociones.LocalReport.SetParameters(new ReportParameter("UsuarioActual", usuario.FirstName + " " + usuario.LastName, true));
        rvPromociones.LocalReport.SetParameters(new ReportParameter("Fecha", txtFecha.Text, true));
        rvPromociones.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", datos));
        rvPromociones.LocalReport.Refresh();
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}